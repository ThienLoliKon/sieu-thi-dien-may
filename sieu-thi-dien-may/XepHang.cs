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
    public partial class XepHang : Form
    {
        XepHangBUS xephangbus = new XepHangBUS();
        public XepHang()
        {
            InitializeComponent();
        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XepHang_Load(object sender, EventArgs e)
        {
            dgvRank.DataSource = xephangbus.getAllRank();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvRank.DataSource = xephangbus.getAllRank();
        }
    }
}
