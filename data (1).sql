USE dien_may;
GO

-- 1. XÓA SẠCH DỮ LIỆU CŨ
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

---------------------------------------------------------------------------
-- 2. DỮ LIỆU CỐ ĐỊNH (KHÔNG SỬA THEO YÊU CẦU)
---------------------------------------------------------------------------
-- Bảng: cap_bac_nhan_vien (20)
INSERT INTO cap_bac_nhan_vien (ma_cap_bac, ten_cap_bac, mo_ta_cap_bac) VALUES
('CB10000001', N'Nhân viên', N'Nhân viên bán hàng, kho'),
('CB10000002', N'Quản lý chi nhánh', N'Trưởng nhóm kinh doanh'),
('CB10000003', N'Quản lý khu vực', N'Quản lý chi nhánh'),
('CB10000004', N'Bộ phận sản phẩm', N'Giám đốc khu vực'),
('CB10000005', N'Giám đốc', N'Nhân viên phòng kế toán');

-- Bảng: khu_vuc (20) (nhan_vien_quan_ly = NULL)
INSERT INTO khu_vuc (ma_khu_vuc, ten_khu_vuc, nhan_vien_quan_ly) VALUES
('KV10000001', N'Miền Bắc', NULL),
('KV10000002', N'Miền Trung', NULL),
('KV10000003', N'Miền Nam', NULL),
('KV10000004', N'Tây Nguyên', NULL),
('KV10000005', N'Đồng bằng SCL', NULL),
('KV10000006', N'Đông Bắc Bộ', NULL),
('KV10000007', N'Tây Bắc Bộ', NULL),
('KV10000008', N'Bắc Trung Bộ', NULL),
('KV10000009', N'Nam Trung Bộ', NULL);

---------------------------------------------------------------------------
-- 3. DANH MỤC KHÁC (MÃ 2 CHỮ + 8 SỐ)
---------------------------------------------------------------------------

-- Nhà Cung Cấp (NC...)
INSERT INTO nha_cung_cap VALUES 
('NC10000001', N'Sony VN', N'Q1 HCM'), 
('NC10000002', N'Samsung Vina', N'Q9 HCM'), 
('NC10000003', N'LG Electronics', N'Hà Nội'), 
('NC10000004', N'Panasonic VN', N'HCM'), 
('NC10000005', N'Daikin Vietnam', N'Hà Nội'), 
('NC10000006', N'Apple FPT', N'Q3 HCM');

-- Nhà Sản Xuất (NS...)
INSERT INTO nha_san_xuat VALUES 
('NS10000001', N'Sony', N'Nhật Bản'), 
('NS10000002', N'Samsung', N'Hàn Quốc'), 
('NS10000003', N'LG', N'Hàn Quốc'), 
('NS10000004', N'Panasonic', N'Nhật Bản'), 
('NS10000005', N'Daikin', N'Nhật Bản'), 
('NS10000006', N'Apple', N'Mỹ');

-- Loại Hàng (LH...)
INSERT INTO loai_hang VALUES 
('LH10000001', N'Tivi', N'Nghe nhìn'), 
('LH10000002', N'Tủ lạnh', N'Điện lạnh'), 
('LH10000003', N'Máy giặt', N'Điện lạnh'), 
('LH10000004', N'Máy lạnh', N'Điện lạnh'), 
('LH10000005', N'Gia dụng', N'Nồi cơm, quạt'), 
('LH10000006', N'Laptop', N'Công nghệ');

-- Xếp Hạng (XH...) - Ưu đãi 0-100
INSERT INTO xep_hang VALUES 
('XH10000001', N'Thành viên', 0, 0),      
('XH10000002', N'Bạc', 10000000, 2),       
('XH10000003', N'Vàng', 50000000, 5),      
('XH10000004', N'Kim Cương', 200000000, 10); 

