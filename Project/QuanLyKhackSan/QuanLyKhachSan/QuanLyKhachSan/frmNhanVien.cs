using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmNhanVien : Form
    {
        function fn = new function();
        String query;
        public frmNhanVien()
        {
            InitializeComponent();
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Hide();
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LayMaxID();


            query = "Select * from NhanVien";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void GbtnDangKy_Click(object sender, EventArgs e)
        {
            if (GtxtTen.Text != "" && GtxtSDT.Text != "" && GcbbGioiTinh.Text != "" && GtxtChucVu.Text != "" && GtxtTenDangNhap.Text != "" && GtxtMatKhau.Text != "")
            {
                String Ten = GtxtTen.Text;
                Int64 SDT = Int64.Parse(GtxtSDT.Text);
                String GioiTinh = GcbbGioiTinh.Text;
                String ChucVu = GtxtChucVu.Text;
                String TenDangNhap = GtxtTenDangNhap.Text;
                String MatKhau = GtxtMatKhau.Text;
                String DiaChi = GtxtDiaChiNV.Text;
                query = "insert into NhanVien (TenNhanVien, SDT, GioiTinh, DiaChi, ChucVu, TenDangNhap, MatKhau) values (N'" + Ten + "', N'" + SDT + "', N'" + GioiTinh + "', N'" + DiaChi + "', N'" + ChucVu + "', N'" + TenDangNhap + "', N'" + MatKhau + "') ";
                fn.setData(query, "Đăng ký nhân viên thành công.");

                clearAll();
                LayMaxID();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 0)
            {
                setNhanVien(DataGridView1);
            }
            else if (guna2TabControl1.SelectedIndex == 2)
            {
                setNhanVien(DataGridView2);
            }
        }

        private void GbtnXoa_Click(object sender, EventArgs e)
        {
            if(GtxtXoaID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn Xóa Nhân Viên Này không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from NhanVien where MaNV = " + GtxtXoaID.Text + "";
                    fn.setData(query, "Xóa Nhân Viên Thành công.");
                    guna2TabControl1_SelectedIndexChanged(this, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID nhân viên muốn xóa", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNhanVien_Leave(object sender, EventArgs e)
            {
                clearAll();
            }

        //============================================================================

        public void LayMaxID()
        {
            query = "Select max(MaNV) from NhanVien";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                GlblMaNhanVien.Text = (num + 1).ToString();
            }
        }
        public void clearAll()
        {
            GtxtTen.Clear();
            GtxtSDT.Clear();
            GcbbGioiTinh.SelectedIndex = -1;
            GtxtChucVu.Clear();
            GtxtTenDangNhap.Clear();
            GtxtMatKhau.Clear();
        }

        public void setNhanVien(DataGridView dgv)
        {
            query = "select * from NhanVien";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        
    }
}
