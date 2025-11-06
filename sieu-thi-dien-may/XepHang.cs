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

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            string checkvar = checkValidFields();
            if (checkvar != "")
            {
                MessageBox.Show(checkvar);return;
            }
            DialogResult rs = MessageBox.Show("Are you sure to add new rank?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            try
            {
                XepHangBUS.XepHang addrank = new XepHangBUS.XepHang();
                addrank.mahang = txtMaRank.TextButton;
                addrank.tenhang = txtTenRank.TextButton;
                addrank.yeucau = double.Parse(txtYeuCau.TextButton);
                addrank.uudai = double.Parse(txtUuDai.TextButton);
                if (xephangbus.addRank(addrank) == 1)
                {
                    MessageBox.Show("Add new rank successfully!");
                    dgvRank.DataSource = xephangbus.getAllRank();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input data. Please check again!\n" + ex.Message);
                return;
            }
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            string checkvar = checkValidFields();
            if (checkvar != "")
            {
                MessageBox.Show(checkvar); return;
            }
            DialogResult rs = MessageBox.Show("Delete?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            try
            {
                XepHangBUS.XepHang xephang = new XepHangBUS.XepHang();
                xephang.mahang = txtMaRank.TextButton;
                xephang.tenhang = txtTenRank.TextButton;
                xephang.yeucau = double.Parse(txtYeuCau.TextButton);
                xephang.uudai = double.Parse(txtYeuCau.TextButton);
                if (xephangbus.updateRank(xephang) == 1)
                {
                    MessageBox.Show("Update rank successfully!");
                    dgvRank.DataSource = xephangbus.getAllRank();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input data. Please check again!\n" + ex.Message);
                return;
            }
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            xephangbus.deleteRank(txtMaRank.TextButton);
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {

        }
        private string checkValidFields()
        {
            string noti = "";
            if (txtMaRank.TextButton == "" || txtMaRank.TextButton.Length != 10)
            {
                noti += "Ma hang khong hop le!";
            }
            if (txtTenRank.TextButton == "" || txtTenRank.TextButton.Length > 50)
            {
                noti += "\nTen hang khong hop le";
            }
            try
            {
                double x = double.Parse(txtYeuCau.TextButton) + 1;
            }
            catch (Exception ex)
            {
                noti += "\nSo tien yeu cau khong hop le!";
            }
            try
            {
                double x = double.Parse(txtUuDai.TextButton) + 1;
            }
            catch (Exception ex)
            {
                noti += "\nSo phan tram uu dai khong hop le!";
            }
            return noti;
        }
    }
}
