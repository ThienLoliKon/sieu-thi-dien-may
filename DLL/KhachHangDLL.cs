using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class KhachHangDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
        public KhachHangDLL()
        {
            if(!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }   
        }
        public List<khach_hang> getAllKhachHang()
        {
            return db.khach_hangs.ToList();
        }
        public int AddKhachHang(khach_hang kh)
        {
            try
            {
                db.khach_hangs.InsertOnSubmit(kh);
                db.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(kh.xep_hang);
                //throw new Exception("Loi khi them khach hang: "+ex.Message);
            }
            return 1;
        }
        public int updateKhachHang(khach_hang kh)
        {
            try
            {
                var khach = db.khach_hangs.SingleOrDefault(n => n.ma_khach_hang == kh.ma_khach_hang);
                if (khach != null)
                {
                    khach.ho_ten_khach_hang = kh.ho_ten_khach_hang;
                    khach.sdt = kh.sdt;
                    khach.diachi = kh.diachi;
                    khach.xep_hang = kh.xep_hang;
                    khach.diem = kh.diem;
                    db.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }
        public List<chi_tiet_hoa_don> getAllHoaDonKhachHang(string makh)
        {
            //var danhsachhoadoncuakhachhang = ;
            var listhoadon = from cthd in db.chi_tiet_hoa_dons
                             join hd in db.hoa_dons on cthd.ma_hoa_don equals hd.ma_hoa_don
                             where hd.ma_khach_hang == makh
                             select cthd;
            return listhoadon.ToList();
        }
        public List<xep_hang> getAllXepHang()
        {
            return db.xep_hangs.OrderBy(xh => xh.yeu_cau).ToList();
        }
    }
}
