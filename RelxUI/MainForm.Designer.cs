namespace RelxUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            progressBar = new ProgressBar();
            comboBoxProcesses = new ComboBox();
            cbRedeem = new CheckBox();
            plredeem = new Panel();
            btnGet = new Button();
            txtCode = new TextBox();
            label1 = new Label();
            lblState = new Label();
            btnConfirmProcess = new Button();
            lblStatus = new Label();
            btnTG = new Button();
            btnclose = new Button();
            btnload = new Button();
            btnLogout = new Button();
            pictureBox2 = new PictureBox();
            lbUsername = new Label();
            btnWebsite = new Button();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblSubscription = new Label();
            panel1.SuspendLayout();
            plredeem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(progressBar);
            panel1.Controls.Add(comboBoxProcesses);
            panel1.Controls.Add(cbRedeem);
            panel1.Controls.Add(plredeem);
            panel1.Controls.Add(lblState);
            panel1.Controls.Add(btnConfirmProcess);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnTG);
            panel1.Controls.Add(btnclose);
            panel1.Controls.Add(btnload);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(btnWebsite);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblSubscription);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 358);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.Red;
            progressBar.Location = new Point(31, 219);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(281, 16);
            progressBar.TabIndex = 21;
            progressBar.Visible = false;
            // 
            // comboBoxProcesses
            // 
            comboBoxProcesses.BackColor = Color.FromArgb(30, 30, 30);
            comboBoxProcesses.FlatStyle = FlatStyle.Flat;
            comboBoxProcesses.Font = new Font("Microsoft YaHei UI", 8F);
            comboBoxProcesses.ForeColor = Color.White;
            comboBoxProcesses.FormattingEnabled = true;
            comboBoxProcesses.Location = new Point(42, 240);
            comboBoxProcesses.Name = "comboBoxProcesses";
            comboBoxProcesses.Size = new Size(257, 24);
            comboBoxProcesses.TabIndex = 22;
            comboBoxProcesses.Visible = false;
            // 
            // cbRedeem
            // 
            cbRedeem.Appearance = Appearance.Button;
            cbRedeem.FlatAppearance.BorderSize = 0;
            cbRedeem.FlatStyle = FlatStyle.Flat;
            cbRedeem.ForeColor = Color.White;
            cbRedeem.Location = new Point(302, 1);
            cbRedeem.Name = "cbRedeem";
            cbRedeem.Size = new Size(32, 32);
            cbRedeem.TabIndex = 26;
            cbRedeem.Text = "🎟️";
            cbRedeem.UseVisualStyleBackColor = true;
            cbRedeem.CheckedChanged += cbRedeem_CheckedChanged;
            // 
            // plredeem
            // 
            plredeem.BorderStyle = BorderStyle.FixedSingle;
            plredeem.Controls.Add(btnGet);
            plredeem.Controls.Add(txtCode);
            plredeem.Controls.Add(label1);
            plredeem.Location = new Point(70, 33);
            plredeem.Name = "plredeem";
            plredeem.Size = new Size(264, 44);
            plredeem.TabIndex = 25;
            plredeem.Visible = false;
            // 
            // btnGet
            // 
            btnGet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGet.BackColor = Color.FromArgb(35, 35, 35);
            btnGet.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnGet.FlatStyle = FlatStyle.Flat;
            btnGet.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnGet.ForeColor = Color.White;
            btnGet.Location = new Point(215, 6);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(42, 31);
            btnGet.TabIndex = 24;
            btnGet.Text = "→";
            btnGet.UseVisualStyleBackColor = false;
            btnGet.Click += btnGet_Click;
            // 
            // txtCode
            // 
            txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCode.BackColor = Color.FromArgb(45, 45, 45);
            txtCode.BorderStyle = BorderStyle.None;
            txtCode.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtCode.ForeColor = Color.White;
            txtCode.Location = new Point(4, 21);
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "XXXX-XXXX-XXXX-XXXX";
            txtCode.Size = new Size(207, 16);
            txtCode.TabIndex = 21;
            txtCode.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 4);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 20;
            label1.Text = "Redeem";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblState
            // 
            lblState.Anchor = AnchorStyles.None;
            lblState.Font = new Font("Microsoft YaHei UI", 8F);
            lblState.ForeColor = Color.White;
            lblState.Location = new Point(40, 199);
            lblState.Name = "lblState";
            lblState.Size = new Size(259, 17);
            lblState.TabIndex = 20;
            lblState.Text = "State";
            lblState.TextAlign = ContentAlignment.MiddleLeft;
            lblState.Visible = false;
            // 
            // btnConfirmProcess
            // 
            btnConfirmProcess.Anchor = AnchorStyles.None;
            btnConfirmProcess.BackColor = Color.FromArgb(35, 35, 35);
            btnConfirmProcess.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnConfirmProcess.FlatStyle = FlatStyle.Flat;
            btnConfirmProcess.ForeColor = Color.White;
            btnConfirmProcess.Location = new Point(217, 270);
            btnConfirmProcess.Name = "btnConfirmProcess";
            btnConfirmProcess.Size = new Size(82, 28);
            btnConfirmProcess.TabIndex = 23;
            btnConfirmProcess.Text = "Confirm";
            btnConfirmProcess.UseVisualStyleBackColor = false;
            btnConfirmProcess.Visible = false;
            btnConfirmProcess.Click += btnConfirmProcess_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.None;
            lblStatus.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(40, 182);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(259, 19);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Visible = false;
            // 
            // btnTG
            // 
            btnTG.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTG.FlatAppearance.BorderSize = 0;
            btnTG.FlatStyle = FlatStyle.Flat;
            btnTG.ForeColor = Color.White;
            btnTG.Location = new Point(269, 325);
            btnTG.Name = "btnTG";
            btnTG.Size = new Size(32, 32);
            btnTG.TabIndex = 18;
            btnTG.Text = "➢";
            btnTG.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            btnclose.Anchor = AnchorStyles.None;
            btnclose.BackColor = Color.FromArgb(30, 30, 30);
            btnclose.FlatAppearance.BorderColor = Color.Maroon;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.ForeColor = SystemColors.ControlLightLight;
            btnclose.Location = new Point(170, 241);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(87, 24);
            btnclose.TabIndex = 0;
            btnclose.Text = "Exit";
            btnclose.UseVisualStyleBackColor = false;
            btnclose.Click += btnclose_Click;
            btnclose.MouseEnter += btnclose_MouseEnter;
            btnclose.MouseLeave += btnclose_MouseLeave;
            // 
            // btnload
            // 
            btnload.Anchor = AnchorStyles.None;
            btnload.BackColor = Color.FromArgb(35, 35, 35);
            btnload.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnload.FlatStyle = FlatStyle.Flat;
            btnload.ForeColor = Color.White;
            btnload.Location = new Point(77, 211);
            btnload.Name = "btnload";
            btnload.Size = new Size(180, 24);
            btnload.TabIndex = 14;
            btnload.Text = "Load";
            btnload.UseVisualStyleBackColor = false;
            btnload.Visible = false;
            btnload.Click += btnload_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.None;
            btnLogout.BackColor = Color.FromArgb(30, 30, 30);
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(77, 241);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(87, 24);
            btnLogout.TabIndex = 13;
            btnLogout.Text = "logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = Properties.Resources.avatar;
            pictureBox2.Location = new Point(140, 92);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // lbUsername
            // 
            lbUsername.Anchor = AnchorStyles.None;
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lbUsername.ForeColor = Color.White;
            lbUsername.Location = new Point(124, 143);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(80, 19);
            lbUsername.TabIndex = 14;
            lbUsername.Text = "Username";
            lbUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWebsite
            // 
            btnWebsite.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnWebsite.FlatAppearance.BorderSize = 0;
            btnWebsite.FlatStyle = FlatStyle.Flat;
            btnWebsite.ForeColor = Color.White;
            btnWebsite.Location = new Point(302, 325);
            btnWebsite.Name = "btnWebsite";
            btnWebsite.Size = new Size(32, 32);
            btnWebsite.TabIndex = 12;
            btnWebsite.Text = "🌐";
            btnWebsite.UseVisualStyleBackColor = true;
            btnWebsite.Click += btnWebsite_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.v4red;
            pictureBox4.Location = new Point(133, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.vapelogosmall;
            pictureBox3.Location = new Point(42, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(95, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.relxMAX;
            pictureBox1.Location = new Point(11, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblSubscription
            // 
            lblSubscription.Anchor = AnchorStyles.None;
            lblSubscription.ForeColor = Color.Silver;
            lblSubscription.Location = new Point(63, 160);
            lblSubscription.Name = "lblSubscription";
            lblSubscription.Size = new Size(209, 19);
            lblSubscription.TabIndex = 2;
            lblSubscription.Text = "getting...";
            lblSubscription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(335, 358);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            plredeem.ResumeLayout(false);
            plredeem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnclose;
        private PictureBox pictureBox1;
        private Label lblSubscription;
        private Button btnWebsite;
        private Button btnLogout;
        private Label lbUsername;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button btnload;
        private Button btnTG;
        private Label lblStatus;
        private Label lblState;
        private ProgressBar progressBar;
        private ComboBox comboBoxProcesses;
        private Button btnConfirmProcess;
        private Panel plredeem;
        private Label label1;
        private TextBox txtCode;
        private Button btnGet;
        private CheckBox cbRedeem;
    }
}