-- Chi Nhánh (CN...) - Gắn với Khu vực đã có
INSERT INTO chi_nhanh VALUES 
('CN10000001', N'CN Hà Nội', N'Cầu Giấy', 'KV10000001'), 
('CN10000002', N'CN Hải Phòng', N'Lê Chân', 'KV10000006'),
('CN10000003', N'CN Đà Nẵng', N'Hải Châu', 'KV10000002'),
('CN10000004', N'CN Quận 1', N'Q1 HCM', 'KV10000003'), 
('CN10000005', N'CN Thủ Đức', N'Thủ Đức', 'KV10000003'), 
('CN10000006', N'CN Cần Thơ', N'Ninh Kiều', 'KV10000005');

-- Kho Tổng (KT...)
INSERT INTO kho_tong VALUES 
('KT10000001', NULL, N'Kho Miền Bắc', N'HN', 5000), 
('KT10000002', NULL, N'Kho Miền Nam', N'BD', 8000);

-- Vi Phạm & Thưởng (VP..., TH...)
INSERT INTO loai_vi_pham VALUES ('VP10000001', N'Đi trễ', 1, 50000);
INSERT INTO loai_thuong VALUES ('TH10000001', N'Chuyên cần', 26, 500000);

---------------------------------------------------------------------------
-- 4. SẢN PHẨM (SP...) - 20 Món
---------------------------------------------------------------------------
INSERT INTO san_pham VALUES
('SP10000001', N'Tivi Sony 4K 55 inch', 'NS10000001', 'NC10000001', 15, 24, 15000000, '2023-01-01'),
('SP10000002', N'Tivi Samsung QLED 65"', 'NS10000002', 'NC10000002', 20, 36, 25000000, '2023-02-01'),
('SP10000003', N'Tủ lạnh LG Inverter', 'NS10000003', 'NC10000003', 60, 24, 8000000, '2023-03-01'),
('SP10000004', N'Tủ lạnh Pana 2 cánh', 'NS10000004', 'NC10000004', 55, 24, 7500000, '2023-03-15'),
('SP10000005', N'Máy giặt LG Ngang', 'NS10000003', 'NC10000003', 50, 24, 9000000, '2023-04-01'),
('SP10000006', N'Máy giặt Samsung Top', 'NS10000002', 'NC10000002', 45, 24, 6000000, '2023-04-10'),
('SP10000007', N'Máy lạnh Daikin 1HP', 'NS10000005', 'NC10000005', 30, 12, 10000000, '2023-05-01'),
('SP10000008', N'Máy lạnh Pana 1.5HP', 'NS10000004', 'NC10000004', 35, 12, 13000000, '2023-05-05'),
('SP10000009', N'Nồi cơm Sharp', 'NS10000004', 'NC10000003', 3, 12, 1500000, '2023-06-01'),
('SP10000010', N'Lò vi sóng Samsung', 'NS10000002', 'NC10000002', 10, 12, 3000000, '2023-06-15'),
('SP10000011', N'Macbook Air M1', 'NS10000006', 'NC10000006', 1.2, 12, 18000000, '2022-12-01'),
('SP10000012', N'Macbook Pro M2', 'NS10000006', 'NC10000006', 1.5, 12, 30000000, '2023-01-20'),
('SP10000013', N'Quạt Senko', 'NS10000004', 'NC10000004', 5, 12, 500000, '2023-07-01'),
('SP10000014', N'Bàn ủi Philips', 'NS10000004', 'NC10000003', 2, 12, 1200000, '2023-07-10'),
('SP10000015', N'Máy xay Sunhouse', 'NS10000002', 'NC10000002', 3, 12, 800000, '2023-08-01'),
('SP10000016', N'Tivi LG OLED 55"', 'NS10000003', 'NC10000003', 16, 24, 14000000, '2023-02-10'),
('SP10000017', N'Máy lạnh LG Dual', 'NS10000003', 'NC10000003', 32, 24, 10500000, '2023-05-20'),
('SP10000018', N'Tủ lạnh SideBySide', 'NS10000002', 'NC10000002', 100, 24, 30000000, '2023-03-20'),
('SP10000019', N'Robot hút bụi Xiaomi', 'NS10000002', 'NC10000002', 4, 12, 6500000, '2023-09-01'),
('SP10000020', N'Máy lọc không khí', 'NS10000004', 'NC10000004', 6, 12, 4000000, '2023-09-15');

