using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamTrongKhoTongBUS
    {
        public class SanPhamTrongKhoTong
        {
            public string makho { get; set; }
            public string masanpham { get; set; }
            public string tensanpham { get; set; }
            public int soluong { get; set; }

            public SanPhamTrongKhoTong()
            {
                this.makho = "";
                this.masanpham = "";
                this.soluong = 0;
            }
        }
        private SanPhamTrongKhoTongDLL sanphamtrongkhotongdll = new SanPhamTrongKhoTongDLL();
        public List<SanPhamTrongKhoTong> getAllSanPhamTrongKhoTong(string makho = "")
        {
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPhamTrongKhoTong> list = new List<SanPhamTrongKhoTong>();
            foreach (var item in sanphamtrongkhotongdll.getAllSanPhamTrongKhoTong())
            {
                if (item.ma_kho != makho)
                {
                    continue;
                }
                SanPhamTrongKhoTong sptkt = new SanPhamTrongKhoTong();
                sptkt.makho = item.ma_kho;
                sptkt.masanpham = item.ma_san_pham;
                sptkt.soluong = item.so_luong ?? 0;
                sptkt.tensanpham = sanphambus.getTenSanPham(sptkt.masanpham);
                list.Add(sptkt);
            }
            return list;
        }
        public List<SanPhamTrongKhoTong> searchSPTrongKhoTong(string input)
        {
            List<SanPhamTrongKhoTong> list = new List<SanPhamTrongKhoTong>();
            foreach (var item in getAllSanPhamTrongKhoTong())
            {
                if (item.masanpham.Contains(input) || item.tensanpham.Contains(input))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public void updateSoLuongNhapKho(string makho, string masanpham, int soluong)
        {
            sanphamtrongkhotongdll.updateSoLuongNhapKho(makho, masanpham, soluong);
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
    //        return "KH10000001";
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
    //    decimal sumtien = 0;
    //    foreach (var hd in hoadons)
    //    {
    //        sumtien = hd.so_luong.Value;
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
