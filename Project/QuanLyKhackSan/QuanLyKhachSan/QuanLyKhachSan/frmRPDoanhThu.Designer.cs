namespace QuanLyKhachSan
{
    partial class frmRPDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPDoanhThu));
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GbtnLogo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.GlblHotline = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GbtnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuayLai = new Guna.UI2.WinForms.Guna2Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GbtnLogo)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Red;
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel2.Controls.Add(this.GbtnLogo);
            this.guna2Panel2.Controls.Add(this.GlblHotline);
            this.guna2Panel2.Controls.Add(this.GbtnExit);
            this.guna2Panel2.Controls.Add(this.btnQuayLai);
            this.guna2Panel2.Location = new System.Drawing.Point(-2, -1);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1215, 99);
            this.guna2Panel2.TabIndex = 6;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(113, 55);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(293, 32);
            this.guna2HtmlLabel2.TabIndex = 15;
            this.guna2HtmlLabel2.Text = "Management \r\nSuite";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(67)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(113, 31);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(210, 27);
            this.guna2HtmlLabel1.TabIndex = 14;
            this.guna2HtmlLabel1.Text = "RICE Hotel";
            // 
            // GbtnLogo
            // 
            this.GbtnLogo.BackColor = System.Drawing.Color.Transparent;
            this.GbtnLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GbtnLogo.BackgroundImage")));
            this.GbtnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GbtnLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GbtnLogo.FillColor = System.Drawing.Color.Transparent;
            this.GbtnLogo.ImageRotate = 0F;
            this.GbtnLogo.Location = new System.Drawing.Point(14, 13);
            this.GbtnLogo.Name = "GbtnLogo";
            this.GbtnLogo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GbtnLogo.Size = new System.Drawing.Size(93, 74);
            this.GbtnLogo.TabIndex = 13;
            this.GbtnLogo.TabStop = false;
            this.GbtnLogo.Click += new System.EventHandler(this.GbtnLogo_Click);
            // 
            // GlblHotline
            // 
            this.GlblHotline.AutoSize = false;
            this.GlblHotline.BackColor = System.Drawing.Color.Transparent;
            this.GlblHotline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlblHotline.Location = new System.Drawing.Point(961, 65);
            this.GlblHotline.Name = "GlblHotline";
            this.GlblHotline.Size = new System.Drawing.Size(328, 22);
            this.GlblHotline.TabIndex = 12;
            this.GlblHotline.Text = "Hotline: 0917-XXXX-250X";
            // 
            // GbtnExit
            // 
            this.GbtnExit.BackColor = System.Drawing.Color.Transparent;
            this.GbtnExit.BorderRadius = 8;
            this.GbtnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(67)))));
            this.GbtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GbtnExit.ForeColor = System.Drawing.Color.White;
            this.GbtnExit.Location = new System.Drawing.Point(1067, 14);
            this.GbtnExit.Name = "GbtnExit";
            this.GbtnExit.Size = new System.Drawing.Size(100, 45);
            this.GbtnExit.TabIndex = 10;
            this.GbtnExit.Text = "Exit";
            this.GbtnExit.Click += new System.EventHandler(this.GbtnExit_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.Transparent;
            this.btnQuayLai.BorderRadius = 8;
            this.btnQuayLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuayLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuayLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(67)))));
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(961, 14);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(100, 45);
            this.btnQuayLai.TabIndex = 11;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.RPDoanhThu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(75, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(996, 640);
            this.reportViewer1.TabIndex = 7;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.reportViewer1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(67)))));
            this.guna2Panel1.Location = new System.Drawing.Point(27, 115);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1159, 640);
            this.guna2Panel1.TabIndex = 8;
            // 
            // frmRPDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 767);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRPDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRPDoanhThu";
            this.Load += new System.EventHandler(this.frmRPDoanhThu_Load);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GbtnLogo)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox GbtnLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblHotline;
        private Guna.UI2.WinForms.Guna2Button GbtnExit;
        private Guna.UI2.WinForms.Guna2Button btnQuayLai;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}