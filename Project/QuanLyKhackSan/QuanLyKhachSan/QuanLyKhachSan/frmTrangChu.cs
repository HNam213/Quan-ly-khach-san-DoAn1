using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace QuanLyKhachSan
{
    
    public partial class frmTrangChu : Form
    {
        function fn = new function();
        string query;

        public frmTrangChu()
        {
            InitializeComponent();
        }
        

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GbtnThemPhong_Click(object sender, EventArgs e)
        {
            frmThemPhong formThemPhong = new frmThemPhong();
            formThemPhong.ShowDialog();
            //formThemPhong.Show();
            this.Hide();
        }

        private void GbtnThemKhach_Click(object sender, EventArgs e)
        {
            frmCheckIn formCheckIn = new frmCheckIn();
            formCheckIn.ShowDialog();
            //formCheckIn.Show();
            this.Hide();

        }

        private void GbtnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut formCheckOut = new frmCheckOut();
            formCheckOut.ShowDialog();
            //formCheckOut.Show();
            this.Hide();
        }

        private void GbtnThongTin_Click(object sender, EventArgs e)
        {
            frmThongTin formThongTin = new frmThongTin();
            formThongTin.ShowDialog();
            //formThongTin.Show();
            this.Hide();
        }

        private void GbtnDichVu_Click(object sender, EventArgs e)
        {
           frmDichVu frmDichVu = new frmDichVu();
            frmDichVu.ShowDialog();
            //frmDichVu.Show();
            this.Hide();
        }
        private void GbtnThanhToan_Click(object sender, EventArgs e)
        {
            frmThanhToan formThanhToan = new frmThanhToan();
            formThanhToan.ShowDialog();
            //formThanhToan.Show();
            this.Hide();
        }
        private void GbtnNhanVien_Click(object sender, EventArgs e)
        {
            if (function.ChucVu_DangNhap != "Quản Lý")
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmNhanVien formNhanVien = new frmNhanVien();
            formNhanVien.ShowDialog();
            //formNhanVien.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn đăng xuất không?",
        "Xác nhận đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng tất cả form trừ form login (nếu đã mở)
                foreach (Form form in Application.OpenForms.Cast<Form>().Reverse())
                {
                    if (form.Name != "frmDangNhap")  // thay tên form login thật của bạn
                    {
                        form.Close();
                    }
                }

                // Mở lại form đăng nhập (nếu chưa mở)
                frmDangNhap loginForm = new frmDangNhap();
                loginForm.Show();
            }
        }

        private void GlblTenNhanVien_Click(object sender, EventArgs e)
        {
            frmInfNhanVien formInfNhanVien = new frmInfNhanVien();
            formInfNhanVien.ShowDialog();
            //formInfNhanVien.Show();
            this.Hide();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.CustomFormat = "dd/MM/yyyy";
            DateTimePicker1.ShowUpDown = false;
            DateTimePicker1.Width = 150;

            GlblTenNhanVien.Text = function.TenNV_DangNhap;
            GlblChucVu.Text = function.ChucVu_DangNhap;

            string query = "SELECT SUM(TongTien) FROM HoaDon";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0] != DBNull.Value)
            {
                decimal tongTien = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                GtxtTongDoanhThu.Text = tongTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            }
            else
            {
                GtxtTongDoanhThu.Text = "0 VNĐ";
            }
            LoadAnhDaiDien();

            LoadChartDoanhThu();

            LoadChartDichVu();
            chartDichVu.Legends[0].Docking = Docking.Bottom;
            chartDichVu.Series[0]["PieLabelStyle"] = "Outside";
            chartDichVu.Series[0]["PieLineColor"] = "Black";


            
        }

        private void guna2Panel12_Click(object sender, EventArgs e)
        {
            frmRPKhachHang fn = new frmRPKhachHang();
            fn.ShowDialog();
            //fn.Show();
            this.Hide();
        }

        private void GbtnDoanhThu_Click(object sender, EventArgs e)
        {
            frmRPDoanhThu fn = new frmRPDoanhThu();
            fn.ShowDialog();
            //fn.Show();
            this.Hide();
        }

        private void guna2Panel14_Click(object sender, EventArgs e)
        {
         frmMayTinh fn = new frmMayTinh();
            fn.ShowDialog();
        }


        private void Bell_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hiện Tại Chưa có thông báo nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GbtnDVK_Click(object sender, EventArgs e)
        {
            frmDichVuKhach formDichVuKhach = new frmDichVuKhach();
            formDichVuKhach.ShowDialog();
            //formDichVuKhach.Show();
            this.Hide();
        }
        private void guna2Panel17_Click(object sender, EventArgs e)
        {
            frmThongTinPhong fn = new frmThongTinPhong();
            fn.ShowDialog();
            //fn.Show();
            this.Hide();
        }

        //=================================================================================

        public void LoadAnhDaiDien()
        {
            string query = "SELECT AnhDaiDien FROM NhanVien WHERE MaNV = " + function.MaNV_DangNhap;

            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if (row["AnhDaiDien"] != DBNull.Value)
                {
                    byte[] img = (byte[])row["AnhDaiDien"];
                    MemoryStream ms = new MemoryStream(img);
                    guna2CirclePictureBox2.Image = Image.FromStream(ms);
                }
            }
        }

        public void LoadChartDichVu()
        {
            string query = @"SELECT TOP 5
                     dv.TenDichVu,
                     SUM(dvk.SoLuong) AS TongSuDung
                     FROM DichVuKhach dvk
                     INNER JOIN DichVu dv ON dvk.IdDichVu = dv.IdDichVu
                     GROUP BY dv.TenDichVu
                     ORDER BY TongSuDung DESC";

            DataSet ds = fn.getData(query);

            chartDichVu.Series.Clear();
            chartDichVu.Titles.Clear();

            chartDichVu.Titles.Add("Top 5 dịch vụ được sử dụng");

            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                series.Points.AddXY(
                    row["TenDichVu"].ToString(),
                    Convert.ToInt32(row["TongSuDung"])
                );
            }

            series.IsValueShownAsLabel = true;
            
            
            series.Label = "#PERCENT";
            series.LegendText = "#VALX";
            series.IsValueShownAsLabel = true;

            chartDichVu.Series.Add(series);
        }

        public void LoadChartDoanhThu()
        {
            string query = @"SELECT 
                     MONTH(NgayLap) AS Thang,
                     SUM(TongTien) AS DoanhThu
                     FROM HoaDon
                     GROUP BY MONTH(NgayLap)
                     ORDER BY Thang";

            DataSet ds = fn.getData(query);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            chartDoanhThu.Titles.Add("Doanh thu theo tháng");

            
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(142, 115, 67);
            series["PointWidth"] = "0.6";
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            series.IsValueShownAsLabel = true;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                series.Points.AddXY(
                    "Tháng " + row["Thang"].ToString(),
                    Convert.ToDecimal(row["DoanhThu"])
                );
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Legends[0].Docking = Docking.Bottom;
            chartDoanhThu.Palette = ChartColorPalette.BrightPastel;

            chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
        }


        private void Pinterest_Paint(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.pinterest.com/halekulanihotel/");
        }

        private void Instargram_Paint(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/halekulanihotel/");
        }

        private void youtobe_Paint(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCFlpzIt8Ri0hoZ87O4n670A");
        }

        private void Facebook_Paint(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/HalekulaniHotel");
        }
    }
}
