using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class ChiTietHoaDonDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
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
				if (entityUpdate != null)
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
			bool ketQua = db.chi_tiet_hoa_dons.Any(p =>
						p.ma_hoa_don == maHoaDon
						&& p.ma_san_pham == maSanPham); // Dùng && mới đúng

			return ketQua;
		}

		// (Trong ChiTietHoaDonDLL.cs)
		public bool AddChiTietHoaDonVaTruKho(chi_tiet_hoa_don addItem, string maChiNhanh)
		{
			try
			{
				// BƯỚC 1: MỞ KẾT NỐI BẰNG TAY
				db.Connection.Open();

				// BƯỚC 2: BẮT ĐẦU TRANSACTION
				using (var transaction = db.Connection.BeginTransaction())
				{
					db.Transaction = transaction; // Gán transaction cho DataContext

					try
					{
						// BƯỚC 3: KIỂM TRA VÀ TRỪ KHO CHI NHÁNH
						var khoChiNhanh = db.san_pham_trong_chi_nhanhs.SingleOrDefault(k =>
							k.ma_san_pham == addItem.ma_san_pham &&
							k.ma_chi_nhanh == maChiNhanh);

						if (khoChiNhanh == null || khoChiNhanh.so_luong < addItem.so_luong)
						{
							transaction.Rollback();
							return false; // Không đủ hàng
						}

						khoChiNhanh.so_luong = khoChiNhanh.so_luong - addItem.so_luong;
						db.SubmitChanges();

						// BƯỚC 4: THÊM (HOẶC CỘNG DỒN) CHI TIẾT HÓA ĐƠN
						var entityUpdate = db.chi_tiet_hoa_dons.SingleOrDefault(n =>
							n.ma_hoa_don == addItem.ma_hoa_don &&
							n.ma_san_pham == addItem.ma_san_pham);

						if (entityUpdate != null)
						{
							entityUpdate.so_luong = entityUpdate.so_luong + addItem.so_luong;
						}
						else
						{
							db.chi_tiet_hoa_dons.InsertOnSubmit(addItem);
						}
						db.SubmitChanges();

						// BƯỚC 5: HOÀN TẤT
						transaction.Commit();
						return true;
					}
					catch (Exception ex)
					{
						transaction.Rollback(); // Hủy bỏ nếu có lỗi ở Bước 3 hoặc 4
						Console.WriteLine("Lỗi (Rollback): " + ex.Message);
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi Transaction/Connection: " + ex.Message);
				return false; // Lỗi từ lúc mở kết nối
			}
			finally
			{
				// BƯỚC 6: LUÔN LUÔN ĐÓNG KẾT NỐI
				if (db.Connection.State == System.Data.ConnectionState.Open)
				{
					db.Connection.Close();
				}
			}
		}
	}
}
