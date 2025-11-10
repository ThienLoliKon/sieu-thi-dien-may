using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class SanPhamTrongChiNhanhDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
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
            var sptrongchinhanh = db.san_pham_trong_chi_nhanhs.Where(x => x.ma_chi_nhanh == machinhanh && x.ma_san_pham == masanpham).FirstOrDefault();
            if (sptrongchinhanh != null)
            {
                sptrongchinhanh.so_luong += soluong;
            }
            db.SubmitChanges();
        }
    }
}
