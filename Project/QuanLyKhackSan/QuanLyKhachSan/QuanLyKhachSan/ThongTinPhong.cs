using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyKhachSan
{
    public partial class ThongTinPhong : UserControl
    {
        public ThongTinPhong()
        {
            InitializeComponent();
        }

        private void ThongTinPhong_Load(object sender, EventArgs e)
        {

        }

        public string SoPhong
        {
            get { return GlblSoPhong.Text; }
            set { GlblSoPhong.Text = "Phòng: " + value; }
        }

        public string TinhTrang
        {
            get { return GlblTinhTrang.Text; }
            set { GlblTinhTrang.Text = "Tình trạng: " + value; }
        }

        public Image PhongImage
        {
            get { return GPictureBox1.Image; }
            set { GPictureBox1.Image = value; }
        }

        public string LoaiPhong
        {
            get { return GlblLoaiPhong.Text; }
            set { GlblLoaiPhong.Text = "Loại phòng: " + value; }
        }

        public string LoaiGiuong
        {
            get { return GlblLoaiGiuong.Text; }
            set { GlblLoaiGiuong.Text = "Loại giường: " + value; }
        }

        public string SoPhongID { get; set; }

        public event Action<string, byte[]> OnChangeImage;

        

        private void GbtnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GPictureBox1.Image = Image.FromFile(ofd.FileName);
                byte[] imgBytes = File.ReadAllBytes(ofd.FileName);

                OnChangeImage?.Invoke(SoPhongID, imgBytes);
            }
        }

        
    }
}
