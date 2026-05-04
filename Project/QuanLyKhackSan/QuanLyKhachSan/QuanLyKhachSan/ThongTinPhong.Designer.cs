namespace QuanLyKhachSan
{
    partial class ThongTinPhong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GlblSoPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GlblTinhTrang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GPictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.GbtnDoiAnh = new Guna.UI2.WinForms.Guna2Button();
            this.GlblLoaiPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GlblLoaiGiuong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GlblSoPhong
            // 
            this.GlblSoPhong.BackColor = System.Drawing.Color.Transparent;
            this.GlblSoPhong.Location = new System.Drawing.Point(16, 155);
            this.GlblSoPhong.Name = "GlblSoPhong";
            this.GlblSoPhong.Size = new System.Drawing.Size(15, 18);
            this.GlblSoPhong.TabIndex = 3;
            this.GlblSoPhong.Text = "---";
            // 
            // GlblTinhTrang
            // 
            this.GlblTinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.GlblTinhTrang.Location = new System.Drawing.Point(16, 179);
            this.GlblTinhTrang.Name = "GlblTinhTrang";
            this.GlblTinhTrang.Size = new System.Drawing.Size(15, 18);
            this.GlblTinhTrang.TabIndex = 4;
            this.GlblTinhTrang.Text = "---";
            // 
            // GPictureBox1
            // 
            this.GPictureBox1.ImageRotate = 0F;
            this.GPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.GPictureBox1.Name = "GPictureBox1";
            this.GPictureBox1.Size = new System.Drawing.Size(230, 146);
            this.GPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GPictureBox1.TabIndex = 0;
            this.GPictureBox1.TabStop = false;
            // 
            // GbtnDoiAnh
            // 
            this.GbtnDoiAnh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GbtnDoiAnh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GbtnDoiAnh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GbtnDoiAnh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GbtnDoiAnh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(67)))));
            this.GbtnDoiAnh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GbtnDoiAnh.ForeColor = System.Drawing.Color.White;
            this.GbtnDoiAnh.Location = new System.Drawing.Point(37, 249);
            this.GbtnDoiAnh.Name = "GbtnDoiAnh";
            this.GbtnDoiAnh.Size = new System.Drawing.Size(150, 29);
            this.GbtnDoiAnh.TabIndex = 5;
            this.GbtnDoiAnh.Text = "Đổi Ảnh Phòng";
            this.GbtnDoiAnh.Click += new System.EventHandler(this.GbtnDoiAnh_Click);
            // 
            // GlblLoaiPhong
            // 
            this.GlblLoaiPhong.BackColor = System.Drawing.Color.Transparent;
            this.GlblLoaiPhong.Location = new System.Drawing.Point(16, 203);
            this.GlblLoaiPhong.Name = "GlblLoaiPhong";
            this.GlblLoaiPhong.Size = new System.Drawing.Size(15, 18);
            this.GlblLoaiPhong.TabIndex = 6;
            this.GlblLoaiPhong.Text = "---";
            // 
            // GlblLoaiGiuong
            // 
            this.GlblLoaiGiuong.BackColor = System.Drawing.Color.Transparent;
            this.GlblLoaiGiuong.Location = new System.Drawing.Point(16, 227);
            this.GlblLoaiGiuong.Name = "GlblLoaiGiuong";
            this.GlblLoaiGiuong.Size = new System.Drawing.Size(15, 18);
            this.GlblLoaiGiuong.TabIndex = 7;
            this.GlblLoaiGiuong.Text = "---";
            // 
            // ThongTinPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GlblLoaiGiuong);
            this.Controls.Add(this.GlblLoaiPhong);
            this.Controls.Add(this.GbtnDoiAnh);
            this.Controls.Add(this.GlblTinhTrang);
            this.Controls.Add(this.GlblSoPhong);
            this.Controls.Add(this.GPictureBox1);
            this.Name = "ThongTinPhong";
            this.Size = new System.Drawing.Size(230, 287);
            this.Load += new System.EventHandler(this.ThongTinPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox GPictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblSoPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblTinhTrang;
        private Guna.UI2.WinForms.Guna2Button GbtnDoiAnh;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblLoaiPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel GlblLoaiGiuong;
    }
}
