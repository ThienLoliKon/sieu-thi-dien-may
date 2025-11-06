using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhoTongBUS
    {
        public class KhoTong
        {
            public string makho { get; set; }
            public string tenkho { get; set; }
            public string diachi { get; set; }
            public string quanly { get; set; }
            public double succhua { get; set; }

            public KhoTong()
            {
                this.makho = "";
                this.tenkho = "";
                this.diachi = "";
                this.quanly = "";
                this.succhua = 0;
            }
        }
        private KhoTongDLL khotongdll = new KhoTongDLL();
        public List<KhoTong> getAllKhoTong()
        {
            List<KhoTong> list = new List<KhoTong>();
            foreach (var item in khotongdll.getAllKhoTong())
            {
                KhoTong kt = new KhoTong();
                kt.makho = item.ma_kho;
                kt.tenkho = item.ten_kho;
                kt.quanly = item.nhan_vien_quan_ly;
                kt.diachi = item.dia_chi;

                list.Add(kt);
            }
            return list;
        }
        public int addKhoTong(KhoTong kt)
        {
            DLL.kho_tong khotong = new DLL.kho_tong()
            {
                ma_kho = createMaKhoTong(),
                ten_kho = kt.tenkho,
                dia_chi = kt.diachi,
                nhan_vien_quan_ly = kt.quanly,
                suc_chua = kt.succhua,
            };
            try
            {
                return khotongdll.addKhoTong(khotong);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateKhoTong(KhoTong kt)
        {
            DLL.kho_tong khotong = new DLL.kho_tong()
            {
                ma_kho = kt.makho,
                ten_kho = kt.tenkho,
                dia_chi = kt.diachi,
                nhan_vien_quan_ly = kt.quanly,
                suc_chua = kt.succhua
            };
            return khotongdll.updateKhoTong(khotong);
        }
        public string createMaKhoTong()
        {
            var khotongcuoicung = khotongdll.getAllKhoTong().LastOrDefault();
            if (khotongcuoicung != null)
            {
                string makhotongcuoi = khotongcuoicung.ma_kho;
                int so = int.Parse(makhotongcuoi.Substring(2)) + 1;
                return "KT" + so.ToString();
            }
            else
            {
                return "KT10000001";
            }
        }
        public bool ngungHoatDongKhoTong(string makho)
        {
            try
            {
                var khotong = khotongdll.getAllKhoTong().SingleOrDefault(n => n.ma_kho == makho);
                if (khotong != null)
                {
                    //khotong.trang_thai = false;
                    khotongdll.updateKhoTong(khotong);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public List<KhachHang> searchKhachHang(string ma, string ten, string sdt)
        //{
        //    List<KhachHang> list = new List<KhachHang>();
        //    foreach (var item in khotongdll.getAllKhachHang())
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
        //    var hoadons = khotongdll.getAllHoaDonKhachHang(makh);
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
        //    var listxh = khotongdll.getAllXepHang();
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
