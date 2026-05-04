using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmInfNhanVien : Form
    {
        function fn = new function();
        string query;
        public frmInfNhanVien()
        {
            InitializeComponent();
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Hide();
        }

        private void GbtnLogo_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "frmTrangChu")  // thay tên form trang chủ
                {
                    f.Hide();
                }
            }

            // Hiện lại trang chủ
            Form trangChu = Application.OpenForms["frmTrangChu"];
            if (trangChu != null)
            {
                trangChu.BringToFront();
                trangChu.Show();
            }
        }

        private void frmInfNhanVien_Load(object sender, EventArgs e)
        {

            LoadThongTinNhanVien();

        }

        private void GbtnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                GtxtAnhDaiDien.Image = Image.FromFile(ofd.FileName);

                
                MemoryStream ms = new MemoryStream();
                GtxtAnhDaiDien.Image.Save(ms, GtxtAnhDaiDien.Image.RawFormat);
                byte[] img = ms.ToArray();

                
                using (SqlConnection conn = new function().GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE NhanVien SET AnhDaiDien = @img WHERE MaNV = @id", conn);

                    cmd.Parameters.AddWithValue("@img", img);
                    cmd.Parameters.AddWithValue("@id", function.MaNV_DangNhap);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đổi ảnh thành công!");
            }
        }

        private void GbtnCapNhat_Click(object sender, EventArgs e)
        {
            string query = @"
        UPDATE NhanVien SET
        TenNhanVien = N'" + GtxtTen.Text + @"',
        SDT = '" + GtxtSoDienThoai.Text + @"',
        GioiTinh = N'" + GcbbGioiTinh.Text + @"',
        DiaChi = N'" + GtxtDiaChiNV.Text + @"',
        TenDangNhap = '" + GtxtTenDangNhap.Text + @"',
        MatKhau = '" + GtxtMatKhau.Text + @"'
        WHERE MaNV = " + function.MaNV_DangNhap;

            fn.setData(query, "Cập nhật thành công!");

            LoadThongTinNhanVien();

            frmTrangChu f = (frmTrangChu)Application.OpenForms["frmTrangChu"];
            if (f != null)
            {
                f.LoadAnhDaiDien();
            }
        }

        //=========================================================================================================
        public void LoadThongTinNhanVien()
        {
            string query = "SELECT * FROM NhanVien WHERE MaNV = " + function.MaNV_DangNhap;

            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                GtxtIDNhanVien1.Text = row["MaNV"].ToString();
                GtxtTenNV1.Text = row["TenNhanVien"].ToString();
                GtxtSoDienThoai1.Text = row["SDT"].ToString();
                GtxtGioiTinh1.Text = row["GioiTinh"].ToString();
                GtxtDiaChi1.Text = row["DiaChi"].ToString();
                GtxtChucVu1.Text = row["ChucVu"].ToString();
                GtxtTenDangNhap1.Text = row["TenDangNhap"].ToString();
                GtxtMatKhau1.Text = row["MatKhau"].ToString();


                GtxtTen.Text = row["TenNhanVien"].ToString();
                GtxtSoDienThoai.Text = row["SDT"].ToString();
                GcbbGioiTinh.Text = row["GioiTinh"].ToString();
                GtxtDiaChiNV.Text = row["DiaChi"].ToString();
                GtxtChucVu.Text = row["ChucVu"].ToString();
                GtxtTenDangNhap.Text = row["TenDangNhap"].ToString();
                GtxtMatKhau.Text = row["MatKhau"].ToString();
                if (row["AnhDaiDien"] != DBNull.Value)
                {
                    byte[] img = (byte[])row["AnhDaiDien"];
                    MemoryStream ms = new MemoryStream(img);
                    GtxtAnhDaiDien.Image = Image.FromStream(ms);
                }
            }
        }


    }
}
