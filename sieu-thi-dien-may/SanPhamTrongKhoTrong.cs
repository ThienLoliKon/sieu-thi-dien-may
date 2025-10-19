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
    public partial class SanPhamTrongKhoTrong : Form
    {
        public SanPhamTrongKhoTrong()
        {
            InitializeComponent();
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            Form f = new MenuKho();
            f.ShowDialog();
        }
    }
}
