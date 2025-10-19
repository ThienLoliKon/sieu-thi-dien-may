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
    public partial class MenuKho : Form
    {
        public MenuKho()
        {
            InitializeComponent();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            Form f = new frmRPSanPhamTrongChiNhanh();
            f.ShowDialog();
        }
    }
}
