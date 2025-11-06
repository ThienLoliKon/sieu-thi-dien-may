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
        public int updateKhoTong(phieu_nhap_kho kt)
        {
            try
            {
                var khotong = db.phieu_nhap_khos.SingleOrDefault(n => n.ma_kho == kt.ma_kho);
                if (khotong != null)
                {
                    khotong.ma_kho = kt.ma_kho;
                    khotong.ten_kho = kt.ten_kho;
                    khotong.dia_chi = kt.dia_chi;
                    khotong.nhan_vien_quan_ly = kt.nhan_vien_quan_ly;
                    khotong.suc_chua = kt.suc_chua;
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
