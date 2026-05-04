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
    public partial class frmThongTin : Form
    {
        function fn = new function();
        String query;
        public frmThongTin()
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

        private void GcbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GcbbTimKiem.SelectedIndex == 0)
            {
                query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.TinhTrang FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang IN (N'Đang dùng', N'Chua Thanh Toán', N'Đã Thanh Toán')";
                getRecord(query);
            }
            else if (GcbbTimKiem.SelectedIndex == 1)
            {
                query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.TinhTrang FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang IN (N'Đang dùng')";
                getRecord(query);
            }
            else if (GcbbTimKiem.SelectedIndex == 2)
            {
                query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.TinhTrang FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang IN (N'Chua Thanh Toán')";
                getRecord(query);
            }
            else if (GcbbTimKiem.SelectedIndex == 3)
            {
                query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.TinhTrang FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang IN (N'Đã Thanh Toán')";
                getRecord(query);
            }
        }
        private void frmThongTin_Load(object sender, EventArgs e)
        {
            query = "SELECT Khach.IdKhach, Khach.TenKhach, Khach.SDT, Khach.QuocTich, Khach.GioiTinh, Khach.CCCD, Khach.DiaChi, DatPhong.NgayDat, DatPhong.Checkin, DatPhong.Checkout, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.TinhTrang FROM Khach INNER JOIN DatPhong ON Khach.IdKhach = DatPhong.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang IN (N'Đang dùng', N'Chua Thanh Toán', N'Đã Thanh Toán')";
            
            getRecord(query);
        }


        //==================================================================================================================================
        private void getRecord(String query)
        {
            
            DataSet ds = fn.getData(query);
            GDataGridView1.DataSource = ds.Tables[0];
        }

        
    }
}
  
