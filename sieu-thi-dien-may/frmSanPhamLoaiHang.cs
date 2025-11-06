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
	public partial class frmSanPhamLoaiHang : Form
	{
		public frmSanPhamLoaiHang()
		{
			InitializeComponent();
		}
		SanPhamLoaiHangBUS bus = new SanPhamLoaiHangBUS();

		public void loadData()
		{
			dgvSanPhamLoaiHang.DataSource = bus.GetAllSanPhamLoaiHang();
		}
		public void loadLoaiHang()
		{
			//load nha san xuat
			LoaiHangBUS busNhaSX = new LoaiHangBUS();
			cboLoaiHang.DataSource = busNhaSX.GetAllLoaiHang();
			cboLoaiHang.DisplayMember = "ten_loai_hang";
			cboLoaiHang.ValueMember = "ma_loai_hang";
			cboLoaiHang.SelectedIndex = 0;
		}
		public void loadSanPham()
		{
			//load nha san xuat
			SanPhamBUS busNhaSX = new SanPhamBUS();
			cboSanPham.DataSource = busNhaSX.GetAllSanPhamAsTable();
			cboSanPham.DisplayMember = "ten_san_pham";
			cboSanPham.ValueMember = "ma_san_pham";
			cboSanPham.SelectedIndex = 0;
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

		private void frmSanPhamLoaiHang_Load(object sender, EventArgs e)
		{
			dgvSanPhamLoaiHang.AutoGenerateColumns = false;

			dgvSanPhamLoaiHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã sản phẩm",
				DataPropertyName = "ma_san_pham",
				Width = 100
			});

			dgvSanPhamLoaiHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã loại hàng",
				DataPropertyName = "ma_loai_hang",
				Width = 200
			});

			loadData();
			loadLoaiHang();
			loadSanPham();
		}

		private void dgvSanPham_Click(object sender, EventArgs e)
		{
			try
			{
				int line = dgvSanPhamLoaiHang.CurrentCell.RowIndex;

				cboSanPham.SelectedValue = dgvSanPhamLoaiHang.Rows[line].Cells[0].Value.ToString();
				cboLoaiHang.SelectedValue = dgvSanPhamLoaiHang.Rows[line].Cells[1].Value.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			SanPhamLoaiHangBUS bus = new SanPhamLoaiHangBUS();
			
			MessageBox.Show("Vui lòng nhập dữ liệu vào các ô trống");			
			bus.AddSanPhamLoaiHang(cboLoaiHang.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString());
			loadData();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			cboSanPham.SelectedIndex = 0;
			cboLoaiHang.SelectedIndex = 0;
		}

		private void dgvSanPhamLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvSanPhamLoaiHang.CurrentCell.RowIndex;
				if (dgvSanPhamLoaiHang.Rows[line].Cells[0].Value != DBNull.Value)
				{
					cboLoaiHang.SelectedValue = dgvSanPhamLoaiHang.Rows[line].Cells[0].Value.ToString();
					cboSanPham.SelectedValue = dgvSanPhamLoaiHang.Rows[line].Cells[1].Value.ToString();
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}
	}
}
