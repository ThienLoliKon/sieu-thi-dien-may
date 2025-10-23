using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class NhaCCBUS
	{
		private NhaCungCapDLL dal;

		public NhaCCBUS()
		{
			dal = new NhaCungCapDLL();
		}

		//public List<TacGia> GetAllTacGia()
		//{
		//	return dal.GetAllTacGia();
		//}

		public bool AddNhaCungCap(string tenNhaCungCap, string diaChiNhaCungCap)
		{
			nha_cung_cap addVariable = new nha_cung_cap();

			addVariable.ma_nha_cung_cap = dal.TaoMaSanPham();
			addVariable.ten_nha_cung_cap = tenNhaCungCap;
			addVariable.dia_chi_nha_cung_cap = diaChiNhaCungCap;
			

			dal.addNhaCungCap(addVariable);
			if (dal.check(addVariable.ma_nha_cung_cap) == true) { return false; }
			return true;
		}

		public bool DeleteNhaCungCap(string id)
		{
			dal.deleteNhaCungCap(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateNhaCungCap(string maNCC, string tenNhaCungCap, string diaChiNhaCungCap)
		{
			nha_cung_cap updateItem = new nha_cung_cap();

			updateItem.ma_nha_cung_cap = maNCC;
			updateItem.ten_nha_cung_cap = tenNhaCungCap;
			updateItem.dia_chi_nha_cung_cap = diaChiNhaCungCap;

			if (dal.check(updateItem.ma_nha_cung_cap) == true) { return false; }
			return true;
		}

		public DataTable timNhaCungCap(string keyword)
		{
			List<nha_cung_cap> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("ten_nha_cung_cap", typeof(string));
			dt.Columns.Add("dia_chi_nha_cung_cap", typeof(string));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_cung_cap, indexData.ten_nha_cung_cap, indexData.dia_chi_nha_cung_cap);
			}

			return dt;
		}

		public DataTable GetAllNhaCungCapAsTable()
		{
			List<nha_cung_cap> listData = dal.GetAllNhaCungCap(); // Kiểm tra danh sách từ DAL

			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("ten_nha_cung_cap", typeof(string));
			dt.Columns.Add("dia_chi_nha_cung_cap", typeof(string));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_cung_cap, indexData.ten_nha_cung_cap, indexData.dia_chi_nha_cung_cap);
			}

			return dt;
		}

	}
}