-- Liên kết Sản phẩm - Loại hàng
INSERT INTO san_pham_loai_hang VALUES 
('SP10000001','LH10000001'),('SP10000002','LH10000001'),('SP10000003','LH10000002'),('SP10000004','LH10000002'),
('SP10000005','LH10000003'),('SP10000006','LH10000003'),('SP10000007','LH10000004'),('SP10000008','LH10000004'),
('SP10000009','LH10000005'),('SP10000010','LH10000005'),('SP10000011','LH10000006'),('SP10000012','LH10000006'),
('SP10000013','LH10000005'),('SP10000014','LH10000005'),('SP10000015','LH10000005'),('SP10000016','LH10000001'),
('SP10000017','LH10000004'),('SP10000018','LH10000002'),('SP10000019','LH10000005'),('SP10000020','LH10000005');

---------------------------------------------------------------------------
-- 5. NHÂN SỰ & KHÁCH HÀNG (NV..., KH...)
---------------------------------------------------------------------------
INSERT INTO nhan_vien VALUES 
('NV10000001', N'Nguyễn Quốc Hưng', 'CB10000005', '0901', N'HCM', 'CN10000004', 1), -- Giám đốc
('NV10000002', N'Trần Thị Thu Hà', 'CB10000004', '0902', N'HN', 'CN10000001', 1),  -- QL Sản phẩm (Bắc)
('NV10000003', N'Lê Văn Tùng', 'CB10000003', '0903', N'HCM', 'CN10000004', 1),  -- QL Khu vực Nam
('NV10000004', N'Phạm Minh Tuấn', 'CB10000002', '0904', N'HN', 'CN10000001', 1),  -- QL Chi nhánh HN
('NV10000005', N'Hoàng Thị Lan', 'CB10000002', '0905', N'ĐN', 'CN10000003', 1),  -- QL Chi nhánh ĐN
('NV10000006', N'Võ Văn Kiệt', 'CB10000002', '0906', N'HCM', 'CN10000004', 1),  -- QL Chi nhánh Q1
('NV10000007', N'Bùi Thị Hoa', 'CB10000001', '0907', N'HN', 'CN10000001', 1),   -- NV
('NV10000008', N'Đỗ Văn Nam', 'CB10000001', '0908', N'HP', 'CN10000002', 1),
('NV10000009', N'Ngô Thị Tuyết', 'CB10000001', '0909', N'ĐN', 'CN10000003', 1),
('NV10000010', N'Lý Văn Hùng', 'CB10000001', '0910', N'HCM', 'CN10000004', 1),
('NV10000011', N'Trương Thị Mỹ', 'CB10000001', '0911', N'HCM', 'CN10000004', 1),
('NV10000012', N'Đinh Văn Dũng', 'CB10000001', '0912', N'HCM', 'CN10000005', 1),
('NV10000013', N'Lâm Thị Bé', 'CB10000001', '0913', N'CT', 'CN10000006', 1),
('NV10000014', N'Phan Văn Khải', 'CB10000001', '0914', N'HN', 'CN10000001', 1), -- NV Kho
('NV10000015', N'Cao Thị Hồng', 'CB10000001', '0915', N'BD', 'CN10000004', 1);

-- Cập nhật quản lý kho/khu vực
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV10000002' WHERE ma_kho = 'KT10000001';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV10000003' WHERE ma_kho = 'KT10000002';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV10000003' WHERE ma_khu_vuc = 'KV10000003';

INSERT INTO tai_khoan SELECT ma_nhan_vien, '123', ma_cap_bac FROM nhan_vien;

