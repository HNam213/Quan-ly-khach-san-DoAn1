using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        function fn = new function();
        String query;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void foreverTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //string user, pass;

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        bool isPasswordHidden = true;
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            {
                GtxtPassword.UseSystemPasswordChar = true;
                GbtnEye.Image = Properties.Resources.icon_eye;
            }
            this.AcceptButton = GbtnLogin;
            GtxtUsername.Focus();
            this.CancelButton = GbtnExit;

        }

        private void GbtnEye_Click(object sender, EventArgs e)
        {
            if (isPasswordHidden)
            {
                // Hiện password
                GtxtPassword.UseSystemPasswordChar = false;
                GbtnEye.Image = Properties.Resources.icons_eye;
                isPasswordHidden = false;
            }
            else
            {
                // Ẩn password
                GtxtPassword.UseSystemPasswordChar = true;
                GbtnEye.Image = Properties.Resources.icon_eye;
                isPasswordHidden = true;
            }
        }

        private void GbtnLinkHotel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.halekulani.com/");
        }

        private void GbtnLogin_Click(object sender, EventArgs e)
        {
            
            query = "select TenDangNhap,MatKhau,MaNV,TenNhanVien,ChucVu from NhanVien where TenDangNhap='" + GtxtUsername.Text + "' and MatKhau='" + GtxtPassword.Text + "'";
            
            DataSet ds = fn.getData(query);

            

            if (ds.Tables[0].Rows.Count != 0)
            {
                function.MaNV_DangNhap = Convert.ToInt32(ds.Tables[0].Rows[0]["MaNV"]);
                function.TenNV_DangNhap = ds.Tables[0].Rows[0]["TenNhanVien"].ToString();
                function.ChucVu_DangNhap = ds.Tables[0].Rows[0]["ChucVu"].ToString();
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTrangChu dash = new frmTrangChu();
                this.Hide();
                dash.Show();
            }

            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! xin vui lòng nhập lại", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GtxtPassword.Clear();
            }
        }

        private void GtxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            GtxtUsername.Focus();

        }
    }
}








//string user = GtxtUsername.Text.Trim();
            //string pass = GtxtPassword.Text.Trim();
            //string sql = "SELECT COUNT(*) FROM QuanLy WHERE TenDangNhap=@u AND MatKhau=@p";
            //SqlConnection ketnoi = new SqlConnection(@"Data Source=DESKTOP-QJU1F7H\SQLEXPRESS;Integrated Security=True;Initial Catalog=QLKS;");
            ////nếu để trống hiện thông báo 
            //if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
            //    return;
            //}

            //try
            //{

            //    ketnoi.Open();
            //    if (ketnoi.State == ConnectionState.Open)
            //    {
            //        SqlCommand cmp = ketnoi.CreateCommand();
            //        cmp.CommandText = sql;
            //        cmp.Parameters.Clear();
            //        cmp.Parameters.AddWithValue("@u", user);
            //        cmp.Parameters.AddWithValue("@p", pass);

            //        int kq = (int)cmp.ExecuteScalar();
            //        //điều kiện kiểm tra đăng nhập từ cơ sở dữ liệu
            //        if (kq > 0)
            //        {
            //            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            frmTrangChu ds = new frmTrangChu();
            //            this.Hide();
            //            ds.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! xin vui lòng nhập lại", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi kết nối CSDL:\n" + ex.Message);

            //}
            //finally
            //{
            //    if (ketnoi.State == ConnectionState.Open)
            //    {
            //        ketnoi.Close();
            //    }
            //}