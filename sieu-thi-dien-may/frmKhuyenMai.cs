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
	public partial class frmKhuyenMai : Form
	{
		public frmKhuyenMai()
		{
			InitializeComponent();
		}
		KhuyenMaiBUS bus = new KhuyenMaiBUS();
		BindingSource bs = new BindingSource(); // <-- THÊM DÒNG NÀY

		public void loadData()
		{
			bs.DataSource = bus.GetAllKhuyenMaiAsTable();
			dgvKhuyenMai.DataSource = bs;
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
		public void loadLoaiHang()
		{
			//load nha cung cap
			LoaiHangBUS busNhaCC = new LoaiHangBUS();
			cboLoaiHang.DataSource = busNhaCC.GetAllLoaiHang();
			cboLoaiHang.DisplayMember = "ten_loai_hang";
			cboLoaiHang.ValueMember = "ma_loai_hang";
			cboLoaiHang.SelectedIndex = 0;
		}
		private void frmKhuyenMai_Load(object sender, EventArgs e)
		{
			dgvKhuyenMai.AutoGenerateColumns = false;
			dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã khuyến mãi",
				DataPropertyName = "ma_khuyen_mai",
				Width = 100
			});

			dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Giảm giá",
				DataPropertyName = "giam_gia",
				Width = 200
			});

			dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã loại hàng",
				DataPropertyName = "ma_loai_hang",
				Width = 100
			});

			dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày bắt đầu",
				DataPropertyName = "ngay_bat_dau",
				Width = 100
			});

			dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Ngày kết thúc",
				DataPropertyName = "ngay_ket_thuc",
				Width = 100
			});
			loadData();
			loadLoaiHang();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			KhuyenMaiBUS bus = new KhuyenMaiBUS();
			if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.AddKhuyenMai(txtGiamGia.Text, cboLoaiHang.SelectedValue.ToString(), dtpNgayBatDau.Value,dtpNgayKetThuc.Value) == false)
				{
					MessageBox.Show("Thêm khuyến mãi thành công!");
				}
				else
				{
					MessageBox.Show("Thêm khuyến mãi thất bại!");
				}
			}
			loadData();
		}
		private bool checkDuLieuNhap()
		{
			// Xóa hết lỗi ❗ cũ trước khi kiểm tra
			errorProvider1.Clear();
			bool coLoi = false;
			// 1. Kiểm tra rỗng
			if (CheckTestCase.checkKhoangTrang(txtGiamGia.Text) == false)
			{
				errorProvider1.SetError(txtGiamGia, "Giảm giá không được trống!");
				coLoi = true;
			}

			if (coLoi == false) // Nếu đã qua được hết check rỗng
			{
				
				if (CheckTestCase.checkKieuFloat(txtGiamGia.Text,100) == false)
				{
					errorProvider1.SetError(txtGiamGia, "giảm giá phải là số (ví dụ: 0.5) và nhỏ hơn 100!");
					coLoi = true;
				}
			}
			//4. Kiểm tra ComboBox
			if (cboLoaiHang.SelectedIndex == -1 || cboLoaiHang.SelectedValue == null)
			{
				errorProvider1.SetError(cboLoaiHang, "Vui lòng chọn loại hàng được giảm giá!");
				coLoi = true;
			}
			return !coLoi; // Trả về true (Không có lỗi) nếu coLoi = false

		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(txtMaKhuyenMai.Text) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.UpdateKhuyenMai(txtMaKhuyenMai.Text, txtGiamGia.Text, cboLoaiHang.SelectedValue.ToString(), dtpNgayBatDau.Value, dtpNgayKetThuc.Value) == false)
				{
					MessageBox.Show("Sửa khuyến mãi thành công!");
				}
				else
				{
					MessageBox.Show("Sửa Khuyến mãi thất bại!");
				}
			}
			loadData();
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			txtGiamGia.Text = "";
			txtMaKhuyenMai.Text = "";
		}

		private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvKhuyenMai.CurrentCell.RowIndex;
				if (dgvKhuyenMai.Rows[line].Cells[0].Value != DBNull.Value)
				{
					txtMaKhuyenMai.Text = dgvKhuyenMai.Rows[line].Cells[0].Value.ToString();
					txtGiamGia.Text = dgvKhuyenMai.Rows[line].Cells[1].Value.ToString();
					cboLoaiHang.SelectedValue = dgvKhuyenMai.Rows[line].Cells[2].Value.ToString();
					dtpNgayBatDau.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[line].Cells[3].Value); 
					dtpNgayKetThuc.Value = Convert.ToDateTime(dgvKhuyenMai.Rows[line].Cells[4].Value);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}
	}
}
