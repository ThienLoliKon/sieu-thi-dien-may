using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class SanPhamLoaiHangDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();
		public SanPhamLoaiHangDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}

		public List<san_pham_loai_hang> GetAllSanPhamLoaiHang()
		{
			return db.san_pham_loai_hangs.ToList();
		}

		public int addSanPhamLoaiHang(san_pham_loai_hang addItem)
		{
			try
			{
				db.san_pham_loai_hangs.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm liên kết sản phẩm loại hàng: " + ex.Message);
			}
			return 1;
		}

		//fix sau
		public int deleteSanPhamLoaiHang(string id)
		{
			var sp = db.san_pham_loai_hangs.SingleOrDefault(p => p.ma_san_pham == id);
			if (sp != null)
			{
				db.san_pham_loai_hangs.DeleteOnSubmit(sp);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public int updateSanPhamLoaiHang(san_pham_loai_hang updateNew)
		{
			var entityUpdate = db.san_pham_loai_hangs.SingleOrDefault(n => n.ma_san_pham == updateNew.ma_san_pham);
			if (entityUpdate != null)
			{
				entityUpdate.ma_san_pham = updateNew.ma_san_pham;
				entityUpdate.ma_loai_hang = updateNew.ma_loai_hang;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<san_pham_loai_hang> searchByNameOrID(string name_id)
		{
			List<san_pham_loai_hang> list = new List<san_pham_loai_hang>();
			IEnumerable<san_pham_loai_hang> query = from item in db.san_pham_loai_hangs
										  where item.ma_san_pham.Contains(name_id) || item.ma_loai_hang.Contains(name_id)
										  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaSanPham()
		{
			// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
			var listItem = db.san_phams.Select(p => p.ma_san_pham).ToList();

			int maxId = 0;

			if (listItem.Any()) // Kiểm tra nếu có dữ liệu
			{
				maxId = listItem
							.Where(m => m.StartsWith("SP")) // Lọc các mã bắt đầu bằng "TG"
							.Select(m => int.Parse(m.Substring(3))) // Lấy phần số sau "TG"
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
			return "SP" + maxId.ToString("D3");
		}
		public bool check(string id)
		{
			return db.san_phams.Any(p => p.ma_san_pham == id);
		}
	}
}

