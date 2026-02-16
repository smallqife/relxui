using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RelxRunner;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RelxUI
{
    public partial class MainForm : Form
    {
        private string _username;
        private string _password;
        private RelxRunner _runner;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        void intoinject()
        {
            btnload.Visible = false;
            btnLogout.Visible = false;
            btnclose.Visible = false;
            lblState.Visible = true;
            lblStatus.Visible = true;
            progressBar.Visible = true;
        }
        void intoprogess()
        {
            comboBoxProcesses.Visible = true;
            btnConfirmProcess.Visible = true;
        }
        void outprogress()
        {
            comboBoxProcesses.Visible = false;
            btnConfirmProcess.Visible = false;
        }
        void backtomain()
        {
            btnload.Visible = true;
            btnLogout.Visible = true;
            btnclose.Visible = true;
            btnConfirmProcess.Visible = false;
            lblState.Visible = false;
            lblStatus.Visible = false;
            progressBar.Visible = false;
            comboBoxProcesses.Visible = false;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        public MainForm(string username, string password)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            _username = username;
            _password = password;

            _runner = new RelxRunner();

            _runner.OnLog += line =>
            {
                Invoke(() =>
                {
                    // 只显示以 [ 开头的行
                    if (line.StartsWith("["))
                    {
                        lblStatus.Text = line;
                    }
                });
            };

            _runner.OnStateChanged += (state, progress) =>
            {
                Invoke((Delegate)(() =>
                {
                    progressBar.Value = progress;
                    lblState.Text = state.ToString();
                }));
            };

            _runner.OnProcessListUpdated += list =>
            {
                Invoke(() =>
                {
                    comboBoxProcesses.Items.Clear();
                    comboBoxProcesses.Items.AddRange(list.ToArray());
                    intoprogess();
                    if (comboBoxProcesses.Items.Count > 0)
                    {
                        comboBoxProcesses.SelectedIndex = 0;  // 👈 默认选第一项
                    }
                });
            };

            _runner.OnStateChanged += (state, progress) =>
            {
                Invoke((Delegate)(() =>
                {
                    progressBar.Value = progress;
                    lblState.Text = state.ToString();

                    switch (state)
                    {
                        case RelxState.Authorizing:
                        case RelxState.SessionEstablished:
                        case RelxState.Injecting:
                        case RelxState.Running:
                            break;

                        case RelxState.NetworkError:
                        case RelxState.SubscriptionError:
                        case RelxState.ProcessNotFound:
                            backtomain();
                            break;
                    }
                }));
            };

        }
        private async Task CheckAndUpdateAsync()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDir, "relx.exe");

            Debug.WriteLine("=== Update Check Started ===");
            Debug.WriteLine("Exe Path: " + exePath);

            // UI 显示控制
            btnload.Visible = false;
            progressBar.Visible = true;
            progressBar.Value = 0;

            // 获取远程 hash
            string? remoteHash = await RelxApi.GetRemoteSha256Async();
            Debug.WriteLine("Remote Hash: " + (remoteHash ?? "NULL"));

            if (remoteHash == null)
            {
                Debug.WriteLine("Remote hash is null. Aborting update.");
                progressBar.Visible = false;
                btnload.Visible = true;
                return;
            }

            bool needDownload = true;

            if (File.Exists(exePath))
            {
                string localHash = RelxApi.ComputeFileSha256(exePath);
                Debug.WriteLine("Local Hash: " + localHash);

                if (!string.IsNullOrEmpty(remoteHash) && remoteHash.Equals(localHash, StringComparison.OrdinalIgnoreCase))
                {
                    Debug.WriteLine("Hashes match. No download needed.");
                    needDownload = false;
                }
                else
                {
                    Debug.WriteLine("Hashes differ. Download required.");
                }
            }
            else
            {
                Debug.WriteLine("Local file does not exist. Download required.");
            }

            if (needDownload)
            {
                Debug.WriteLine("Starting download...");

                var progress = new Progress<int>(value =>
                {
                    progressBar.Value = value;
                    //Debug.WriteLine("Download Progress: " + value + "%");
                });

                bool success = await RelxApi.DownloadInjectorAsync(exePath, progress);

                Debug.WriteLine("Download success: " + success);

                if (!success)
                {
                    Debug.WriteLine("Download failed.");
                    MessageBox.Show("Download failed, please check your network or token.");
                }
            }

            // 更新完成，恢复 UI
            progressBar.Visible = false;
            btnload.Visible = true;

            Debug.WriteLine("=== Update Check Finished ===");
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = GlobalData.Username;
            if (GlobalData.Token != null)
            {
                string info = await RelxApi.GetSubscriptionInfoAsync(GlobalData.Token);
                lblSubscription.Text = info;
            }
            else
            {
                lblSubscription.Text = "No token found!";
            }
            await CheckAndUpdateAsync();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 清空全局 token
            GlobalData.Token = null;
            GlobalData.Username = null;

            // 打开 LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // 关闭当前 MainForm
            this.Close();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDir, "relx.exe");

            // ===== 检测文件 =====
            if (!File.Exists(exePath))
            {
                var result = MessageBox.Show(
                    "检测不到 relx.exe，请前往官网下载放在同级目录下并重命名！",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://relx.lunarclient.top",
                        UseShellExecute = true
                    });
                }

                return;
            }

            // ===== 禁用按钮防止重复启动 =====
            intoinject();
            progressBar.Value = 0;

            // ===== 启动 =====
            _runner.Start(exePath, _username, _password);
        }
        private void btnConfirmProcess_Click(object sender, EventArgs e)
        {
            if (comboBoxProcesses.SelectedItem == null)
                return;

            string line = comboBoxProcesses.SelectedItem.ToString();
            string number = Regex.Match(line, @"^\d+").Value;
            outprogress();
            _runner.SendSelection(number);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbRedeem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRedeem.Checked)
            {
                plredeem.Visible = true;
            }
            else
            {
                plredeem.Visible = false;
            }
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();

            // 防止提交占位符或空内容
            if (string.IsNullOrWhiteSpace(code) || code == "XXXX-XXXX-XXXX-XXXX")
            {
                MessageBox.Show("请输入兑换码！");
                return;
            }

            if (string.IsNullOrEmpty(GlobalData.Token))
            {
                MessageBox.Show("请先登录！");
                return;
            }

            btnGet.Enabled = false;

            var result = await RelxApi.RedeemAsync(GlobalData.Token, code);

            btnGet.Enabled = true;

            if (result.success)
            {
                // ✅ 清空输入框
                txtCode.Clear();

                // ✅ 刷新订阅状态
                string info = await RelxApi.GetSubscriptionInfoAsync(GlobalData.Token);
                lblSubscription.Text = info;

                MessageBox.Show("兑换成功！",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cbRedeem.Checked = false;
            }
            else
            {
                MessageBox.Show(result.error ?? "兑换失败",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }
    }
}
