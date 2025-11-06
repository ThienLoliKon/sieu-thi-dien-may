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
	public partial class frmChiTietHoaDon : Form
	{
		public frmChiTietHoaDon()
		{
			InitializeComponent();
		}

		private void foreverForm1_Click(object sender, EventArgs e)
		{

		}

        private void btnThoat_Click(object sender, EventArgs e)
        {
			DialogResult rs = MessageBox.Show("Are you sure to exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rs == DialogResult.No)
			{
				return;
			}
			this.Close();
		}
    }
}
