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
        public SanPhamTrongKhoTong(string makho = "")
        {
            InitializeComponent();
            mk = makho;
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            KhoTongBUS khotongbus = new KhoTongBUS();
            var search = khotongbus.searchKhoTong(txtTimKiem.TextButton);
            if (search != null)
            {
                lblSPTrongChiNhanh.Text = "Sản phẩm trong kho tổng - " + search.tenkho;
            }
            else
            {
                lblSPTrongChiNhanh.Text = "Sản phẩm trong kho tổng - ";
            }
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
            }
        }

        private void SanPhamTrongKhoTong_Load(object sender, EventArgs e)
        {
            lblSPTrongChiNhanh.Text = "Sản phẩm trong kho tổng - " + mk;
        }
    }
}
