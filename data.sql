USE dien_may;
GO

-- TẮT RÀNG BUỘC ĐỂ XÓA SẠCH DỮ LIỆU CŨ
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
DELETE FROM bao_hanh;
DELETE FROM phieu_xuat_kho;
DELETE FROM phieu_nhap_kho;
DELETE FROM thuong;
DELETE FROM vi_pham;
DELETE FROM luong;
DELETE FROM diem_danh;
DELETE FROM san_pham_trong_chi_nhanh;
DELETE FROM san_pham_trong_kho_tong;
DELETE FROM chi_tiet_hoa_don;
DELETE FROM hoa_don;
DELETE FROM khuyen_mai;
DELETE FROM khach_hang;
DELETE FROM tai_khoan;
DELETE FROM nhan_vien;
DELETE FROM chi_nhanh;
DELETE FROM kho_tong;
DELETE FROM khu_vuc;
DELETE FROM san_pham_loai_hang;
DELETE FROM san_pham;
DELETE FROM loai_hang;
DELETE FROM nha_san_xuat;
DELETE FROM nha_cung_cap;
DELETE FROM xep_hang;
DELETE FROM cap_bac_nhan_vien;
DELETE FROM loai_vi_pham;
DELETE FROM loai_thuong;
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO

---------------------------------------------------
-- 1. DANH MỤC CƠ BẢN
---------------------------------------------------
-- Nhà cung cấp & Sản xuất
INSERT INTO nha_cung_cap VALUES ('NCC01', N'Sony VN', N'HCM'), ('NCC02', N'Samsung Vina', N'HCM'), ('NCC03', N'LG VN', N'HN'), ('NCC04', N'Panasonic', N'HCM'), ('NCC05', N'Daikin', N'HN'), ('NCC06', N'Apple FPT', N'HCM');
INSERT INTO nha_san_xuat VALUES ('NSX01', N'Sony', N'Nhật'), ('NSX02', N'Samsung', N'Hàn'), ('NSX03', N'LG', N'Hàn'), ('NSX04', N'Panasonic', N'Nhật'), ('NSX05', N'Daikin', N'Nhật'), ('NSX06', N'Apple', N'Mỹ');
INSERT INTO loai_hang VALUES ('LH01', N'Tivi', N'Nghe nhìn'), ('LH02', N'Tủ lạnh', N'Điện lạnh'), ('LH03', N'Máy giặt', N'Điện lạnh'), ('LH04', N'Máy lạnh', N'Điện lạnh'), ('LH05', N'Gia dụng', N'Nhỏ'), ('LH06', N'Laptop', N'CNTT');

-- Cấp bậc & Xếp hạng
INSERT INTO cap_bac_nhan_vien VALUES ('CB01', N'Giám đốc', N'Cao nhất'), ('CB02', N'Quản lý KV', N'Vùng'), ('CB03', N'Quản lý CN', N'Cửa hàng'), ('CB04', N'Kho', N'QL Kho'), ('CB05', N'Nhân viên', N'Bán hàng');
INSERT INTO xep_hang VALUES ('H01', N'Thành viên', 0, 0), ('H02', N'Bạc', 10000000, 2), ('H03', N'Vàng', 50000000, 5), ('H04', N'Kim Cương', 200000000, 10);

-- Loại Vi Phạm & Thưởng
INSERT INTO loai_vi_pham VALUES ('LVP01', N'Đi trễ', 1, 50000), ('LVP02', N'Vắng không phép', 3, 500000), ('LVP03', N'Làm hư hàng', 2, 200000);
INSERT INTO loai_thuong VALUES ('LT01', N'Chuyên cần', 26, 500000), ('LT02', N'Doanh số', 100000000, 2000000);

-- Khu vực & Chi nhánh & Kho Tổng
INSERT INTO khu_vuc VALUES ('KV01', N'Miền Bắc', NULL), ('KV02', N'Miền Trung', NULL), ('KV03', N'Miền Nam', NULL);
INSERT INTO chi_nhanh VALUES 
('CN01', N'CN Hà Nội 1', N'Cầu Giấy', 'KV01'), ('CN02', N'CN Hải Phòng', N'Lê Chân', 'KV01'),
('CN03', N'CN Đà Nẵng', N'Hải Châu', 'KV02'),
('CN04', N'CN Quận 1', N'Q1 HCM', 'KV03'), ('CN05', N'CN Thủ Đức', N'Thủ Đức', 'KV03'), ('CN06', N'CN Cần Thơ', N'Ninh Kiều', 'KV03');

