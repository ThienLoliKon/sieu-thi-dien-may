using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class NhaSXBUS
	{
		private NhaSanXuatDLL dal;

		public NhaSXBUS()
		{
			dal = new NhaSanXuatDLL();
		}

		//public List<TacGia> GetAllTacGia()
		//{
		//	return dal.GetAllTacGia();
		//}

		public bool AddNhaSanXuat(string tenNhaSX, string diaChiNhaSX)
		{
			nha_san_xuat addVariable = new nha_san_xuat();

			addVariable.ma_nha_san_xuat = dal.TaoMaSanPham();
			addVariable.ten_nha_san_xuat = tenNhaSX;
			addVariable.dia_chi_nha_san_xuat = diaChiNhaSX;
			dal.addNhaSanXuat(addVariable);
			if (dal.check(addVariable.ma_nha_san_xuat) == true) { return false; }
			return true;
		}

		public bool DeleteNhaSanXuat(string id)
		{
			dal.deleteNhaSanXuat(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateNhaSanXuat(string maNSX, string tenNhaSX, string diaChiNhaSX)
		{
			nha_san_xuat updateItem = new nha_san_xuat();
			updateItem.ma_nha_san_xuat = maNSX;
			updateItem.ten_nha_san_xuat = tenNhaSX;
			updateItem.dia_chi_nha_san_xuat = diaChiNhaSX;
			if (dal.check(updateItem.ma_nha_san_xuat) == true) { return false; }
			return true;
		}

		public DataTable timNhaSanXuat(string keyword)
		{
			List<nha_san_xuat> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ten_nha_san_xuat", typeof(string));
			dt.Columns.Add("dia_chi_nha_san_xuat", typeof(string));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_san_xuat, indexData.ten_nha_san_xuat, indexData.dia_chi_nha_san_xuat);
			}

			return dt;
		}

		public DataTable GetAllNhaCungCapAsTable()
		{
			List<nha_san_xuat> listData = dal.GetAllNhaSanXuat(); // Kiểm tra danh sách từ DAL

			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ten_nha_san_xuat", typeof(string));
			dt.Columns.Add("dia_chi_nha_san_xuat", typeof(string));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_san_xuat, indexData.ten_nha_san_xuat, indexData.dia_chi_nha_san_xuat);
			}

			return dt;
		}
	}
}
