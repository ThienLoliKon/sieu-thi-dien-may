using BUS;
using System;
using System.Windows.Forms;

namespace he_thong_dien_may
{
	public partial class frmHoaDon : Form
	{
		public frmHoaDon()
		{
			InitializeComponent();
		}
		HoaDonBUS bus = new HoaDonBUS();
		public void loadData()
		{
			dgvHoaDon.DataSource = bus.GetAllHoaDonAsTable();
		}
		public void loadKhachHang()
		{
			//load nha san xuat
			KhachHangBUS khachHangBUS = new KhachHangBUS();
			cboKhachHang.DataSource = khachHangBUS.GetAllKhachHang();
			cboKhachHang.DisplayMember = "tenkhachhang";
			cboKhachHang.ValueMember = "makhachhang";
			cboKhachHang.SelectedIndex = 0;
		}
		public void loadNhanVienLap()
		{
			//load nha san xuat
			NhanVienBUS NhanVienBUS = new NhanVienBUS();
			cboNhanVienLap.DataSource = NhanVienBUS.GetAllNhanVienAsTable();
			cboNhanVienLap.DisplayMember = "TenNV";
			cboNhanVienLap.ValueMember = "MaNV";
			cboNhanVienLap.SelectedIndex = 0;
		}
		private void btnSuaChiTietHD_Click(object sender, EventArgs e)
		{
			Form f = new frmChiTietHoaDon();
			f.ShowDialog();
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

		private void btnTimKiem_Click(object sender, EventArgs e)
		{

		}

		private void frmHoaDon_Load(object sender, EventArgs e)
		{
			dgvHoaDon.AutoGenerateColumns = false;

			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã hóa đơn",
				DataPropertyName = "ma_hoa_don",
				Width = 150
			});

			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Nhân viên lập",
				DataPropertyName = "ma_nhan_vien_lap",
				Width = 300
			});

			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khách hàng",
				DataPropertyName = "ma_khach_hang",
				Width = 300
			});

			dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày lập",
				DataPropertyName = "ngay_lap",
				Width = 200
			});
			loadData();
			loadKhachHang();
			loadNhanVienLap();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(txtMaHoaDon.Text))
			{
				MessageBox.Show("Vui lòng nhập dữ liệu vào các ô trống");
			}
			bus.AddHoaDon(cboNhanVienLap.SelectedValue.ToString(), cboKhachHang.SelectedValue.ToString());
			loadData();
		}

		private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvHoaDon.CurrentCell.RowIndex;
				txtMaHoaDon.Text = dgvHoaDon.Rows[line].Cells[0].Value.ToString();				
				cboNhanVienLap.SelectedValue = dgvHoaDon.Rows[line].Cells[1].Value.ToString();				
				cboKhachHang.SelectedValue = dgvHoaDon.Rows[line].Cells[2].Value.ToString();
				dtpNgayLap.Value = Convert.ToDateTime(dgvHoaDon.Rows[line].Cells[3].Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}
	}
}
