USE dien_may;
GO

-- XÓA DỮ LIỆU CŨ ĐỂ TRÁNH LỖI TRÙNG KHÓA (Chạy lệnh này cẩn thận)
-- Tắt kiểm tra khóa ngoại tạm thời để xóa cho dễ
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
DELETE FROM chi_tiet_hoa_don;
DELETE FROM hoa_don;
DELETE FROM san_pham_trong_chi_nhanh;
DELETE FROM san_pham_trong_kho_tong;
DELETE FROM khuyen_mai;
DELETE FROM san_pham_loai_hang;
DELETE FROM san_pham;
DELETE FROM khach_hang;
DELETE FROM tai_khoan;
DELETE FROM nhan_vien;
DELETE FROM chi_nhanh;
DELETE FROM khu_vuc;
DELETE FROM cap_bac_nhan_vien;
DELETE FROM xep_hang;
DELETE FROM loai_hang;
DELETE FROM nha_san_xuat;
DELETE FROM nha_cung_cap;
-- Bật lại kiểm tra khóa ngoại
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO

-------------------------------------------------------
-- 1. DỮ LIỆU NỀN (DANH MỤC)
-------------------------------------------------------

-- Nhà cung cấp & Sản xuất
INSERT INTO nha_cung_cap VALUES 
('NCC01', N'Sony VN', N'HCM'), ('NCC02', N'Samsung Vina', N'HCM'), 
('NCC03', N'LG VN', N'Hà Nội'), ('NCC04', N'Panasonic', N'HCM'), 
('NCC05', N'Daikin', N'Hà Nội'), ('NCC06', N'Apple VN', N'HCM');

INSERT INTO nha_san_xuat VALUES 
('NSX01', N'Sony', N'Nhật'), ('NSX02', N'Samsung', N'Hàn'), 
('NSX03', N'LG', N'Hàn'), ('NSX04', N'Panasonic', N'Nhật'), 
('NSX05', N'Daikin', N'Nhật'), ('NSX06', N'Apple', N'Mỹ');

-- Loại hàng
INSERT INTO loai_hang VALUES 
('LH01', N'Tivi', N'Nghe nhìn'), 
('LH02', N'Tủ lạnh', N'Điện lạnh'), 
('LH03', N'Máy giặt', N'Điện lạnh'), 
('LH04', N'Máy lạnh', N'Điện lạnh'), 
('LH05', N'Gia dụng', N'Nồi cơm, quạt'),
('LH06', N'Laptop', N'Công nghệ');

-- Cấp bậc nhân viên (Đúng theo yêu cầu của bạn)
INSERT INTO cap_bac_nhan_vien VALUES 
('CB01', N'Giám đốc', N'Lãnh đạo cao nhất'),
('CB02', N'Quản lý khu vực', N'Quản lý vùng (Bắc/Trung/Nam)'),
('CB03', N'Quản lý chi nhánh', N'Trưởng cửa hàng'),
('CB04', N'Bộ phận sản phẩm', N'Quản lý nhập hàng/giá'),
('CB05', N'Nhân viên', N'Bán hàng/Kho/Thu ngân');

-- Xếp hạng khách hàng (Ưu đãi 0-100)
INSERT INTO xep_hang VALUES 
('H01', N'Thành viên', 0, 0),       -- 0%
('H02', N'Bạc', 10000000, 2),        -- 2%
('H03', N'Vàng', 50000000, 5),       -- 5%
('H04', N'Kim Cương', 200000000, 10); -- 10%

-- Khu vực
INSERT INTO khu_vuc VALUES 
('KV01', N'Miền Bắc', NULL),
('KV02', N'Miền Trung', NULL),
('KV03', N'Miền Nam', NULL);

-- Chi nhánh (Rải rác 3 miền)
INSERT INTO chi_nhanh VALUES 
('CN01', N'CN Hà Nội 1', N'Cầu Giấy, HN', 'KV01'),
('CN02', N'CN Hải Phòng', N'Lê Chân, HP', 'KV01'),
('CN03', N'CN Đà Nẵng', N'Hải Châu, ĐN', 'KV02'),
('CN04', N'CN Quận 1', N'Nguyễn Huệ, HCM', 'KV03'),
('CN05', N'CN Thủ Đức', N'Thủ Đức, HCM', 'KV03'),
('CN06', N'CN Cần Thơ', N'Ninh Kiều, CT', 'KV03');

