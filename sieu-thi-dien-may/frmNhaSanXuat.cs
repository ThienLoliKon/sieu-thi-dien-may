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

		private void btnThem_Click(object sender, EventArgs e)
		{
			NhaSXBUS bus = new NhaSXBUS();
			bus.AddNhaSanXuat(txtTenNSX.Text, txtDiaChiNXS.Text);
			loadData();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
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
	}
}
