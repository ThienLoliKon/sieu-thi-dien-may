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
            NhanVienBUS bus = new NhanVienBUS();
			Form f = new frmMainMenu();
            TaiKhoanBUS.currentUserMaNV = txtMaNV.TextButton+"     ";
            TaiKhoanBUS.currentChiNhanh = bus.timChiNhanhByMaNhanVien(txtMaNV.TextButton);
			TaiKhoanBUS.currentUserQuyen = bus.timQuyenByMaNhanVien(txtMaNV.TextButton);

			MessageBox.Show("Đăng nhập thành công!"); 
            MessageBox.Show("Chi nhánh : "+ TaiKhoanBUS.currentChiNhanh);
            MessageBox.Show("Mã nhân viên : " + TaiKhoanBUS.currentUserMaNV);
            MessageBox.Show("Quyền : " + TaiKhoanBUS.currentUserQuyen);
			f.Show();
            this.Hide();
        }
    }
}
