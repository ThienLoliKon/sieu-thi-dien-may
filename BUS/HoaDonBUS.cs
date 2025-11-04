using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class HoaDonBUS
	{
		private HoaDonDLL dal;

		public HoaDonBUS()
		{
			dal = new HoaDonDLL();
		}

		public bool AddHoaDon(string maNhanVienLap, string maKhachHang)
		{
			hoa_don addVariable = new hoa_don();
			addVariable.ma_hoa_don = dal.TaoMaHoaDon();
			addVariable.ma_nhan_vien_lap = maNhanVienLap;
			addVariable.ma_khach_hang = maKhachHang;
			addVariable.ngay_lap = DateTime.Now;
			dal.addHoaDon(addVariable);
			if (dal.check(addVariable.ma_hoa_don) == true) { return false; }
			return true;
		}

	

		public bool UpdateHoaDon(string maHoaDon, string maNhanVienLap, string maKhachHang)
		{
			hoa_don updateItem = new hoa_don();

			updateItem.ma_nhan_vien_lap = maNhanVienLap;

			updateItem.ma_khach_hang = maKhachHang;
			dal.updateHoaDon(updateItem);

			if (dal.check(updateItem.ma_hoa_don) == true) { return false; }
			return true;
		}

		public DataTable timHoaDon(string keyword)
		{
			List<hoa_don> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_nhan_vien_lap", typeof(float));
			dt.Columns.Add("ma_khach_hang", typeof(string));
			dt.Columns.Add("ngay_lap", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_nhan_vien_lap, indexData.ma_khach_hang, indexData.ngay_lap);
			}

			return dt;
		}

		public DataTable GetAllHoaDonAsTable()
		{
			List<hoa_don> listData = dal.GetAllHoaDon(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_nhan_vien_lap", typeof(float));
			dt.Columns.Add("ma_khach_hang", typeof(string));
			dt.Columns.Add("ngay_lap", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_nhan_vien_lap, indexData.ma_khach_hang, indexData.ngay_lap);
			}
			return dt;
		}

	}
}
