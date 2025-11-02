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

namespace he_thong_dien_may
{
    public partial class KhuVuc : Form
    {
        KhuVucBUS khuvucbus = new KhuVucBUS();
        public KhuVuc()
        {
            InitializeComponent();
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            dgvKhuVuc.DataSource = khuvucbus.getAllKhuVuc();
            NhanVienBUS nhanvienbus = new NhanVienBUS();
            cbxQuanLy.DataSource = nhanvienbus.GetAllNhanVienAsTable();
            cbxQuanLy.ValueMember = "MaNV";
            cbxQuanLy.DisplayMember = "TenNV";
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Add khu vuc?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            KhuVucBUS.KhuVuc kv = new KhuVucBUS.KhuVuc();
            //kv.makhu = txtMaKhu.TextButton;
            kv.tenkhu = txtTenKhu.TextButton;
            //kv.nhanvienquanly = txtQuanLy.TextButton;
            khuvucbus.addKhuVuc(kv);
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Update khu vuc?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.No)
            {
                return;
            }
            KhuVucBUS.KhuVuc kv = new KhuVucBUS.KhuVuc();
            kv.makhu = txtMaKhu.TextButton;
            kv.tenkhu = txtTenKhu.TextButton;
            //kv.nhanvienquanly = txtQuanLy.TextButton;
            khuvucbus.updateKhuVuc(kv);
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Delete khu vuc?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.No)
            {
                return;
            }
            khuvucbus.deleteKhuVuc(txtMaKhu.TextButton);
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            KhuVucBUS.KhuVuc kv = new KhuVucBUS.KhuVuc();
            kv.makhu = txtMaKhu.TextButton;
            kv.tenkhu= txtTenKhu.TextButton;
            //kv.nhanvienquanly= txtQuanLy.TextButton;
            dgvKhuVuc.DataSource = khuvucbus.searchKhuVuc(kv);
        }
    }
}