-------------------------------------------------------
-- 2. SẢN PHẨM (20 Sản phẩm)
-------------------------------------------------------
INSERT INTO san_pham (ma_san_pham, ten_san_pham, ma_nha_san_xuat, ma_nha_cung_cap, khoi_luong, thoi_gian_bao_hanh, gia_tien, ngay_san_xuat) VALUES
('SP001', N'Tivi Sony 4K 55 inch', 'NSX01', 'NCC01', 15, 24, 15000000, '2023-01-01'),
('SP002', N'Tivi Sony OLED 65 inch', 'NSX01', 'NCC01', 20, 36, 45000000, '2023-02-01'),
('SP003', N'Tủ lạnh Samsung Inverter 300L', 'NSX02', 'NCC02', 60, 24, 8000000, '2023-03-01'),
('SP004', N'Tủ lạnh Samsung SideBySide', 'NSX02', 'NCC02', 100, 24, 30000000, '2023-03-15'),
('SP005', N'Máy giặt LG lồng ngang 9kg', 'NSX03', 'NCC03', 50, 24, 9500000, '2023-04-01'),
('SP006', N'Máy giặt LG lồng đứng 10kg', 'NSX03', 'NCC03', 45, 24, 6000000, '2023-04-10'),
('SP007', N'Máy lạnh Panasonic 1HP', 'NSX04', 'NCC04', 30, 12, 11000000, '2023-05-01'),
('SP008', N'Máy lạnh Daikin Inverter 1.5HP', 'NSX05', 'NCC05', 35, 12, 14000000, '2023-05-05'),
('SP009', N'Nồi cơm điện Sharp', 'NSX04', 'NCC04', 3, 12, 1500000, '2023-06-01'),
('SP010', N'Lò vi sóng Samsung', 'NSX02', 'NCC02', 10, 12, 3000000, '2023-06-15'),
('SP011', N'Laptop Macbook Air M1', 'NSX06', 'NCC06', 1.2, 12, 18000000, '2022-12-01'),
('SP012', N'Laptop Macbook Pro M2', 'NSX06', 'NCC06', 1.5, 12, 30000000, '2023-01-20'),
('SP013', N'Quạt đứng Senko', 'NSX04', 'NCC03', 5, 12, 500000, '2023-07-01'),
('SP014', N'Bàn ủi hơi nước Philips', 'NSX04', 'NCC03', 2, 12, 1200000, '2023-07-10'),
('SP015', N'Máy xay sinh tố Sunhouse', 'NSX02', 'NCC02', 3, 12, 800000, '2023-08-01'),
('SP016', N'Tivi Samsung QLED 55 inch', 'NSX02', 'NCC02', 16, 24, 14000000, '2023-02-10'),
('SP017', N'Máy lạnh LG Dual Inverter', 'NSX03', 'NCC03', 32, 24, 10500000, '2023-05-20'),
('SP018', N'Tủ lạnh Panasonic 2 cánh', 'NSX04', 'NCC04', 55, 24, 7500000, '2023-03-20'),
('SP019', N'Robot hút bụi Xiaomi', 'NSX02', 'NCC02', 4, 12, 6500000, '2023-09-01'),
('SP020', N'Máy lọc không khí Sharp', 'NSX04', 'NCC04', 6, 12, 4000000, '2023-09-15');

-- Link Sản phẩm - Loại hàng
INSERT INTO san_pham_loai_hang VALUES 
('SP001','LH01'), ('SP002','LH01'), ('SP016','LH01'), -- Tivi
('SP003','LH02'), ('SP004','LH02'), ('SP018','LH02'), -- Tủ lạnh
('SP005','LH03'), ('SP006','LH03'), -- Máy giặt
('SP007','LH04'), ('SP008','LH04'), ('SP017','LH04'), -- Máy lạnh
('SP009','LH05'), ('SP010','LH05'), ('SP013','LH05'), ('SP014','LH05'), ('SP015','LH05'), ('SP019','LH05'), ('SP020','LH05'), -- Gia dụng
('SP011','LH06'), ('SP012','LH06'); -- Laptop

