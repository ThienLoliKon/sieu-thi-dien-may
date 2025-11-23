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
        private string namenv;
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
            if (CheckTestCase.checkChiChuaSo(txtSucChua.TextButton) == false)
            {
                MessageBox.Show("Suc chua phai la chuoi so"); return;
            }
            if (CheckTestCase.checkKhoangTrang(txtTenKho.TextButton, txtDiaChi.TextButton, txtQuanLy.TextButton, txtSucChua.TextButton) == false)
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
            MessageBox.Show("Them thanh cong");
        }
        private bool checkLenghtAllFieldsKhoTong()
        {
            if (CheckTestCase.checkLenghtChuoi(txtTenKho.TextButton, 50) == false)
            {
                MessageBox.Show("Ten kho khong vuot qua 50 ki tu!");
                return false;
            }
            if (CheckTestCase.checkLenghtChuoi(txtDiaChi.TextButton, 50) == false)
            {
                MessageBox.Show("Dia chi kho khong vuot qua 50 ki tu!"); return false;
            }
            //if (CheckTestCase.checkLenghtChuoi(txtQuanLy.TextButton, 10, 10) == false)
            //{
            //    MessageBox.Show("Ma nhan vien quan ly phai co 10 ki tu!"); return false;
            //}
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
            resetAllFields();
        }

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            
            if(checkLenghtAllFieldsKhoTong() == false)
            {
                return;
            }
            if(CheckTestCase.checkKhoangTrang(txtTenKho.TextButton, txtDiaChi.TextButton, txtQuanLy.TextButton, txtSucChua.TextButton) == false)
            {
                MessageBox.Show("Khong duoc nhap khoang trang"); return;
            }
            if (CheckTestCase.checkChiChuaSo(txtSucChua.TextButton) == false)
            {
                MessageBox.Show("Suc chua phai la chuoi so"); return;
            }
            var item = createKhoTongItem();
            //item.makho = dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString();
            khotongbus.updateKhoTong(item);
            MessageBox.Show("Cap nhat thanh cong");
        }
        private KhoTongBUS.KhoTong createKhoTongItem()
        {
            KhoTongBUS.KhoTong kt = new KhoTongBUS.KhoTong()
            {
                makho = dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString(),
                tenkho = txtTenKho.TextButton,
                diachi = txtDiaChi.TextButton,
                quanly = txtQuanLy.TextButton,
                succhua = double.Parse(txtSucChua.TextButton)
            };
            return kt;
        }

        private void cyberButton7_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon xoa kho tong nay khong?", "Xac nhan", MessageBoxButtons.YesNo);
            if (rs == DialogResult.No)
            {
                return;
            }
            try
            {
                khotongbus.xoaKhoTong(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
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
            SanPhamTrongKhoTong sptkt = new SanPhamTrongKhoTong(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
            if (sptkt != null)
            {
                sptkt.ShowDialog();
            }
            //SanPhamTrongKhoTong sptkt = new SanPhamTrongKhoTong(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
            //if (sptkt != null)
            //{
            //    sptkt.ShowDialog();
            //}

        }

        private void lblDanhSachTrong_Click(object sender, EventArgs e)
        {

        }

        private void cyberButton3_Click(object sender, EventArgs e)
        {
            dgvKhoTong.DataSource = khotongbus.searchAllKhoTong(txtMaKho.TextButton, txtTenKho.TextButton);
        }

        private void cyberButton8_Click_1(object sender, EventArgs e)
        {
            PhieuXuatKho pxk = new PhieuXuatKho(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
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
            NhanVienBUS nvbus = new NhanVienBUS();
            txtTenKho.TextButton = dgvKhoTong.SelectedRows[0].Cells[1].Value.ToString();
            txtDiaChi.TextButton = dgvKhoTong.SelectedRows[0].Cells[2].Value.ToString();
            txtQuanLy.TextButton = dgvKhoTong.SelectedRows[0].Cells[3].Value.ToString();
            txtSucChua.TextButton = dgvKhoTong.SelectedRows[0].Cells[4].Value.ToString();
            txtTenQuanLy.TextButton = nvbus.getNameNV(txtQuanLy.TextButton);
        }

        private void dgvKhoTong_SelectionChanged(object sender, EventArgs e)
        {
            selectGridXuatNhap();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());return;
            string makhonhap = dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString();
            PhieuNhapKho pnk = new PhieuNhapKho(makhonhap);
            pnk.ShowDialog();
        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtQuanLy_Leave(object sender, EventArgs e)
        {
            //NhanVienBUS nvbus = new NhanVienBUS();
            //string gettennv = nvbus.getNameNV(txtQuanLy.TextButton);
            //if (gettennv == null)
            //{
            //    MessageBox.Show("Ma nhan vien khong ton tai!");
            //    txtQuanLy.TextButton = "";
            //    txtQuanLy.Focus();
            //}
            //else
            //{
            //    namenv = nvbus.getNameNV(txtQuanLy.TextButton);
            //    txtTenQuanLy.TextButton = namenv;
            //}
        }

        private void txtTenQuanLy_Click(object sender, EventArgs e)
        {
            NhanVienBUS nvbus = new NhanVienBUS();
            string gettennv = nvbus.getNameNV(txtQuanLy.TextButton);
            if (gettennv == null)
            {
                MessageBox.Show("Ma nhan vien khong ton tai!");
                txtQuanLy.TextButton = "";
                txtQuanLy.Focus();
            }
            else
            {
                namenv = nvbus.getNameNV(txtQuanLy.TextButton);
                txtTenQuanLy.TextButton = namenv;
            }
            txtTenQuanLy.Enabled = false;
        }

        private void txtQuanLy_Click(object sender, EventArgs e)
        {
            txtTenQuanLy.Enabled = true;
            txtTenQuanLy.TextButton = "";
        }

        private void txtQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void dgvKhoTong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVienBUS nvbus = new NhanVienBUS();
            txtTenKho.TextButton = dgvKhoTong.SelectedRows[0].Cells[1].Value.ToString();
            txtDiaChi.TextButton = dgvKhoTong.SelectedRows[0].Cells[2].Value.ToString();
            txtQuanLy.TextButton = dgvKhoTong.SelectedRows[0].Cells[3].Value.ToString();
            txtSucChua.TextButton = dgvKhoTong.SelectedRows[0].Cells[4].Value.ToString();
            txtTenQuanLy.TextButton = nvbus.getNameNV(txtQuanLy.TextButton);
        }
        private void resetAllFields()
        {
            txtMaKho.TextButton = "";
            txtTenKho.TextButton = "";
            txtDiaChi.TextButton = "";
            txtQuanLy.TextButton = "";
            txtTenQuanLy.TextButton = "";
            txtSucChua.TextButton = "";
        }

        private void cyberButton6_Click(object sender, EventArgs e)
        {
            frmRPSanPhamTrongKhoTong rptkhotong = new frmRPSanPhamTrongKhoTong(dgvKhoTong.SelectedRows[0].Cells[0].Value.ToString());
            rptkhotong.ShowDialog();
            
        }


    }
}
