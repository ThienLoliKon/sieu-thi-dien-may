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
}