-------------------------------------------------------
-- 3. NHÂN VIÊN (15 Nhân viên đủ các cấp)
-------------------------------------------------------
INSERT INTO nhan_vien (ma_nhan_vien, ho_va_ten, ma_cap_bac, so_dien_thoai, ma_chi_nhanh, trang_thai) VALUES
('NV001', N'Phạm Tổng Giám', 'CB01', '0900000001', 'CN04', 1), -- Giám đốc ngồi ở Q1
-- Quản lý khu vực
('NV002', N'Lê Quản Bắc', 'CB02', '0900000002', 'CN01', 1),
('NV003', N'Trần Quản Nam', 'CB02', '0900000003', 'CN04', 1),
-- Quản lý chi nhánh
('NV004', N'Nguyễn Trưởng CN1', 'CB03', '0900000004', 'CN01', 1),
('NV005', N'Võ Trưởng CN2', 'CB03', '0900000005', 'CN02', 1),
('NV006', N'Đặng Trưởng CN3', 'CB03', '0900000006', 'CN03', 1),
('NV007', N'Bùi Trưởng CN4', 'CB03', '0900000007', 'CN04', 1),
-- Bộ phận sản phẩm
('NV008', N'Hồ Product', 'CB04', '0900000008', 'CN04', 1),
-- Nhân viên bán hàng
('NV009', N'Đỗ Nhân Viên 1', 'CB05', '0900000009', 'CN01', 1),
('NV010', N'Ngô Nhân Viên 2', 'CB05', '0900000010', 'CN02', 1),
('NV011', N'Dương Nhân Viên 3', 'CB05', '0900000011', 'CN03', 1),
('NV012', N'Lý Nhân Viên 4', 'CB05', '0900000012', 'CN04', 1), -- NV xuất sắc miền Nam
('NV013', N'Mai Nhân Viên 5', 'CB05', '0900000013', 'CN04', 1),
('NV014', N'Trương Nhân Viên 6', 'CB05', '0900000014', 'CN05', 1),
('NV015', N'Đinh Nhân Viên 7', 'CB05', '0900000015', 'CN06', 1);

-- Cập nhật tài khoản
INSERT INTO tai_khoan (ma_nhan_vien, mat_khau, quyen) 
SELECT ma_nhan_vien, '123', ma_cap_bac FROM nhan_vien;

-------------------------------------------------------
-- 4. KHÁCH HÀNG (20 Khách hàng)
-------------------------------------------------------
INSERT INTO khach_hang (ma_khach_hang, ho_ten_khach_hang, sdt, diachi, xep_hang, diem) VALUES
('KH001', N'Khách Vãng Lai', '0000000000', N'Tại quầy', 'H01', 0),
('KH002', N'Nguyễn Văn Đại Gia', '0911111111', N'Biệt thự Q2', 'H04', 300000000), -- Diamond (10%)
('KH003', N'Trần Thị Phú Bà', '0911111112', N'Vinhome Central Park', 'H04', 250000000),
('KH004', N'Lê Văn Giàu', '0911111113', N'Hà Nội', 'H03', 80000000), -- Gold (5%)
('KH005', N'Phạm Thị Sang', '0911111114', N'Đà Nẵng', 'H03', 60000000),
('KH006', N'Võ Văn Khá', '0911111115', N'Cần Thơ', 'H02', 20000000), -- Silver (2%)
('KH007', N'Đặng Thị Thường', '0911111116', N'Hải Phòng', 'H02', 15000000),
('KH008', N'Bùi Văn Bình', '0911111117', N'HCM', 'H01', 5000000), -- Member (0%)
('KH009', N'Hồ Thị Dân', '0911111118', N'HCM', 'H01', 2000000),
('KH010', N'Ngô Văn E', '0911111119', N'HN', 'H01', 0),
('KH011', N'Dương Thị F', '0911111120', N'HN', 'H01', 0),
('KH012', N'Lý Văn G', '0911111121', N'ĐN', 'H02', 11000000),
('KH013', N'Mai Thị H', '0911111122', N'HCM', 'H03', 55000000),
('KH014', N'Trương Văn I', '0911111123', N'CT', 'H01', 0),
('KH015', N'Đinh Thị K', '0911111124', N'HP', 'H04', 210000000),
('KH016', N'Lâm Văn L', '0911111125', N'HCM', 'H01', 0),
('KH017', N'Hà Thị M', '0911111126', N'HN', 'H01', 0),
('KH018', N'Phan Văn N', '0911111127', N'ĐN', 'H02', 18000000),
('KH019', N'Cao Thị O', '0911111128', N'HCM', 'H01', 0),
('KH020', N'Đoàn Văn P', '0911111129', N'CT', 'H03', 70000000);

