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
    public partial class frmMayTinh : Form
    {
        double so1 = 0;
        double so2 = 0;
        string phepToan = "";
        bool nhapMoi = false;
        public frmMayTinh()
        {
            InitializeComponent();
        }
        private void GbtnSo_Click(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            if (btn == null) return;

            if (nhapMoi)
            {
                GtxtKetQua.Text = "";
                nhapMoi = false;
            }

            GtxtKetQua.Text += btn.Text;
        }

        private void GbtnCong_Click(object sender, EventArgs e)
        {
            so1 = double.Parse(GtxtKetQua.Text);
            phepToan = "+";
            nhapMoi = true;
        }

        private void GbtnTru_Click(object sender, EventArgs e)
        {
            so1 = double.Parse(GtxtKetQua.Text);
            phepToan = "-";
            nhapMoi = true;
        }

        private void GbtnNhan_Click(object sender, EventArgs e)
        {
            so1 = double.Parse(GtxtKetQua.Text);
            phepToan = "*";
            nhapMoi = true;
        }

        private void GbtnChia_Click(object sender, EventArgs e)
        {
            so1 = double.Parse(GtxtKetQua.Text);
            phepToan = "/";
            nhapMoi = true;
        }

        private void GbtnBang_Click(object sender, EventArgs e)
        {
            so2 = double.Parse(GtxtKetQua.Text);
            double ketQua = 0;

            switch (phepToan)
            {
                case "+":
                    ketQua = so1 + so2;
                    break;
                case "-":
                    ketQua = so1 - so2;
                    break;
                case "*":
                    ketQua = so1 * so2;
                    break;
                case "/":
                    if (so2 == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0");
                        return;
                    }
                    ketQua = so1 / so2;
                    break;
            }

            GtxtKetQua.Text = ketQua.ToString();
            rtbLichSu.AppendText($"{so1} {phepToan} {so2} = {ketQua}\n");
            nhapMoi = true;
        }

        private void GbtnClear_Click(object sender, EventArgs e)
        {
            GtxtKetQua.Text = "";
            so1 = so2 = 0;
            phepToan = "";
            nhapMoi = false;
        }

        private void GbtnExit_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            this.Close();
        }
    }
}
