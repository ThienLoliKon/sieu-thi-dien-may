using BUS;
using BUSs;
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
	public partial class frmBaoHanh : Form
	{
		public frmBaoHanh()
		{
			InitializeComponent();
		}
		BaoHanhBUS bus = new BaoHanhBUS();
		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void loadKhachHang()
		{
			KhachHangBUS busNhaSX = new KhachHangBUS();
			cboMaKhachHang.DataSource = busNhaSX.GetAllKhachHang();
			cboMaKhachHang.DisplayMember = "ho_ten_khach_hang";
			cboMaKhachHang.ValueMember = "ma_khach_hang";
		}
		
		public void loadKNhanVien()
		{
			NhanVienBUS busKH = new NhanVienBUS();
			cboMaNhanVien.DataSource = busKH.GetAllNhanVienAsTable();
			cboMaNhanVien.DisplayMember = "ho_va_ten";
			cboMaNhanVien.ValueMember = "ma_nhan_vien";
		}
		
		public void loadData()
		{
			dgvBaoHanh.DataSource = bus.GetAllBaoHanhAsTable();
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{

		}

		private void btnSua_Click(object sender, EventArgs e)
		{

		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			BaoHanhBUS bus = new BaoHanhBUS();
			bool hoanThanh = true;
			if (chkHoanThanh.Checked == true)
			{
				hoanThanh = true;
			}
			else
			{
				hoanThanh = false;
			}
			bus.AddBaoHanh(cboMaKhachHang.SelectedValue.ToString(), cboMaNhanVien.SelectedValue.ToString(), rtxtLyDo.Text, txtGiaTien.Text,dtpNgayGui.Value,dtpNgayXong.Value,hoanThanh);
			loadData();
		}

		private void frmBaoHanh_Load(object sender, EventArgs e)
		{
			dgvBaoHanh.AutoGenerateColumns = false;

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã bảo hành",
				DataPropertyName = "ma_bao_hanh",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã sản phẩm",
				DataPropertyName = "ma_san_pham",
				Width = 200
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khách hàng",
				DataPropertyName = "ma_khach_hang",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "nhân viên bảo hành",
				DataPropertyName = "nhan_vien_bao_hanh",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "lý do",
				DataPropertyName = "ly_do",
				Width = 100
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "ngà gửi",
				DataPropertyName = "ngay_gui",
				Width = 300
			});

			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày xong",
				DataPropertyName = "ngay_xong",
				Width = 200
			}); 
			dgvBaoHanh.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "hoàn thành",
				DataPropertyName = "hoan_thanh",
				Width = 200
			});
			loadData();
			loadKhachHang();
			loadKNhanVien();
		}

		private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvBaoHanh.CurrentCell.RowIndex;

				txtMaBaoHanh.Text = dgvBaoHanh.Rows[line].Cells[0].Value.ToString();
				cboMaSanPham.SelectedValue = dgvBaoHanh.Rows[line].Cells[1].Value.ToString();
				cboMaKhachHang.SelectedValue = dgvBaoHanh.Rows[line].Cells[2].Value.ToString();
				cboMaNhanVien.SelectedValue = dgvBaoHanh.Rows[line].Cells[3].Value.ToString();
				rtxtLyDo.Text = dgvBaoHanh.Rows[line].Cells[4].Value.ToString();
				dtpNgayGui.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[5].Value);
				dtpNgayXong.Value = Convert.ToDateTime(dgvBaoHanh.Rows[line].Cells[6].Value);
				chkHoanThanh.Checked = Convert.ToBoolean(dgvBaoHanh.Rows[line].Cells[7].Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

	}
}