-------------------------------------------------------
-- 5. KHUYẾN MÃI (0-100)
-------------------------------------------------------
INSERT INTO khuyen_mai VALUES
('KM01', 10, 'LH01', '2023-01-01', '2025-12-31'), -- Giảm 10% Tivi
('KM02', 15, 'LH04', '2023-01-01', '2025-12-31'), -- Giảm 15% Máy lạnh
('KM03', 5, 'LH06', '2023-01-01', '2025-12-31'), -- Giảm 5% Laptop
('KM04', 20, 'LH05', '2023-01-01', '2025-12-31'); -- Giảm 20% Gia dụng (Sốc)

-------------------------------------------------------
-- 6. HÓA ĐƠN & CHI TIẾT (Tạo ~20 Hóa đơn)
-------------------------------------------------------
-- Lưu ý: Giá Gốc = Giá Sản Phẩm. Đơn Giá = Giá sau khi trừ KM và Ưu đãi KH

-- HD1: Khách VIP (10%) mua Tivi (KM 10%) tại HCM
-- Giá gốc: 45tr. Giảm KH 10% = 40.5tr. Giảm KM 10% tiếp = 36.45tr
INSERT INTO hoa_don VALUES ('HD001', 'NV012', 'KH002', '2023-11-01 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD001', 'SP002', 'KM01', 1, 36450000, 45000000, '2023-11-01 09:00:00');

-- HD2: Khách Vàng (5%) mua 2 Máy lạnh (KM 15%) tại HN
-- Giá gốc: 11tr. Giảm KH 5% = 10.45tr. Giảm KM 15% = 8.882.500
INSERT INTO hoa_don VALUES ('HD002', 'NV009', 'KH004', '2023-11-02 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD002', 'SP007', 'KM02', 2, 8882500, 11000000, '2023-11-02 10:00:00');

-- HD3: Khách Vãng lai (0%) mua Laptop (KM 5%) tại ĐN
-- Giá gốc: 18tr. Giảm KH 0%. Giảm KM 5% = 17.1tr
INSERT INTO hoa_don VALUES ('HD003', 'NV011', 'KH001', '2023-11-03 14:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD003', 'SP011', 'KM03', 1, 17100000, 18000000, '2023-11-03 14:00:00');

-- Các hóa đơn khác (Random dữ liệu để test báo cáo)
INSERT INTO hoa_don VALUES ('HD004', 'NV012', 'KH003', '2023-11-04 15:30:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD004', 'SP004', NULL, 1, 27000000, 30000000, '2023-11-04 15:30:00'); -- Chỉ giảm KH VIP 10%

INSERT INTO hoa_don VALUES ('HD005', 'NV013', 'KH005', '2023-11-05 08:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD005', 'SP009', 'KM04', 2, 1140000, 1500000, '2023-11-05 08:00:00'); -- Giảm KH 5% + KM 20%

INSERT INTO hoa_don VALUES ('HD006', 'NV014', 'KH001', '2023-11-06 11:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD006', 'SP020', 'KM04', 1, 3200000, 4000000, '2023-11-06 11:00:00'); -- Khách vãng lai, giảm KM 20%