INSERT INTO khach_hang VALUES 
('KH10000001', N'Nguyễn Thị Mai', '000', N'N/A', 'XH10000001', 0),
('KH10000002', N'Trần Văn Long', '0991', N'Q2', 'XH10000004', 500000000), -- Kim Cương
('KH10000003', N'Lê Thị Thanh', '0992', N'Q7', 'XH10000003', 80000000),  -- Vàng
('KH10000004', N'Phạm Văn Đức', '0993', N'HN', 'XH10000002', 15000000),  -- Bạc
('KH10000005', N'Hoàng Thị Yến', '0994', N'ĐN', 'XH10000001', 2000000),
('KH10000006', N'Võ Văn Bình', '0995', N'CT', 'XH10000001', 0),
('KH10000007', N'Đặng Thị Ngọc', '0996', N'HP', 'XH10000003', 60000000),
('KH10000008', N'Bùi Văn Tám', '0997', N'HN', 'XH10000001', 100000),
('KH10000009', N'Ngô Thị Hạnh', '0998', N'HCM', 'XH10000002', 12000000),
('KH10000010', N'Mai Văn Sáu', '0999', N'CT', 'XH10000001', 500000);

---------------------------------------------------------------------------
-- 6. KHO HÀNG (ĐẦY ĐỦ ĐỂ BÁN)
---------------------------------------------------------------------------
-- Kho Tổng
INSERT INTO san_pham_trong_kho_tong VALUES 
('KT10000001', 'SP10000001', 100), ('KT10000001', 'SP10000002', 100), ('KT10000001', 'SP10000007', 300),
('KT10000002', 'SP10000001', 200), ('KT10000002', 'SP10000004', 100), ('KT10000002', 'SP10000011', 50);

-- Kho Chi Nhánh (Mỗi CN đều có hàng)
-- Hà Nội
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000001', 'SP10000001', 20), ('CN10000001', 'SP10000007', 50), ('CN10000001', 'SP10000009', 30);
-- Hải Phòng
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000002', 'SP10000001', 10), ('CN10000002', 'SP10000013', 50);
-- Đà Nẵng
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000003', 'SP10000001', 15), ('CN10000003', 'SP10000011', 5);
-- Quận 1 (Nhiều hàng)
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000004', 'SP10000001', 50), ('CN10000004', 'SP10000002', 30), ('CN10000004', 'SP10000011', 20), ('CN10000004', 'SP10000012', 15);
-- Thủ Đức
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000005', 'SP10000001', 10), ('CN10000005', 'SP10000013', 100);
-- Cần Thơ
INSERT INTO san_pham_trong_chi_nhanh VALUES ('CN10000006', 'SP10000003', 15), ('CN10000006', 'SP10000007', 30);

---------------------------------------------------------------------------
-- 7. GIAO DỊCH (KM..., HD...)
---------------------------------------------------------------------------
INSERT INTO khuyen_mai VALUES 
('KM10000001', 10, 'LH10000001', '2023-01-01', '2025-12-31'), -- 10% Tivi
('KM10000002', 20, 'LH10000004', '2023-06-01', '2023-09-30'), -- 20% Mùa hè
('KM10000003', 5,  'LH10000006', '2023-01-01', '2025-12-31'); -- 5% Laptop

-- HD01: Khách Kim Cương (10%) mua Tivi (KM 10%)
-- Giá Gốc 15tr. Giảm KH 10% (1.5tr). Giảm KM 10% (1.35tr). Còn 12.15tr.
INSERT INTO hoa_don VALUES ('HD10000001', 'NV10000010', 'KH10000002', '2023-11-01');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000001', 'SP10000001', 'KM10000001', 1, 12150000, 15000000, '2023-11-01');

-- HD02: Khách Bạc (2%) mua Máy lạnh
INSERT INTO hoa_don VALUES ('HD10000002', 'NV10000007', 'KH10000004', '2023-11-02');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000002', 'SP10000007', NULL, 2, 9800000, 10000000, '2023-11-02');

-- HD03: Khách Vãng Lai (0%) mua Tủ lạnh
INSERT INTO hoa_don VALUES ('HD10000003', 'NV10000013', 'KH10000001', '2023-11-03');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000003', 'SP10000003', NULL, 1, 8000000, 8000000, '2023-11-03');

