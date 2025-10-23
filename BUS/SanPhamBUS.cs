using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class SanPhamBUS
	{
		private SanPhamDLL dal;

		public SanPhamBUS()
		{
			dal = new SanPhamDLL();
		}

		//public List<TacGia> GetAllTacGia()
		//{
		//	return dal.GetAllTacGia();
		//}

		public bool AddSanPham(string tenSanPham, string maNXX, string maNCC, string khoiLuong , string giaTien,DateTime ngaySX)
		{
			san_pham addVariable = new san_pham();

			addVariable.ma_san_pham = dal.TaoMaSanPham();
			addVariable.ten_san_pham = tenSanPham;
			addVariable.ma_nha_san_xuat = maNXX;
			addVariable.ma_nha_cung_cap = maNCC;
			if (double.TryParse(khoiLuong, out double khoiLuongValue))
				addVariable.khoi_luong = khoiLuongValue;
			else
				addVariable.khoi_luong = null; // hoặc xử lý lỗi nhập liệu

			if (double.TryParse(giaTien, out double giaTienValue))
				addVariable.gia_tien = giaTienValue;
			else
				addVariable.gia_tien = null; // hoặc xử lý lỗi nhập liệu

			// Chuyển đổi ngày sản xuất
				addVariable.ngay_san_xuat = ngaySX;


			dal.addSanPham(addVariable);
			if (dal.check(addVariable.ma_san_pham) == true) { return false; }
			return true;
		}

		public bool DeleteSanPham(string id)
		{
			dal.deleteSanPham(id);
			if (dal.check(id) == true) { return false; }
			return true;
		}

		public bool UpdateSanPham(string maSanPham, string tenSanPham, string maNXX, string maNCC, string khoiLuong, string giaTien, DateTime ngaySX)
		{
			san_pham updateItem = new san_pham();

			updateItem.ma_san_pham = maSanPham;
			updateItem.ten_san_pham = tenSanPham;
			updateItem.ma_nha_san_xuat = maNXX;
			updateItem.ma_nha_cung_cap = maNCC;
			if (double.TryParse(khoiLuong, out double khoiLuongValue))
				updateItem.khoi_luong = khoiLuongValue;
			else
				updateItem.khoi_luong = null; // hoặc xử lý lỗi nhập liệu

			if (double.TryParse(giaTien, out double giaTienValue))
				updateItem.gia_tien = giaTienValue;
			else
				updateItem.gia_tien = null; // hoặc xử lý lỗi nhập liệu

			updateItem.ngay_san_xuat = ngaySX;

			dal.updateSanPham(updateItem);
			 
			if (dal.check(updateItem.ma_san_pham) == true) { return false; }
			return true;
		}

		public DataTable timSanPham(string keyword)
		{
			List<san_pham> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();

			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ten_san_pham", typeof(string));
			dt.Columns.Add("ma_nha_san_xuat", typeof(string)); 
			dt.Columns.Add("ma_nha_cung_cap", typeof(string)); 
			dt.Columns.Add("khoi_luong", typeof(float));
			dt.Columns.Add("gia_tien", typeof(float));
			dt.Columns.Add("ngay_san_xuat", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_nha_cung_cap, indexData.ten_san_pham, indexData.ma_nha_cung_cap, indexData.khoi_luong, indexData.gia_tien,indexData.ngay_san_xuat);
			}

			return dt;
		}

		public DataTable GetAllSanPhamAsTable()
		{
			List<san_pham> listData = dal.GetAllSanPham(); // Kiểm tra danh sách từ DAL

			if (listData == null || listData.Count == 0)
			{
				return null;
			}

			DataTable dt = new DataTable();
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ten_san_pham", typeof(string));
			dt.Columns.Add("ma_nha_san_xuat", typeof(string));
			dt.Columns.Add("ma_nha_cung_cap", typeof(string));
			dt.Columns.Add("khoi_luong", typeof(float));
			dt.Columns.Add("gia_tien", typeof(float));
			dt.Columns.Add("ngay_san_xuat", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_san_pham, indexData.ten_san_pham, indexData.ma_nha_san_xuat, indexData.ma_nha_cung_cap, indexData.khoi_luong, indexData.gia_tien, indexData.ngay_san_xuat);
			}
			return dt;
		}




		//public class SanPham
		//{
		//	public san_pham(string manv, string hotennv, string diachi, string email, string sdt, string chucvu, string ngaynhanviec)
		//	{
		//		this.manv = manv;
		//		this.hotennv = hotennv;
		//		this.diachi = diachi;
		//		this.email = email;
		//		this.sdt = sdt;
		//		this.chucvu = chucvu;
		//		this.ngaynhanviec = ngaynhanviec;
		//	}

		//	public string manv { get; set; }
		//	public string hotennv { get; set; }
		//	public string diachi { get; set; }
		//	public string email { get; set; }
		//	public string sdt { get; set; }
		//	public string chucvu { get; set; }
		//	public string ngaynhanviec { get; set; }
		//}

		//private SanPhamDLL sanphamdll;

		//public List<san_pham> getAllSanPham()
		//{
		//	sanphamdll = new SanPhamDLL();
		//	List<san_pham> list = new List<san_pham>();
		//	foreach (var item in sanphamdll.GetAllSanPham())
		//	{
		//		san_pham newIndex = new san_pham(item.ma_san_pham, item.ten_san_pham, item.ma_nha_san_xuat, item.ma_nha_cung_cap, item.khoi_luong, item.gia_tien, item.ngay_san_xuat.Value.ToShortDateString());
		//		list.Add(newIndex);
		//	}
		//	return list;
		//}

		//public int addNhanVien(san_pham nhanVien)
		//{
		//	DLL.san_pham nv = new DLL.san_pham()
		//	{
		//		MaNhanVien = createMaNhanVien(),
		//		TenNhanVien = nhanVien.hotennv,
		//		DiaChi = nhanVien.diachi,
		//		Email = nhanVien.email,
		//		SoDienThoai = nhanVien.sdt,
		//		ChucVu = nhanVien.chucvu,
		//		NgayTao = DateTime.Now,
		//		NgayCapNhat = DateTime.Now
		//	};
		//	return nhanviendll.addNhanVien(nv);
		//}
		//public string createMaNhanVien()
		//{
		//	return $"S{int.Parse(nhanviendll.GetAllNhanVien().Last().MaNhanVien.Substring(2)) + 1}";
		//}
		//public int deleteNhanVien(string id)
		//{
		//	int rs = nhanviendll.deleteNhanVien(id);
		//	return rs;
		//}
		//public int updateNhanVien(NhanVien nhanVien)
		//{
		//	DAODLL.NhanVien nv = new DAODLL.NhanVien()
		//	{
		//		MaNhanVien = nhanVien.manv,
		//		TenNhanVien = nhanVien.hotennv,
		//		DiaChi = nhanVien.diachi,
		//		Email = nhanVien.email,
		//		SoDienThoai = nhanVien.sdt,
		//		ChucVu = nhanVien.chucvu,
		//		NgayTao = DateTime.Parse(nhanVien.ngaynhanviec),
		//		NgayCapNhat = DateTime.Now
		//	};
		//	return nhanviendll.updateNhanVien(nv);
		//}

		//public List<NhanVien> searchByNameOrID(string name_id)
		//{
		//	List<NhanVien> list = new List<NhanVien>();
		//	foreach (var item in nhanviendll.searchByNameOrID(name_id))
		//	{
		//		NhanVien nhanvien = new NhanVien(item.MaNhanVien, item.TenNhanVien, item.DiaChi, item.Email, item.SoDienThoai, item.ChucVu, item.NgayCapNhat.Value.ToShortTimeString());

		//		list.Add(nhanvien);
		//	}
		//	return list;
		//}
		
	}
}
