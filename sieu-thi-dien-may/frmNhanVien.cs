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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void foreverForm1_Click(object sender, EventArgs e)
        {

        }

        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void foreverLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            Form f = new frmTaiKhoan();
            f.ShowDialog();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            Form f = new frmLuong();
            f.ShowDialog();
        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThuong_Click(object sender, EventArgs e)
        {
            Form f = new frmThuong();
            f.ShowDialog();
        }

        private void btnViPham_Click(object sender, EventArgs e)
        {
            Form f = new frmViPhamm();
            f.ShowDialog();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            Form f = new frmDiemDanh();
            f.ShowDialog();
        }
    }
}
