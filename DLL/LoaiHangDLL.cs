using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class LoaiHangDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();

		public LoaiHangDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<loai_hang> GetAllLoaiHang()
		{
			return db.loai_hangs.ToList();
		}

		public int addLoaiHang(loai_hang addItem)
		{
			try
			{
				db.loai_hangs.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm Loại Hàng: " + ex.Message);
			}
			return 1;
		}
		public int deleteLoaiHang(string id)
		{
			var nv = db.loai_hangs.SingleOrDefault(p => p.ma_loai_hang == id);
			if (nv != null)
			{
				db.loai_hangs.DeleteOnSubmit(nv);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}
		public int updateLoaiHang(loai_hang updateNew)
		{
			var entityUpdate = db.loai_hangs.SingleOrDefault(n => n.ma_loai_hang == updateNew.ma_loai_hang);
			if (entityUpdate != null)
			{
				entityUpdate.ten_loai_hang = updateNew.ten_loai_hang;
				entityUpdate.mo_ta = updateNew.mo_ta;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<loai_hang> searchByNameOrID(string name_id)
		{
			List<loai_hang> list = new List<loai_hang>();
			IEnumerable<loai_hang> query = from item in db.loai_hangs
											where item.ma_loai_hang.Contains(name_id) || item.ten_loai_hang.Contains(name_id)
										   select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaLoaiHang()
		{
			// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
			var listItem = db.loai_hangs.Select(p => p.ma_loai_hang).ToList();

			int maxId = 0;

			if (listItem.Any()) // Kiểm tra nếu có dữ liệu
			{
				maxId = listItem
							.Where(m => m.StartsWith("LH")) 
							.Select(m => int.Parse(m.Substring(8)))
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới và đảm bảo đúng định dạng
			return "LH" + maxId.ToString("D8");
		}
		public bool check(string id)
		{
			return db.loai_hangs.Any(p => p.ma_loai_hang == id);
		}
	}
}
