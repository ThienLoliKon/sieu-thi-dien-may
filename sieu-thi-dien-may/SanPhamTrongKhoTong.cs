using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stdm
{
    public partial class SanPhamTrongKhoTong : Form
    {
        string mk = "";
        SanPhamTrongKhoTongBUS sanphamtrongkhotongbus = new SanPhamTrongKhoTongBUS();
        public SanPhamTrongKhoTong(string makho = "")
        {
            InitializeComponent();
            mk = makho;
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            dgvKhoTong.DataSource = sanphamtrongkhotongbus.searchSPTrongKhoTong(txtTimKiem.TextButton);
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            if (dgvKhoTong.Rows.Count != 0)
            {
                lblDanhSachTrong.Visible = true;
            }
            else
            {
                lblDanhSachTrong.Visible = false;
                dgvKhoTong.DataSource = sanphamtrongkhotongbus.getAllSanPhamTrongKhoTong(this.mk);
            }
        }

        private void SanPhamTrongKhoTong_Load(object sender, EventArgs e)
        {
            lblSPTrongChiNhanh.Text = "Sản phẩm trong kho tổng - " + mk;
            dgvKhoTong.DataSource = sanphamtrongkhotongbus.getAllSanPhamTrongKhoTong(this.mk);
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
