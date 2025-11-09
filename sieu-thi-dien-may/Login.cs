using BUS;
using he_thong_dien_may;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            Form f = new frmMainMenu();
            TaiKhoanBUS.currentUserMaNV = txtMaNV.TextButton;
            f.Show();
            this.Hide();
        }
    }
}
