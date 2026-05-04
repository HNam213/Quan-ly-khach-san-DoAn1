namespace QuanLyKhachSan
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.GbtnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.GtxtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.GtxtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.GbtnExit = new Guna.UI2.WinForms.Guna2Button();
            this.GlblUserLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.GbtnEye = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.GbtnLinkHotel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // GbtnLogin
            // 
            this.GbtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.GbtnLogin.BorderRadius = 8;
            this.GbtnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnLogin.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.GbtnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GbtnLogin.ForeColor = System.Drawing.SystemColors.Window;
            this.GbtnLogin.Location = new System.Drawing.Point(647, 365);
            this.GbtnLogin.Name = "GbtnLogin";
            this.GbtnLogin.Size = new System.Drawing.Size(100, 45);
            this.GbtnLogin.TabIndex = 6;
            this.GbtnLogin.Text = "Login";
            this.GbtnLogin.Click += new System.EventHandler(this.GbtnLogin_Click);
            // 
            // GtxtUsername
            // 
            this.GtxtUsername.BackColor = System.Drawing.Color.Transparent;
            this.GtxtUsername.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.GtxtUsername.BorderRadius = 8;
            this.GtxtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GtxtUsername.DefaultText = "";
            this.GtxtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GtxtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GtxtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GtxtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GtxtUsername.FillColor = System.Drawing.Color.Snow;
            this.GtxtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GtxtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GtxtUsername.ForeColor = System.Drawing.Color.Black;
            this.GtxtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GtxtUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("GtxtUsername.IconLeft")));
            this.GtxtUsername.IconLeftSize = new System.Drawing.Size(30, 30);
            this.GtxtUsername.Location = new System.Drawing.Point(533, 268);
            this.GtxtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GtxtUsername.Name = "GtxtUsername";
            this.GtxtUsername.PlaceholderForeColor = System.Drawing.Color.Black;
            this.GtxtUsername.PlaceholderText = "Username";
            this.GtxtUsername.SelectedText = "";
            this.GtxtUsername.Size = new System.Drawing.Size(214, 41);
            this.GtxtUsername.TabIndex = 7;
            this.GtxtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GtxtUsername_KeyDown);
            // 
            // GtxtPassword
            // 
            this.GtxtPassword.BackColor = System.Drawing.Color.Transparent;
            this.GtxtPassword.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.GtxtPassword.BorderRadius = 8;
            this.GtxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GtxtPassword.DefaultText = "";
            this.GtxtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GtxtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GtxtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GtxtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GtxtPassword.FillColor = System.Drawing.Color.Snow;
            this.GtxtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GtxtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GtxtPassword.ForeColor = System.Drawing.Color.Black;
            this.GtxtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GtxtPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("GtxtPassword.IconLeft")));
            this.GtxtPassword.IconLeftSize = new System.Drawing.Size(30, 25);
            this.GtxtPassword.Location = new System.Drawing.Point(533, 317);
            this.GtxtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GtxtPassword.Name = "GtxtPassword";
            this.GtxtPassword.PlaceholderForeColor = System.Drawing.Color.Black;
            this.GtxtPassword.PlaceholderText = "Password";
            this.GtxtPassword.SelectedText = "";
            this.GtxtPassword.Size = new System.Drawing.Size(214, 41);
            this.GtxtPassword.TabIndex = 8;
            this.GtxtPassword.UseSystemPasswordChar = true;
            // 
            // GbtnExit
            // 
            this.GbtnExit.BackColor = System.Drawing.Color.Transparent;
            this.GbtnExit.BorderRadius = 8;
            this.GbtnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnExit.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.GbtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GbtnExit.ForeColor = System.Drawing.Color.White;
            this.GbtnExit.Location = new System.Drawing.Point(533, 365);
            this.GbtnExit.Name = "GbtnExit";
            this.GbtnExit.Size = new System.Drawing.Size(100, 45);
            this.GbtnExit.TabIndex = 9;
            this.GbtnExit.Text = "Exit";
            this.GbtnExit.Click += new System.EventHandler(this.GbtnExit_Click);
            // 
            // GlblUserLogin
            // 
            this.GlblUserLogin.AutoSize = false;
            this.GlblUserLogin.BackColor = System.Drawing.Color.Transparent;
            this.GlblUserLogin.Font = new System.Drawing.Font("Lucida Handwriting", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlblUserLogin.ForeColor = System.Drawing.Color.Red;
            this.GlblUserLogin.Location = new System.Drawing.Point(521, 210);
            this.GlblUserLogin.Name = "GlblUserLogin";
            this.GlblUserLogin.Size = new System.Drawing.Size(259, 51);
            this.GlblUserLogin.TabIndex = 10;
            this.GlblUserLogin.Text = "USER LOGIN";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(424, 175);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(79, 70);
            this.guna2Panel1.TabIndex = 11;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel3.BackgroundImage")));
            this.guna2Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.Location = new System.Drawing.Point(433, 377);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(79, 70);
            this.guna2Panel3.TabIndex = 13;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel2.BackgroundImage")));
            this.guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Location = new System.Drawing.Point(774, 303);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(79, 70);
            this.guna2Panel2.TabIndex = 14;
            // 
            // GbtnEye
            // 
            this.GbtnEye.BackColor = System.Drawing.Color.Transparent;
            this.GbtnEye.BorderColor = System.Drawing.Color.Transparent;
            this.GbtnEye.BorderRadius = 15;
            this.GbtnEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GbtnEye.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnEye.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnEye.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnEye.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnEye.FillColor = System.Drawing.Color.Transparent;
            this.GbtnEye.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GbtnEye.ForeColor = System.Drawing.Color.White;
            this.GbtnEye.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.GbtnEye.Location = new System.Drawing.Point(706, 323);
            this.GbtnEye.Name = "GbtnEye";
            this.GbtnEye.Size = new System.Drawing.Size(30, 30);
            this.GbtnEye.TabIndex = 15;
            this.GbtnEye.Click += new System.EventHandler(this.GbtnEye_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel4.BackgroundImage")));
            this.guna2Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.Location = new System.Drawing.Point(795, 486);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(80, 115);
            this.guna2Panel4.TabIndex = 16;
            // 
            // GbtnLinkHotel
            // 
            this.GbtnLinkHotel.BackColor = System.Drawing.Color.Transparent;
            this.GbtnLinkHotel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GbtnLinkHotel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnLinkHotel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnLinkHotel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnLinkHotel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnLinkHotel.FillColor = System.Drawing.Color.Transparent;
            this.GbtnLinkHotel.Font = new System.Drawing.Font("Lucida Bright", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbtnLinkHotel.ForeColor = System.Drawing.Color.White;
            this.GbtnLinkHotel.Location = new System.Drawing.Point(521, 560);
            this.GbtnLinkHotel.Name = "GbtnLinkHotel";
            this.GbtnLinkHotel.Size = new System.Drawing.Size(247, 31);
            this.GbtnLinkHotel.TabIndex = 17;
            this.GbtnLinkHotel.Text = "www.halekulani.com";
            this.GbtnLinkHotel.Click += new System.EventHandler(this.GbtnLinkHotel_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(865, 595);
            this.Controls.Add(this.GbtnLinkHotel);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.GbtnEye);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.GlblUserLogin);
            this.Controls.Add(this.GbtnExit);
            this.Controls.Add(this.GbtnLogin);
            this.Controls.Add(this.GtxtUsername);
            this.Controls.Add(this.GtxtPassword);
            this.Controls.Add(this.guna2Panel2);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button GbtnExit;
        private Guna.UI2.WinForms.Guna2TextBox GtxtPassword;
        private Guna.UI2.WinForms.Guna2TextBox GtxtUsername;
        private Guna.UI2.WinForms.Guna2Button GbtnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblUserLogin;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button GbtnEye;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Button GbtnLinkHotel;
    }
}

