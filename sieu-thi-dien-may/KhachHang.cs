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
    public partial class KhachHang : Form
    {
        KhachHangBUS khbus = new KhachHangBUS();
        public KhachHang()
        {
            InitializeComponent();
        }

        private void RTKhachHangForm_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton5_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure to exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            Form f = new MenuXuatKhachHang();
            f.ShowDialog();
        }
        //private bool checkInput()
        //{
        //    if(CheckTestCase.checkKhoangTrang(txtTenKH.TextButton, txtSDT.TextButton, txtDiaChi.TextButton) == false)
        //    {
        //        MessageBox.Show("Vui long khong de trong cac truong bat buoc!"); return false;
        //    }
        //}
        private bool checkRange()
        {
            if (CheckTestCase.checkLenghtChuoi(txtTenKH.TextButton, 50) == false)
            {
                MessageBox.Show("Input length of Customer Name is out of range!"); return false;
            }
            if (CheckTestCase.checkLenghtChuoi(txtDiaChi.TextButton, 100) ==  false)
            {
                MessageBox.Show("Input length of Address is out of range!"); return false;
            }
            if (CheckTestCase.checkLenghtChuoi(txtSDT.TextButton, 20, 10))
            {
                MessageBox.Show("Input length of Phone Number is out of range!");return false;
            }
            return true;
        }
        private bool checkKhoangTrang()
        {
            if(CheckTestCase.checkKhoangTrang(txtTenKH.TextButton, txtSDT.TextButton, txtDiaChi.TextButton) == false)
            {
                MessageBox.Show("Please fill in all required fields!"); return false;
            }
            return true;
        }
        private void cyberButton1_Click(object sender, EventArgs e)
        {
            if(checkRange() == false)
            {
                return;
            }
            if (CheckTestCase.checkChuoiSo(txtSDT.TextButton) == false)
            {
                MessageBox.Show("Phone Number must be numeric!"); return;
            }
            if(checkKhoangTrang() == false)
            {
                return;
            }
            DialogResult rs = MessageBox.Show("Are you sure to add?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            KhachHangBUS.KhachHang addkh = new KhachHangBUS.KhachHang();
            addkh.tenkhachhang = txtTenKH.TextButton;
            addkh.sdt = txtSDT.TextButton;
            addkh.diachi = txtDiaChi.TextButton;
            //MessageBox.Show($"{addkh.makhachhang}\n{addkh.tenkhachhang}\n{addkh.sdt}\n{addkh.diachi}\n{addkh.diem}\n{addkh.xephang}");
            if (khbus.addKhachHang(addkh) == 1)
            {
                MessageBox.Show("Them thanh cong!");
                DGVKhachHang.DataSource = khbus.GetAllKhachHang();
            }
            else
            {
                MessageBox.Show("That bai!");
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            XoaAllField();
            DGVKhachHang.DataSource = khbus.GetAllKhachHang();
        }
        private void XoaAllField()
        {
            txtMaKH.TextButton = "";
            txtTenKH.TextButton = "";
            txtSDT.TextButton = "";
            txtDiaChi.TextButton = "";
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            if (checkRange() ==  false)
            {
                return;
            }
            if(CheckTestCase.checkChuoiSo(txtSDT.TextButton) == false)
            {
                MessageBox.Show("Phone Number must be numeric!"); return;
            }
            if(checkKhoangTrang() == false)
            {
                return;
            }
            DialogResult submit = MessageBox.Show("Are you sure to update?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (submit == DialogResult.No)
            {
                return;
            }
            KhachHangBUS.KhachHang updkh = new KhachHangBUS.KhachHang();
            updkh.makhachhang = DGVKhachHang.SelectedRows[0].Cells[0].Value.ToString();
            updkh.tenkhachhang = txtTenKH.TextButton;
            updkh.sdt = txtSDT.TextButton;
            updkh.diachi = txtDiaChi.TextButton;
            //updkh.xephang = txtRank.TextButton;
            //MessageBox.Show($"{addkh.makhachhang}\n{addkh.tenkhachhang}\n{addkh.sdt}\n{addkh.diachi}\n{addkh.diem}\n{addkh.xephang}");
            if (khbus.updateKhachHang(updkh) == 1)
            {
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            DGVKhachHang.DataSource = khbus.searchKhachHang(txtMaKH.TextButton, txtMaKH.TextButton, txtSDT.TextButton);
        }

        private void DGVKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVKhachHang.Rows[e.RowIndex];
                txtMaKH.TextButton = row.Cells[0].Value.ToString();
                txtTenKH.TextButton = row.Cells[1].Value.ToString();
                txtSDT.TextButton = row.Cells[2].Value.ToString();
                txtDiaChi.TextButton = row.Cells[3].Value.ToString();
            }
        }

        private void txtSDT_Load(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtSDT.TextButton) + 1;

            }
            catch (Exception ex)
            {

            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtSDT.TextButton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid phone number!");
                txtSDT.Focus();
            }
        }
    }
}