INSERT INTO hoa_don VALUES ('HD007', 'NV015', 'KH015', '2023-11-07 13:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD007', 'SP012', 'KM03', 1, 25650000, 30000000, '2023-11-07 13:00:00');

-- Hóa đơn tháng 10 (Để test lọc theo thời gian)
INSERT INTO hoa_don VALUES ('HD008', 'NV012', 'KH002', '2023-10-15 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD008', 'SP001', 'KM01', 2, 12150000, 15000000, '2023-10-15 09:00:00');

INSERT INTO hoa_don VALUES ('HD009', 'NV012', 'KH002', '2023-10-20 19:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD009', 'SP019', 'KM04', 1, 4680000, 6500000, '2023-10-20 19:00:00');

-- Hóa đơn nhiều sản phẩm
INSERT INTO hoa_don VALUES ('HD010', 'NV012', 'KH003', '2023-11-10 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD010', 'SP013', 'KM04', 5, 360000, 500000, '2023-11-10 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD010', 'SP015', 'KM04', 2, 576000, 800000, '2023-11-10 10:00:00');

INSERT INTO hoa_don VALUES ('HD011', 'NV009', 'KH007', '2023-11-11 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD011', 'SP005', NULL, 1, 9310000, 9500000, '2023-11-11 09:00:00');

INSERT INTO hoa_don VALUES ('HD012', 'NV009', 'KH007', '2023-11-12 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD012', 'SP006', NULL, 1, 5880000, 6000000, '2023-11-12 09:00:00');

INSERT INTO hoa_don VALUES ('HD013', 'NV010', 'KH001', '2023-11-13 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD013', 'SP001', 'KM01', 1, 13500000, 15000000, '2023-11-13 09:00:00');

INSERT INTO hoa_don VALUES ('HD014', 'NV010', 'KH001', '2023-11-14 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD014', 'SP010', 'KM04', 1, 2400000, 3000000, '2023-11-14 09:00:00');

INSERT INTO hoa_don VALUES ('HD015', 'NV011', 'KH020', '2023-11-15 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD015', 'SP008', 'KM02', 1, 11305000, 14000000, '2023-11-15 09:00:00');

INSERT INTO hoa_don VALUES ('HD016', 'NV012', 'KH002', '2023-11-16 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD016', 'SP017', 'KM02', 2, 8032500, 10500000, '2023-11-16 09:00:00');

INSERT INTO hoa_don VALUES ('HD017', 'NV013', 'KH008', '2023-11-17 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD017', 'SP014', 'KM04', 1, 960000, 1200000, '2023-11-17 09:00:00');

INSERT INTO hoa_don VALUES ('HD018', 'NV014', 'KH001', '2023-11-18 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD018', 'SP003', NULL, 1, 8000000, 8000000, '2023-11-18 09:00:00');

INSERT INTO hoa_don VALUES ('HD019', 'NV015', 'KH012', '2023-11-19 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD019', 'SP005', NULL, 1, 9310000, 9500000, '2023-11-19 09:00:00');

INSERT INTO hoa_don VALUES ('HD020', 'NV012', 'KH002', '2023-11-20 09:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD020', 'SP016', 'KM01', 2, 11340000, 14000000, '2023-11-20 09:00:00');

-- Thêm vài đơn hàng cho các sản phẩm bán chạy (Tivi Sony, Máy lạnh Daikin)
INSERT INTO hoa_don VALUES ('HD021', 'NV009', 'KH001', '2023-11-21 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD021', 'SP001', 'KM01', 1, 13500000, 15000000, '2023-11-21 10:00:00');

INSERT INTO hoa_don VALUES ('HD022', 'NV012', 'KH003', '2023-11-22 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD022', 'SP001', 'KM01', 1, 12150000, 15000000, '2023-11-22 10:00:00');

INSERT INTO hoa_don VALUES ('HD023', 'NV011', 'KH005', '2023-11-23 10:00:00');
INSERT INTO chi_tiet_hoa_don VALUES ('HD023', 'SP008', 'KM02', 2, 11305000, 14000000, '2023-11-23 10:00:00');