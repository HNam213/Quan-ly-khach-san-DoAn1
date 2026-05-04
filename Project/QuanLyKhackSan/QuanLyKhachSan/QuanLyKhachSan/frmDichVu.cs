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
    public partial class frmDichVu : Form
    {
        function fn = new function();
        string query;
        string conn;
        public frmDichVu()
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

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadDV();
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

        private void GbtnAdd_Click(object sender, EventArgs e)
        {
            if (GtxtLoaiDV.Text != "" && GtxtMaDV.Text != "" && GtxtTenDV.Text != "" && GtxtDonViDV.Text != "" && GtxtGiaDV.Text != "")
            {
                String LoaiDV = GtxtLoaiDV.Text;
                String MaDV = GtxtMaDV.Text;
                String TenDV = GtxtTenDV.Text;
                String DonViDV = GtxtDonViDV.Text;
                Int64 GiaDV = Int64.Parse(GtxtGiaDV.Text);

                query = "insert into DichVu(MaDV, TenDichVu, LoaiDV, DonVi, DonGia) values" +
                    "(N'" + MaDV + "', N'" + TenDV + "', N'" + LoaiDV + "' ,N'" + DonViDV + "', " + GiaDV + ")";
                fn.setData(query, "Thêm Dịch Vụ thành công.");


                frmDichVu_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Dịch vụ cần thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GbtnUpdate_Click(object sender, EventArgs e)
        {
            

            string queryUpdate =
                "UPDATE DichVu SET " +
                "MaDV = '" + GtxtMaDV.Text + "', " +
                "LoaiDV = N'" + GtxtLoaiDV.Text + "', " +
                "TenDichVu = N'" + GtxtTenDV.Text + "', " +
                "DonGia = " + GtxtGiaDV.Text +
                " WHERE IdDichVu = '" + GlblId.Text + "'";
            fn.setData(queryUpdate, "Cập nhật Dịch Vụ thành công");
            LoadDV();
            clearAll();
        }

        private void GbtnDelete_Click(object sender, EventArgs e)
        {
            if (GlblId.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn Xóa Dịch Vụ Này không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                { 

                    query = "delete from DichVu where IdDichVu = " + GlblId.Text + "";
                    fn.setData(query, "Xóa Dịch Vụ " + GtxtTenDV + " Thành công.");
                    LoadDV();
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng muốn xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GlblId.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                GtxtMaDV.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                GtxtTenDV.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                GtxtLoaiDV.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                GtxtDonViDV.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                GtxtGiaDV.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Không có Dịch Vụ cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GbtnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        //==============================================================================================================

        public void clearAll()
        {
            GlblId.Text = "";
            GtxtLoaiDV.SelectedIndex = -1;
            GtxtMaDV.Clear();
            GtxtTenDV.Clear();
            GtxtDonViDV.Clear();
            GtxtGiaDV.Clear();
            
        }

        
        void LoadDV()
        {
            query = "select IdDichVu, MaDV, TenDichVu, LoaiDV, DonVi, DonGia from DichVu";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
            
        }

        
    }
}
