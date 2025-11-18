using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static DLL.SanPhamTrongKhoTongDLL;

namespace BUS
{
	public class ChiTietHoaDonBUS
	{
		public enum ThemChiTietStatus
		{
			ThanhCong,            // 0 (Tương đương với 0 của bạn)
			Loi_NhanVienKhongCoChiNhanh, // 1
			Loi_KhongTimThayKho,  // 2 (Tương đương với 1 của bạn)
			Loi_KhongDuSoLuong,   // 3 (Tương đương với 2 của bạn)
			Loi_Database         // 4 (Lỗi chung)
		}
		private ChiTietHoaDonDLL dal;
		private NhanVienDLL dalNhanVien;
		public ChiTietHoaDonBUS()
		{
			dal = new ChiTietHoaDonDLL();
			dalNhanVien = new NhanVienDLL(); // <-- Khởi tạo
		}

		public ThemChiTietStatus AddChiTietHoaDon(string maHoaDon,string maNhanVien ,string maSanPham, string maKhuyenMai, string soLuong, string donGia,decimal giaGoc, DateTime ngayGioIn)
		{
			SanPhamBUS busSP = new SanPhamBUS();
			chi_tiet_hoa_don addVariable = new chi_tiet_hoa_don();
			if (int.TryParse(soLuong, out int soLuongInt))
				addVariable.so_luong = soLuongInt;
			else
				addVariable.so_luong = null; // hoặc xử lý lỗi nhập liệu

			string maChiNhanh = TaiKhoanBUS.currentChiNhanh;
			if (string.IsNullOrEmpty(maChiNhanh))
			{
				return ThemChiTietStatus.Loi_NhanVienKhongCoChiNhanh; // Lỗi 1
			}

			try
			{
				using (var scope = new TransactionScope())
				{
					// BƯỚC 2a: TRỪ KHO
					// (Giả sử bạn đã sửa KhoBUS để nó trả về TruKhoStatus)
					SanPhamTrongChiNhanhDLL sanPhamTrongChiNhanhDLL = new SanPhamTrongChiNhanhDLL();
					TruKhoStatus truKhoResult = sanPhamTrongChiNhanhDLL.TruSoLuongKhoChiNhanh(maSanPham, maChiNhanh, soLuongInt);

					if (truKhoResult != TruKhoStatus.ThanhCong)
					{
						// Chuyển lỗi từ KhoBUS sang lỗi của ChiTietBUS
						if (truKhoResult == TruKhoStatus.KhoNotFound)
						{
							return ThemChiTietStatus.Loi_KhongTimThayKho; // Lỗi 2
						}
						if (truKhoResult == TruKhoStatus.KhongDuHang)
						{
							return ThemChiTietStatus.Loi_KhongDuSoLuong; // Lỗi 3
						}
					}

					// BƯỚC 2b: THÊM CHI TIẾT HÓA ĐƠN
					{
						// ... (gán giá trị) ...
						addVariable.ma_hoa_don = maHoaDon;
						addVariable.ma_san_pham = maSanPham;
						addVariable.ma_khuyen_mai = maKhuyenMai;
						addVariable.gia_goc = giaGoc;
						//if (maKhuyenMai == null)
						//{
						//	maKhuyenMai = "";
						//}

						if (Decimal.TryParse(donGia, out decimal donGiaDemical))
							addVariable.don_gia = donGiaDemical;
						else
							addVariable.don_gia = null; // hoặc xử lý lỗi nhập liệu			
						addVariable.ngay_gio_in = DateTime.Now;

					}
					;

					// (Sửa lại hàm addChiTietHoaDon trong DLL để nó chỉ thêm/cộng dồn
					// và không trả về bool, để SubmitChanges xử lý)
					dal.addChiTietHoaDon(addVariable); // Hàm này chỉ nên là void hoặc int

					// BƯỚC 2c: HOÀN TẤT
					scope.Complete();
					return ThemChiTietStatus.ThanhCong; // Thành công!
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi TransactionScope: " + ex.Message);
				return ThemChiTietStatus.Loi_Database; // Lỗi 4
			}



			
		}

		// SỬA LẠI HÀM NÀY
		//public bool AddChiTietHoaDon(string maHoaDon, string maNhanVienLap, string maSanPham, string maKhuyenMai, string soLuong, string donGia, DateTime ngayGioIn)
		//{
		//	// BƯỚC 1: LẤY MÃ CHI NHÁNH TỪ MÃ NHÂN VIÊN
		//	var nhanVien = dalNhanVien.GetNhanVienByMaNV(maNhanVienLap);

		//	// Kiểm tra xem có tìm thấy nhân viên và chi nhánh không
		//	if (nhanVien == null || string.IsNullOrEmpty(nhanVien.ma_chi_nhanh))
		//	{
		//		// Nếu nhân viên không thuộc chi nhánh nào, không cho bán
		//		return false;
		//	}
		//	string maChiNhanh = nhanVien.ma_chi_nhanh.Trim();

		//	// BƯỚC 2: TẠO ĐỐI TƯỢNG CTHD
		//	chi_tiet_hoa_don addVariable = new chi_tiet_hoa_don();
		//	addVariable.ma_hoa_don = maHoaDon.Trim();
		//	addVariable.ma_san_pham = maSanPham.Trim();
		//	addVariable.ma_khuyen_mai = maKhuyenMai; // (Cho phép null)

		//	if (int.TryParse(soLuong, out int soLuongInt))
		//		addVariable.so_luong = soLuongInt;
		//	else
		//		return false; // Lỗi số lượng

		//	if (Decimal.TryParse(donGia, out decimal donGiaDemical))
		//		addVariable.don_gia = donGiaDemical;
		//	else
		//		return false; // Lỗi đơn giá

		//	addVariable.ngay_gio_in = ngayGioIn;

		//	// BƯỚC 3: GỌI HÀM MỚI TRONG DLL
		//	// Hàm này sẽ tự động trừ kho VÀ thêm CTHD
		//	return dal.AddChiTietHoaDonVaTruKho(addVariable, maChiNhanh);
		//}

		public bool DeleteChiTietHoaDon(string maHoaDon, string maSanPham)
		{
			dal.deleteChiTietHoaDon(maHoaDon, maSanPham);
			if (dal.check(maHoaDon, maSanPham) == true) { return false; }
			return true;
		}

		public bool UpdateChiTietHoaDon(string maHoaDon, string maSanPham, string maKhuyenMai, string soLuong, string donGia, DateTime ngayGioIn)
		{
			chi_tiet_hoa_don updateItem = new chi_tiet_hoa_don();

			updateItem.ma_hoa_don = maHoaDon;
			updateItem.ma_san_pham = maSanPham;
			updateItem.ma_khuyen_mai = maKhuyenMai;
			if (int.TryParse(soLuong, out int soLuongInt))
				updateItem.so_luong = soLuongInt;
			else
				updateItem.so_luong = null; // hoặc xử lý lỗi nhập liệu
			if (Decimal.TryParse(donGia, out decimal donGiaDemical))
				updateItem.don_gia = donGiaDemical;
			else
				updateItem.don_gia = null; // hoặc xử lý lỗi nhập liệu
			updateItem.ngay_gio_in = ngayGioIn;
			dal.updateChiTietHoaDon(updateItem);

			if (dal.check(updateItem.ma_hoa_don, updateItem.ma_san_pham) == true) { return false; }
			return true;
		}

		public DataTable timChiTietHoaDon(string keyword)
		{
			List<chi_tiet_hoa_don> listData = dal.searchByNameOrID(keyword);
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(float));
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("so_luong", typeof(int));
			dt.Columns.Add("don_gia", typeof(decimal));
			dt.Columns.Add("ngay_gio", typeof(DateTime));

			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_san_pham, indexData.ma_khuyen_mai, indexData.so_luong, indexData.don_gia, indexData.ngay_gio_in);
			}

