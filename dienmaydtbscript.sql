--drop database dien_may
create database dien_may;
go
use dien_may;
go

-- Sản phẩm
create table san_pham (
    ma_san_pham char(10) primary key,
    ten_san_pham nvarchar(100),
    ma_nha_san_xuat char(10),
    ma_nha_cung_cap char(10),
    khoi_luong float,
    thoi_gian_bao_hanh int,
    gia_tien DECIMAL(18, 0),
    ngay_san_xuat date
);
go

-- Nhân viên
create table nhan_vien (
    ma_nhan_vien char(10) primary key,
    ho_va_ten nvarchar(50),
    ma_cap_bac char(10),
    so_dien_thoai char(12),
    dia_chi_thuong_tru nvarchar(200),
    ma_chi_nhanh char(10),
    trang_thai bit
);
go

-- Nhà cung cấp
create table nha_cung_cap (
    ma_nha_cung_cap char(10) primary key,
    ten_nha_cung_cap nvarchar(50),
    dia_chi_nha_cung_cap nvarchar(100)
);
go

-- Nhà sản xuất
create table nha_san_xuat (
    ma_nha_san_xuat char(10) primary key,
    ten_nha_san_xuat nvarchar(50),
    dia_chi_nha_san_xuat nvarchar(100)
);
go

-- Kho tổng
create table kho_tong (
    ma_kho char(10) primary key,
    nhan_vien_quan_ly char(10),
    ten_kho nvarchar(50),
    dia_chi nvarchar(50),
    suc_chua float
);
go

-- Sản phẩm trong kho tổng (N-N giữa kho và sản phẩm)
create table san_pham_trong_kho_tong (
    ma_kho char(10),
    ma_san_pham char(10),
    so_luong int,
    primary key (ma_kho, ma_san_pham)
);
go

-- Phiếu nhập kho
create table phieu_nhap_kho (
    ma_phieu_nhap char(10) primary key,
    ma_kho char(10),
    ma_san_pham char(10),
    ma_nhan_vien_kiem_tra char(10),
    so_luong int,
    don_gia DECIMAL(18, 0)
);
go

-- Phiếu xuất kho
create table phieu_xuat_kho (
    ma_phieu_xuat char(10) primary key,
    ma_kho char(10),
    ma_san_pham char(10),
    ma_chi_nhanh_nhap char(10),
    ma_nhan_vien_kiem_tra char(10),
    so_luong int
);
go

-- Sản phẩm trong chi nhánh (N-N giữa chi nhánh và sản phẩm)
create table san_pham_trong_chi_nhanh (
    ma_chi_nhanh char(10),
    ma_san_pham char(10),
    so_luong int,
    primary key (ma_chi_nhanh, ma_san_pham)
);
go

-- Hóa đơn
create table hoa_don (
    ma_hoa_Don char(10)
    ma_nhan_vien_lap char(10),
    ma_khach_hang char(10),
    ngay_lap datetime,
    primary key (ma_hoa_don)
);
go

-- Chi tiết hóa đơn (N-N giữa hóa đơn và sản phẩm)
create table chi_tiet_hoa_don (
    ma_hoa_don char(10),
    ma_san_pham char(10),
    ma_khuyen_mai char(10),
    so_luong int,
    don_gia DECIMAL(18, 0),
    ngay_gio_in datetime,
    primary key (ma_hoa_don, ma_san_pham)
);
go

create table khuyen_mai (
    ma_khuyen_mai char(10),
    giam_gia float,
    ma_loai_hang char(10),
    ngay_bat_dau datetime,
    ngay_ket_thuc datetime,
    primary key (ma_khuyen_mai)
);
go


create table loai_hang (
    ma_loai_hang char(10) primary key,
    ten_loai_hang nvarchar (100),
    mo_ta nvarchar (100)
);
go

create table bao_hanh(
ma_bao_hanh char(10) primary key,
ma_san_pham char(10),
ma_khach_hang char(10),
nhan_vien_bao_hanh char(10),
ly_do nvarchar (100),
ngay_gui datetime,
ngay_xong datetime,
hoan_thanh bit
);
go

create table san_pham_loai_hang(
    ma_san_pham char(10),
    ma_loai_hang char(10),
    primary key (ma_san_pham,ma_loai_hang)

);
go


-- Tài khoản
create table tai_khoan(
    ma_nhan_vien char(10) primary key,
    mat_khau char(10),
    quyen char(10)
);

go

-- Chi nhánh
create table chi_nhanh(
    ma_chi_nhanh char(10) primary key,
    ten_chi_nhanh nvarchar(50),
    dia_chi nvarchar(200),
    khu_vuc char(10)
);
go

