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
    public partial class frmCheckOut : Form
    {
        function fn = new function();
        String query;
        public frmCheckOut()
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

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
     
            
            query = "SELECT DatPhong.MaDP, Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE Phong.TinhTrang = 'Đang dùng' AND DatPhong.Checkout IS NULL";


            DataSet ds = fn.getData(query);
            GDataGridView1.DataSource = ds.Tables[0];
        }

        private void GtxtTen_TextChanged(object sender, EventArgs e)
        {
            query = "select DatPhong.MaDP, Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong from Khach inner join DatPhong on Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong where TenKhach LIKE N'" + GtxtTen.Text + "%' and Phong.TinhTrang = 'Đang dùng' AND DatPhong.Checkout IS NULL";
            DataSet ds = fn.getData(query);
            GDataGridView1.DataSource = ds.Tables[0];
        }
        int MaDP;

        // lấy dữ liệu từ datagridview đổ vào các textbox
        private void GDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MaDP = int.Parse(GDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                GtxtTenKhach.Text = GDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                GtxtSoPhong.Text = GDataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        private void GbtnCheckOut_Click(object sender, EventArgs e)
        {
            if (GtxtTenKhach.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn check out khách hàng Tên:  " + GtxtTenKhach.Text + " khỏi phòng " + GtxtSoPhong.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String checkOutDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    query = "update DatPhong set TinhTrang = 'Chưa Thanh Toán', Checkout = '" + checkOutDate + "' where MaDP = " + MaDP + " update Phong set TinhTrang = 'Chưa Thanh Toán' where SoPhong = '" + GtxtSoPhong.Text + "'";
                    fn.setData(query, "Khách hàng " + GtxtTenKhach.Text + " đã được check out khỏi phòng " + GtxtSoPhong.Text);
                    frmCheckOut_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để check out", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            GtxtTenKhach.Clear();
            GtxtTen.Clear();
            GtxtSoPhong.Clear();
            GDTPCheckOutDate.Value = DateTime.Now;
        }
    }
}
