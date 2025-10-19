using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	internal class KhuyenMaiDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();

		public KhuyenMaiDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<khuyen_mai> GetAllKhuyenMai()
		{
			return db.khuyen_mais.ToList();
		}

		public int addKhuyenMai(khuyen_mai addItem)
		{
			try
			{
				db.khuyen_mais.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm Khuyến Mãi: " + ex.Message);
			}
			return 1;
		}
		public int deleteKhuyenMai(string id)
		{
			var nv = db.khuyen_mais.SingleOrDefault(p => p.ma_khuyen_mai == id);
			if (nv != null)
			{
				db.khuyen_mais.DeleteOnSubmit(nv);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}
		public int updateKhuyenMai(khuyen_mai updateNew)
		{
			var entityUpdate = db.khuyen_mais.SingleOrDefault(n => n.ma_khuyen_mai == updateNew.ma_khuyen_mai);
			if (entityUpdate != null)
			{
				entityUpdate.giam_gia = updateNew.giam_gia;
				entityUpdate.ma_loai_hang = updateNew.ma_loai_hang;
				entityUpdate.ngay_bat_dau = updateNew.ngay_bat_dau;
				entityUpdate.ngay_ket_thuc = updateNew.ngay_ket_thuc;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<khuyen_mai> searchByNameOrID(string name_id)
		{
			List<khuyen_mai> list = new List<khuyen_mai>();
			IEnumerable<khuyen_mai> query = from item in db.khuyen_mais
										  where item.ma_khuyen_mai.Contains(name_id)
										  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
	}
}
