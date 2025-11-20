using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class KhuyenMaiDLL
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
										    where item.ma_khuyen_mai.Contains(name_id) || item.ma_loai_hang.Contains(name_id)
											select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaKhuyenMai()
		{
			// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
			var listItem = db.khuyen_mais.Select(p => p.ma_khuyen_mai).ToList();

			int maxId = 0;

			if (listItem.Any()) // Kiểm tra nếu có dữ liệu
			{
				maxId = listItem
							.Where(m => m.StartsWith("KM")) // Lọc các mã bắt đầu bằng "TG"
							.Select(m => int.Parse(m.Substring(8))) // Lấy phần số sau "TG"
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
			return "KM" + maxId.ToString("D8");
		}
		/// Lấy danh sách khuyến mãi ĐANG CÒN HẠN của một sản phẩm cụ thể
		public List<khuyen_mai> GetActiveKhuyenMaiByMaSP(string maSanPham)
		{
			DateTime ngayHienTai = DateTime.Now;

			try
			{
				// Truy vấn JOIN 2 bảng:
				// 1. Từ khuyen_mai JOIN san_pham_loai_hang
				// 2. Lọc theo ma_san_pham
				// 3. Lọc theo ngày (còn hạn)
				var query = from km in db.khuyen_mais
							join splh in db.san_pham_loai_hangs on km.ma_loai_hang equals splh.ma_loai_hang
							where splh.ma_san_pham == maSanPham &&
								  ngayHienTai >= km.ngay_bat_dau &&
								  ngayHienTai <= km.ngay_ket_thuc
							select km;

				return query.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi khi lấy KM theo Mã SP: " + ex.Message);
				return new List<khuyen_mai>(); // Trả về danh sách rỗng
			}
		}

		public bool check(string id)
		{
			return db.khuyen_mais.Any(p => p.ma_khuyen_mai == id);
		}
	}
}
