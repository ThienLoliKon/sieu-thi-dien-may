using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class BaoHanhDLL
	{
		DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
		public BaoHanhDLL()
		{
			if (!db.DatabaseExists())
			{
				throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
			}
		}
		public List<bao_hanh> GetAllBaoHanh()
		{
			return db.bao_hanhs.ToList();
		}
		public int addBaoHanh(bao_hanh addItem)
		{
			try
			{
				db.bao_hanhs.InsertOnSubmit(addItem);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				return 0;
				throw new Exception("Lỗi khi thêm phiếu bảo hành: " + ex.Message);
			}
			return 1;
		}

		//fix sau
		public int deleteBaoHanh(string id)
		{
			var sp = db.bao_hanhs.SingleOrDefault(p => p.ma_bao_hanh == id);
			if (sp != null)
			{
				db.bao_hanhs.DeleteOnSubmit(sp);
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public int updateBaoHanh(bao_hanh updateNew)
		{
			var entityUpdate = db.bao_hanhs.SingleOrDefault(n => n.ma_bao_hanh == updateNew.ma_bao_hanh);
			if (entityUpdate != null)
			{
				entityUpdate.ma_san_pham = updateNew.ma_san_pham;
				entityUpdate.ma_khach_hang = updateNew.ma_khach_hang;
				entityUpdate.nhan_vien_bao_hanh = updateNew.nhan_vien_bao_hanh;
				entityUpdate.ly_do = updateNew.ly_do;
				entityUpdate.ngay_gui = updateNew.ngay_gui;
				entityUpdate.ngay_xong = updateNew.ngay_xong;
				entityUpdate.hoan_thanh = updateNew.hoan_thanh;
				db.SubmitChanges();
				return 1;
			}
			return 0;
		}

		public List<bao_hanh> searchByNameOrID(string name_id)
		{
			List<bao_hanh> list = new List<bao_hanh>();
			IEnumerable<bao_hanh> query = from item in db.bao_hanhs
										  where item.ma_khach_hang.Contains(name_id) || item.ma_bao_hanh.Contains(name_id)
										  select item;
			foreach (var item in query)
			{
				list.Add(item);
			}
			return list;
		}
		public string TaoMaBaoHanh()
		{
			// Lấy danh sách mã TacGia và kiểm tra có dữ liệu hay không
			var listItem = db.bao_hanhs.Select(p => p.ma_bao_hanh).ToList();

			int maxId = 0;

			if (listItem.Any()) // Kiểm tra nếu có dữ liệu
			{
				maxId = listItem
							.Where(m => m.StartsWith("BH")) // Lọc các mã bắt đầu bằng "TG"
							.Select(m => int.Parse(m.Substring(2))) // Lấy phần số sau "TG"
							.Max(); // Lấy giá trị lớn nhất
			}

			// Tăng giá trị ID lớn nhất
			maxId++;

			// Tạo mã mới với tiền tố "NXB" và đảm bảo đúng định dạng
			return "BH" + maxId.ToString("D8");
		}
		public bool check(string id)
		{
			return db.bao_hanhs.Any(p => p.ma_bao_hanh == id);
		}
	}
}
