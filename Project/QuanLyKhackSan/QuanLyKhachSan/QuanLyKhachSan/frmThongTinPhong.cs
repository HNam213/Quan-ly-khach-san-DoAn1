using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmThongTinPhong : Form
    {
        function fn = new function();
        string query;
        public frmThongTinPhong()
        {
            InitializeComponent();
        }

        private void frmThongTinPhong_Load(object sender, EventArgs e)
        {
            LoadPhongCards();
        }
        private void GbtnQuayLai_Click(object sender, EventArgs e)
        {
        this.Hide();
        frmTrangChu f = new frmTrangChu();
        f.Show();
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
        Application.Exit();
        }
        //===============================================================
        private void LoadPhongCards()
        {
            flpPhong.Controls.Clear();

            query = "SELECT * FROM Phong";
            DataSet ds = fn.getData(query);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ThongTinPhong card = new ThongTinPhong();

                card.SoPhongID = row["SoPhong"].ToString();
                card.SoPhong = row["SoPhong"].ToString();
                card.TinhTrang = row["TinhTrang"].ToString();
                card.LoaiPhong = row["LoaiPhong"].ToString();
                card.LoaiGiuong = row["LoaiGiuong"].ToString();

                // Đổi màu
                if (row["TinhTrang"].ToString() == "Ðang dùng")
                    card.BackColor = Color.LightGreen;
                else if (row["TinhTrang"].ToString() == "Chua Thanh Toán")
                    card.BackColor = Color.LightYellow;
                else
                    card.BackColor = Color.LightGray;

                // Load ảnh từ database
                if (row["AnhPhong"] != DBNull.Value)
                {
                    byte[] img = (byte[])row["AnhPhong"];
                    MemoryStream ms = new MemoryStream(img);
                    card.PhongImage = Image.FromStream(ms);
                }

                // BẮT SỰ KIỆN ĐỔI ẢNH
                card.OnChangeImage += (soPhong, imgBytes) =>
                {
                    fn.UpdateAnhPhong(soPhong, imgBytes);
                };

                flpPhong.Controls.Add(card);
            }
        }

        
    }
}