			return dt;
		}

		public DataTable GetAllChiTietHoaDonAsTable()
		{
			List<chi_tiet_hoa_don> listData = dal.GetAllChiTietHoaDon(); // Kiểm tra danh sách từ DAL
			if (listData == null || listData.Count == 0)
			{
				return null;
			}
			DataTable dt = new DataTable();
			dt.Columns.Add("ma_hoa_don", typeof(string));
			dt.Columns.Add("ma_san_pham", typeof(string));
			dt.Columns.Add("ma_khuyen_mai", typeof(string));
			dt.Columns.Add("so_luong", typeof(int));
			dt.Columns.Add("don_gia", typeof(decimal));
			dt.Columns.Add("ngay_gio_in", typeof(DateTime));
			foreach (var indexData in listData)
			{
				dt.Rows.Add(indexData.ma_hoa_don, indexData.ma_san_pham, indexData.ma_khuyen_mai, indexData.so_luong, indexData.don_gia, indexData.ngay_gio_in);
			}
			return dt;
		}

		// Trong KhachHangBUS.cs

		public float LayUuDaiCuaKhachBangMaHD(string maHD)
		{
			XepHangDLL xepHangBUS = new XepHangDLL();
			// Gọi xuống DLL
			return xepHangBUS.GetUuDaiByMaHoaDon(maHD);
		}
	}
}
