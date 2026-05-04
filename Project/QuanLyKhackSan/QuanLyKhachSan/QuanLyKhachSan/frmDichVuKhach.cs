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
    public partial class frmDichVuKhach : Form
    {
        function fn = new function();
        string query;
        string conn;
        int idKhachHienTai = -1;
        public frmDichVuKhach()
        {
            InitializeComponent();
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



        private void frmDichVuKhach_Load(object sender, EventArgs e)
        {
            LoadDV();

            string query2 = @"
        SELECT 
            p.MaPhong,
            p.SoPhong,
            k.TenKhach,
            k.SDT
        FROM Phong p
        JOIN DatPhong dp ON p.MaPhong = dp.MaPhong
        JOIN Khach k ON dp.IdKhach = k.IdKhach
        WHERE p.TinhTrang <> 'No'
          AND dp.TinhTrang IN (N'Đang dùng', N'Chua Thanh Toán') ";

            DataSet ds = fn.getData(query2);

            GcbbSoPhong.DataSource = ds.Tables[0];
            GcbbSoPhong.DisplayMember = "SoPhong"; // hiện số phòng
            GcbbSoPhong.ValueMember = "MaPhong";  // mã phòng 
        }
        
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (e.RowIndex < 0 || idKhachHienTai == -1) return;

                    int idDichVu = Convert.ToInt32(
                        DataGridView1.Rows[e.RowIndex].Cells["IdDichVu"].Value);

                    decimal donGia = Convert.ToDecimal(
                        DataGridView1.Rows[e.RowIndex].Cells["DonGia"].Value);

                    query = @"
                SELECT Id 
                FROM DichVuKhach
                WHERE IdKhach = " + idKhachHienTai +
                        " AND IdDichVu = " + idDichVu;

                    DataSet ds = fn.getData(query);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        query = @"
            UPDATE DichVuKhach
            SET SoLuong = SoLuong + 1
            WHERE IdKhach = " + idKhachHienTai +
            " AND IdDichVu = " + idDichVu;
                    }
                    else
                    {
                        query = @"
            INSERT INTO DichVuKhach(IdKhach, IdDichVu, SoLuong, DonGia)
            VALUES(" + idKhachHienTai + "," + idDichVu + ",1," + donGia + ")";
                    }

                    fn.setData(query, "Đã thêm dịch vụ thành công"); 
                    LoadDichVuKhach();
                }
        private void btnTang_Click(object sender, EventArgs e)
                {
            if (DataGridView2.CurrentRow == null) return;

            int id = Convert.ToInt32(DataGridView2.CurrentRow.Cells["Id"].Value);

            query = @"
    UPDATE DichVuKhach
    SET SoLuong = SoLuong + 1
    WHERE Id = " + id;

            fn.setData(query, "Đã tăng số lượng dịch vụ lên 1");
            LoadDichVuKhach();
        }
        private void btnGiam_Click(object sender, EventArgs e)
                {
                    if (DataGridView2.CurrentRow == null) return;

                    int id = Convert.ToInt32(DataGridView2.CurrentRow.Cells["Id"].Value);
                    int soLuong = Convert.ToInt32(DataGridView2.CurrentRow.Cells["SoLuong"].Value);

            if (soLuong <= 1)
                query = "DELETE FROM DichVuKhach WHERE Id = " + id;
            else
                query = @"
        UPDATE DichVuKhach
        SET SoLuong = SoLuong - 1
        WHERE Id = " + id;

            fn.setData(query, "Đã giảm số lượng dịch vụ đi 1");
                    LoadDichVuKhach();
                }


        //=====================================================================
        void LoadDV()
        {
            
            query = "SELECT IdDichVu, TenDichVu, DonGia FROM DichVu";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        

        private void GcbbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GcbbSoPhong.SelectedItem == null)
                return;

            DataRowView row = (DataRowView)GcbbSoPhong.SelectedItem;

            GtxtTenKhach.Text = row["TenKhach"].ToString();
            GtxtSDT.Text = row["SDT"].ToString();


            string maPhong = row["MaPhong"].ToString();

            query = $@"
        SELECT TOP 1 IdKhach 
        FROM DatPhong 
        WHERE MaPhong = '{maPhong}'
          AND TinhTrang IN (N'Đang dùng', N'Chua Thanh Toán')";

            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                idKhachHienTai = Convert.ToInt32(ds.Tables[0].Rows[0]["IdKhach"]);
                LoadDichVuKhach();
            }   
        }

        void LoadDichVuKhach()
            {
            if (idKhachHienTai == -1) return;

            query = @"
        SELECT dvk.Id,
               dv.TenDichVu,
               dvk.SoLuong,
               dvk.DonGia,
               dvk.TongDon
        FROM DichVuKhach dvk
        JOIN DichVu dv ON dvk.IdDichVu = dv.IdDichVu
        WHERE dvk.IdKhach = " + idKhachHienTai;

            DataSet ds = fn.getData(query);
            DataGridView2.DataSource = ds.Tables[0];

            DataGridView2.Columns["DonGia"].HeaderCell.Style.Alignment
                = DataGridViewContentAlignment.MiddleCenter;
            DataGridView2.Columns["TongDon"].HeaderCell.Style.Alignment
                = DataGridViewContentAlignment.MiddleCenter;
            DataGridView2.Columns["SoLuong"].HeaderCell.Style.Alignment
                = DataGridViewContentAlignment.MiddleCenter;

            var center = DataGridViewContentAlignment.MiddleCenter;
            DataGridView2.Columns["SoLuong"].DefaultCellStyle.Alignment = center;
            DataGridView2.Columns["DonGia"].DefaultCellStyle.Alignment = center;
            DataGridView2.Columns["TongDon"].DefaultCellStyle.Alignment = center;

            DataGridView2.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 'VND'";
            DataGridView2.Columns["TongDon"].DefaultCellStyle.Format = "#,##0 'VND'";

            TinhTongTien();
        }

        void TinhTongTien()
        {
            query = "SELECT ISNULL(SUM(TongDon),0) FROM DichVuKhach WHERE IdKhach = " + idKhachHienTai;
            DataSet ds = fn.getData(query);

            decimal tongTien = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            GtxtTongTien.Text = tongTien.ToString("N0") + " VND";
        }

        
    }
}
