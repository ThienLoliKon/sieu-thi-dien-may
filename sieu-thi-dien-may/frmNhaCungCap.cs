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
	public partial class frmNhaCungCap : Form
	{
		public frmNhaCungCap()
		{
			InitializeComponent();
		}

		NhaCCBUS bus = new NhaCCBUS();
		BindingSource bsNhaCungCap = new BindingSource(); // <-- THÊM DÒNG NÀY
		public void loadData()
		{
			bsNhaCungCap.DataSource = bus.GetAllNhaCungCapAsTable();
			dgvNhaCungCap.DataSource = bsNhaCungCap; // <-- SỬA DÒNG NÀY
		}
		private void frmNhaCungCap_Load(object sender, EventArgs e)
		{
			dgvNhaCungCap.AutoGenerateColumns = false;

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà cung cấp",
				DataPropertyName = "ma_nha_cung_cap",
				Width = 300
			});

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Tên nhà cung cấp",
				DataPropertyName = "ten_nha_cung_cap",
				Width = 400
			});

			dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã nhà cung cấp",
				DataPropertyName = "dia_chi_nha_cung_cap",
				Width = 800
			});

			loadData();
		}
		private void btnTimKiem_Click(object sender, EventArgs e)
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

		private void btnSua_Click(object sender, EventArgs e)
		{
			bus.UpdateNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text);
			loadData();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			NhaCCBUS bus = new NhaCCBUS();
			if(CheckTestCase.checkKhoangTrang( txtTenNCC.Text, txtDiaChiNCC.Text) == false)
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			bus.AddNhaCungCap(txtTenNCC.Text, txtDiaChiNCC.Text);
			loadData();

		}

		private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvNhaCungCap.CurrentCell.RowIndex;

				txtMaNCC.Text = dgvNhaCungCap.Rows[line].Cells[0].Value.ToString();
				txtTenNCC.Text = dgvNhaCungCap.Rows[line].Cells[1].Value.ToString();
				txtDiaChiNCC.Text = dgvNhaCungCap.Rows[line].Cells[2].Value.ToString();

			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void txtTimKiem_TextChanged(object sender, EventArgs e)
		{
			string keyword = txtTimKiem.Text;

			if (string.IsNullOrEmpty(keyword))
			{
				// Nếu ô tìm kiếm trống, xóa bộ lọc và hiển thị tất cả
				bsNhaCungCap.Filter = null;
			}
			else
			{
				// 2. "Làm sạch" từ khóa để tránh lỗi
				string safeKeyword = keyword.Replace("'", "''");

				// 3. Áp dụng bộ lọc cho BindingSource
				// DataGridView sẽ tự động cập nhật
				bsNhaCungCap.Filter = string.Format(
					"ten_nha_cung_cap LIKE '%{0}%' OR dia_chi_nha_cung_cap LIKE '%{0}%'",
					safeKeyword
				);
			}
		}
	}
}