INSERT INTO kho_tong VALUES ('KHO01', NULL, N'Kho Tổng Miền Bắc', N'Hà Nội', 5000), ('KHO02', NULL, N'Kho Tổng Miền Nam', N'Bình Dương', 8000);

---------------------------------------------------
-- 2. SẢN PHẨM (20 Món)
---------------------------------------------------
INSERT INTO san_pham VALUES
('SP01', N'Tivi Sony 4K 55 inch', 'NSX01', 'NCC01', 15, 24, 15000000, '2023-01-01'),
('SP02', N'Tivi Samsung QLED 65"', 'NSX02', 'NCC02', 20, 36, 25000000, '2023-02-01'),
('SP03', N'Tủ lạnh LG Inverter', 'NSX03', 'NCC03', 60, 24, 8000000, '2023-03-01'),
('SP04', N'Tủ lạnh Pana 2 cánh', 'NSX04', 'NCC04', 55, 24, 7500000, '2023-03-15'),
('SP05', N'Máy giặt LG lồng ngang', 'NSX03', 'NCC03', 50, 24, 9000000, '2023-04-01'),
('SP06', N'Máy giặt Samsung Top', 'NSX02', 'NCC02', 45, 24, 6000000, '2023-04-10'),
('SP07', N'Máy lạnh Daikin 1HP', 'NSX05', 'NCC05', 30, 12, 10000000, '2023-05-01'),
('SP08', N'Máy lạnh Pana 1.5HP', 'NSX04', 'NCC04', 35, 12, 13000000, '2023-05-05'),
('SP09', N'Nồi cơm Sharp', 'NSX04', 'NCC03', 3, 12, 1500000, '2023-06-01'),
('SP10', N'Lò vi sóng Samsung', 'NSX02', 'NCC02', 10, 12, 3000000, '2023-06-15'),
('SP11', N'Macbook Air M1', 'NSX06', 'NCC06', 1.2, 12, 18000000, '2022-12-01'),
('SP12', N'Macbook Pro M2', 'NSX06', 'NCC06', 1.5, 12, 30000000, '2023-01-20'),
('SP13', N'Quạt Senko', 'NSX04', 'NCC04', 5, 12, 500000, '2023-07-01'),
('SP14', N'Bàn ủi Philips', 'NSX04', 'NCC03', 2, 12, 1200000, '2023-07-10'),
('SP15', N'Máy xay Sunhouse', 'NSX02', 'NCC02', 3, 12, 800000, '2023-08-01'),
('SP16', N'Tivi LG OLED 55"', 'NSX03', 'NCC03', 16, 24, 14000000, '2023-02-10'),
('SP17', N'Máy lạnh LG Dual', 'NSX03', 'NCC03', 32, 24, 10500000, '2023-05-20'),
('SP18', N'Tủ lạnh SideBySide', 'NSX02', 'NCC02', 100, 24, 30000000, '2023-03-20'),
('SP19', N'Robot hút bụi Xiaomi', 'NSX02', 'NCC02', 4, 12, 6500000, '2023-09-01'),
('SP20', N'Máy lọc không khí', 'NSX04', 'NCC04', 6, 12, 4000000, '2023-09-15');

INSERT INTO san_pham_loai_hang VALUES ('SP01','LH01'),('SP02','LH01'),('SP03','LH02'),('SP04','LH02'),('SP05','LH03'),('SP06','LH03'),('SP07','LH04'),('SP08','LH04'),('SP09','LH05'),('SP10','LH05'),('SP11','LH06'),('SP12','LH06'),('SP13','LH05'),('SP14','LH05'),('SP15','LH05'),('SP16','LH01'),('SP17','LH04'),('SP18','LH02'),('SP19','LH05'),('SP20','LH05');

