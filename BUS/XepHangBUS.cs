using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class XepHangBUS
    {
        public class XepHang
        {
            public string mahang { get; set; }
            public string tenhang { get; set; }
            public double yeucau { get; set; }
            public double uudai { get; set; }

            public XepHang()
            {
                this.mahang = "";
                this.tenhang = "";
                this.yeucau = 0;
                this.uudai = 0;
            }
        }
        private XepHangDLL xephangdll = new XepHangDLL();
        public List<XepHang> getAllRank()
        {
            //khachhangdll = new KhachHangDLL();
            List<XepHang> list = new List<XepHang>();
            foreach (var item in xephangdll.getAllXepHang())
            {
                XepHang xh = new XepHang();
                xh.mahang = item.ma_hang;
                xh.tenhang = item.ten_hang;
                xh.yeucau = item.yeu_cau ?? 0;
                xh.uudai = item.uu_dai ?? 0;
                //kh.xephang = item.xep_hang;
                //kh.diem = item.diem.HasValue ? item.diem.Value : 0;
                list.Add(xh);
            }
            return list;
        }
        public int addRank(XepHang xh)
        {
            if (checkTrungIDRank(xh.mahang) == true)
            {
                throw new Exception("Duplicated rank id!!!");
            }
            DLL.xep_hang xephang = new DLL.xep_hang()
            {
                ma_hang = xh.mahang,
                ten_hang = xh.tenhang,
                yeu_cau = xh.yeucau,
                uu_dai = xh.uudai,
            };
            try
            {
                return xephangdll.AddXepHang(xephang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateRank(XepHang xh)
        {
            DLL.xep_hang xephang = new DLL.xep_hang()
            {
                ma_hang = xh.mahang,
                ten_hang = xh.tenhang,
                yeu_cau = xh.yeucau,
                uu_dai = xh.uudai,
            };
            return xephangdll.UpdateRank(xephang);
        }
        public bool checkTrungIDRank(string id)
        {
            var listrank = xephangdll.getAllXepHang();
            foreach (var r in listrank)
            {
                if (r.ma_hang == id)
                {
                    return true;
                }
            }
            return false;
        }
        public int deleteRank(string id)
        {
            try
            {
                return xephangdll.deleteRank(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public int addKhachHang(KhachHang kh)
        //{
        //    DLL.khach_hang khach = new DLL.khach_hang()
        //    {
        //        ma_khach_hang = createMaKhachHang(),
        //        ho_ten_khach_hang = kh.tenkhachhang,
        //        sdt = kh.sdt,
        //        diachi = kh.diachi,
        //        xep_hang = "bronze",
        //        diem = 0
        //    };
        //    try
        //    {
        //        return khachhangdll.AddKhachHang(khach);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(kh.xephang.ToString());
        //    }
        //}
        //public int updateKhachHang(KhachHang kh)
        //{
        //    DLL.khach_hang khach = new DLL.khach_hang()
        //    {
        //        ma_khach_hang = kh.makhachhang,
        //        ho_ten_khach_hang = kh.tenkhachhang,
        //        sdt = kh.sdt,
        //        diachi = kh.diachi,
        //    };
        //    return khachhangdll.updateKhachHang(khach);
        //}
        //public string createMaKhachHang()
        //{
        //    var khachhangcuoicung = khachhangdll.getAllKhachHang().LastOrDefault();
        //    if (khachhangcuoicung != null)
        //    {
        //        string makhcuoicung = khachhangcuoicung.ma_khach_hang;
        //        int so = int.Parse(makhcuoicung.Substring(2)) + 1;
        //        return "KH" + so.ToString();
        //    }
        //    else
        //    {
        //        return "KH0001";
        //    }
        //}
        //public List<KhachHang> searchKhachHang(string ma, string ten, string sdt)
        //{
        //    List<KhachHang> list = new List<KhachHang>();
        //    foreach (var item in khachhangdll.getAllKhachHang())
        //    {
        //        if (item.ma_khach_hang.Contains(ma) || item.ho_ten_khach_hang.Contains(ten) || item.sdt.Contains(sdt))
        //        {
        //            KhachHang kh = new KhachHang();
        //            kh.makhachhang = item.ma_khach_hang;
        //            kh.tenkhachhang = item.ho_ten_khach_hang;
        //            kh.sdt = item.sdt;
        //            kh.diachi = item.diachi;
        //            kh.diem = tinhTongTienHoaDonThanhDiem(item.ma_khach_hang);
        //            kh.xephang = xepHangKhachHang(kh.diem);
        //            list.Add(kh);
        //        }
        //    }
        //    return list;
        //}
        //public int tinhTongTienHoaDonThanhDiem(string makh)
        //{
        //    int tongtien = 0;
        //    var hoadons = khachhangdll.getAllHoaDonKhachHang(makh);
        //    double sumtien = 0;
        //    foreach (var hd in hoadons)
        //    {
        //        sumtien = hd.so_luong.Value * hd.don_gia.Value;
        //        tongtien += (int)sumtien;
        //    }
        //    return tongtien / 1000;
        //}
        //public string xepHangKhachHang(int diem)
        //{
        //    string rank = "bronze";
        //    var listxh = khachhangdll.getAllXepHang();
        //    foreach (var xh in listxh)
        //    {
        //        if (diem >= xh.yeu_cau)
        //        {
        //            rank = xh.ma_hang;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    return rank;
        //}
    }
}
