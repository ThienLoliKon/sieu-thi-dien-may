using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class LoaiHangBUS
	{
		private LoaiHangDLL dal;

		public LoaiHangBUS()
		{
			dal = new LoaiHangDLL();
		}

		public bool AddLoaiHang(string maLoaiHang, string tenLoaiHang, string moTa)
		{
			loai_hang addVariable = new loai_hang();
			addVariable.ma_loai_hang = dal.TaoMaLoaiHang();			
			addVariable.ten_loai_hang = tenLoaiHang;
			addVariable.mo_ta = moTa;
			dal.addLoaiHang(addVariable);
			if (dal.check(addVariable.ma_loai_hang) == true) { return false; }
			return true;
		}

		public bool DeleteLoaiHang(string id)
		{
			dal.deleteLoaiHang(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateLoaiHang(string maLoaiHang, string tenLoaiHang, string moTa)
		{
			loai_hang updateItem = new loai_hang();
			updateItem.ma_loai_hang = maLoaiHang;
			updateItem.ten_loai_hang = tenLoaiHang;
			updateItem.mo_ta = moTa;
			dal.updateLoaiHang(updateItem);
			if (dal.check(updateItem.ma_loai_hang) == true) { return false; }
			return true;
		}

		public DataTable timLoaiHang(string keyword)
		{
			List<loai_hang> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_loai_hang", typeof(string));
			dt.Columns.Add("ten_loai_hang", typeof(float));
			dt.Columns.Add("mo_ta", typeof(string));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_loai_hang, indexData.ten_loai_hang, indexData.mo_ta);
			}

			return dt;
		}

		public DataTable GetAllLoaiHang()
		{
			List<loai_hang> listData = dal.GetAllLoaiHang(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_loai_hang", typeof(string));
			dt.Columns.Add("ten_loai_hang", typeof(float));
			dt.Columns.Add("mo_ta", typeof(string));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_loai_hang, indexData.ten_loai_hang, indexData.mo_ta);
			}
			return dt;
		}

	}
}