---------------------------------------------------
-- 3. NHÂN VIÊN & KHÁCH HÀNG
---------------------------------------------------
INSERT INTO nhan_vien VALUES 
('NV01', N'Sếp Tổng', 'CB01', '0901', N'HCM', 'CN04', 1),
('NV02', N'Quản Lý Kho Bắc', 'CB04', '0902', N'HN', 'CN01', 1),
('NV03', N'Quản Lý Kho Nam', 'CB04', '0903', N'HCM', 'CN04', 1),
('NV04', N'Trưởng CN Hà Nội', 'CB03', '0904', N'HN', 'CN01', 1),
('NV05', N'Trưởng CN Đà Nẵng', 'CB03', '0905', N'ĐN', 'CN03', 1),
('NV06', N'Trưởng CN Quận 1', 'CB03', '0906', N'HCM', 'CN04', 1),
('NV07', N'Nhân Viên HN1', 'CB05', '0907', N'HN', 'CN01', 1),
('NV08', N'Nhân Viên HN2', 'CB05', '0908', N'HP', 'CN02', 1),
('NV09', N'Nhân Viên ĐN1', 'CB05', '0909', N'ĐN', 'CN03', 1),
('NV10', N'Nhân Viên Q1-A', 'CB05', '0910', N'HCM', 'CN04', 1),
('NV11', N'Nhân Viên Q1-B', 'CB05', '0911', N'HCM', 'CN04', 1),
('NV12', N'Nhân Viên Thủ Đức', 'CB05', '0912', N'HCM', 'CN05', 1),
('NV13', N'Nhân Viên Cần Thơ', 'CB05', '0913', N'CT', 'CN06', 1),
('NV14', N'NV Kho Tổng Bắc', 'CB04', '0914', N'HN', 'CN01', 1),
('NV15', N'NV Kho Tổng Nam', 'CB04', '0915', N'BD', 'CN04', 1);

-- Cập nhật quản lý kho tổng
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV02' WHERE ma_kho = 'KHO01';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV03' WHERE ma_kho = 'KHO02';

INSERT INTO tai_khoan SELECT ma_nhan_vien, '123', ma_cap_bac FROM nhan_vien;

INSERT INTO khach_hang VALUES 
('KH01', N'Khách Vãng Lai', '000', N'N/A', 'H01', 0),
('KH02', N'Nguyễn Đại Gia', '0991', N'Q2', 'H04', 500000000),
('KH03', N'Trần Phú Bà', '0992', N'Q7', 'H03', 80000000),
('KH04', N'Lê Văn Khá', '0993', N'HN', 'H02', 15000000),
('KH05', N'Phạm Bình Dân', '0994', N'ĐN', 'H01', 2000000),
('KH06', N'Võ Thị Mới', '0995', N'CT', 'H01', 0);

---------------------------------------------------
-- 4. KHO HÀNG (QUAN TRỌNG: Đổ đầy hàng cho tất cả)
---------------------------------------------------
-- KHO TỔNG: Chứa số lượng cực lớn
INSERT INTO san_pham_trong_kho_tong VALUES 
('KHO01', 'SP01', 100), ('KHO01', 'SP02', 100), ('KHO01', 'SP03', 200), ('KHO01', 'SP07', 300), -- Kho Bắc
('KHO02', 'SP01', 200), ('KHO02', 'SP02', 150), ('KHO02', 'SP03', 200), ('KHO02', 'SP04', 100), -- Kho Nam
('KHO02', 'SP07', 400), ('KHO02', 'SP08', 300), ('KHO02', 'SP11', 50), ('KHO02', 'SP12', 50);

-- KHO CHI NHÁNH: Rải đều để bán (Mỗi CN có khoảng 10-20 món mỗi loại)
-- CN01 (Hà Nội)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN01', 'SP01', 20), ('CN01', 'SP02', 10), ('CN01', 'SP03', 15), ('CN01', 'SP07', 50);
-- CN02 (Hải Phòng)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN02', 'SP01', 10), ('CN02', 'SP03', 10), ('CN02', 'SP07', 30);
-- CN03 (Đà Nẵng)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN03', 'SP01', 15), ('CN03', 'SP04', 5), ('CN03', 'SP08', 20), ('CN03', 'SP11', 5);
-- CN04 (Quận 1 - Kho lớn)
INSERT INTO san_pham_trong_chi_nhanh VALUES 
('CN04', 'SP01', 50), ('CN04', 'SP02', 30), ('CN04', 'SP03', 40), ('CN04', 'SP04', 20),
('CN04', 'SP07', 60), ('CN04', 'SP08', 50), ('CN04', 'SP11', 20), ('CN04', 'SP12', 15);
-- CN05 (Thủ Đức)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN05', 'SP01', 10), ('CN05', 'SP05', 20), ('CN05', 'SP09', 50), ('CN05', 'SP13', 100);
-- CN06 (Cần Thơ)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN06', 'SP03', 15), ('CN06', 'SP04', 10), ('CN06', 'SP06', 20), ('CN06', 'SP07', 30);

