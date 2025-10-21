using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	internal class NhaCungCapDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();

		public NhaCungCapDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<nha_cung_cap> GetAllNhaCungCap()
		{
			return db.nha_cung_caps.ToList();
		}

		public int addNhaCungCap(nha_cung_cap addItem)
		{
			try
			{
				db.nha_cung_caps.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm Nhà cung cấp: " + ex.Message);
			}
			return 1;
		}
		public int deleteNhaCungCap(string id)
		{
			var nv = db.nha_cung_caps.SingleOrDefault(p => p.ma_nha_cung_cap == id);
			if (nv != null)
			{
				db.nha_cung_caps.DeleteOnSubmit(nv);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}
		public int updateNhaCungCap(nha_cung_cap updateNew)
		{
			var entityUpdate = db.nha_cung_caps.SingleOrDefault(n => n.ma_nha_cung_cap == updateNew.ma_nha_cung_cap);
			if (entityUpdate != null)
			{
				entityUpdate.ten_nha_cung_cap = updateNew.ten_nha_cung_cap;
				entityUpdate.dia_chi_nha_cung_cap = updateNew.dia_chi_nha_cung_cap;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<nha_cung_cap> searchByNameOrID(string name_id)
		{
			List<nha_cung_cap> list = new List<nha_cung_cap>();
			IEnumerable<nha_cung_cap> query = from item in db.nha_cung_caps
											where item.ma_nha_cung_cap.Contains(name_id) || item.ten_nha_cung_cap.Contains(name_id)
											  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
	}
}
