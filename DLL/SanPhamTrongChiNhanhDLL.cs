using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DLL.SanPhamTrongKhoTongDLL;

namespace DLL
{
    public class SanPhamTrongChiNhanhDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext(ConnectDLL.ReadConnectionString());
        public SanPhamTrongChiNhanhDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<san_pham_trong_chi_nhanh> getAllSanPhamTrongChiNhanh()
        {
            return db.san_pham_trong_chi_nhanhs.ToList();
        }
        public void updateSoLuongNhapKho(string machinhanh, string masanpham, int soluong)
        {
            var sptrongchinhanh = db.san_pham_trong_chi_nhanhs.Where(x => x.ma_chi_nhanh.Trim() == machinhanh.Trim() && x.ma_san_pham.Trim() == masanpham.Trim()).FirstOrDefault();
            if (sptrongchinhanh != null)
            {
                sptrongchinhanh.so_luong += soluong;
            }
            db.SubmitChanges();
        }

		public TruKhoStatus TruSoLuongKhoChiNhanh(string maSP, string maCN, int soLuongCanTru)
		{
			try
			{
				var khoChiNhanh = db.san_pham_trong_chi_nhanhs.SingleOrDefault(k =>
					k.ma_san_pham.Trim() == maSP.Trim() &&
					k.ma_chi_nhanh.Trim() == maCN.Trim());

				if (khoChiNhanh == null)
				{
					return TruKhoStatus.KhoNotFound; // Lỗi 1
				}

				if (khoChiNhanh.so_luong < soLuongCanTru)
				{
					return TruKhoStatus.KhongDuHang; // Lỗi 2
				}

				khoChiNhanh.so_luong = khoChiNhanh.so_luong - soLuongCanTru;
				db.SubmitChanges();
				return TruKhoStatus.ThanhCong; // Thành công
			}
			catch (Exception)
			{
				return TruKhoStatus.Loi; // Lỗi Database
			}
		}
	}
}
