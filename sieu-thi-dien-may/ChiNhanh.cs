using BUS;
using stdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace he_thong_dien_may
{
    public partial class ChiNhanh : Form
    {
        ChiNhanhBUS chinhanhbus = new ChiNhanhBUS();
        public ChiNhanh()
        {
            InitializeComponent();
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            ChiNhanhBUS.ChiNhanh chinhanh = new ChiNhanhBUS.ChiNhanh();
            //chinhanh.machinhanh = 
            chinhanh.tenchinhanh = txtTenChiNhanh.TextButton;
            chinhanh.diachi = txtDiaChi.TextButton;
            chinhanh.khuvuc = cbxKhuVuc.SelectedValue.ToString();
            chinhanhbus.AddChiNhanh(chinhanh);
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            KhuVucBUS khuvucbus = new KhuVucBUS();
            cbxKhuVuc.DataSource = khuvucbus.getAllKhuVuc();
            cbxKhuVuc.DisplayMember = "tenkhu";
            cbxKhuVuc.ValueMember = "makhu";
            dgvChiNhanh.DataSource = chinhanhbus.GetAllChiNhanhAsTable();
        }

        private void dgvChiNhanh_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPhamTrongChiNhanh sptcnform = new SanPhamTrongChiNhanh(dgvChiNhanh.SelectedRows[0].Cells[0].Value.ToString());
            sptcnform.ShowDialog();
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            dgvChiNhanh.DataSource = chinhanhbus.searchChiNhanh(txtMaChiNhanh.TextButton, txtTenChiNhanh.TextButton);
        }

        private void dgvChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            dgvChiNhanh.DataSource = chinhanhbus.GetAllChiNhanh();
            KhuVucBUS khuvucbus = new KhuVucBUS();
            cbxKhuVuc.DataSource = khuvucbus.getAllKhuVuc();
        }
    }
}