create table khu_vuc(
ma_khu_vuc char(10) primary key,
ten_khu_vuc nvarchar(50),
nhan_vien_quan_ly char(10)
)
go

-- Điểm danh
create table diem_danh (
    ma_diem_danh char(10) primary key,
    ma_nhan_vien char(10),
    thoi_gian_vao datetime,
    thoi_gian_ra datetime
);
go

-- Lương
create table luong(
    ma_phieu_luong char(10) primary key,
    ma_nhan_vien char(10),
    luong_co_ban float,
    he_so float,
    thang_luong date,
    thuong float,
    phat float
);
go

-- Vi phạm
create table vi_pham (
    ma_vi_pham char(10) primary key,
    ma_nhan_vien char(10),
    ma_loai_vi_pham char(10),
    thoi_gian_vi_pham datetime,
    trang_thai bit
);
go

-- Loại vi phạm
create table loai_vi_pham (
    ma_loai_vi_pham char(10) primary key,
    mo_ta_vi_pham nvarchar(200),
    muc_do_vi_pham int,
    muc_phat float
);
go

-- Khách hàng
create table khach_hang (
    ma_khach_hang char(10) primary key,
    ho_ten_khach_hang nvarchar(50),
    sdt varchar(20),
    diachi nvarchar(100),
    xep_hang char(10),
    diem int
);
go
create table xep_hang (
    ma_hang char(10) primary key,
    ten_hang nvarchar(50),
    yeu_cau float,
    uu_dai float
);
go

-- Vi phạm
create table thuong (
    ma_thuong char(10) primary key,
    ma_nhan_vien char(10),
    ma_loai_thuong char(10),
    trang_thai bit,
    thoi_gian_thuong datetime
);
go

-- Loại vi phạm
create table loai_thuong (
    ma_loai_thuong char(10) primary key,
    loai_yeu_cau nvarchar(20),
    yeu_cau int,
    muc_thuong float
);
go

-- Cấp bậc nhân viên
create table cap_bac_nhan_vien (
    ma_cap_bac char(10) primary key,
    ten_cap_bac nvarchar(20),
    mo_ta_cap_bac nvarchar(200)
);
go

create table nghi_viec(
    ma_nghi_viec char(10) primary key,
    nhan_vien_nghi_viec char(10) ,
    ly_do nvarchar(200),
    thoi_gian_cho_nghi datetime
);
go

alter table nghi_viec
add constraint FK_nghi_viec_nhan_vien
    foreign key (nhan_vien_nghi_viec) references nhan_vien(ma_nhan_vien);
go

-- san_pham -> nha_cung_cap, nha_san_xuat
alter table san_pham
add constraint FK_san_pham_nha_cung_cap 
    foreign key (ma_nha_cung_cap) references nha_cung_cap(ma_nha_cung_cap);
go
alter table san_pham
add constraint FK_san_pham_nha_san_xuat 
    foreign key (ma_nha_san_xuat) references nha_san_xuat(ma_nha_san_xuat);
go

-- nhan_vien -> chi_nhanh, cap_bac_nhan_vien
alter table nhan_vien
add constraint FK_nhan_vien_chi_nhanh 
    foreign key (ma_chi_nhanh) references chi_nhanh(ma_chi_nhanh);
go
alter table nhan_vien
add constraint FK_nhan_vien_cap_bac 
    foreign key (ma_cap_bac) references cap_bac_nhan_vien(ma_cap_bac);
go

-- san_pham_trong_kho_tong -> san_pham, kho_tong
alter table san_pham_trong_kho_tong
add constraint FK_san_pham_trong_kho_tong_san_pham 
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go
alter table san_pham_trong_kho_tong
add constraint FK_san_pham_trong_kho_tong_kho_tong 
    foreign key (ma_kho) references kho_tong(ma_kho);
go

-- hoa_don -> khach_hang, nhan_vien
alter table hoa_don
add constraint FK_hoa_don_khach_hang 
    foreign key (ma_khach_hang) references khach_hang(ma_khach_hang);
go
alter table hoa_don
add constraint FK_hoa_don_nhan_vien 
    foreign key (ma_nhan_vien_lap) references nhan_vien(ma_nhan_vien);
go

-- chi_tiet_hoa_don -> hoa_don, san_pham
alter table chi_tiet_hoa_don
add constraint FK_chi_tiet_hoa_don_hoa_don 
    foreign key (ma_hoa_don) references hoa_don(ma_hoa_don);
go
alter table chi_tiet_hoa_don
add constraint FK_chi_tiet_hoa_don_san_pham 
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

