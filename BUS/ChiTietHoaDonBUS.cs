using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	internal class ChiTietHoaDonBUS
	{
		private ChiTietHoaDonDLL dal;

		public ChiTietHoaDonBUS()
		{
			dal = new ChiTietHoaDonDLL();
		}

		public bool AddChiTietHoaDon(string maHoaDon, string maSanPham, string maKhuyenMai, string soLuong, string donGia, DateTime ngayGioIn)
		{
			chi_tiet_hoa_don addVariable = new chi_tiet_hoa_don();

			addVariable.ma_hoa_don = maHoaDon;
			addVariable.ma_san_pham = maSanPham;
			addVariable.ma_khuyen_mai = maKhuyenMai;
			if (int.TryParse(soLuong, out int soLuongInt))
				addVariable.so_luong = soLuongInt;
			else
				addVariable.so_luong = null; // hoặc xử lý lỗi nhập liệu
			if (Decimal.TryParse(donGia, out decimal donGiaDemical))
				addVariable.don_gia = donGiaDemical;
			else
				addVariable.don_gia = null; // hoặc xử lý lỗi nhập liệu
			addVariable.ngay_gio_in = ngayGioIn;
			dal.addChiTietHoaDon(addVariable);

			if (dal.check(addVariable.ma_hoa_don, addVariable.ma_san_pham) == true) { return false; }
			return true;
		}

		
		public bool DeleteChiTietHoaDon(string maHoaDon, string maSanPham)
		{
			dal.deleteChiTietHoaDon(maHoaDon,maSanPham);
			if (dal.check(maHoaDon,maSanPham) == true) { return false; }
			return true;
		}

		public bool UpdateChiTietHoaDon(string maHoaDon, string maSanPham, string maKhuyenMai, string soLuong, string donGia, DateTime ngayGioIn)
		{
			chi_tiet_hoa_don updateItem = new chi_tiet_hoa_don();

			updateItem.ma_hoa_don = maHoaDon;
			updateItem.ma_san_pham = maSanPham;
			updateItem.ma_khuyen_mai = maKhuyenMai;
			if (int.TryParse(soLuong, out int soLuongInt))
				updateItem.so_luong = soLuongInt;
			else
				updateItem.so_luong = null; // hoặc xử lý lỗi nhập liệu
			if (Decimal.TryParse(donGia, out decimal donGiaDemical))
				updateItem.don_gia = donGiaDemical;
			else
				updateItem.don_gia = null; // hoặc xử lý lỗi nhập liệu
			updateItem.ngay_gio_in = ngayGioIn;
			dal.updateChiTietHoaDon(updateItem);

			if (dal.check(updateItem.ma_hoa_don, updateItem.ma_san_pham) == true) { return false; }
			return true;
		}

		public DataTable timChiTietHoaDon(string keyword)
		{
			List<chi_tiet_hoa_don> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(float));
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("so_luong", typeof(int));
			dt.Columns.Add("don_gia", typeof(decimal)); 
			dt.Columns.Add("ngay_gio", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_san_pham, indexData.ma_khuyen_mai, indexData.so_luong, indexData.don_gia,indexData.ngay_gio_in);
			}

			return dt;
		}

		public DataTable GetAllChiTietHoaDonAsTable()
		{
			List<chi_tiet_hoa_don> listData = dal.GetAllChiTietHoaDon(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(float));
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("so_luong", typeof(int));
			dt.Columns.Add("don_gia", typeof(decimal));
			dt.Columns.Add("ngay_gio", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_san_pham, indexData.ma_khuyen_mai, indexData.so_luong, indexData.don_gia, indexData.ngay_gio_in);
			}
			return dt;
		}

	}
}
