using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class SanPhamTrongKhoTongDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
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
            var sptrongkhotong = db.san_pham_trong_kho_tongs.Where(x => x.ma_kho == makho && x.ma_san_pham == masanpham).FirstOrDefault();
            if (sptrongkhotong != null)
            {
                sptrongkhotong.so_luong += soluong;
            }
            db.SubmitChanges();
        }
    }
}
