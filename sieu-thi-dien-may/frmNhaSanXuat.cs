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
	public partial class frmNhaSanXuat : Form
	{
		public frmNhaSanXuat()
		{
			InitializeComponent();
		}
		NhaSXBUS bus = new NhaSXBUS();

		private void btnThoat_Click(object sender, EventArgs e)
        {
			this.Close();
        }

		public void loadData()
		{
			dgvNhaSanXuat.DataSource = bus.GetAllNhaCungCapAsTable();
		}

		private void frmNhaSanXuat_Load(object sender, EventArgs e)
		{// Đặt font cho tiêu đề (ví dụ: Tahoma, 12, In đậm)
			dgvNhaSanXuat.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12f, FontStyle.Bold);
			// Đặt font cho nội dung (ví dụ: Tahoma, 11, Thường)
			dgvNhaSanXuat.DefaultCellStyle.Font = new Font("Tahoma", 11f, FontStyle.Regular);
			dgvNhaSanXuat.AutoGenerateColumns = false;

			dgvNhaSanXuat.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà sản xuất",
				DataPropertyName = "ma_nha_san_xuat",
				Width = 300
			}); 

			dgvNhaSanXuat.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Tên nhà sản xuất",
				DataPropertyName = "ten_nha_san_xuat",
				Width = 400
			});

			dgvNhaSanXuat.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "địa chỉ nhà sản xuất",
				DataPropertyName = "dia_chi_nha_san_xuat",
				Width = 800
			});
			dgvNhaSanXuat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);


			loadData();

		}
		private bool checkDuLieuNhap()
		{
			errorProvider1.Clear();
			bool coLoi = false;
			// 1. Kiểm tra rỗng
			if (CheckTestCase.checkKhoangTrang(txtTenNSX.Text) == false)
			{
				errorProvider1.SetError(txtTenNSX, "Tên nhà sản xuất không được trống!");
				coLoi = true;
			}
			if (CheckTestCase.checkKhoangTrang(txtDiaChiNXS.Text) == false)
			{
				errorProvider1.SetError(txtDiaChiNXS, "Địa chỉ nhà sản xuất không được trống!");
				coLoi = true;
			}
			// 2. Kiểm tra độ dài
			if (CheckTestCase.checkLenghtChuoi(txtTenNSX.Text, 50) == false)
			{
				errorProvider1.SetError(txtTenNSX, "Tên nhà sản xuất không được quá 50 kí tự!");
				coLoi = true;
			}
			if (CheckTestCase.checkLenghtChuoi(txtDiaChiNXS.Text, 100) == false)
			{
				errorProvider1.SetError(txtDiaChiNXS, "Địa chỉ nhà sản xuất không được quá 100 kí tự!");
				coLoi = true;
			}
			return !coLoi; // Trả về true (Không có lỗi) nếu coLoi = false
		}
		private void btnThem_Click(object sender, EventArgs e)
		{			
			NhaSXBUS bus = new NhaSXBUS();
			if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.AddNhaSanXuat(txtTenNSX.Text, txtDiaChiNXS.Text) == false)
				{
					MessageBox.Show("Thêm nhà sản xuất thành công!");
				}
				else
				{
					MessageBox.Show("Thêm nhà sản xuất thất bại!");
				}
			}
			loadData();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (CheckTestCase.checkKhoangTrang(txtTenNSX.Text) == false)
			{
				MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa");
				return;
			}
			else if (checkDuLieuNhap() == false)
			{
			}
			else
			{
				if (bus.UpdateNhaSanXuat(txtMaNSX.Text, txtTenNSX.Text, txtDiaChiNXS.Text) == false)
				{
					MessageBox.Show("Sửa sản phẩm thành công!");
				}
				else
				{
					MessageBox.Show("Sửa sản phẩm thất bại!");
				}
			}
			bus.UpdateNhaSanXuat(txtMaNSX.Text, txtTenNSX.Text, txtDiaChiNXS.Text);
			loadData();
		}

		private void dgvNhaSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvNhaSanXuat.CurrentCell.RowIndex;

				txtMaNSX.Text = dgvNhaSanXuat.Rows[line].Cells[0].Value.ToString();
				txtTenNSX.Text = dgvNhaSanXuat.Rows[line].Cells[1].Value.ToString();
				txtDiaChiNXS.Text = dgvNhaSanXuat.Rows[line].Cells[2].Value.ToString();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			txtDiaChiNXS.Text = "";
			txtMaNSX.Text = "";
			txtTenNSX.Text = "";
		}
	}
}
