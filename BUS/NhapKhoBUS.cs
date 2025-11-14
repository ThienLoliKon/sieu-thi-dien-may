using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhapKhoBUS
    {
        public class NhapKho
        {
            public string maphieu { get; set; }
            public string makho { get; set; }
            public string masanpham { get; set; }
            public string manhanviennhapkho { get; set; }
            public int soluong { get; set; }
            public decimal dongia {  get; set; }

            public NhapKho()
            {
                this.maphieu = "";
                this.makho = "";
                this.masanpham = "";
                this.manhanviennhapkho = "";
                this.soluong = 0;
                this.dongia = 0;
            }
        }
        private NhapKhoDLL nhapkhodll = new NhapKhoDLL();
        public List<NhapKho> getAllNhapKho()
        {
            List<NhapKho> list = new List<NhapKho>();
            foreach (var item in nhapkhodll.getAllPhieuNhap())
            {
                NhapKho nk = new NhapKho();
                nk.maphieu = item.ma_phieu_nhap;
                nk.makho = item.ma_kho;
                nk.masanpham = item.ma_san_pham;
                nk.manhanviennhapkho = item.ma_nhan_vien_kiem_tra;
                nk.soluong = item.so_luong ?? 0;
                nk.dongia = item.don_gia ?? 0;
                list.Add(nk);
            }
            return list;
        }
        public int addPhieuNhap(NhapKho nk)
        {
            DLL.phieu_nhap_kho nhapkho = new DLL.phieu_nhap_kho()
            {
                ma_phieu_nhap = createMaPN(),
                ma_kho = nk.makho,
                ma_san_pham = nk.masanpham,
                ma_nhan_vien_kiem_tra = nk.manhanviennhapkho,
                so_luong = nk.soluong,
                don_gia = nk.dongia
            };
            try
            {
                return nhapkhodll.addPhieuNhap(nhapkho);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateNhapKho(NhapKho nk)
        {
            DLL.phieu_nhap_kho nhapkho = new DLL.phieu_nhap_kho()
            {
                ma_phieu_nhap = nk.maphieu,
                ma_kho = nk.makho,
                ma_san_pham = nk.masanpham,
                ma_nhan_vien_kiem_tra = nk.manhanviennhapkho,
                so_luong = nk.soluong,
                don_gia = nk.dongia
            };
            return nhapkhodll.updatePN(nhapkho);
        }
        public string createMaPN()
        {
            var itemcuoi = nhapkhodll.getAllPhieuNhap().LastOrDefault();
            if (itemcuoi != null)
            {
                string makhotongcuoi = itemcuoi.ma_phieu_nhap;
                int so = int.Parse(makhotongcuoi.Substring(2)) + 1;
                return "PN" + so.ToString();
            }
            else
            {
                return "PN10000001";
            }
        }
        
        public List<NhapKho> searchNhapKho(string maphieunhap, string makho)
        {
            List<NhapKho> list = new List<NhapKho>();
            foreach (var item in getAllNhapKho())
            {
                if (item.maphieu == maphieunhap && item.makho == makho)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<NhapKho> searchNhapKhoTheoKho(string makho)
        {
            List<NhapKho> list = new List<NhapKho>();
            foreach (var item in getAllNhapKho())
            {
                if (item.makho == makho)
                {
                    list.Add(item);
                }
            }
            return list;
        }
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