---------------------------------------------------
-- 5. GIAO DỊCH (Hóa đơn, Nhập/Xuất, Bảo hành)
---------------------------------------------------
INSERT INTO khuyen_mai VALUES 
('KM01', 10, 'LH01', '2023-01-01', '2025-12-31'), -- Giảm 10% Tivi
('KM02', 20, 'LH04', '2023-06-01', '2023-09-30'); -- Giảm 20% Mùa hè

-- Hóa đơn (Bán hàng)
INSERT INTO hoa_don VALUES 
('HD01', 'NV10', 'KH02', '2023-11-01'), -- VIP mua Tivi
('HD02', 'NV07', 'KH04', '2023-11-02'), -- HN mua Máy lạnh
('HD03', 'NV13', 'KH01', '2023-11-03'), -- Cần Thơ mua Tủ lạnh
('HD04', 'NV10', 'KH03', '2023-11-04'); -- VIP Q7 mua Laptop

-- Chi tiết HD (Có cột gia_goc)
-- HD01: Tivi Sony (15tr). Giảm KH 10%, KM 10%. 
INSERT INTO chi_tiet_hoa_don VALUES ('HD01', 'SP01', 'KM01', 1, 12150000, 15000000, '2023-11-01');
-- HD02: Máy lạnh Daikin (10tr). Giảm KH 2%, KM 0.
INSERT INTO chi_tiet_hoa_don VALUES ('HD02', 'SP07', NULL, 2, 9800000, 10000000, '2023-11-02');
-- HD03: Tủ lạnh LG (8tr). Khách vãng lai, KM 0.
INSERT INTO chi_tiet_hoa_don VALUES ('HD03', 'SP03', NULL, 1, 8000000, 8000000, '2023-11-03');
-- HD04: Macbook M1 (18tr). Giảm KH 5%.
INSERT INTO chi_tiet_hoa_don VALUES ('HD04', 'SP11', NULL, 1, 17100000, 18000000, '2023-11-04');

-- Phiếu Nhập Kho (Nhập từ NCC về Kho Tổng)
INSERT INTO phieu_nhap_kho VALUES ('PN01', 'KHO01', 'SP01', 'NV14', 100, 14000000); -- Nhập Tivi về kho Bắc
INSERT INTO phieu_nhap_kho VALUES ('PN02', 'KHO02', 'SP07', 'NV15', 200, 9000000);  -- Nhập Máy lạnh về kho Nam

-- Phiếu Xuất Kho (Xuất từ Kho Tổng về Chi Nhánh)
INSERT INTO phieu_xuat_kho VALUES ('PX01', 'KHO01', 'SP01', 'CN01', 'NV14', 20); -- Chuyển 20 cái Tivi về CN Hà Nội

-- Bảo Hành
INSERT INTO bao_hanh VALUES ('BH01', 'SP01', 'KH02', 'NV10', N'Lỗi màn hình', '2023-11-10', '2023-11-15', 1);
INSERT INTO bao_hanh VALUES ('BH02', 'SP03', 'KH01', 'NV13', N'Không lạnh', '2023-11-12', NULL, 0); -- Chưa xong

---------------------------------------------------
-- 6. NHÂN SỰ (Lương, Thưởng, Vi phạm, Điểm danh)
---------------------------------------------------
-- Điểm danh (Tháng 11)
INSERT INTO diem_danh VALUES ('DD01', 'NV10', '2023-11-01 07:55:00', '2023-11-01 17:05:00');
INSERT INTO diem_danh VALUES ('DD02', 'NV10', '2023-11-02 08:10:00', '2023-11-02 17:00:00'); -- Đi trễ
INSERT INTO diem_danh VALUES ('DD03', 'NV07', '2023-11-01 08:00:00', '2023-11-01 17:00:00');

-- Vi phạm
INSERT INTO vi_pham VALUES ('VP01', 'NV10', 'LVP01', '2023-11-02 08:10:00', 0); -- NV10 đi trễ, chưa đóng phạt

-- Thưởng
INSERT INTO thuong VALUES ('TH01', 'NV10', 'LT02', 0, '2023-10-31'); -- NV10 đạt doanh số tháng 10

-- Lương (Tháng 10)
-- NV10: Lương cứng 10tr + Thưởng 2tr - Phạt 0 = 12tr
INSERT INTO luong VALUES ('L01', 'NV10', 10000000, 1.0, '2023-10-31', 2000000, 0);
-- NV07: Lương cứng 8tr
INSERT INTO luong VALUES ('L02', 'NV07', 8000000, 1.0, '2023-10-31', 0, 0);