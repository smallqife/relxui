using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelxUI
{
    public partial class LoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const string ConfigFile = "config.dat";
        private void ShowLoginUI()
        {
            btnlogin.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            checkRmPassword.Enabled = true;
            btnChangeAcc.Enabled = true;

            label1.Visible = true;
            label2.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            checkRmPassword.Visible = true;

            NowAccount.Visible = false;
            btnChangeAcc.Visible = false;

            btnlogin.Text = "Login";
            btnlogin.Visible = true;
        }
        private void ShowAccountUI(string username)
        {
            btnlogin.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            checkRmPassword.Enabled = true;
            btnChangeAcc.Enabled = true;

            label1.Visible = false;
            label2.Visible = false;
            txtUsername.Visible = false;
            txtPassword.Visible = false;
            checkRmPassword.Visible = false;

            NowAccount.Text = "Welcome!" + username;
            NowAccount.Visible = true;
            btnChangeAcc.Visible = true;

            btnlogin.Text = "Enter";
            btnlogin.Visible = true;
        }


        private void CheckSavedAccount()
        {
            if (File.Exists(ConfigFile))
            {
                try
                {
                    using (FileStream fs = new FileStream(ConfigFile, FileMode.Open, FileAccess.Read))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        string username = br.ReadString();
                        int length = br.ReadInt32();
                        byte[] encrypted = br.ReadBytes(length);

                        // 解密密码（如果需要的话）
                        byte[] decrypted = ProtectedData.Unprotect(
                            encrypted,
                            null,
                            DataProtectionScope.CurrentUser
                        );

                        string password = Encoding.UTF8.GetString(decrypted);

                        // 显示账户 UI
                        ShowAccountUI(username);
                        txtUsername.Text = username; // 自动填充
                        txtPassword.Text = password;
                    }
                }
                catch
                {
                    // 文件损坏或者无法解密，直接删除
                    File.Delete(ConfigFile);
                    ShowLoginUI();
                }
            }
            else
            {
                ShowLoginUI();
            }
        }


        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            CheckSavedAccount();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnclose_MouseEnter(object sender, EventArgs e)
        {
            btnclose.BackColor = Color.Red;
        }

        private void btnclose_MouseLeave(object sender, EventArgs e)
        {
            btnclose.BackColor = Color.FromArgb(30, 30, 30);
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            checkRmPassword.Enabled = false;
            btnChangeAcc.Enabled = false;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter the username and password!");
                ShowLoginUI();
                return;
            }

            var result = await RelxApi.TryLoginAsync(username, password);

            if (!result.success)
            {
                MessageBox.Show($"Login failed: {result.error}");
                if (File.Exists(ConfigFile)) File.Delete(ConfigFile);
                ShowLoginUI();
                return;
            }

            // 保存全局 token 和用户名
            GlobalData.Token = result.token;
            GlobalData.Username = username;

            // 保存密码（可选）
            if (checkRmPassword.Checked)
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] encrypted = System.Security.Cryptography.ProtectedData.Protect(
                    passwordBytes,
                    null,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser
                );

                using (var fs = new FileStream(ConfigFile, FileMode.Create, FileAccess.Write))
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(username);
                    bw.Write(encrypted.Length);
                    bw.Write(encrypted);
                }
            }
            else
            {
                if (File.Exists(ConfigFile)) File.Delete(ConfigFile);
            }

            // 打开主窗口
            MainForm mainForm = new MainForm(username,password);
            mainForm.Show();
            this.Hide();
        }





        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            ShowLoginUI();

            // 清空输入框
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开默认浏览器访问指定网址
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://relxui.22333777.xyz/",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed." + ex.Message);
            }
        }

        private void btnTG_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开默认浏览器访问指定网址
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://t.me/earthsworth",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed." + ex.Message);
            }
        }
    }

}
