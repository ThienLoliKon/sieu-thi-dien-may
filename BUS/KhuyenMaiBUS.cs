using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class KhuyenMaiBUS
	{
		private KhuyenMaiDLL dal;

		public KhuyenMaiBUS()
		{
			dal = new KhuyenMaiDLL();
		}

		public bool AddKhuyenMai(string giamGia, string maLoaiHang, DateTime ngayBatDau, DateTime ngayKetThuc)
		{
			khuyen_mai addVariable = new khuyen_mai();
			addVariable.ma_khuyen_mai = dal.TaoMaKhuyenMai();
			if (double.TryParse(giamGia, out double giamGiaValue))
				addVariable.giam_gia = giamGiaValue;
			else
				addVariable.giam_gia = null; // or handle invalid input as needed

			addVariable.ma_loai_hang = maLoaiHang;
			addVariable.ngay_bat_dau = ngayBatDau;
			addVariable.ngay_ket_thuc = ngayKetThuc;
			dal.addKhuyenMai(addVariable);
			if (dal.check(addVariable.ma_khuyen_mai) == true) { return false; }
			return true;
		}

		public bool DeleteKhuyenMai(string id)
		{
			dal.deleteKhuyenMai(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateKhuyenMai(string maKhuyenMai, string giamGia, string maLoaiHang, DateTime ngayBatDau, DateTime ngayKetThuc)
		{
			khuyen_mai updateItem = new khuyen_mai();

			updateItem.ma_khuyen_mai = maKhuyenMai;
			updateItem.ma_loai_hang = maLoaiHang;

			if (double.TryParse(giamGia, out double giamGiaValue))
				updateItem.giam_gia = giamGiaValue;
			else
				updateItem.giam_gia = null;

			updateItem.ngay_bat_dau = ngayBatDau;
			updateItem.ngay_ket_thuc = ngayKetThuc;

			dal.updateKhuyenMai(updateItem);

			if (dal.check(updateItem.ma_khuyen_mai) == true) { return false; }
			return true;
		}

		public DataTable timKhuyenMai(string keyword)
		{
			List<khuyen_mai> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("giam_gia", typeof(float));
			dt.Columns.Add("ma_loai_hang", typeof(string));
			dt.Columns.Add("ngay_bat_dau", typeof(DateTime));
			dt.Columns.Add("ngay_ket_thuc", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_khuyen_mai , indexData.giam_gia, indexData.ma_loai_hang , indexData.ngay_bat_dau, indexData.ngay_ket_thuc);
			}

			return dt;
		}

		public DataTable GetAllKhuyenMaiAsTable()
		{
			List<khuyen_mai> listData = dal.GetAllKhuyenMai(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("giam_gia", typeof(float));
			dt.Columns.Add("ma_loai_hang", typeof(string));
			dt.Columns.Add("ngay_bat_dau", typeof(DateTime));
			dt.Columns.Add("ngay_ket_thuc", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_khuyen_mai , indexData.giam_gia, indexData.ma_loai_hang , indexData.ngay_bat_dau, indexData.ngay_ket_thuc);
			}
			return dt;
		}

		public DataTable GetAllKhuyenMaiByMaSPAsTable(string maSp)
		{
			List<khuyen_mai> listData = dal.GetActiveKhuyenMaiByMaSP(maSp); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("giam_gia", typeof(float));
			dt.Columns.Add("ma_loai_hang", typeof(string));
			dt.Columns.Add("ngay_bat_dau", typeof(DateTime));
			dt.Columns.Add("ngay_ket_thuc", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_khuyen_mai, indexData.giam_gia, indexData.ma_loai_hang, indexData.ngay_bat_dau, indexData.ngay_ket_thuc);
			}
			return dt;
		}
	}
}