-- tai_khoan -> nhan_vien
alter table tai_khoan
add constraint FK_tai_khoan_nhan_vien 
    foreign key (ma_nhan_vien) references nhan_vien(ma_nhan_vien);
go

-- diem_danh -> nhan_vien
alter table diem_danh
add constraint FK_diem_danh_nhan_vien 
    foreign key (ma_nhan_vien) references nhan_vien(ma_nhan_vien);
go

-- luong -> nhan_vien
alter table luong
add constraint FK_luong_nhan_vien 
    foreign key (ma_nhan_vien) references nhan_vien(ma_nhan_vien);
go

-- vi_pham -> nhan_vien, loai_vi_pham
alter table vi_pham
add constraint FK_vi_pham_nhan_vien 
    foreign key (ma_nhan_vien) references nhan_vien(ma_nhan_vien);
go

alter table vi_pham
add constraint FK_vi_pham_loai_vi_pham 
    foreign key (ma_loai_vi_pham) references loai_vi_pham(ma_loai_vi_pham);
go

-- san_pham_trong_chi_nhanh -> san_pham, chi_nhanh
alter table san_pham_trong_chi_nhanh
add constraint FK_san_pham_trong_chi_nhanh_san_pham 
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

alter table san_pham_trong_chi_nhanh
add constraint FK_san_pham_trong_chi_nhanh_chi_nhanh 
    foreign key (ma_chi_nhanh) references chi_nhanh(ma_chi_nhanh);
go

-- phieu_nhap_kho -> kho_tong, san_pham, nhan_vien
alter table phieu_nhap_kho
add constraint FK_phieu_nhap_kho_kho_tong 
    foreign key (ma_kho) references kho_tong(ma_kho);
go

alter table phieu_nhap_kho
add constraint FK_phieu_nhap_kho_san_pham 
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

alter table phieu_nhap_kho
add constraint FK_phieu_nhap_kho_nhan_vien 
    foreign key (ma_nhan_vien_kiem_tra) references nhan_vien(ma_nhan_vien);
go

-- phieu_xuat_kho -> kho_tong, san_pham, chi_nhanh, nhan_vien
alter table phieu_xuat_kho
add constraint FK_phieu_xuat_kho_kho_tong 
    foreign key (ma_kho) references kho_tong(ma_kho);
go

alter table phieu_xuat_kho
add constraint FK_phieu_xuat_kho_san_pham 
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

alter table phieu_xuat_kho
add constraint FK_phieu_xuat_kho_chi_nhanh 
    foreign key (ma_chi_nhanh_nhap) references chi_nhanh(ma_chi_nhanh);
go

alter table phieu_xuat_kho
add constraint FK_phieu_xuat_kho_nhan_vien 
    foreign key (ma_nhan_vien_kiem_tra) references nhan_vien(ma_nhan_vien);
go

alter table bao_hanh
add constraint FK_bao_hanh_khach_hang
    foreign key (ma_khach_hang) references khach_hang(ma_khach_hang);
go

alter table bao_hanh
add constraint FK_bao_hanh_san_pham
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

alter table san_pham_loai_hang
add constraint FK_san_pham_loai_hang_san_pham
    foreign key (ma_san_pham) references san_pham(ma_san_pham);
go

alter table san_pham_loai_hang
add constraint FK_san_pham_loai_hang_loai_hang
    foreign key (ma_loai_hang) references loai_hang(ma_loai_hang);
go

alter table khuyen_mai
add constraint FK_khuyen_mai_loai_hang
    foreign key (ma_loai_hang) references loai_hang(ma_loai_hang);
go

alter table khach_hang
add constraint FK_khach_hang_xep_hang
    foreign key (xep_hang) references xep_hang(ma_hang);
go

alter table thuong
add constraint FK_thuong_loai_thuong
    foreign key (ma_loai_thuong) references loai_thuong(ma_loai_thuong);
go

alter table thuong
add constraint FK_thuong_nhan_vien
    foreign key (ma_nhan_vien) references nhan_vien(ma_nhan_vien);
go

alter table chi_nhanh
add constraint FK_chi_nhanh_khu_vuc 
    foreign key (khu_vuc) references khu_vuc(ma_khu_vuc);
go  





alter table kho_tong
add constraint FK_kho_tong_nhan_vien 
    foreign key (nhan_vien_quan_ly) references nhan_vien(ma_nhan_vien);
go

alter table chi_tiet_hoa_don
add constraint FK_chi_tiet_hoa_don
    foreign key (ma_khuyen_mai) references khuyen_mai(ma_khuyen_mai);
go

alter table tai_khoan
add constraint FK_tai_khoan 
    foreign key (quyen) references cap_bac_nhan_vien(ma_cap_bac);