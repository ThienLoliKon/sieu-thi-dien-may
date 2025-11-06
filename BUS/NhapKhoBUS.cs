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
        public void xoaKhoTong(string makho)
        {
            khotongdll.xoaKhoTong(makho);
        }
        public KhoTong searchKhoTong(string ten_kho_ma_kho)
        {
            var khotong = getAllKhoTong().FirstOrDefault();
            if (khotong != null)
            {
                return khotong;
            }
            return null;
        }
        public List<KhoTong> searchAllKhoTong(string makho, string tenkho)
        {
            List<KhoTong> listkhotong = new List<KhoTong>();
            foreach (var item in getAllKhoTong())
            {
                if (item.makho == makho || item.tenkho == tenkho)
                {
                    listkhotong.Add(item);
                }
            }
            return listkhotong;
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
