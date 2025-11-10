using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class XuatKhoBUS
    {
        public class XuatKho
        {
            public string maphieu { get; set; }
            public string makho { get; set; }
            public string masanpham { get; set; }
            public string manhanviennhapkho { get; set; }
            public int soluong { get; set; }
            public string machinhanh { get; set; }

            public XuatKho()
            {
                this.maphieu = "";
                this.makho = "";
                this.masanpham = "";
                this.manhanviennhapkho = "";
                this.soluong = 0;
                this.machinhanh = "";
            }
        }
        private XuatKhoDLL xuatkhodll = new XuatKhoDLL();
        public List<XuatKho> getAllXuatKho()
        {
            List<XuatKho> list = new List<XuatKho>();
            foreach (var item in xuatkhodll.getAllPhieuXuat())
            {
                XuatKho nk = new XuatKho();
                nk.maphieu = item.ma_phieu_xuat;
                nk.makho = item.ma_kho;
                nk.masanpham = item.ma_san_pham;
                nk.manhanviennhapkho = item.ma_nhan_vien_kiem_tra;
                nk.soluong = item.so_luong ?? 0;
                nk.machinhanh = item.ma_chi_nhanh_nhap;
                list.Add(nk);
            }
            return list;
        }
        public int addXuatKho(XuatKho nk)
        {
            DLL.phieu_xuat_kho xuatkho = new DLL.phieu_xuat_kho()
            {
                ma_phieu_xuat = createMaPhieuXuat(),
                ma_kho = nk.makho,
                ma_san_pham = nk.masanpham,
                ma_nhan_vien_kiem_tra = nk.manhanviennhapkho,
                so_luong = nk.soluong,
                ma_chi_nhanh_nhap = nk.machinhanh
            };
            try
            {
                return xuatkhodll.addPhieuXuat(xuatkho);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateXuatKho(XuatKho nk)
        {
            DLL.phieu_xuat_kho xuatkho = new DLL.phieu_xuat_kho()
            {
                ma_phieu_xuat = nk.maphieu,
                ma_kho = nk.makho,
                ma_san_pham = nk.masanpham,
                ma_nhan_vien_kiem_tra = nk.manhanviennhapkho,
                so_luong = nk.soluong,
                ma_chi_nhanh_nhap = nk.machinhanh
            };
            return xuatkhodll.updateXuatKho(xuatkho);
        }
        public string createMaPhieuXuat()
        {
            var khotongcuoicung = xuatkhodll.getAllPhieuXuat().LastOrDefault();
            if (khotongcuoicung != null)
            {
                string makhotongcuoi = khotongcuoicung.ma_kho;
                int so = int.Parse(makhotongcuoi.Substring(2)) + 1;
                return "PX" + so.ToString();
            }
            else
            {
                return "PX10000001";
            }
        }

        public List<XuatKho> searchXuatKho(string maphieuxuat)
        {
            List<XuatKho> list = new List<XuatKho>();
            foreach (var item in getAllXuatKho())
            {
                if (item.maphieu == maphieuxuat)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