-- HD04: Khách Vàng (5%) mua Laptop (KM 5%)
INSERT INTO hoa_don VALUES ('HD10000004', 'NV10000010', 'KH10000003', '2023-11-04');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000004', 'SP10000011', 'KM10000003', 1, 16245000, 18000000, '2023-11-04');

-- Thêm nhiều hóa đơn khác
INSERT INTO hoa_don VALUES ('HD10000005', 'NV10000008', 'KH10000007', '2023-11-05');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000005', 'SP10000001', 'KM10000001', 1, 13500000, 15000000, '2023-11-05');

INSERT INTO hoa_don VALUES ('HD10000006', 'NV10000012', 'KH10000001', '2023-11-06');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000006', 'SP10000009', NULL, 2, 1500000, 1500000, '2023-11-06');

INSERT INTO hoa_don VALUES ('HD10000007', 'NV10000010', 'KH10000002', '2023-11-07');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000007', 'SP10000002', 'KM10000001', 1, 20250000, 25000000, '2023-11-07');

INSERT INTO hoa_don VALUES ('HD10000008', 'NV10000011', 'KH10000001', '2023-11-08');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000008', 'SP10000013', NULL, 5, 500000, 500000, '2023-11-08');

INSERT INTO hoa_don VALUES ('HD10000009', 'NV10000007', 'KH10000008', '2023-11-09');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000009', 'SP10000007', NULL, 1, 10000000, 10000000, '2023-11-09');

INSERT INTO hoa_don VALUES ('HD10000010', 'NV10000009', 'KH10000005', '2023-11-10');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000010', 'SP10000008', NULL, 1, 13000000, 13000000, '2023-11-10');

INSERT INTO hoa_don VALUES ('HD10000011', 'NV10000010', 'KH10000002', '2023-11-11');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000011', 'SP10000012', 'KM10000003', 1, 25650000, 30000000, '2023-11-11');

INSERT INTO hoa_don VALUES ('HD10000012', 'NV10000013', 'KH10000010', '2023-11-12');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000012', 'SP10000006', NULL, 1, 6000000, 6000000, '2023-11-12');

INSERT INTO hoa_don VALUES ('HD10000013', 'NV10000007', 'KH10000001', '2023-11-13');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000013', 'SP10000001', 'KM10000001', 1, 13500000, 15000000, '2023-11-13');

INSERT INTO hoa_don VALUES ('HD10000014', 'NV10000008', 'KH10000007', '2023-11-14');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000014', 'SP10000013', NULL, 3, 500000, 500000, '2023-11-14');

INSERT INTO hoa_don VALUES ('HD10000015', 'NV10000009', 'KH10000005', '2023-11-15');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000015', 'SP10000004', NULL, 1, 7500000, 7500000, '2023-11-15');

INSERT INTO hoa_don VALUES ('HD10000016', 'NV10000010', 'KH10000002', '2023-11-16');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000016', 'SP10000019', NULL, 1, 5850000, 6500000, '2023-11-16');

INSERT INTO hoa_don VALUES ('HD10000017', 'NV10000011', 'KH10000009', '2023-11-17');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000017', 'SP10000007', NULL, 1, 9800000, 10000000, '2023-11-17');

INSERT INTO hoa_don VALUES ('HD10000018', 'NV10000012', 'KH10000001', '2023-11-18');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000018', 'SP10000005', NULL, 1, 9000000, 9000000, '2023-11-18');

INSERT INTO hoa_don VALUES ('HD10000019', 'NV10000007', 'KH10000004', '2023-11-19');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000019', 'SP10000010', NULL, 1, 2940000, 3000000, '2023-11-19');

INSERT INTO hoa_don VALUES ('HD10000020', 'NV10000010', 'KH10000003', '2023-11-20');
INSERT INTO chi_tiet_hoa_don VALUES ('HD10000020', 'SP10000016', 'KM10000001', 2, 11970000, 14000000, '2023-11-20');
