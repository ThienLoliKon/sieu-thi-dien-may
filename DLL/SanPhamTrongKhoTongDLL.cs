using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
	public class SanPhamTrongKhoTongDLL
	{
		public enum TruKhoStatus { ThanhCong, KhoNotFound, KhongDuHang, Loi }
		DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
        public SanPhamTrongKhoTongDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<san_pham_trong_kho_tong> getAllSanPhamTrongKhoTong()
        {
            return db.san_pham_trong_kho_tongs.ToList();
        }
        public void updateSoLuongNhapKho(string makho, string masanpham, int soluong)
        {
            var sptrongkhotong = db.san_pham_trong_kho_tongs.SingleOrDefault(x => x.ma_kho.Trim() == makho.Trim() && x.ma_san_pham.Trim() == masanpham.Trim());
            if (sptrongkhotong != null)
            {
                sptrongkhotong.so_luong += soluong;
            }
            db.SubmitChanges();
        }
        public bool addSanPhamVaoKhoTong(string makho, string masanpham, int soluong)
        {
            try
            {
                san_pham_trong_kho_tong sptrongkhotong = new san_pham_trong_kho_tong();
                sptrongkhotong.ma_kho = makho;
                sptrongkhotong.ma_san_pham = masanpham;
                sptrongkhotong.so_luong = soluong;
                db.san_pham_trong_kho_tongs.InsertOnSubmit(sptrongkhotong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool checkTonTaiSanPhamTrongKhoTong(string makho, string masanpham)
        {
            return db.san_pham_trong_kho_tongs.Any(x => x.ma_kho.Trim() == makho.Trim() && x.ma_san_pham.Trim() == masanpham.Trim());
            //var sptrongkhotong = db.san_pham_trong_kho_tongs.SingleOrDefault(x => x.ma_kho.Trim() == makho.Trim() && x.ma_san_pham.Trim() == masanpham.Trim());
            //if (sptrongkhotong != null)
            //{
            //    return true;
            //}
            //return false;
        }
    }
		//public bool TruSoLuongKhoChiNhanh(string maSP, string maCN, int soLuongCanTru)
		//{
		//	try
		//	{
		//		// 1. Tìm kho của chi nhánh
		//		var khoChiNhanh = db.san_pham_trong_chi_nhanhs.SingleOrDefault(k =>
		//			k.ma_san_pham.Trim() == maSP.Trim() &&
		//			k.ma_chi_nhanh.Trim() == maCN.Trim());

		//		// 2. Kiểm tra xem kho có tồn tại và đủ hàng không
		//		if (khoChiNhanh == null)
		//		{
		//			// Lỗi: Sản phẩm này không tồn tại trong kho chi nhánh
		//			return false;
		//		}

		//		if (khoChiNhanh.so_luong < soLuongCanTru)
		//		{
		//			// Lỗi: Không đủ hàng trong kho
		//			return false;
		//		}

		//		// 3. Đủ hàng -> Trừ kho
		//		khoChiNhanh.so_luong = khoChiNhanh.so_luong - soLuongCanTru;

		//		// 4. Lưu thay đổi
		//		// (Lưu ý: Nếu hàm này được gọi từ TransactionScope, 
		//		// SubmitChanges() sẽ chỉ ghi tạm, chưa Commit)
		//		db.SubmitChanges();

		//		return true; // Báo thành công
		//	}
		//	catch (Exception)
		//	{
		//		return false; // Báo thất bại nếu có lỗi
		//	}
		//}
	}

