using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class SanPhamLoaiHangBUS
	{
		private SanPhamLoaiHangDLL dal;

		public SanPhamLoaiHangBUS()
		{
			dal = new SanPhamLoaiHangDLL();
		}

		public bool AddSanPhamLoaiHang(string maSanPham,string maLoaiHang)
		{
			san_pham_loai_hang addVariable = new san_pham_loai_hang();
			addVariable.ma_loai_hang = maLoaiHang;
			addVariable.ma_san_pham = maSanPham;
			dal.addSanPhamLoaiHang(addVariable);
			if (dal.check(maSanPham, maLoaiHang) == true) { return false; }
			return true;
		}

		public bool DeleteSanPhamLoaiHang(string maSanPham, string maLoaiHang)
		{
			dal.deleteSanPhamLoaiHang(maSanPham,maLoaiHang);
			if (dal.check(maSanPham,maLoaiHang) == true) { return false; }
			return true;
		}

		public bool UpdateSanPhamLoaiHang(string maSanPham, string maLoaiHang)
		{
			san_pham_loai_hang updateItem = new san_pham_loai_hang();
			updateItem.ma_loai_hang = maLoaiHang;
			updateItem.ma_san_pham = maLoaiHang;
			dal.updateSanPhamLoaiHang(updateItem);
			if (dal.check(updateItem.ma_san_pham,updateItem.ma_loai_hang) == true) { return false; }
			return true;
		}

		public DataTable timSanPhamLoaiHangTheoSanPham(string keyword)
		{
			List<san_pham_loai_hang> listData = dal.searchByNameOrIDLoaiHang(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_loai_hang", typeof(float));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham, indexData.ma_loai_hang);
			}

			return dt;
		}
		public DataTable timSanPhamLoaiHangTheoLoaiHang(string keyword)
		{
			List<san_pham_loai_hang> listData = dal.searchByNameOrIDLoaiHang(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_loai_hang", typeof(float));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham, indexData.ma_loai_hang);
			}

			return dt;
		}
		public DataTable GetAllSanPhamLoaiHang()
		{
			List<san_pham_loai_hang> listData = dal.GetAllSanPhamLoaiHang(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_loai_hang", typeof(string));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham, indexData.ma_loai_hang);
			}
			return dt;
		}
	}
}
