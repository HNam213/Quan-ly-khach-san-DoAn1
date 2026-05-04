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
    public partial class frmRPDoanhThu : Form
    {

        function fn = new function();
        String query;
        public frmRPDoanhThu()
        {
            InitializeComponent();
        }

        private void frmRPDoanhThu_Load(object sender, EventArgs e)
        {
            query = @"SELECT 
                MaHD,
                MaDP,
                MaNV,
                NgayLap,
                SoNgayO,
                TongTien
                FROM HoaDon";

            DataSet ds = fn.getData(query);
            reportViewer1.LocalReport.DataSources.Clear();

            // Gán datasource cho report // PHẢI TRÙNG TÊN Dataset trong RDLC
            ReportDataSource rds = new ReportDataSource("HoaDon", ds.Tables[0]);

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\RPDoanhThu.rdlc";
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
