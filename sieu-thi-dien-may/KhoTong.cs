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
    public partial class KhoTong : Form
    {
        KhoTongBUS khotongbus = new KhoTongBUS();
        public KhoTong()
        {
            InitializeComponent();
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cyberButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            bool checkvalid = CheckTestCase.checkKhoangTrang()
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            dgvKhoTong.DataSource = khotongbus.getAllKhoTong();
        }
    }
}
