using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmBill : Form

    {
        int _maHD;
        function fn = new function();
        String query;
        public frmBill(int maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

    public void LoadHoaDon()
        {
            //query = "SELECT HoaDon.MaHD, HoaDon.NgayLap, HoaDon.TongTien, NhanVien.TenNhanVien, Khach.TenKhach, Khach.SDT, Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, DatPhong.Checkin, DatPhong.Checkout, HoaDon.NgayLap, HoaDon.SoNgayO FROM HoaDon INNER JOIN NhanVien ON HoaDon.MaNV = NhanVien.MaNV INNER JOIN DatPhong ON HoaDon.MaDP = DatPhong.MaDP INNER JOIN Khach ON DatPhong.IdKhach = Khach.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE HoaDon.MaHD = " + _maHD; 

            query = "SELECT HoaDon.MaHD, HoaDon.NgayLap, HoaDon.TongTien, HoaDon.SoNgayO, " +
        "NhanVien.TenNhanVien, Khach.TenKhach, Khach.SDT, " +
        "Phong.SoPhong, Phong.LoaiPhong, Phong.LoaiGiuong, Phong.GiaPhong, " +
        "DatPhong.Checkin, DatPhong.Checkout, " +

        // TỔNG TIỀN DỊCH VỤ
        "ISNULL((SELECT SUM(TongDon) FROM DichVuKhach WHERE IdKhach = Khach.IdKhach),0) AS TienDichVu " +

        "FROM HoaDon " +
        "INNER JOIN NhanVien ON HoaDon.MaNV = NhanVien.MaNV " +
        "INNER JOIN DatPhong ON HoaDon.MaDP = DatPhong.MaDP " +
        "INNER JOIN Khach ON DatPhong.IdKhach = Khach.IdKhach " +
        "INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong " +
        "WHERE HoaDon.MaHD = " + _maHD;


            DataSet ds = fn.getData(query);



            if (ds.Tables[0].Rows.Count > 0)
            {
                //DataRow r = ds.Tables[0].Rows[0];
                //GtxtTenNV.Text = r["TenNhanVien"].ToString();
                //GtxtNgayLap.Text = Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy");
                //GtxtMaHD.Text = r["MaHD"].ToString();
                //GtxtTenKH.Text = r["TenKhach"].ToString();
                //GtxtSDT.Text = r["SDT"].ToString();
                //GtxtSoPhong.Text = r["SoPhong"].ToString();
                //GtxtLoaiPhong.Text = r["LoaiPhong"].ToString();
                //GtxtLoaiGiuong.Text = r["LoaiGiuong"].ToString();
                //GtxtGiaPhong.Text = r["GiaPhong"].ToString();
                //GtxtSoNgayO.Text = r["SoNgayO"].ToString();
                //GtxtTongTien.Text = r["TongTien"].ToString();
                ////GtxtTongTienPhong.Text = r["TongTien"].ToString();

                //int giaPhong = int.Parse(GtxtGiaPhong.Text);
                //int SoNgayO = int.Parse(GtxtSoNgayO.Text);
                //int TongTien = SoNgayO * giaPhong;
                //GtxtTongTienPhong.Text = TongTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";

                DataRow r = ds.Tables[0].Rows[0];

                GtxtTenNV.Text = r["TenNhanVien"].ToString();
                GtxtNgayLap.Text = Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy");
                GtxtMaHD.Text = r["MaHD"].ToString();
                GtxtTenKH.Text = r["TenKhach"].ToString();
                GtxtSDT.Text = r["SDT"].ToString();
                GtxtSoPhong.Text = r["SoPhong"].ToString();
                GtxtLoaiPhong.Text = r["LoaiPhong"].ToString();
                GtxtLoaiGiuong.Text = r["LoaiGiuong"].ToString();

                int giaPhong = Convert.ToInt32(r["GiaPhong"]);
                int soNgayO = Convert.ToInt32(r["SoNgayO"]);
                int tienDV = Convert.ToInt32(r["TienDichVu"]);
                int tongTien = Convert.ToInt32(r["TongTien"]);

                GtxtGiaPhong.Text = giaPhong.ToString("N0");
                GtxtSoNgayO.Text = soNgayO.ToString();

                // ===== TIỀN PHÒNG =====
                int tongTienPhong = giaPhong * soNgayO;
                GtxtTongTienPhong.Text = tongTienPhong.ToString("N0",
                    CultureInfo.GetCultureInfo("vi-VN")) + " VND";

                // ===== TIỀN DỊCH VỤ =====
                GtxtTienDichVu.Text = tienDV.ToString("N0",
                    CultureInfo.GetCultureInfo("vi-VN")) + " VND";

                // ===== TỔNG TIỀN =====
                GtxtTongTien.Text = tongTien.ToString("N0",
                    CultureInfo.GetCultureInfo("vi-VN")) + " VND";


            }

        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            frmThanhToan f = new frmThanhToan();
            this.Close();
        }

       
    }
}
