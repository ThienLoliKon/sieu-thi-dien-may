using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace BUS
{
    public class KhachHangBUS
    {
        public class KhachHang
        {
            public string makhachhang { get; set; }
            public string tenkhachhang { get; set; }
            public string sdt { get; set; }
            public string diachi { get; set; }
            public string xephang { get; set; }
            public int diem { get; set; }

            public KhachHang()
            {
                this.makhachhang = "";
                this.tenkhachhang = "";
                this.sdt = "";
                this.diachi = "";
                this.xephang = "bronze";
                this.diem = 0;
            }
        }
        private KhachHangDLL khachhangdll = new KhachHangDLL();
        public List<KhachHang> GetAllKhachHang()
        {
            //khachhangdll = new KhachHangDLL();
            List<KhachHang> list = new List<KhachHang>();
            foreach (var item in khachhangdll.getAllKhachHang())
            {
                KhachHang kh = new KhachHang();
                kh.makhachhang = item.ma_khach_hang;
                kh.tenkhachhang = item.ho_ten_khach_hang;
                kh.sdt = item.sdt;
                kh.diachi = item.diachi;
                //kh.xephang = item.xep_hang;
                kh.diem = tinhTongTienHoaDonThanhDiem(kh.makhachhang);
				//kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                kh.xephang = xepHangKhachHang(kh.diem);
                //kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                list.Add(kh);
            }
            return list;
        }
        public int addKhachHang(KhachHang kh)
        {
            DLL.khach_hang khach = new DLL.khach_hang()
            {
                ma_khach_hang = createMaKhachHang(),
                ho_ten_khach_hang = kh.tenkhachhang,
                sdt = kh.sdt,
                diachi = kh.diachi,
                xep_hang = "XH10000001",
                diem = 0
            };
            try
            {
                return khachhangdll.AddKhachHang(khach);
            }
            catch (Exception ex)
            {
                throw new Exception(kh.xephang.ToString());
            }
        }
        public int updateKhachHang(KhachHang kh)
        {
            DLL.khach_hang khach = new DLL.khach_hang()
            {
                ma_khach_hang = kh.makhachhang,
                ho_ten_khach_hang = kh.tenkhachhang,
                sdt = kh.sdt,
                diachi = kh.diachi,
            };
            return khachhangdll.updateKhachHang(khach);
        }
        public string createMaKhachHang()
        {
            var khachhangcuoicung = khachhangdll.getAllKhachHang().LastOrDefault();
            if (khachhangcuoicung != null)
            {
                string makhcuoicung = khachhangcuoicung.ma_khach_hang;
                int so = int.Parse(makhcuoicung.Substring(2)) + 1;
                return "KH" + so.ToString();
            }
            else
            {
                return "KH10000001";
            }
        }
        public List<KhachHang> searchKhachHang(string ma, string ten, string sdt)
        {
            List<KhachHang> list = new List<KhachHang>();
            foreach (var item in khachhangdll.getAllKhachHang())
            {
                if (item.ma_khach_hang.Contains(ma) || item.ho_ten_khach_hang.Contains(ten) || item.sdt.Contains(sdt))
                {
                    KhachHang kh = new KhachHang();
                    kh.makhachhang = item.ma_khach_hang;
                    kh.tenkhachhang = item.ho_ten_khach_hang;
                    kh.sdt = item.sdt;
                    kh.diachi = item.diachi;
                    kh.diem = tinhTongTienHoaDonThanhDiem(item.ma_khach_hang);
                    kh.xephang = xepHangKhachHang(kh.diem);
                    list.Add(kh);
                }
            }
            return list;
        }
        public int tinhTongTienHoaDonThanhDiem(string makh)
        {
            int tongtien = 0;
            var hoadons = khachhangdll.getAllHoaDonKhachHang(makh);
            decimal sumtien = 0;
            foreach (var hd in hoadons)
            {
                sumtien = hd.so_luong.Value ;
                tongtien += (int)sumtien;
            }
            return tongtien/1000;
        }
        public string xepHangKhachHang(int diem)
        {
            string rank = "XH10000001";
            var listxh = khachhangdll.getAllXepHang();
            foreach (var xh in listxh)
            {
                if (diem >= xh.yeu_cau)
                {
                    rank = xh.ma_hang;
                }
                else
                {
                    break;
                }
            }
            return rank;
        }
    }
}
