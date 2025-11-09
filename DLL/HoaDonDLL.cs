using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class HoaDonDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext();
		public HoaDonDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<hoa_don> GetAllHoaDon()
		{
			return db.hoa_dons.ToList();
		}
		public int addHoaDon(hoa_don addItem)
		{
			try
			{
				db.hoa_dons.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
			}
			return 1;
		}


		public int updateHoaDon(hoa_don updateNew)
		{
			var entityUpdate = db.hoa_dons.SingleOrDefault(n => n.ma_hoa_don == updateNew.ma_hoa_don);
			if (entityUpdate != null)
			{
				entityUpdate.ma_nhan_vien_lap = updateNew.ma_nhan_vien_lap;
				entityUpdate.ma_khach_hang = updateNew.ma_khach_hang;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}



		public List<hoa_don> searchByNameOrID(string name_id)
		{
			List<hoa_don> list = new List<hoa_don>();
			IEnumerable<hoa_don> query = from item in db.hoa_dons
										 where item.ma_hoa_don.Contains(name_id) || item.ma_nhan_vien_lap.Contains(name_id) || item.ma_khach_hang.Contains(name_id)
										 select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaHoaDon()
		{
			// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
			var listItem = db.hoa_dons.Select(p => p.ma_hoa_don).ToList();

			int maxId = 0;

			if (listItem.Any()) // Kiểm tra nếu có dữ liệu
			{
				maxId = listItem
							.Where(m => m.StartsWith("HD"))
							.Select(m => int.Parse(m.Substring(3)))
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
			return "HD" + maxId.ToString("D3");
		}
		public bool check(string id)
		{
			return db.hoa_dons.Any(p => p.ma_hoa_don == id);
		}
		public hoa_don GetHoaDonByMaHD(string maHD)
		{
			return db.hoa_dons.SingleOrDefault(hd => hd.ma_hoa_don == maHD);
		}
	}
}