using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
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

    public partial class frmRPKhachHang : Form
    {
        int _maHD;
        
        function fn = new function();
        String query;
        String querygrid1;
        String querygrid2;
        public frmRPKhachHang()
        {
            InitializeComponent();
        }

        private void frmRPHoaDon_Load(object sender, EventArgs e)
        {
            querygrid1 = "SELECT  Khach.IdKhach, Khach.TenKhach, HoaDon.SoNgayO, HoaDon.TongTien FROM HoaDon INNER JOIN DatPhong ON HoaDon.MaDP = DatPhong.MaDP INNER JOIN Khach ON DatPhong.IdKhach = Khach.IdKhach INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong WHERE DatPhong.TinhTrang = N'Đã Thanh Toán' ORDER BY HoaDon.MaHD DESC";
            DataSet dsgrid1 = fn.getData(querygrid1);
            GDataGridView1.DataSource = dsgrid1.Tables[0];

            querygrid2 = @"SELECT 
    Phong.MaPhong,
    Phong.SoPhong,
    Phong.GiaPhong
FROM DatPhong
INNER JOIN Phong ON DatPhong.MaPhong = Phong.MaPhong
INNER JOIN Khach ON DatPhong.IdKhach = Khach.IdKhach
WHERE DatPhong.TinhTrang = N'Đã Thanh Toán'
ORDER BY Khach.IdKhach DESC";
            DataSet dsgrid2 = fn.getData(querygrid2);
            GDataGridView2.DataSource = dsgrid2.Tables[0];

            query = @"SELECT 
                MaDP,
                MaPhong,
                IdKhach,
                NgayDat,
                Checkin,
                Checkout,
                TinhTrang,
                MaNV
              FROM DatPhong
              WHERE TinhTrang = N'Đã Thanh Toán'";

            DataSet ds = fn.getData(query);
            reportViewer1.LocalReport.DataSources.Clear();

            // Gán datasource cho report // PHẢI TRÙNG TÊN Dataset trong RDLC
            ReportDataSource rds = new ReportDataSource("DatPhong", ds.Tables[0]);

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\RPHoaDon.rdlc";
            this.reportViewer1.RefreshReport();


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

       
    }
}
