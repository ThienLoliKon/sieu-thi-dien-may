using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class XepHangDLL
    {
        DBSTDMDataContext db = new DBSTDMDataContext();
        public XepHangDLL()
        {
            if (!db.DatabaseExists())
            {
                //db.CreateDatabase();
            }
        }
        public List<xep_hang> getAllXepHang()
        {
            return db.xep_hangs.ToList();
        }
        public int AddXepHang(xep_hang xh)
        {
            try
            {
                db.xep_hangs.InsertOnSubmit(xh);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                //throw new Exception(xh.xep_hang);
                throw new Exception("Loi khi them khach hang: "+ex.Message);
            }
            return 1;
        }
        public int UpdateRank(xep_hang xh)
        {
            try
            {
                var xephang = db.xep_hangs.SingleOrDefault(n => n.ma_hang == xh.ma_hang);
                if (xephang != null)
                {
                    xephang.ma_hang = xh.ma_hang;
                    xephang.ten_hang = xh.ten_hang;
                    xephang.yeu_cau = xh.yeu_cau;
                    xephang.uu_dai = xh.uu_dai;
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

        public int deleteRank(string mahang)
        {
            try
            {
                db.xep_hangs.DeleteOnSubmit(db.xep_hangs.SingleOrDefault(n => n.ma_hang == mahang));
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

		// Trong KhachHangDLL.cs

		// Trong file HoaDonDLL.cs

		public float GetUuDaiByMaHoaDon(string maHD)
		{
			using (DBSTDMDataContext db = new DBSTDMDataContext())
			{
				var query = from hd in db.hoa_dons
								// 1. Nối Hóa Đơn với Khách Hàng qua ma_khach_hang
							join kh in db.khach_hangs on hd.ma_khach_hang equals kh.ma_khach_hang

							// 2. Nối Khách Hàng với Xếp Hạng
							// Cột 'xep_hang' trong bảng Khách Hàng nối với 'ma_hang' trong bảng Xếp Hạng
							join xh in db.xep_hangs on kh.xep_hang equals xh.ma_hang

							// 3. Điều kiện lọc
							where hd.ma_hoa_don == maHD

							// 4. Lấy kết quả
							select xh.uu_dai;

				// Lấy giá trị đầu tiên tìm thấy
				double? result = query.FirstOrDefault();

				if (result != null)
				{
					return Convert.ToSingle(result);
				}
				else
				{
					return 0f;
				}
			}
		}
	}
}
