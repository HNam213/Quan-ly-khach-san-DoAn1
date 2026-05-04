using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public class function
    {
        public static int MaNV_DangNhap; //Biến toàn cục lưu MaNV nhân viên đã đăng nhập
        public static string TenNV_DangNhap; //  lưu Tên nhân viên đã đăng nhập
        public static string ChucVu_DangNhap; //  lưu Chức vụ nhân viên đã đăng nhập
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-QJU1F7H\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            return con;
        }
        public DataSet getData(string query) //lấy dữ liệu từ database
        {
            SqlConnection con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query,String message)  // thêm , sửa, xóa dữ liệu
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //============================================================================================
        public SqlDataReader getForCombo(string query)  //Đổ dữ liệu vào combobox
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query,con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
        public int setDataReturnID(string query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(query +"; SELECT SCOPE_IDENTITY();", con);
            con.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }

        public bool DangNhap(string TenDangNhap, string MatKhau)
        {
            string query = "SELECT MaNV,TenNhanVien FROM NhanVien WHERE TenDangNhap = @user AND MatKhau = @pass";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@user", TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", MatKhau);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())  // Nếu tìm thấy nhân viên hợp lệ
                    {
                        MaNV_DangNhap = Convert.ToInt32(reader["MaNV"]);  
                        TenNV_DangNhap = reader["TenNhanVien"].ToString(); 
                        return true;  
                    }
                    else
                    {
                        return false; // Sai tài khoản hoặc mật khẩu
                    }
                }
            }
        }

        public void UpdateAnhPhong(string soPhong, byte[] imgBytes)
        {
            using (SqlConnection con = GetConnection())
            using (SqlCommand cmd = new SqlCommand("UPDATE Phong SET AnhPhong = @img WHERE SoPhong = @id", con))
            {
                cmd.Parameters.AddWithValue("@img", imgBytes);
                cmd.Parameters.AddWithValue("@id", soPhong);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Đã cập nhật ảnh phòng!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

    }
}
