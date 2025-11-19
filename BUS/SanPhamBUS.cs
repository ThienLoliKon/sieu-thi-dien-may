using DLL;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class SanPhamBUS
	{
		private SanPhamDLL dal;

		public SanPhamBUS()
		{
			dal = new SanPhamDLL();
		}

		//public List<TacGia> GetAllTacGia()
		//{
		//	return dal.GetAllTacGia();
		//}

		public bool AddSanPham(string tenSanPham, string maNXX, string maNCC, string khoiLuong, string thoiGianBH, string giaTien, DateTime ngaySX)
		{
			san_pham addVariable = new san_pham();

			addVariable.ma_san_pham = dal.TaoMaSanPham();
			addVariable.ten_san_pham = tenSanPham;
			addVariable.ma_nha_san_xuat = maNXX;
			addVariable.ma_nha_cung_cap = maNCC;

			float khoiLuongFloat = float.Parse(khoiLuong);
			addVariable.khoi_luong = khoiLuongFloat; 

			int thoiGianInt = int.Parse(thoiGianBH);
			addVariable.thoi_gian_bao_hanh = thoiGianInt;

			decimal giaTienFloat = decimal.Parse(giaTien);
			addVariable.gia_tien = giaTienFloat;

			addVariable.ngay_san_xuat = ngaySX;

			dal.addSanPham(addVariable);
			if (dal.check(addVariable.ma_san_pham) == true) { return false; }
			return true;
		}
<<<<<<< Updated upstream
		public string getTenSanPham(string masp)
		{
			var x = dal.GetAllSanPham();
			foreach (var item in x)
			{
				if (item.ma_san_pham == masp)
					return item.ten_san_pham;
            }
			return null;
        }
=======

		//public bool DeleteSanPham(string id)
		//{
		//	dal.deleteSanPham(id);
		//	if (dal.check(id) == true) { return false; }
		//	return true;
		//}
>>>>>>> Stashed changes

		//public bool DeleteSanPham(string id)
		//{
		//	dal.deleteSanPham(id);
		//	if (dal.check(id) == true) { return false; }
		//	return true;
		//}

		public bool UpdateSanPham(string maSanPham, string tenSanPham, string maNXX, string maNCC, string khoiLuong,string thoiGianBH, string giaTien, DateTime ngaySX)
		{
			san_pham updateItem = new san_pham();

			updateItem.ma_san_pham = maSanPham;
			updateItem.ten_san_pham = tenSanPham;
			updateItem.ma_nha_san_xuat = maNXX;
			updateItem.ma_nha_cung_cap = maNCC;

			if (float.TryParse(khoiLuong, out float khoiLuongValue))
				updateItem.khoi_luong = khoiLuongValue;
			else
				updateItem.khoi_luong = null; // hoặc xử lý lỗi nhập liệu

			if (int.TryParse(thoiGianBH, out int thoiGianBHValue))
				updateItem.thoi_gian_bao_hanh = thoiGianBHValue;
			else
				updateItem.khoi_luong = null; // hoặc xử lý lỗi nhập liệu

			if (decimal.TryParse(giaTien, out decimal giaTienValue))
				updateItem.gia_tien = giaTienValue;
			else
				updateItem.gia_tien = null; // hoặc xử lý lỗi nhập liệu
			//if (decimal.TryParse(giaTien, out decimal giaTienValue))
				//updateItem.gia_tien = giaTienValue;
			//else
			//	updateItem.gia_tien = null; // hoặc xử lý lỗi nhập liệu

			updateItem.ngay_san_xuat = ngaySX;

			dal.updateSanPham(updateItem);

			if (dal.check(updateItem.ma_san_pham) == true) { return false; }
			return true;
		}

		public decimal layGiaTienSanPhamBangMa(string maSanPham)
		{
			List<san_pham> listData = dal.searchByNameOrID(maSanPham);
			if (listData == null || listData.Count == 0)
			{
				return 0;
			}
			foreach (var indexData in listData)
			{
				return (decimal)indexData.gia_tien;
			}

			return 0;
		}

		public DataTable timSanPham(string keyword)
		{
			List<san_pham> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ten_san_pham", typeof(string));
			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("khoi_luong", typeof(float));
			dt.Columns.Add("gia_tien", typeof(float));
			dt.Columns.Add("ngay_san_xuat", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_cung_cap, indexData.ten_san_pham, indexData.ma_nha_cung_cap, indexData.khoi_luong, indexData.gia_tien, indexData.ngay_san_xuat);
			}

			return dt;
		}

		public DataTable getSanPhamByMaHDAsTable(string keyword)
		{
			List<san_pham> listData = dal.GetSanPhamByMaHD(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ten_san_pham", typeof(string));
			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("khoi_luong", typeof(float));
			dt.Columns.Add("thoi_gian_bao_hanh", typeof(int));
			dt.Columns.Add("gia_tien", typeof(decimal));
			dt.Columns.Add("ngay_san_xuat", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham , indexData.ten_san_pham, indexData.ma_nha_san_xuat , indexData.ma_nha_cung_cap , indexData.khoi_luong, indexData.thoi_gian_bao_hanh, indexData.gia_tien, indexData.ngay_san_xuat);
			}
			return dt;
		}

		public DataTable GetAllSanPhamAsTable()
		{
			List<san_pham> listData = dal.GetAllSanPham(); // Kiểm tra danh sách từ DAL

			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ten_san_pham", typeof(string));
			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("khoi_luong", typeof(float)); 
			dt.Columns.Add("thoi_gian_bao_hanh", typeof(int));
			dt.Columns.Add("gia_tien", typeof(decimal));
			dt.Columns.Add("ngay_san_xuat", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham , indexData.ten_san_pham, indexData.ma_nha_san_xuat , indexData.ma_nha_cung_cap , indexData.khoi_luong, indexData.thoi_gian_bao_hanh, indexData.gia_tien, indexData.ngay_san_xuat);
			}
			return dt;
		}




	}
}
