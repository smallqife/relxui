namespace RelxUI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            btnclose = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            checkRmPassword = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnlogin = new Button();
            btnChangeAcc = new Button();
            NowAccount = new Label();
            btnWebsite = new Button();
            btnTG = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(btnclose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 32);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // btnclose
            // 
            btnclose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnclose.BackColor = Color.FromArgb(30, 30, 30);
            btnclose.FlatAppearance.BorderSize = 0;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.ForeColor = SystemColors.ControlLightLight;
            btnclose.Location = new Point(284, 0);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(32, 32);
            btnclose.TabIndex = 0;
            btnclose.Text = "×";
            btnclose.UseVisualStyleBackColor = false;
            btnclose.Click += btnclose_Click;
            btnclose.MouseEnter += btnclose_MouseEnter;
            btnclose.MouseLeave += btnclose_MouseLeave;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BackColor = Color.FromArgb(45, 45, 45);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(50, 172);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 21);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.FromArgb(45, 45, 45);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(51, 222);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(220, 21);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // checkRmPassword
            // 
            checkRmPassword.Anchor = AnchorStyles.None;
            checkRmPassword.AutoSize = true;
            checkRmPassword.BackColor = Color.FromArgb(30, 30, 30);
            checkRmPassword.FlatAppearance.BorderSize = 0;
            checkRmPassword.FlatStyle = FlatStyle.Flat;
            checkRmPassword.ForeColor = Color.White;
            checkRmPassword.Location = new Point(51, 249);
            checkRmPassword.Name = "checkRmPassword";
            checkRmPassword.Size = new Size(148, 21);
            checkRmPassword.TabIndex = 3;
            checkRmPassword.Text = "Remember Password";
            checkRmPassword.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(30, 30, 30);
            label1.FlatStyle = FlatStyle.Flat;
            label1.ForeColor = Color.White;
            label1.Location = new Point(50, 153);
            label1.Name = "label1";
            label1.Size = new Size(54, 17);
            label1.TabIndex = 4;
            label1.Text = "Account";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(30, 30, 30);
            label2.FlatStyle = FlatStyle.Flat;
            label2.ForeColor = Color.White;
            label2.Location = new Point(51, 203);
            label2.Name = "label2";
            label2.Size = new Size(64, 17);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Latest;
            pictureBox1.Location = new Point(66, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnlogin
            // 
            btnlogin.Anchor = AnchorStyles.None;
            btnlogin.BackColor = Color.FromArgb(35, 35, 35);
            btnlogin.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(109, 294);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(98, 38);
            btnlogin.TabIndex = 7;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // btnChangeAcc
            // 
            btnChangeAcc.Anchor = AnchorStyles.None;
            btnChangeAcc.BackColor = Color.FromArgb(35, 35, 35);
            btnChangeAcc.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnChangeAcc.FlatStyle = FlatStyle.Flat;
            btnChangeAcc.ForeColor = Color.White;
            btnChangeAcc.Location = new Point(142, 219);
            btnChangeAcc.Name = "btnChangeAcc";
            btnChangeAcc.Size = new Size(128, 28);
            btnChangeAcc.TabIndex = 9;
            btnChangeAcc.Text = "Change Account";
            btnChangeAcc.UseVisualStyleBackColor = false;
            btnChangeAcc.Visible = false;
            btnChangeAcc.Click += btnChangeAcc_Click;
            // 
            // NowAccount
            // 
            NowAccount.Anchor = AnchorStyles.None;
            NowAccount.AutoSize = true;
            NowAccount.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            NowAccount.ForeColor = Color.White;
            NowAccount.Location = new Point(50, 172);
            NowAccount.Name = "NowAccount";
            NowAccount.Size = new Size(135, 22);
            NowAccount.TabIndex = 10;
            NowAccount.Text = "Logon_Account";
            NowAccount.Visible = false;
            // 
            // btnWebsite
            // 
            btnWebsite.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnWebsite.FlatAppearance.BorderSize = 0;
            btnWebsite.FlatStyle = FlatStyle.Flat;
            btnWebsite.ForeColor = Color.White;
            btnWebsite.Location = new Point(283, 351);
            btnWebsite.Name = "btnWebsite";
            btnWebsite.Size = new Size(32, 32);
            btnWebsite.TabIndex = 11;
            btnWebsite.Text = "🌐";
            btnWebsite.UseVisualStyleBackColor = true;
            btnWebsite.Click += btnWebsite_Click;
            // 
            // btnTG
            // 
            btnTG.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTG.FlatAppearance.BorderSize = 0;
            btnTG.FlatStyle = FlatStyle.Flat;
            btnTG.ForeColor = Color.White;
            btnTG.Location = new Point(251, 351);
            btnTG.Name = "btnTG";
            btnTG.Size = new Size(32, 32);
            btnTG.TabIndex = 12;
            btnTG.Text = "➢";
            btnTG.UseVisualStyleBackColor = true;
            btnTG.Click += btnTG_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(316, 384);
            Controls.Add(btnTG);
            Controls.Add(btnWebsite);
            Controls.Add(NowAccount);
            Controls.Add(btnChangeAcc);
            Controls.Add(btnlogin);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkRmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Opacity = 0.98D;
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnclose;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox checkRmPassword;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnlogin;
        private Button btnChangeAcc;
        private Label NowAccount;
        private Button btnWebsite;
        private Button btnTG;
    }
}