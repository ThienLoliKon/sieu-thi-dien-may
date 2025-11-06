using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSs
{
	public class BaoHanhBUS
	{
		private BaoHanhDLL dal;

		public BaoHanhBUS()
		{
			dal = new BaoHanhDLL();
		}

		//public List<TacGia> GetAllTacGia()
		//{
		//	return dal.GetAllTacGia();
		//}

		public bool AddBaoHanh(string maSanPham, string maKhachHang, string nhanVienBaoHanh, string lyDo, DateTime ngayGui, DateTime ngayXong, bool HoanThanh)
		{
			bao_hanh addVariable = new bao_hanh();
			addVariable.ma_bao_hanh = dal.TaoMaBaoHanh();
			addVariable.ma_san_pham = maSanPham;
			addVariable.ma_khach_hang = maKhachHang;
			addVariable.nhan_vien_bao_hanh = nhanVienBaoHanh;
			addVariable.ly_do = lyDo;
			addVariable.ngay_gui = ngayGui;
			addVariable.ngay_xong = ngayXong;
			addVariable.hoan_thanh = HoanThanh;
			dal.addBaoHanh(addVariable);
			if (dal.check(addVariable.ma_bao_hanh) == true) { return false; }
			return true;
		}

		public bool DeleteBaoHanh(string id)
		{
			dal.deleteBaoHanh(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateBaoHanh(string maBaoHanh, string maSanPham, string maKhachHang, string nhanVienBaoHanh, string lyDo, DateTime ngayGui, DateTime ngayXong, bool HoanThanh)
		{
			bao_hanh updateItem = new bao_hanh();

			updateItem.ma_bao_hanh = dal.TaoMaBaoHanh();
			updateItem.ma_san_pham = maSanPham;
			updateItem.ma_khach_hang = maKhachHang;
			updateItem.nhan_vien_bao_hanh = nhanVienBaoHanh;
			updateItem.ly_do = lyDo;
			updateItem.ngay_gui = ngayGui;
			
			if (HoanThanh == true)
				updateItem.ngay_xong = ngayXong;
			else
				updateItem.ngay_xong = null; // hoặc xử lý lỗi nhập liệu

			updateItem.hoan_thanh = HoanThanh;

			dal.updateBaoHanh(updateItem);

			if (dal.check(updateItem.ma_san_pham) == true) { return false; }
			return true;
		}

		public DataTable timBaoHanh(string keyword)
		{
			List<bao_hanh> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_bao_hanh", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_khach_hang", typeof(string));
			dt.Columns.Add("nhan_vien_bao_hanh", typeof(string));
			dt.Columns.Add("ly_do", typeof(string));
			dt.Columns.Add("ngay_gui", typeof(DateTime));
			dt.Columns.Add("ngay_xong", typeof(DateTime));
			dt.Columns.Add("hoan_thanh", typeof(bool));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_bao_hanh, indexData.ma_san_pham, indexData.ma_khach_hang, indexData.nhan_vien_bao_hanh, indexData.ly_do, indexData.ngay_gui, indexData.ngay_xong, indexData.hoan_thanh);
			}

			return dt;
		}

		public DataTable GetAllBaoHanhAsTable()
		{
			List<bao_hanh> listData = dal.GetAllBaoHanh(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_bao_hanh", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_khach_hang", typeof(string));
			dt.Columns.Add("nhan_vien_bao_hanh", typeof(string));
			dt.Columns.Add("ly_do", typeof(string));
			dt.Columns.Add("ngay_gui", typeof(DateTime));
			dt.Columns.Add("ngay_xong", typeof(DateTime));
			dt.Columns.Add("hoan_thanh", typeof(bool));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_bao_hanh, indexData.ma_san_pham, indexData.ma_khach_hang, indexData.nhan_vien_bao_hanh, indexData.ly_do, indexData.ngay_gui, indexData.ngay_xong, indexData.hoan_thanh);
			}
			return dt;
		}
	}
}
