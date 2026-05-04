using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmThemPhong : Form
    {
        function fn = new function();
        string query;
        string conn;
        public frmThemPhong()
        {
            InitializeComponent();
        }

        private void frmThemPhong_Load(object sender, EventArgs e)
        {
            LoadPhong();
            //DataGridView1.RowTemplate.Height = 80;

            //DataGridViewImageColumn imgCol =
            //    (DataGridViewImageColumn)DataGridView1.Columns["AnhPhong"];

            //imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //imgCol.Width = 120;

        }
        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
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

        private void GbtnThemPhong_Click(object sender, EventArgs e)
        {
            if (GtxtSoPhong.Text != "" && GtxtLoaiPhong.Text != "" && GtxtLoaiGiuong.Text != "" && GtxtGiaPhong.Text != "")
            {
               String SoPhong = GtxtSoPhong.Text;
               String LoaiPhong = GtxtLoaiPhong.Text;
               String LoaiGiuong = GtxtLoaiGiuong.Text;
               Int64 GiaPhong = Int64.Parse(GtxtGiaPhong.Text);

                query = "insert into Phong(SoPhong, LoaiPhong, LoaiGiuong, GiaPhong) values" +
                    "(N'" + SoPhong + "', N'" + LoaiPhong + "', N'" + LoaiGiuong + "', " + GiaPhong + ")";
                fn.setData(query, "Thêm phòng thành công.");


                frmThemPhong_Load(this, null);
                clearAll();
            }
            else
            {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void GbtnUpdate_Click(object sender, EventArgs e)
        {
            string queryCheck = "SELECT TinhTrang FROM Phong WHERE MaPhong = '" + GtxtMaPhong.Text + "'";
            DataSet ds = fn.getData(queryCheck);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng!");
                return;
            }

            string tinhTrang = ds.Tables[0].Rows[0]["TinhTrang"].ToString().Trim();

            if (tinhTrang != "NO")
            {
                MessageBox.Show(
                    "Phòng đang sử dụng hoặc chưa thanh toán,\nkhông thể cập nhật!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string queryUpdate =
                "UPDATE Phong SET " +
                "SoPhong = N'" + GtxtSoPhong.Text + "', " +
                "LoaiPhong = N'" + GtxtLoaiPhong.Text + "', " +
                "LoaiGiuong = N'" + GtxtLoaiGiuong.Text + "', " +
                "GiaPhong = " + GtxtGiaPhong.Text +
                " WHERE MaPhong = '" + GtxtMaPhong.Text + "'";
            fn.setData(queryUpdate, "Cập nhật phòng thành công");
            LoadPhong();
            clearAll();
        }

        

        private void GbtnDelete_Click(object sender, EventArgs e)
        {
            if (GtxtMaPhong.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn Xóa Phòng Này không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string queryCheck = "SELECT TinhTrang FROM Phong WHERE MaPhong = " + GtxtMaPhong.Text;
                    DataSet ds = fn.getData(queryCheck);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string tinhTrang = ds.Tables[0].Rows[0]["TinhTrang"].ToString().Trim();

                        if (tinhTrang == "Đang dùng")
                        {
                            MessageBox.Show(
                                "Phòng đang sử dụng, không thể xóa!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    query = "delete from Phong where MaPhong = " + GtxtMaPhong.Text + "";
                    fn.setData(query, "Xóa phòng " + GtxtSoPhong + " Thành công.");
                    LoadPhong();
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng muốn xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
        
        //==================================================================================================
        public void clearAll()
        {
            GtxtSoPhong.Clear();
            GtxtLoaiPhong.SelectedIndex = -1;
            GtxtLoaiGiuong.SelectedIndex = -1;
            GtxtGiaPhong.Clear();
            GtxtMaPhong.Clear();
        }

        void LoadPhong()
        {
            query = "select MaPhong, SoPhong, LoaiPhong, LoaiGiuong, GiaPhong, TinhTrang from Phong";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                GtxtMaPhong.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                GtxtSoPhong.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                GtxtLoaiPhong.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                GtxtLoaiGiuong.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                GtxtGiaPhong.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
            else
            {
                MessageBox.Show("Không có phòng cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
    