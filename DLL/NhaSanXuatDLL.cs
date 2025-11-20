using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class NhaSanXuatDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();
		public NhaSanXuatDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<nha_san_xuat> GetAllNhaSanXuat()
		{
			return db.nha_san_xuats.ToList();
		}
		public int addNhaSanXuat(nha_san_xuat addItem)
		{
			try
			{
				db.nha_san_xuats.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm nhà sản xuất: " + ex.Message);
			}
			return 1;
		}

		//fix sau
		public int deleteNhaSanXuat(string id)
		{
			var sp = db.nha_san_xuats.SingleOrDefault(p => p.ma_nha_san_xuat == id);
			if (sp != null)
			{
				db.nha_san_xuats.DeleteOnSubmit(sp);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public int updateNhaSanXuat(nha_san_xuat updateNew)
		{
			var entityUpdate = db.nha_san_xuats.SingleOrDefault(n => n.ma_nha_san_xuat == updateNew.ma_nha_san_xuat);
			if (entityUpdate != null)
			{
				entityUpdate.ten_nha_san_xuat = updateNew.ten_nha_san_xuat;
				entityUpdate.dia_chi_nha_san_xuat = updateNew.dia_chi_nha_san_xuat;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<nha_san_xuat> searchByNameOrID(string name_id)
		{
			List<nha_san_xuat> list = new List<nha_san_xuat>();
			IEnumerable<nha_san_xuat> query = from item in db.nha_san_xuats
										  where item.ma_nha_san_xuat.Contains(name_id) || item.ten_nha_san_xuat.Contains(name_id)
											  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaNSX()
		{
			var listItem = db.nha_san_xuats.Select(p => p.ma_nha_san_xuat).ToList();

			int maxId = 0;
			var nsxItems = listItem
				.Where(m => m.StartsWith("NSX") && m.Length > 3)
				.Select(m => {
					int id;
					return int.TryParse(m.Substring(7), out id) ? id : 0;
				});

			if (nsxItems.Any())
			{
				maxId = nsxItems.Max();
			}

			maxId++;

			return "NSX" + maxId.ToString("D7");
		}
		public bool check(string id)
		{
			return db.nha_san_xuats.Any(p => p.ma_nha_san_xuat == id);
		}
	}
}
