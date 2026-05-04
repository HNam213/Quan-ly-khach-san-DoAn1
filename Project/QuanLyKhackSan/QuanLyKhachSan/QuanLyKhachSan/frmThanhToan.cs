using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuanLyKhachSan
{
    public partial class frmThanhToan : Form
    {
        function fn = new function();
        String query;
 
        public frmThanhToan()
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

        private void GbtnQuayLai_Click(object sender, EventArgs e)
        {
            
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Hide();
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GtxtTimTenKhach_TextChanged(object sender, EventArgs e)
        {
            query = "select Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.MaDP, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong from Khach inner join DatPhong on Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong where TenKhach LIKE N'" + GtxtTimTenKhach.Text + "%' "; //and Phong.TinhTrang = 'Chưa Thanh Toán'
            DataSet ds = fn.getData(query);
            GDataGridView1.DataSource = ds.Tables[0];
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            //query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.MaDP, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang = 'Chưa Thanh Toán'";
            query = @"SELECT 
    Khach.IdKhach,
    Khach.TenKhach,
    Khach.SDT,
    Khach.QuocTich,
    Khach.GioiTinh,
    Khach.CCCD,
    Khach.DiaChi,
    DatPhong.MaDP,
    DatPhong.NgayDat,
    DatPhong.Checkin,
    DatPhong.Checkout,
    Phong.SoPhong,
    Phong.LoaiPhong,
    Phong.LoaiGiuong,
    Phong.GiaPhong,

    -- Tổng tiền dịch vụ
    ISNULL(
        (SELECT SUM(TongDon) 
         FROM DichVuKhach 
         WHERE DichVuKhach.IdKhach = Khach.IdKhach),
    0) AS TongTienDichVu

FROM Khach
INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach
INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong
WHERE DatPhong.TinhTrang = N'Chua Thanh Toán'";




            DataSet ds = fn.getData(query);
            GDataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void GDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                id = int.Parse(GDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                GtxtTenKhach.Text = GDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                GtxtSoPhong.Text = GDataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                GtxtSDT.Text = GDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                DateTime checkIn = Convert.ToDateTime(GDataGridView1.Rows[e.RowIndex].Cells["CheckIn"].Value);
                DateTime checkOut = Convert.ToDateTime(GDataGridView1.Rows[e.RowIndex].Cells["CheckOut"].Value);

                int SoNgayO = (checkOut - checkIn).Days;
                GtxtSoNgayO.Text = SoNgayO.ToString();
                GtxtGiaPhong.Text = GDataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                int giaPhong = Convert.ToInt32(GDataGridView1.Rows[e.RowIndex].Cells[14].Value);


                int tienDV = 0;

                if (GDataGridView1.Rows[e.RowIndex].Cells["TongTienDichVu"].Value != DBNull.Value)
                {
                    tienDV = Convert.ToInt32(
                        GDataGridView1.Rows[e.RowIndex].Cells["TongTienDichVu"].Value
                    );
                }

                GtxtTienDV.Text = tienDV.ToString("N0");


                int TongTien = (SoNgayO * giaPhong) + tienDV;

                GtxtTongThanhToan.Text = TongTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
                
                String checkOutDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                GtxtNgayThanhToan.Text = checkOutDate;

                
                GtxtTenNhanVien.Text = function.TenNV_DangNhap;
                GtxtMaDatPhong.Text = GDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            else
            {
                MessageBox.Show("Không có khách hàng cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GbtnThanhToan_Click(object sender, EventArgs e)
        {
            //if (GtxtTenKhach.Text != "" && GtxtSDT.Text != "" && GtxtSoPhong.Text != "" && GtxtSoNgayO.Text != "" && GtxtMaDatPhong.Text != "" && GtxtNgayThanhToan.Text != "" && GtxtTenNhanVien.Text != "")
            //{

            //    int giaPhong = int.Parse(GtxtGiaPhong.Text);
            //    int SoNgayO = int.Parse(GtxtSoNgayO.Text);
            //    Int64 SDT = Int64.Parse(GtxtSDT.Text);
            //    Int64 MaDP = Int64.Parse(GtxtMaDatPhong.Text);
            //    String NgayThanhToan = GtxtNgayThanhToan.Text;
            //    int TongTien = SoNgayO * giaPhong;
            //    int MaNV = function.MaNV_DangNhap;


            //    query = "insert into HoaDon( NgayLap, TongTien, MaNV, MaDP, SoNgayO) values(N'" + NgayThanhToan + "', " + TongTien + ", '" + MaNV + "', '" + MaDP + "', '" + SoNgayO + "'); update DatPhong set TinhTrang = 'Đã Thanh Toán' where IdKhach = " + id + " update Phong set TinhTrang = 'NO' where SoPhong = '" + GtxtSoPhong.Text + "' update DatPhong set TinhTrang = N'Đã Thanh Toán' where MaDP = '" + GtxtMaDatPhong.Text + "'";
            //    int maHD = fn.setDataReturnID(query);

            //    MessageBox.Show(
            //        "Khách hàng " + GtxtTenKhach.Text + " ở phòng số " + GtxtSoPhong.Text + " đã thanh toán thành công");

            //    frmBill f = new frmBill(maHD);
            //    f.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn khách hàng cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            if (GtxtTenKhach.Text != "" && GtxtSDT.Text != "" &&
        GtxtSoPhong.Text != "" && GtxtSoNgayO.Text != "" &&
        GtxtMaDatPhong.Text != "" && GtxtNgayThanhToan.Text != "" &&
        GtxtTenNhanVien.Text != "")
            {
                int giaPhong = int.Parse(GtxtGiaPhong.Text);
                int SoNgayO = int.Parse(GtxtSoNgayO.Text);
                int tienDV = 0;

                // Lấy tiền dịch vụ (bỏ dấu phẩy nếu có format N0)
                if (GtxtTienDV.Text != "")
                {
                    tienDV = int.Parse(GtxtTienDV.Text.Replace(",", ""));
                }

                Int64 MaDP = Int64.Parse(GtxtMaDatPhong.Text);
                String NgayThanhToan = GtxtNgayThanhToan.Text;
                int MaNV = function.MaNV_DangNhap;

                // ===== TÍNH TỔNG TIỀN ĐÚNG =====
                int TongTien = (SoNgayO * giaPhong) + tienDV;

                query = "INSERT INTO HoaDon(NgayLap, TongTien, MaNV, MaDP, SoNgayO) VALUES " +
                        "(N'" + NgayThanhToan + "', " + TongTien + ", " + MaNV + ", " + MaDP + ", " + SoNgayO + "); " +

                        "UPDATE DatPhong SET TinhTrang = N'Đã Thanh Toán' WHERE MaDP = " + MaDP + "; " +

                        "UPDATE Phong SET TinhTrang = N'NO' WHERE SoPhong = '" + GtxtSoPhong.Text + "';";

                int maHD = fn.setDataReturnID(query);

                MessageBox.Show("Khách hàng " + GtxtTenKhach.Text +
                                " ở phòng số " + GtxtSoPhong.Text +
                                " đã thanh toán thành công!");

                frmBill f = new frmBill(maHD);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần thanh toán!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

            ClearAll();
        }

        //===============================================================================================================
        public void ClearAll()
        {
            GtxtTenKhach.Clear();
            GtxtSDT.Clear();
            GtxtSoPhong.Clear();
            GtxtGiaPhong.Clear();
            GtxtSoNgayO.Clear();
            GtxtTongThanhToan.Clear();
            GtxtNgayThanhToan.Clear();
            GtxtMaDatPhong.Clear();
            GtxtTenNhanVien.Clear(); 
            GtxtTienDV.Clear();
        }


    }
}
