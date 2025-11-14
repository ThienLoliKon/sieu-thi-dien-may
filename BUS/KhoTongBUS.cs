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
        public void xoaKhoTong(string makho)
        {
            khotongdll.xoaKhoTong(makho);
        }
        public KhoTong searchKhoTong(string ten_kho_ma_kho)
        {
            var khotong = getAllKhoTong();
            foreach (var item in khotong)
            {
                if (item.makho == ten_kho_ma_kho || item.tenkho == ten_kho_ma_kho)
                {
                    return item;
                }
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
