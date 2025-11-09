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
            if (CheckTestCase.checkKhoangTrang(txtMaKho.TextButton, txtTenKho.TextButton, txtDiaChi.TextButton, txtQuanLy.TextButton, txtSucChua.TextButton) == false)
            {
                MessageBox.Show("Khong duoc nhap khoang trang"); return;
            }
            if (CheckTestCase.checkChuoiSo(txtSucChua.TextButton) == false)
            {
                MessageBox.Show("Suc chua phai la chuoi so"); return;
            }
            if (checkLenghtAllFieldsKhoTong() == false)
            {
                return;
            }
            khotongbus.addKhoTong(createKhoTongItem());
        }
        private bool checkLenghtAllFieldsKhoTong()
        {
            if (CheckTestCase.checkLenghtChuoi(txtTenKho.TextButton, 50) == false)
            {
                MessageBox.Show("Ten khon khong vuot qua 50 ki tu!");
                return false;
            }
            if (CheckTestCase.checkLenghtChuoi(txtDiaChi.TextButton, 50))
            {
                MessageBox.Show("Dia chi kho khong vuot qua 50 ki tu!"); return false;
            }
            if (CheckTestCase.checkLenghtChuoi(txtQuanLy.TextButton, 10, 10))
            {
                MessageBox.Show("Ma nhan vien quan ly phai co 10 ki tu!"); return false;
            }
            return true;
        }
        private void cyberButton4_Click(object sender, EventArgs e)
        {
            dgvKhoTong.DataSource = khotongbus.getAllKhoTong();
            if (dgvKhoTong.RowCount == 0)
            {
                lblDanhSachTrong.Visible = true;
            }
            else
            {
                lblDanhSachTrong.Visible = false;
            }
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            khotongbus.updateKhoTong(createKhoTongItem());
        }
        private KhoTongBUS.KhoTong createKhoTongItem()
        {
            KhoTongBUS.KhoTong kt = new KhoTongBUS.KhoTong()
            {
                makho = txtMaKho.TextButton,
                tenkho = txtTenKho.TextButton,
                diachi = txtDiaChi.TextButton,
                quanly = txtQuanLy.TextButton,
                succhua = int.Parse(txtSucChua.TextButton)
            };
            return kt;
        }

        private void cyberButton7_Click(object sender, EventArgs e)
        {
            try
            {
                khotongbus.xoaKhoTong(txtMaKho.TextButton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the xoa kho!");
            }
        }

        private void dgvKhoTong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvKhoTong.SelectedRows[0].Cells[0]
            //MessageBox.Show(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
            SanPhamTrongKhoTong sptkt = new SanPhamTrongKhoTong(dgvKhoTong.SelectedRows[0].Cells[1].Value.ToString());
            if (sptkt != null)
            {
                sptkt.ShowDialog();
            }

        }

        private void lblDanhSachTrong_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton8_Click_1(object sender, EventArgs e)
        {
            PhieuXuatKho pxk = new PhieuXuatKho();
            pxk.ShowDialog();
        }
        private void selectGridXuatNhap()
        {
            if (dgvKhoTong.SelectedRows.Count != 0)
            {
                btnXuat.Enabled = true;
                btnNhap.Enabled = true;
            }
            else
            {
                btnXuat.Enabled = false;
                btnNhap.Enabled = false;
            }
        }

        private void dgvKhoTong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhoTong_SelectionChanged(object sender, EventArgs e)
        {
            selectGridXuatNhap();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());return;
            PhieuNhapKho pnk = new PhieuNhapKho(dgvKhoTong.SelectedRows[0].Cells[1].Value.ToString());
            pnk.ShowDialog();
        }
    }
}
