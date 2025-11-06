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
	public partial class frmLoaiHang : Form
	{
		public frmLoaiHang()
		{
			InitializeComponent();
		}
		LoaiHangBUS bus = new LoaiHangBUS();

		public void loadData()
		{
			dgvLoaiHang.DataSource = bus.GetAllLoaiHang();
		}
		private void aloneTextBox1_TextChanged(object sender, EventArgs e)
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

		private void btnThem_Click(object sender, EventArgs e)
		{
			if(CheckTestCase.checkKhoangTrang(txtTenLoaiHang.Text, rtxtMoTa.Text) == false)
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào các ô trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
		}

		private void frmLoaiHang_Load(object sender, EventArgs e)
		{

			dgvLoaiHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mã loại hàng",
				DataPropertyName = "ma_loai_hang",
				Width = 100
			});

			dgvLoaiHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Tên loại hàng",
				DataPropertyName = "ten_loai_hang",
				Width = 200
			});

			dgvLoaiHang.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Mô tả",
				DataPropertyName = "mo_ta",
				Width = 100
			});

			
			loadData();

		}

		private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int line = dgvLoaiHang.CurrentCell.RowIndex;

				txtMaLoaiHang.Text = dgvLoaiHang.Rows[line].Cells[0].Value.ToString();
				txtTenLoaiHang.Text = dgvLoaiHang.Rows[line].Cells[1].Value.ToString();
				rtxtMoTa.Text = dgvLoaiHang.Rows[line].Cells[2].Value.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show("loi" + ex);
			}
		}
	}
}
