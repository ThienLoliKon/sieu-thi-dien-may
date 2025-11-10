using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class XuatKhoDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
        public XuatKhoDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<phieu_xuat_kho> getAllPhieuXuat()
        {
            return db.phieu_xuat_khos.ToList();
        }
        public int addPhieuXuat(phieu_xuat_kho nk)
        {
            try
            {
                db.phieu_xuat_khos.InsertOnSubmit(nk);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi them phieu xuat: " + ex.Message);
            }
            return 1;
        }
        public int updateXuatKho(phieu_xuat_kho kt)
        {
            try
            {
                var xuatkho = db.phieu_xuat_khos.SingleOrDefault(n => n.ma_phieu_xuat == kt.ma_phieu_xuat);
                if (xuatkho != null)
                {
                    xuatkho.ma_kho = kt.ma_kho;
                    xuatkho.ma_san_pham = kt.ma_san_pham;
                    xuatkho.ma_nhan_vien_kiem_tra = kt.ma_nhan_vien_kiem_tra;
                    xuatkho.so_luong = kt.so_luong;
                    xuatkho.ma_chi_nhanh_nhap = kt.ma_chi_nhanh_nhap;
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
