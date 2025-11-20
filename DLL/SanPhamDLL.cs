using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class SanPhamDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();
		public SanPhamDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<san_pham> GetAllSanPham()
		{
			return db.san_phams.ToList();
		}
		public int addSanPham(san_pham addItem)
		{
			try
			{
				db.san_phams.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
			}
			return 1;
		}

//		//fix sau
//		public int deleteSanPham(string id)
//		{
//			var sp = db.san_phams.SingleOrDefault(p => p.ma_san_pham == id);
//			if (sp != null)
//			{
//				db.san_phams.DeleteOnSubmit(sp);
//				db.SubmitChanges();
//				return 1;
//			}
//			return 0;
//		}

		public int updateSanPham(san_pham updateNew)
		{
			var entityUpdate = db.san_phams.SingleOrDefault(n => n.ma_san_pham == updateNew.ma_san_pham);
			if (entityUpdate != null)
			{
				entityUpdate.ten_san_pham = updateNew.ten_san_pham;
				entityUpdate.ma_nha_san_xuat = updateNew.ma_nha_san_xuat;
				entityUpdate.ma_nha_cung_cap = updateNew.ma_nha_cung_cap;
				entityUpdate.khoi_luong = updateNew.khoi_luong; 
				entityUpdate.thoi_gian_bao_hanh = updateNew.thoi_gian_bao_hanh;
				entityUpdate.gia_tien = updateNew.gia_tien;
				entityUpdate.ngay_san_xuat = updateNew.ngay_san_xuat;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}



		public List<san_pham> searchByNameOrID(string name_id)
		{
			List<san_pham> list = new List<san_pham>();
			IEnumerable<san_pham> query = from item in db.san_phams
										  where item.ma_san_pham.Contains(name_id) || item.ten_san_pham.Contains(name_id)
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
							.Select(m => int.Parse(m.Substring(8))) // Lấy phần số sau "TG"
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
			return "SP" + maxId.ToString("D8");
		}
		public bool check(string id)
		{
			return db.san_phams.Any(p => p.ma_san_pham == id);
		}


		public List<san_pham> GetSanPhamByMaHD(string maHoaDon)
		{
			try
			{
				var query = from cthd in db.chi_tiet_hoa_dons
							join sp in db.san_phams on cthd.ma_san_pham equals sp.ma_san_pham
							where cthd.ma_hoa_don == maHoaDon
							select sp; // Chọn toàn bộ đối tượng sản phẩm

				return query.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi khi lấy SP theo mã Hóa Đơn: " + ex.Message);
				return new List<san_pham>(); // Trả về danh sách rỗng
			}
		}

		public san_pham GetSanPhamByMaSP(string maSP)
		{
			return db.san_phams.SingleOrDefault(sp => sp.ma_san_pham == maSP);
		}
	}
}
