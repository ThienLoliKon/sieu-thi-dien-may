using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class ChiTietHoaDonDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();
		public ChiTietHoaDonDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<chi_tiet_hoa_don> GetAllChiTietHoaDon()
		{
			return db.chi_tiet_hoa_dons.ToList();
		}


		public int addChiTietHoaDon(chi_tiet_hoa_don addItem)
		{
			try
			{
				var entityUpdate = db.chi_tiet_hoa_dons.SingleOrDefault(n => n.ma_hoa_don == addItem.ma_hoa_don && n.ma_san_pham == addItem.ma_san_pham);
				if (addItem != null)
				{
					entityUpdate.so_luong = entityUpdate.so_luong + addItem.so_luong;
				}
				else
				{
					db.chi_tiet_hoa_dons.InsertOnSubmit(addItem);
				}
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
			}
			return 1;
		}


		public int updateChiTietHoaDon(chi_tiet_hoa_don updateNew)
		{
			var entityUpdate = db.chi_tiet_hoa_dons.SingleOrDefault(n => n.ma_hoa_don == updateNew.ma_hoa_don && n.ma_san_pham == updateNew.ma_san_pham);
			if (entityUpdate != null)
			{
				entityUpdate.ma_khuyen_mai = updateNew.ma_khuyen_mai;
				entityUpdate.so_luong = updateNew.so_luong;
				entityUpdate.don_gia = updateNew.don_gia;
				entityUpdate.ngay_gio_in = updateNew.ngay_gio_in;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}



		public List<chi_tiet_hoa_don> searchByNameOrID(string name_id)
		{
			List<chi_tiet_hoa_don> list = new List<chi_tiet_hoa_don>();
			IEnumerable<chi_tiet_hoa_don> query = from item in db.chi_tiet_hoa_dons
												  where item.ma_hoa_don.Contains(name_id) || item.ma_san_pham.Contains(name_id)
												  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		//public string TaoMaHoaDon()
		//{
		//	// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
		//	var listItem = db.hoa_dons.Select(p => p.ma_hoa_don).ToList();

		//	int maxId = 0;

		//	if (listItem.Any()) // Kiểm tra nếu có dữ liệu
		//	{
		//		maxId = listItem
		//					.Where(m => m.StartsWith("HD"))
		//					.Select(m => int.Parse(m.Substring(3)))
		//					.Max(); // Lấy giá trị lớn nhất
		//	}

		//	// Tăng giá trị ID lớn nhất
		//	maxId++;

		//	// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
		//	return "HD" + maxId.ToString("D3");
		//}
		public int deleteChiTietHoaDon(string maHoaDon, string maSanPham)
		{
			var sp = db.chi_tiet_hoa_dons.SingleOrDefault(p => p.ma_san_pham == maSanPham && p.ma_hoa_don == maHoaDon);
			if (sp != null)
			{
				db.chi_tiet_hoa_dons.DeleteOnSubmit(sp);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public bool check(string maHoaDon, string maSanPham)
		{
			if (db.chi_tiet_hoa_dons.Any(p => p.ma_san_pham == maSanPham) == false)
			{
				return false;
			}
			if (db.chi_tiet_hoa_dons.Any(p => p.ma_hoa_don == maHoaDon) == false)
			{
				return false;
			}
			return true;
		}
	}
}
