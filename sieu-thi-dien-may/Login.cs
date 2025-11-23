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
using System.Xml.Linq;

namespace stdm
{
	public partial class Login : Form
	{
		NhanVienBUS busNV = new NhanVienBUS();
		TaiKhoanBUS bus = new TaiKhoanBUS();
		public Login()
		{
			InitializeComponent();
		}

		public bool checkTaiKhoan()
		{
			if (bus.CheckLogin(txtMaNV.Text, txtMatKhau.Text))
			{
				return true;
			}
			return false;
		}


		private void cyberButton1_Click(object sender, EventArgs e)
		{
			if (checkTaiKhoan() == false)
			
			{			
				MessageBox.Show("Sai tài khoản hoặc mật khẩu! Vui lòng thử lại.");
				return;
			}

			if (busNV.KiemTraNhanVienConLamViec(TaiKhoanBUS.currentUserMaNV) == false)
			{
				MessageBox.Show("Tài khoản này đã bị KHÓA hoặc nhân viên đã nghỉ việc!",
								"Cảnh báo",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				return; // Dừng lại, không cho vào
			}
			Form f = new frmMainMenu();
			TaiKhoanBUS.currentUserMaNV = txtMaNV.Text + "     ";
			TaiKhoanBUS.currentChiNhanh = busNV.timChiNhanhByMaNhanVien(txtMaNV.Text);
			TaiKhoanBUS.currentUserQuyen = busNV.timQuyenByMaNhanVien(txtMaNV.Text);

			//MessageBox.Show("Đăng nhập thành công!"); 
   //         MessageBox.Show("Chi nhánh : "+ TaiKhoanBUS.currentChiNhanh);
   //         MessageBox.Show("Mã nhân viên : " + TaiKhoanBUS.currentUserMaNV);
   //         MessageBox.Show("Quyền : " + TaiKhoanBUS.currentUserQuyen);
			MessageBox.Show("Đăng nhập thành công!");
			f.Show();
			this.Hide();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			ConnectBus.clearConnect();
			frmConnectString frm = new frmConnectString(true);
			frm.ShowDialog();
			this.Hide();
		}


	}
}
