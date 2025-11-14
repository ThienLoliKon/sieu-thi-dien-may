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
    public partial class SanPhamTrongChiNhanh : Form
    {
        private string macn;
        SanPhamTrongChiNhanhBUS sptcnbus = new SanPhamTrongChiNhanhBUS();
        public SanPhamTrongChiNhanh(string machinhanh = "")
        {
            InitializeComponent();
            this.macn = machinhanh;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvSPTrongChiNhanh.DataSource = sptcnbus.getAllSanPhamTrongChiNhanh(macn);
            if (dgvSPTrongChiNhanh.Rows.Count == 0)
            {
                lblDanhSachTrong.Visible = true;
            }
            else
            {
                lblDanhSachTrong.Visible = false;
            }
        }

        private void SanPhamTrongChiNhanh_Load(object sender, EventArgs e)
        {
            dgvSPTrongChiNhanh.DataSource = sptcnbus.getAllSanPhamTrongChiNhanh(macn);
            lblSPTrongChiNhanh.Text = "Sản phẩm trong chi nhánh " + macn;
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            dgvSPTrongChiNhanh.DataSource = sptcnbus.searchSPTrongChiNhanh(txtTimKiem.TextButton);
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
