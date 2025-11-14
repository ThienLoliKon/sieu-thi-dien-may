using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class NhapKhoDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
        public NhapKhoDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<phieu_nhap_kho> getAllPhieuNhap()
        {
            return db.phieu_nhap_khos.ToList();
        }
        public int addPhieuNhap(phieu_nhap_kho nk)
        {
            try
            {
                db.phieu_nhap_khos.InsertOnSubmit(nk);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi them khach hang: " + ex.Message);
            }
            return 1;
        }
        public int updatePN(phieu_nhap_kho kt)
        {
            try
            {
                var khotong = db.phieu_nhap_khos.SingleOrDefault(n => n.ma_phieu_nhap == kt.ma_phieu_nhap);
                if (khotong != null)
                {
                    khotong.ma_kho = kt.ma_kho;
                    khotong.ma_san_pham = kt.ma_san_pham;
                    khotong.ma_nhan_vien_kiem_tra = kt.ma_nhan_vien_kiem_tra;
                    khotong.so_luong = kt.so_luong;
                    khotong.don_gia = kt.don_gia;
                    db.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;
        }
        public int xoaKhoTong(string makho)
        {
            try
            {
                var khotong = db.kho_tongs.SingleOrDefault(n => n.ma_kho == makho);
                if (khotong != null)
                {
                    khotong.suc_chua = 0;
                    db.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return 0;
        }
    }
}
