using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmCheckIn : Form
    {
        function fn = new function();
        String query;
        int maNV = function.MaNV_DangNhap;
        
        public frmCheckIn()
        {
            InitializeComponent();
        }

       

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Hide();
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void GtxtLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GtxtLoaiGiuong.Text != "")
            {
                GtxtSoPhong.Items.Clear();
                GtxtGiaPhong.Clear();
        query = "select SoPhong from Phong where LoaiGiuong = N'" + GtxtLoaiGiuong.Text + "' " +
                "and LoaiPhong = N'" + GtxtLoaiPhong.Text + "' and TinhTrang = 'NO'";
                setComboBox(query, GtxtSoPhong);
            }
        }

        private void GtxtLoaiGiuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            GtxtLoaiPhong.SelectedIndex = -1;
            GtxtSoPhong.Items.Clear();
            GtxtGiaPhong.Clear();
        }

        int rid;
        private void GtxtSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select GiaPhong,MaPhong from Phong where SoPhong = N'" + GtxtSoPhong.Text + "'";
            DataSet ds = fn.getData(query);
            GtxtGiaPhong.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        

        private void GbtnCheckIn_Click(object sender, EventArgs e)
        {
            if (GtxtTen.Text != "" && GtxtSDT.Text != "" && GtxtQuocTich.Text != "" && GtxtGioiTinh.Text != "" && GtxtSoNguoi.Text != "" && GDTPNgayDat.Text != "" && GtxtCMND.Text != "" && GtxtDiaChi.Text != "" && GDTPCheckIn.Text != "" && GtxtGiaPhong.Text != "")
            {
                
                //Int64 IdKhach = Int64.Parse(GlblMaKH.Text);
                String TenKhach = GtxtTen.Text;
                Int64 SDT = Int64.Parse(GtxtSDT.Text);
                String QuocTich = GtxtQuocTich.Text;
                String GioiTinh = GtxtGioiTinh.Text;
                Int64 SoNguoi = Int64.Parse(GtxtSoNguoi.Text);
                DateTime NgayDat = GDTPNgayDat.Value;
                String CCCD = GtxtCMND.Text;
                String DiaChi = GtxtDiaChi.Text;
                DateTime CheckIn = GDTPCheckIn.Value;

                
              
                query = "insert into Khach(TenKhach, SDT, QuocTich, GioiTinh, SoNguoi, CCCD, DiaChi) values (N'" + TenKhach + "', " + SDT + ", N'" + QuocTich + "', N'" + GioiTinh + "', '" + SoNguoi + "', N'" + CCCD + "', N'" + DiaChi + "'); INSERT INTO DatPhong(NgayDat, Checkin, TinhTrang, MaNV, IdKhach, MaPhong) VALUES (N'" + NgayDat + "', N'" + CheckIn + "', N'Đang dùng', " + maNV + ", "+ rIdK +" ," + rid + "); update Phong set TinhTrang = N'Đang dùng' where SoPhong = '" + GtxtSoPhong.Text + "' ";


                fn.setData(query, "Phòng số " + GtxtSoPhong.Text + " đã được đặt thành công. ");
                ClearAll();
                LayMaxID();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin của khách đăng ký phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            LayMaxID();
            //lấy mã ID khách hàng khi load form
        }


//=====================================================================================
        public void ClearAll()
        {
            GtxtTen.Clear();
            GtxtSDT.Clear();
            GtxtQuocTich.Clear();
            GtxtGioiTinh.SelectedIndex = -1;
            GtxtSoNguoi.Clear();
            GtxtCMND.Clear();
            GtxtDiaChi.Clear();
            GDTPNgayDat.Value = DateTime.Now;
            GDTPCheckIn.Value = DateTime.Now;
            GtxtLoaiGiuong.SelectedIndex = -1;
            GtxtLoaiPhong.SelectedIndex = -1;
            GtxtSoPhong.Items.Clear();
            GtxtGiaPhong.Clear();
        }
        
 
        int rIdK;
        public void LayMaxID()
        {
            query = "Select max(IdKhach) from Khach";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                GlblMaKH.Text = (num + 1).ToString();
            }
            rIdK = int.Parse(GlblMaKH.Text);
        }

    }
}
