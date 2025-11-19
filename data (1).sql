USE dien_may;
GO

-- ### NHÓM 1: BẢNG GỐC (KHÔNG PHỤ THUỘC) ###

-- Bảng: cap_bac_nhan_vien (20)
INSERT INTO cap_bac_nhan_vien (ma_cap_bac, ten_cap_bac, mo_ta_cap_bac) VALUES
('CB001', N'Nhân viên', N'Nhân viên bán hàng, kho'),
('CB002', N'Quản lý chi nhánh', N'Trưởng nhóm kinh doanh'),
('CB003', N'Quản lý khu vực', N'Quản lý chi nhánh'),
('CB004', N'Bộ phận sản phẩm', N'Giám đốc khu vực'),
('CB005', N'Giám đốc', N'Nhân viên phòng kế toán')
GO

-- Bảng: loai_hang (20)
INSERT INTO loai_hang (ma_loai_hang, ten_loai_hang, mo_ta) VALUES
('LH001', N'Tivi', N'Các loại tivi thông minh, 4K, 8K'),
('LH002', N'Tủ lạnh', N'Tủ lạnh gia đình, side-by-side'),
('LH003', N'Máy giặt', N'Máy giặt cửa trước, cửa trên'),
('LH004', N'Điều hòa', N'Điều hòa 1 chiều, 2 chiều'),
('LH005', N'Điện thoại', N'Điện thoại thông minh'),
('LH006', N'Laptop', N'Máy tính xách tay'),
('LH007', N'Âm thanh', N'Loa, tai nghe, amply'),
('LH008', N'Gia dụng nhỏ', N'Nồi cơm, lò vi sóng, máy xay'),
('LH009', N'Máy ảnh', N'Máy ảnh DSLR, Mirrorless'),
('LH010', N'Phụ kiện', N'Cáp sạc, pin dự phòng, chuột'),
('LH011', N'Máy tính bảng', N'iPad, Samsung Galaxy Tab'),
('LH012', N'Đồng hồ', N'Đồng hồ thông minh'),
('LH013', N'Máy sấy', N'Máy sấy quần áo'),
('LH014', N'Bếp điện', N'Bếp từ, bếp hồng ngoại'),
('LH015', N'Máy lọc nước', N'Máy lọc RO, Nano'),
('LH016', N'Quạt', N'Quạt cây, quạt trần'),
('LH017', N'PC - Máy bộ', N'Máy tính để bàn'),
('LH018', N'Màn hình', N'Màn hình máy tính'),
('LH019', N'Thiết bị mạng', N'Router, modem, switch'),
('LH020', N'Sim thẻ', N'Sim 4G, thẻ cào');
GO

-- Bảng: loai_thuong (20)
INSERT INTO loai_thuong (ma_loai_thuong, loai_yeu_cau, yeu_cau, muc_thuong) VALUES
('LT001', N'Doanh số', 500000000, 5000000),
('LT002', N'KPI', 100, 2000000),
('LT003', N'Chuyên cần', 26, 500000),
('LT004', N'Thâm niên 5 năm', 5, 3000000),
('LT005', N'Sáng kiến', 1, 1000000),
('LT006', N'Hỗ trợ', 10, 300000),
('LT007', N'Tết Âm lịch', 0, 10000000),
('LT008', N'Lễ 30/4', 0, 1000000),
('LT009', N'Quốc Khánh 2/9', 0, 1000000),
('LT010', N'NV Xuất sắc', 1, 5000000),
('LT011', N'Doanh số 1 tỷ', 1000000000, 10000000),
('LT012', N'Giới thiệu NV', 1, 500000),
('LT013', N'Sinh nhật', 0, 300000),
('LT014', N'Tết Dương lịch', 0, 500000),
('LT015', N'Không vi phạm', 0, 200000),
('LT016', N'Hỗ trợ kho', 5, 250000),
('LT017', N'Thâm niên 1 năm', 1, 1000000),
('LT018', N'Thâm niên 3 năm', 3, 2000000),
('LT019', N'Tăng ca', 40, 1000000),
('LT020', N'Đào tạo NV mới', 2, 600000);
GO

-- Bảng: loai_vi_pham (20)
INSERT INTO loai_vi_pham (ma_loai_vi_pham, mo_ta_vi_pham, muc_do_vi_pham, muc_phat) VALUES
('LVP001', N'Đi trễ < 15 phút', 1, 100000),
('LVP002', N'Về sớm < 15 phút', 1, 100000),
('LVP003', N'Quên đồng phục', 1, 50000),
('LVP004', N'Sai quy trình', 2, 500000),
('LVP005', N'Gây thất thoát', 3, 2000000),
('LVP006', N'Nghỉ không phép', 2, 300000),
('LVP007', N'Ăn vặt tại quầy', 1, 20000),
('LVP008', N'Sử dụng ĐT cá nhân', 1, 50000),
('LVP009', N'Thái độ xấu khách', 3, 1000000),
('LVP010', N'Mất vệ sinh', 1, 50000),
('LVP011', N'Đi trễ > 15 phút', 2, 250000),
('LVP012', N'Hút thuốc sai nơi', 1, 100000),
('LVP013', N'Làm mất thẻ NV', 1, 50000),
('LVP014', N'Làm hỏng CCDC', 2, 300000),
('LVP015', N'Quên chấm công', 1, 50000),
('LVP016', N'Gây gổ', 3, 1500000),
('LVP017', N'Ngủ gật', 2, 200000),
('LVP018', N'Sai sót sổ sách', 2, 400000),
('LVP019', N'Trang phục lôi thôi', 1, 50000),
('LVP020', N'Rời vị trí', 1, 100000);
GO

-- Bảng: nha_cung_cap (20)
INSERT INTO nha_cung_cap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi_nha_cung_cap) VALUES
('NCC001', N'Digiworld', N'Quận 1, TP. HCM'),
('NCC002', N'FPT Synnex', N'Cầu Giấy, Hà Nội'),
('NCC003', N'Petrosetco', N'Quận 3, TP. HCM'),
('NCC004', N'Viettel Distribution', N'Hoàn Kiếm, Hà Nội'),
('NCC005', N'Thế Giới Di Động', N'Quận 9, TP. HCM'),
('NCC006', N'Phúc Anh', N'Đống Đa, Hà Nội'),
('NCC007', N'An Phát PC', N'Hai Bà Trưng, Hà Nội'),
('NCC008', N'Song Tấn', N'Tân Bình, TP. HCM'),
('NCC009', N'Lê Phụng', N'Quận 10, TP. HCM'),
('NCC010', N'Ánh Minh', N'Đà Nẵng'),
('NCC011', N'MeKo', N'Quận 1, TP. HCM'),
('NCC012', N'Hoàng Hà Mobile', N'Cầu Giấy, Hà Nội'),
('NCC013', N'Cellphones', N'Quận 10, TP. HCM'),
('NCC014', N'Phú Thái', N'Thanh Xuân, Hà Nội'),
('NCC015', N'Dầu Khí', N'Ba Đình, Hà Nội'),
('NCC016', N'Viễn Thông A', N'Quận 1, TP. HCM'),
('NCC017', N'TLC', N'Đống Đa, Hà Nội'),
('NCC018', N'Thủy Linh', N'Hai Bà Trưng, Hà Nội'),
('NCC019', N'Vĩnh Xuân', N'Hoàn Kiếm, Hà Nội'),
('NCC020', N'Sunhouse', N'Hà Đông, Hà Nội');
GO

-- Bảng: nha_san_xuat (20)
INSERT INTO nha_san_xuat (ma_nha_san_xuat, ten_nha_san_xuat, dia_chi_nha_san_xuat) VALUES
('NSX001', N'Samsung', N'Hàn Quốc'),
('NSX002', N'LG', N'Hàn Quốc'),
('NSX003', N'Sony', N'Nhật Bản'),
('NSX004', N'Apple', N'Hoa Kỳ'),
('NSX005', N'Panasonic', N'Nhật Bản'),
('NSX006', N'Xiaomi', N'Trung Quốc'),
('NSX007', N'Dell', N'Hoa Kỳ'),
('NSX008', N'HP', N'Hoa Kỳ'),
('NSX009', N'Asus', N'Đài Loan'),
('NSX010', N'Bose', N'Hoa Kỳ'),
('NSX011', N'Hitachi', N'Nhật Bản'),
('NSX012', N'Toshiba', N'Nhật Bản'),
('NSX013', N'Sharp', N'Nhật Bản'),
('NSX014', N'Aqua', N'Trung Quốc'),
('NSX015', N'Kangaroo', N'Việt Nam'),
('NSX016', N'Sunhouse', N'Việt Nam'),
('NSX017', N'Logitech', N'Thụy Sĩ'),
('NSX018', N'JBL', N'Hoa Kỳ'),
('NSX019', N'Canon', N'Nhật Bản'),
('NSX020', N'Nikon', N'Nhật Bản');
GO

-- Bảng: xep_hang (20)
INSERT INTO xep_hang (ma_hang, ten_hang, yeu_cau, uu_dai) VALUES
('XH001', N'Đồng', 5000000, 0.01),
('XH002', N'Bạc', 15000000, 0.02),
('XH003', N'Vàng', 50000000, 0.03),
('XH004', N'Bạch kim', 100000000, 0.05),
('XH005', N'Kim cương', 500000000, 0.07),
('XH006', N'Thành viên', 0, 0),
('XH007', N'VIP', 200000000, 0.06),
('XH008', N'Đối tác', 0, 0.1),
('XH009', N'VVIP', 1000000000, 0.1),
('XH010', N'Member', 1000000, 0.005),
('XH011', N'Thân thiết', 30000000, 0.025),
('XH012', N'Titanium', 300000000, 0.065),
('XH013', N'Gold Plus', 75000000, 0.04),
('XH014', LTRIM(RTRIM(N'Silver Plus')), 20000000, 0.022),
('XH015', N'Bronze Plus', 10000000, 0.015),
('XH016', N'Newbie', 0, 0),
('XH017', N'Loyal', 25000000, 0.023),
('XH018', N'Premium', 80000000, 0.045),
('XH019', N'Elite', 150000000, 0.055),
('XH020', N'Ultimate', 2000000000, 0.12);
GO

-- Bảng: khu_vuc (20) (nhan_vien_quan_ly = NULL)
INSERT INTO khu_vuc (ma_khu_vuc, ten_khu_vuc, nhan_vien_quan_ly) VALUES
('KV001', N'Miền Bắc', NULL),
('KV002', N'Miền Trung', NULL),
('KV003', N'Miền Nam', NULL),
('KV004', N'Tây Nguyên', NULL),
('KV005', N'Đồng bằng SCL', NULL),
('KV006', N'Đông Bắc Bộ', NULL),
('KV007', N'Tây Bắc Bộ', NULL),
('KV008', N'Bắc Trung Bộ', NULL),
('KV009', N'Nam Trung Bộ', NULL),
('KV010', N'Hà Nội', NULL),
('KV011', N'TP. Hồ Chí Minh', NULL),
('KV012', N'Đà Nẵng', NULL),
('KV013', N'Hải Phòng', NULL),
('KV014', N'Cần Thơ', NULL),
('KV015', N'Đồng Nai', NULL),
('KV016', N'Bình Dương', NULL),
('KV017', N'An Giang', NULL),
('KV018', N'Kiên Giang', NULL),
('KV019', N'Khánh Hòa', NULL),
('KV020', N'Nghệ An', NULL);
GO

-- ### NHÓM 2: PHỤ THUỘC NHÓM 1 ###

-- Bảng: khach_hang (20)
INSERT INTO khach_hang (ma_khach_hang, ho_ten_khach_hang, sdt, diachi, xep_hang, diem) VALUES
('KH001', N'Nguyễn Văn An', '0905111222', N'Hà Nội', 'XH003', 5500),
('KH002', N'Trần Thị Bình', '0913222333', N'TP. HCM', 'XH002', 2000),
('KH003', N'Lê Hoàng Cường', '0987333444', N'Đà Nẵng', 'XH001', 800),
('KH004', N'Phạm Mỹ Duyên', '0979444555', N'Cần Thơ', 'XH006', 50),
('KH005', N'Võ Minh Hải', '0935555666', N'Hải Phòng', 'XH004', 12000),
('KH006', N'Đỗ Gia Hân', '0909666777', N'TP. HCM', 'XH003', 6000),
('KH007', N'Hoàng Tuấn Kiệt', '0918777888', N'Nha Trang', 'XH001', 600),
('KH008', N'Lý Thu Thảo', '0947888999', N'Hà Nội', 'XH002', 1700),
('KH009', N'Bùi Chí Thanh', '0903999000', N'Bình Dương', 'XH006', 0),
('KH010', N'Mai Anh Thư', '0908000111', N'Vũng Tàu', 'XH005', 51000),
('KH011', N'Trịnh Văn Quyết', '0912345678', N'Hà Nội', 'XH001', 100),
('KH012', N'Đặng Lê Nguyên Vũ', '0987654321', N'BMT', 'XH010', 1200),
('KH013', N'Phạm Nhật Vượng', '0905888888', N'Hà Nội', 'XH009', 99000),
('KH014', N'Hồ Xuân Năng', '0913999888', N'TP. HCM', 'XH007', 25000),
('KH015', N'Nguyễn Thị Phương Thảo', '0905777666', N'Đà Lạt', 'XH004', 15000),
('KH016', N'Trần Đình Long', '0903555444', N'Hải Dương', 'XH003', 7000),
('KH017', N'Cao Thị Ngọc Dung', '0918111333', N'TP. HCM', 'XH002', 3000),
('KH018', N'Lê Viết Lam', '0905222444', N'Thanh Hóa', 'XH001', 900),
('KH019', N'Dương Công Minh', '0988555666', N'Bắc Ninh', 'XH006', 20),
('KH020', N'Nguyễn Đăng Quang', '0917777888', N'Quảng Trị', 'XH008', 30000);
GO

-- Bảng: khuyen_mai (20)
INSERT INTO khuyen_mai (ma_khuyen_mai, giam_gia, ma_loai_hang, ngay_bat_dau, ngay_ket_thuc) VALUES
('KM001', 0.1, 'LH001', '2024-10-01 00:00:00', '2024-10-31 23:59:59'),
('KM002', 0.15, 'LH008', '2024-11-01 00:00:00', '2024-11-15 23:59:59'),
('KM003', 0.05, 'LH005', '2024-09-01 00:00:00', '2024-09-30 23:59:59'),
('KM004', 0.2, 'LH003', '2024-12-01 00:00:00', '2024-12-31 23:59:59'),
('KM005', 500000, 'LH006', '2024-10-15 00:00:00', '2024-11-15 23:59:59'),
('KM006', 0.1, 'LH002', '2024-10-20 00:00:00', '2024-11-20 23:59:59'),
('KM007', 0.3, 'LH010', '2024-11-11 00:00:00', '2024-11-11 23:59:59'),
('KM008', 1000000, 'LH009', '2024-01-01 00:00:00', '2024-12-31 23:59:59'),
('KM009', 0.1, 'LH004', '2024-06-01 00:00:00', '2024-08-30 23:59:59'),
('KM010', 0.05, 'LH007', '2024-10-01 00:00:00', '2024-10-15 23:59:59'),
('KM011', 0.2, 'LH011', '2024-11-20 00:00:00', '2024-11-30 23:59:59'),
('KM012', 300000, 'LH012', '2024-12-01 00:00:00', '2024-12-25 23:59:59'),
('KM013', 0.1, 'LH013', '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
('KM014', 0.15, 'LH014', '2024-09-15 00:00:00', '2024-10-15 23:59:59'),
('KM015', 200000, 'LH015', '2024-01-01 00:00:00', '2024-12-31 23:59:59'),
('KM016', 0.05, 'LH016', '2024-05-01 00:00:00', '2024-05-31 23:59:59'),
('KM017', 0.25, 'LH017', '2024-11-15 00:00:00', '2024-11-30 23:59:59'),
('KM018', 150000, 'LH018', '2024-10-10 00:00:00', '2024-10-20 23:59:59'),
('KM019', 0.3, 'LH019', '2024-12-20 00:00:00', '2024-12-25 23:59:59'),
('KM020', 0.1, 'LH020', '2024-01-01 00:00:00', '2024-12-31 23:59:59');
GO

-- Bảng: san_pham (20)
INSERT INTO san_pham (ma_san_pham, ten_san_pham, ma_nha_san_xuat, ma_nha_cung_cap, khoi_luong, thoi_gian_bao_hanh, gia_tien, ngay_san_xuat) VALUES
('SP001', N'Tivi Samsung QLED 4K 55 inch', 'NSX001', 'NCC001', 20.5, 24, 25000000, '2024-01-15'),
('SP002', N'Tủ lạnh LG Inverter 315L', 'NSX002', 'NCC002', 65.0, 24, 14000000, '2024-02-10'),
('SP003', N'Máy ảnh Sony A7M4', 'NSX003', 'NCC003', 0.65, 12, 58000000, '2023-11-20'),
('SP004', N'iPhone 16 Pro Max 256GB', 'NSX004', 'NCC004', 0.22, 12, 35000000, '2024-09-30'),
('SP005', N'Điều hòa Panasonic 12000BTU', 'NSX005', 'NCC001', 30.0, 24, 11500000, '2024-03-05'),
('SP006', N'Laptop Dell XPS 15', 'NSX007', 'NCC002', 1.8, 12, 45000000, '2024-05-01'),
('SP007', N'Máy giặt Samsung AI 10kg', 'NSX001', 'NCC005', 70.0, 24, 16000000, '2024-04-12'),
('SP008', N'Loa Bose SoundLink Revolve+', 'NSX010', 'NCC008', 0.9, 12, 7500000, '2023-12-25'),
('SP009', N'Nồi cơm điện Xiaomi', 'NSX006', 'NCC006', 3.5, 6, 1800000, '2024-01-30'),
('SP010', N'Tai nghe Sony WH-1000XM5', 'NSX003', 'NCC003', 0.25, 12, 8500000, '2024-06-10'),
('SP011', N'iPad Pro M4 11 inch', 'NSX004', 'NCC004', 0.44, 12, 28000000, '2024-05-15'),
('SP012', N'Apple Watch Series 10', 'NSX004', 'NCC004', 0.05, 12, 11000000, '2024-09-30'),
('SP013', N'Máy sấy Aqua 10kg', 'NSX014', 'NCC005', 45.0, 24, 9500000, '2024-03-01'),
('SP014', N'Bếp từ Kangaroo', 'NSX015', 'NCC010', 5.0, 12, 1200000, '2024-02-01'),
('SP015', N'Máy lọc nước Kangaroo', 'NSX015', 'NCC010', 25.0, 36, 6000000, '2024-01-01'),
('SP016', N'Quạt cây Sunhouse', 'NSX016', 'NCC006', 6.0, 12, 800000, '2024-04-01'),
('SP017', N'PC Gaming Asus Tuf', 'NSX009', 'NCC007', 15.0, 24, 23000000, '2024-05-05'),
('SP018', N'Màn hình Dell Ultrasharp 27"', 'NSX007', 'NCC002', 7.0, 36, 8500000, '2024-03-10'),
('SP019', N'Canon R6 Mark II', 'NSX019', 'NCC003', 0.67, 12, 60000000, '2023-10-01'),
('SP020', N'Router Wifi Asus', 'NSX009', 'NCC007', 0.5, 24, 1500000, '2024-06-01');
GO

-- ### NHÓM 3: PHỤ THUỘC NHÓM 2 ###

-- Bảng: chi_nhanh (20)
INSERT INTO chi_nhanh (ma_chi_nhanh, ten_chi_nhanh, dia_chi, khu_vuc) VALUES
('CN001', N'Hà Nội 1', N'123 Bà Triệu, Hà Nội', 'KV010'),
('CN002', N'Hà Nội 2', N'456 Cầu Giấy, Hà Nội', 'KV010'),
('CN003', N'Hải Phòng', N'789 Lê Lợi, Hải Phòng', 'KV013'),
('CN004', N'Đà Nẵng', N'101 Nguyễn Văn Linh, Đà Nẵng', 'KV012'),
('CN005', N'Nha Trang', N'202 Trần Phú, Nha Trang', 'KV019'),
('CN006', N'HCM 1', N'303 Nguyễn Trãi, Q1, TP. HCM', 'KV011'),
('CN007', N'HCM 2', N'404 Lê Văn Sỹ, Q3, TP. HCM', 'KV011'),
('CN008', N'Cần Thơ', N'505 Nguyễn Văn Cừ, Cần Thơ', 'KV014'),
('CN009', N'Buôn Ma Thuột', N'606 Lý Thường Kiệt, BMT', 'KV004'),
('CN010', N'Vinh', N'707 Quang Trung, Vinh', 'KV020'),
('CN011', N'HCM 3', N'808 Cộng Hòa, Tân Bình, TP. HCM', 'KV011'),
('CN012', N'Bình Dương', N'111 Yersin, Thủ Dầu Một', 'KV016'),
('CN013', N'Đồng Nai', N'222 Phạm Văn Thuận, Biên Hòa', 'KV015'),
('CN014', N'Hà Nội 3', N'333 Nguyễn Trãi, Thanh Xuân', 'KV010'),
('CN015', N'An Giang', N'444 Trần Hưng Đạo, Long Xuyên', 'KV017'),
('CN016', N'Kiên Giang', N'555 Nguyễn Trung Trực, Rạch Giá', 'KV018'),
('CN017', N'Đà Nẵng 2', N'666 Lê Duẩn, Thanh Khê', 'KV012'),
('CN018', N'Hải Phòng 2', N'777 Tô Hiệu, Lê Chân', 'KV013'),
('CN019', N'Cần Thơ 2', N'888 30/4, Ninh Kiều', 'KV014'),
('CN020', N'HCM 4', N'999 Quang Trung, Gò Vấp, TP. HCM', 'KV011');
GO

-- Bảng: san_pham_loai_hang (20)
INSERT INTO san_pham_loai_hang (ma_san_pham, ma_loai_hang) VALUES
('SP001', 'LH001'),
('SP002', 'LH002'),
('SP003', 'LH009'),
('SP004', 'LH005'),
('SP005', 'LH004'),
('SP006', 'LH006'),
('SP007', 'LH003'),
('SP008', 'LH007'),
('SP009', 'LH008'),
('SP010', 'LH007'),
('SP011', 'LH011'),
('SP012', 'LH012'),
('SP013', 'LH013'),
('SP014', 'LH014'),
('SP015', 'LH015'),
('SP016', 'LH016'),
('SP017', 'LH017'),
('SP018', 'LH018'),
('SP019', 'LH009'),
('SP020', 'LH019');
GO

-- ### NHÓM 4: PHỤ THUỘC NHÓM 3 ###

-- Bảng: nhan_vien (20)
INSERT INTO nhan_vien (ma_nhan_vien, ho_va_ten, ma_cap_bac, so_dien_thoai, dia_chi_thuong_tru, ma_chi_nhanh, trang_thai) VALUES
('NV001', N'Nguyễn Văn Hùng', 'CB001', '0912345678', N'Ba Đình, Hà Nội', 'CN001', 1),
('NV002', N'Trần Thị Thu', 'CB001', '0987654321', N'Quận 1, TP. HCM', 'CN006', 1),
('NV003', N'Lê Văn Luyện', 'CB001', '0905123456', N'Hải Châu, Đà Nẵng', 'CN004', 1),
('NV004', N'Phạm Thị Mai', 'CB004', '0933456789', N'Cầu Giấy, Hà Nội', 'CN002', 1),
('NV005', N'Võ Minh Đức', 'CB006', '0977890123', N'Quận 3, TP. HCM', 'CN007', 1),
('NV006', N'Hoàng Thị Kim', 'CB002', '0915678901', N'Lê Chân, Hải Phòng', 'CN003', 1),
('NV007', N'Đỗ Bá Phước', 'CB001', '0908901234', N'Ninh Kiều, Cần Thơ', 'CN008', 1),
('NV008', N'Bùi Thu Trang', 'CB003', '0945123789', N'Ba Đình, Hà Nội', 'CN001', 1),
('NV009', N'Lý Văn Toàn', 'CB003', '0909555888', N'Thủ Đức, TP. HCM', 'CN006', 0),
('NV010', N'Mai Ngọc Anh', 'CB02', '0902789456', N'Sơn Trà, Đà Nẵng', 'CN004', 1),
('NV011', N'Đào Văn An', 'CB001', '0918111222', N'Tân Bình, TP. HCM', 'CN011', 1),
('NV012', N'Lê Thị Hoa', 'CB001', '0918222333', N'Thủ Dầu Một, Bình Dương', 'CN012', 1),
('NV013', N'Trần Văn Nam', 'CB001', '0918333444', N'Biên Hòa, Đồng Nai', 'CN013', 1),
('NV014', N'Ngô Thị Lan', 'CB002', '0918444555', N'Thanh Xuân, Hà Nội', 'CN014', 1),
('NV015', N'Vũ Hải Đăng', 'CB003', '0918555666', N'Long Xuyên, An Giang', 'CN015', 1),
('NV016', N'Hồ Văn Trung', 'CB001', '0918666777', N'Rạch Giá, Kiên Giang', 'CN016', 1),
('NV017', N'Phan Thanh Bình', 'CB005', '0918777888', N'Thanh Khê, Đà Nẵng', 'CN017', 1),
('NV018', N'Nguyễn Thị Kiều', 'CB001', '0918888999', N'Lê Chân, Hải Phòng', 'CN018', 1),
('NV019', N'Lâm Văn Phát', 'CB001', '0918999000', N'Cái Răng, Cần Thơ', 'CN019', 1),
('NV020', N'Trương Mỹ Lan', 'CB003', '0918000111', N'Gò Vấp, TP. HCM', 'CN020', 1);
GO

-- ### NHÓM 5: PHỤ THUỘC NHÓM 4 ###

-- Bảng: kho_tong (20) (nhan_vien_quan_ly = NULL)
INSERT INTO kho_tong (ma_kho, nhan_vien_quan_ly, ten_kho, dia_chi, suc_chua) VALUES
('KHO01', NULL, N'Kho Tổng Miền Bắc', N'Từ Liêm, Hà Nội', 5000),
('KHO02', NULL, N'Kho Tổng Miền Nam', N'Bình Chánh, TP. HCM', 7000),
('KHO03', NULL, N'Kho Tổng Miền Trung', N'Liên Chiểu, Đà Nẵng', 4000),
('KHO04', NULL, N'Kho ĐBSCL', N'Cái Răng, Cần Thơ', 3000),
('KHO05', NULL, N'Kho Hải Phòng', N'Hải An, Hải Phòng', 2500),
('KHO06', NULL, N'Kho Phụ Hà Nội', N'Long Biên, Hà Nội', 1500),
('KHO07', NULL, N'Kho Phụ HCM', N'Quận 12, TP. HCM', 2000),
('KHO08', NULL, N'Kho Nha Trang', N'Diên Khánh, Nha Trang', 1000),
('KHO09', NULL, N'Kho Tây Nguyên', N'Cư Mgar, BMT', 1000),
('KHO10', NULL, N'Kho Nghệ An', N'TP. Vinh', 1200),
('KHO11', NULL, N'Kho Bình Dương', N'Dĩ An, Bình Dương', 3500),
('KHO12', NULL, N'Kho Đồng Nai', N'Long Thành, Đồng Nai', 3000),
('KHO13', NULL, N'Kho An Giang', N'Châu Đốc, An Giang', 1000),
('KHO14', NULL, N'Kho Kiên Giang', N'Phú Quốc, Kiên Giang', 1500),
('KHO15', NULL, N'Kho HCM 2', N'Củ Chi, TP. HCM', 2500),
('KHO16', NULL, N'Kho Hà Nội 3', N'Gia Lâm, Hà Nội', 1800),
('KHO17', NULL, N'Kho Thanh Hóa', N'Sầm Sơn, Thanh Hóa', 1300),
('KHO18', NULL, N'Kho Quảng Ninh', N'Hạ Long, Quảng Ninh', 1400),
('KHO19', NULL, N'Kho Thái Nguyên', N'Sông Công, Thái Nguyên', 900),
('KHO20', NULL, N'Kho Bắc Ninh', N'Từ Sơn, Bắc Ninh', 1100);
GO

-- Bảng: bao_hanh (20)
INSERT INTO bao_hanh (ma_bao_hanh, ma_san_pham, ma_khach_hang, nhan_vien_bao_hanh, ly_do, ngay_gui, ngay_xong, hoan_thanh) VALUES
('BH001', 'SP001', 'KH001', 'NV005', N'Màn hình bị sọc', '2024-10-01 10:00:00', '2024-10-05 14:00:00', 1),
('BH002', 'SP006', 'KH004', 'NV005', N'Không lên nguồn', '2024-10-02 11:00:00', '2024-10-07 17:00:00', 1),
('BH003', 'SP003', 'KH010', 'NV005', N'Lỗi lấy nét', '2024-10-03 14:30:00', '2024-10-10 10:00:00', 1),
('BH004', 'SP010', 'KH008', 'NV017', N'Rè một bên tai', '2024-10-05 09:00:00', NULL, 0),
('BH005', 'SP002', 'KH002', 'NV017', N'Kém lạnh', '2024-10-06 16:00:00', '2024-10-08 11:00:00', 1),
('BH006', 'SP007', 'KH006', 'NV005', N'Kêu to khi vắt', '2024-10-07 08:30:00', NULL, 0),
('BH007', 'SP004', 'KH005', 'NV005', N'Lỗi FaceID', '2024-10-10 13:00:00', '2024-10-12 13:00:00', 1),
('BH008', 'SP001', 'KH001', 'NV017', N'Lỗi kết nối wifi', '2024-10-11 15:00:00', NULL, 0),
('BH009', 'SP008', 'KH003', 'NV005', N'Pin nhanh hết', '2024-10-12 11:00:00', '2024-10-13 17:00:00', 1),
('BH010', 'SP005', 'KH007', 'NV017', N'Chảy nước', '2024-10-15 10:00:00', '2024-10-15 16:00:00', 1),
('BH011', 'SP011', 'KH013', 'NV005', N'Liệt cảm ứng', '2024-11-01 09:00:00', NULL, 0),
('BH012', 'SP012', 'KH013', 'NV017', N'Không đo được SpO2', '2024-11-01 09:00:00', NULL, 0),
('BH013', 'SP013', 'KH015', 'NV005', N'Sấy không khô', '2024-11-02 10:00:00', '2024-11-04 10:00:00', 1),
('BH014', 'SP014', 'KH016', 'NV017', N'Bếp không nóng', '2024-11-03 11:00:00', '2024-11-03 15:00:00', 1),
('BH015', 'SP015', 'KH018', 'NV005', N'Rò rỉ nước', '2024-11-04 14:00:00', NULL, 0),
('BH016', 'SP016', 'KH019', 'NV017', N'Quạt không quay', '2024-11-05 15:00:00', '2024-11-05 16:00:00', 1),
('BH017', 'SP017', 'KH020', 'NV005', N'Lỗi card màn hình', '2024-11-06 16:00:00', NULL, 0),
('BH018', 'SP018', 'KH011', 'NV017', N'Màn hình bị đốm', '2024-11-07 17:00:00', NULL, 0),
('BH019', 'SP019', 'KH010', 'NV005', N'Kẹt ống kính', '2024-11-08 08:00:00', '2024-11-10 17:00:00', 1),
('BH020', 'SP020', 'KH009', 'NV017', N'Wifi chập chờn', '2024-11-09 09:00:00', NULL, 0);
GO

-- Bảng: diem_danh (20)
INSERT INTO diem_danh (ma_diem_danh, ma_nhan_vien, thoi_gian_vao, thoi_gian_ra) VALUES
('DD001', 'NV001', '2024-11-01 07:58:00', '2024-11-01 17:02:00'),
('DD002', 'NV002', '2024-11-01 08:30:00', '2024-11-01 18:01:00'),
('DD003', 'NV003', '2024-11-01 08:29:00', '2024-11-01 17:59:00'),
('DD004', 'NV004', '2024-11-01 08:01:00', '2024-11-01 17:05:00'),
('DD005', 'NV005', '2024-11-01 08:00:00', '2024-11-01 17:00:00'),
('DD006', 'NV006', '2024-11-01 07:55:00', '2024-11-01 17:03:00'),
('DD007', 'NV007', '2024-11-01 08:35:00', '2024-11-01 18:00:00'),
('DD008', 'NV008', '2024-11-01 08:28:00', '2024-11-01 18:02:00'),
('DD009', 'NV010', '2024-11-01 07:59:00', '2024-11-01 17:01:00'),
('DD010', 'NV011', '2024-11-01 08:02:00', '2024-11-01 17:00:00'),
('DD011', 'NV001', '2024-11-02 07:57:00', '2024-11-02 17:01:00'),
('DD012', 'NV002', '2024-11-02 08:31:00', '2024-11-02 18:03:00'),
('DD013', 'NV003', '2024-11-02 08:25:00', '2024-11-02 17:55:00'),
('DD014', 'NV004', '2024-11-02 08:00:00', '2024-11-02 17:00:00'),
('DD015', 'NV005', '2024-11-02 07:59:00', '2024-11-02 17:02:00'),
('DD016', 'NV006', '2024-11-02 07:58:00', '2024-11-02 17:00:00'),
('DD017', 'NV007', '2024-11-02 08:40:00', '2024-11-02 18:01:00'),
('DD018', 'NV008', '2024-11-02 08:30:00', '2024-11-02 18:00:00'),
('DD019', 'NV010', '2024-11-02 08:01:00', '2024-11-02 17:03:00'),
('DD020', 'NV011', '2024-11-02 08:00:00', '2024-11-02 17:01:00');
GO

-- Bảng: hoa_don (20)
INSERT INTO hoa_don (ma_hoa_don, ma_nhan_vien_lap, ma_khach_hang, ngay_lap) VALUES
('HD001', 'NV002', 'KH001', '2024-10-20 09:30:15'),
('HD002', 'NV003', 'KH002', '2024-10-20 11:15:45'),
('HD003', 'NV002', 'KH004', '2024-10-21 14:05:20'),
('HD004', 'NV007', 'KH005', '2024-10-21 16:40:00'),
('HD005', 'NV006', 'KH010', '2024-10-22 08:55:10'),
('HD006', 'NV002', 'KH001', '2024-10-22 10:20:30'),
('HD007', 'NV003', 'KH003', '2024-10-23 11:00:00'),
('HD008', 'NV005', 'KH008', '2024-10-23 15:10:05'),
('HD009', 'NV002', 'KH007', '2024-10-24 10:00:00'),
('HD010', 'NV006', 'KH006', '2024-10-25 09:00:00'),
('HD011', 'NV011', 'KH011', '2024-10-26 10:00:00'),
('HD012', 'NV012', 'KH012', '2024-10-26 11:00:00'),
('HD013', 'NV013', 'KH013', '2024-10-27 12:00:00'),
('HD014', 'NV014', 'KH014', '2024-10-27 13:00:00'),
('HD015', 'NV019', 'KH015', '2024-10-28 14:00:00'),
('HD016', 'NV011', 'KH016', '2024-10-28 15:00:00'),
('HD017', 'NV012', 'KH017', '2024-10-29 16:00:00'),
('HD018', 'NV013', 'KH018', '2024-10-29 17:00:00'),
('HD019', 'NV014', 'KH019', '2024-10-30 18:00:00'),
('HD020', 'NV019', 'KH020', '2024-10-31 19:00:00');
GO

-- Bảng: luong (20)
INSERT INTO luong (ma_phieu_luong, ma_nhan_vien, luong_co_ban, he_so, thang_luong, thuong, phat) VALUES
('PL001', 'NV001', 12000000, 1.5, '2024-10-01', 2000000, 0),
('PL002', 'NV002', 7000000, 1.0, '2024-10-01', 500000, 100000),
('PL003', 'NV003', 7000000, 1.0, '2024-10-01', 0, 0),
('PL004', 'NV004', 10000000, 1.2, '2024-10-01', 500000, 0),
('PL005', 'NV005', 9000000, 1.3, '2024-10-01', 0, 50000),
('PL006', 'NV006', 9000000, 1.2, '2024-10-01', 1000000, 0),
('PL007', 'NV007', 7000000, 1.0, '2024-10-01', 0, 200000),
('PL008', 'NV008', 4000000, 1.0, '2024-10-01', 0, 0),
('PL009', 'NV009', 20000000, 2.0, '2024-10-01', 5000000, 0),
('PL010', 'NV010', 15000000, 1.6, '2024-10-01', 3000000, 0),
('PL011', 'NV011', 7000000, 1.0, '2024-10-01', 0, 0),
('PL012', 'NV012', 7000000, 1.0, '2024-10-01', 200000, 0),
('PL013', 'NV013', 7000000, 1.0, '2024-10-01', 0, 50000),
('PL014', 'NV014', 9000000, 1.2, '2024-10-01', 1000000, 0),
('PL015', 'NV015', 6000000, 1.0, '2024-10-01', 0, 0),
('PL016', 'NV016', 8000000, 1.1, '2024-10-01', 0, 0),
('PL017', 'NV017', 9000000, 1.3, '2024-10-01', 500000, 0),
('PL018', 'NV018', 6500000, 1.0, '2024-10-01', 0, 150000),
('PL019', 'NV019', 7000000, 1.0, '2024-10-01', 0, 0),
('PL020', 'NV020', 12000000, 1.5, '2024-10-01', 1500000, 0);
GO

-- Bảng: nghi_viec (20)
INSERT INTO nghi_viec (ma_nghi_viec, nhan_vien_nghi_viec, ly_do, thoi_gian_cho_nghi) VALUES
('NVL001', 'NV009', N'Lý do cá nhân', '2024-09-30 17:00:00'),
('NVL002', 'NV008', N'Hết hạn thực tập', '2024-10-31 17:00:00'),
('NVL003', 'NV007', N'Vi phạm nhiều lần', '2024-09-15 17:00:00'),
('NVL004', 'NV001', NULL, NULL),
('NVL005', 'NV002', NULL, NULL),
('NVL006', 'NV003', NULL, NULL),
('NVL007', 'NV004', NULL, NULL),
('NVL008', 'NV005', NULL, NULL),
('NVL009', 'NV006', NULL, NULL),
('NVL010', 'NV010', NULL, NULL),
('NVL011', 'NV011', NULL, NULL),
('NVL012', 'NV012', NULL, NULL),
('NVL013', 'NV013', NULL, NULL),
('NVL014', 'NV014', NULL, NULL),
('NVL015', 'NV015', NULL, NULL),
('NVL016', 'NV016', NULL, NULL),
('NVL017', 'NV017', NULL, NULL),
('NVL018', 'NV018', NULL, NULL),
('NVL019', 'NV019', NULL, NULL),
('NVL020', 'NV020', N'Chuyển công tác', '2024-11-15 17:00:00');
GO

-- Bảng: tai_khoan (20)
INSERT INTO tai_khoan (ma_nhan_vien, mat_khau, quyen) VALUES
('NV001', 'pass123', 'CB003'),
('NV002', 'pass123', 'CB001'),
('NV003', 'pass123', 'CB001'),
('NV004', 'pass123', 'CB005'),
('NV005', 'pass123', 'CB006'),
('NV006', 'pass123', 'CB002'),
('NV007', 'pass123', 'CB001'),
('NV008', 'pass123', 'CB007'),
('NV009', 'pass123', 'CB004'),
('NV010', 'pass123', 'CB010'),
('NV011', 'pass123', 'CB001'),
('NV012', 'pass123', 'CB001'),
('NV013', 'pass123', 'CB001'),
('NV014', 'pass123', 'CB002'),
('NV015', 'pass123', 'CB008'),
('NV016', 'pass123', 'CB015'),
('NV017', 'pass123', 'CB006'),
('NV018', 'pass123', 'CB016'),
('NV019', 'pass123', 'CB001'),
('NV020', 'pass123', 'CB003');
GO

-- Bảng: thuong (20)
INSERT INTO thuong (ma_thuong, ma_nhan_vien, ma_loai_thuong, trang_thai, thoi_gian_thuong) VALUES
('T001', 'NV001', 'LT002', 1, '2024-10-01 09:00:00'),
('T002', 'NV002', 'LT003', 1, '2024-10-01 09:00:00'),
('T003', 'NV006', 'LT001', 1, '2024-10-01 09:00:00'),
('T004', 'NV004', 'LT003', 1, '2024-10-01 09:00:00'),
('T005', 'NV005', 'LT005', 0, '2024-10-05 15:00:00'),
('T006', 'NV009', 'LT001', 1, '2024-10-01 09:00:00'),
('T007', 'NV010', 'LT002', 1, '2024-10-01 09:00:00'),
('T008', 'NV001', 'LT004', 1, '2024-09-20 10:00:00'),
('T009', 'NV003', 'LT006', 0, '2024-09-15 11:00:00'),
('T010', 'NV002', 'LT006', 1, '2024-09-18 14:00:00'),
('T011', 'NV011', 'LT003', 1, '2024-10-01 09:00:00'),
('T012', 'NV012', 'LT003', 1, '2024-10-01 09:00:00'),
('T013', 'NV014', 'LT002', 1, '2024-10-01 09:00:00'),
('T014', 'NV017', 'LT005', 1, '2024-10-06 10:00:00'),
('T015', 'NV020', 'LT001', 0, '2024-10-01 09:00:00'),
('T016', 'NV016', 'LT019', 1, '2024-10-01 09:00:00'),
('T017', 'NV004', 'LT012', 1, '2024-10-07 14:00:00'),
('T018', 'NV018', 'LT003', 1, '2024-10-01 09:00:00'),
('T019', 'NV019', 'LT006', 0, '2024-10-10 11:00:00'),
('T020', 'NV001', 'LT007', 1, '2024-10-20 08:00:00');
GO

-- Bảng: vi_pham (20)
INSERT INTO vi_pham (ma_vi_pham, ma_nhan_vien, ma_loai_vi_pham, thoi_gian_vi_pham, trang_thai) VALUES
('VP001', 'NV002', 'LVP001', '2024-10-24 08:30:00', 1),
('VP002', 'NV007', 'LVP001', '2024-10-23 08:40:00', 1),
('VP003', 'NV007', 'LVP002', '2024-10-23 16:30:00', 1),
('VP004', 'NV003', 'LVP003', '2024-10-22 09:00:00', 1),
('VP005', 'NV008', 'LVP008', '2024-10-21 10:30:00', 0),
('VP006', 'NV005', 'LVP004', '2024-10-20 14:15:00', 1),
('VP007', 'NV002', 'LVP001', '2024-10-25 08:35:00', 1),
('VP008', 'NV009', 'LVP006', '2024-10-19 08:00:00', 1),
('VP009', 'NV003', 'LVP001', '2024-10-25 08:28:00', 0),
('VP010', 'NV001', 'LVP007', '2024-10-18 11:00:00', 1),
('VP011', 'NV011', 'LVP001', '2024-10-01 08:31:00', 1),
('VP012', 'NV012', 'LVP011', '2024-10-02 08:46:00', 1),
('VP013', 'NV013', 'LVP015', '2024-10-03 17:00:00', 1),
('VP014', 'NV015', 'LVP017', '2024-10-04 14:00:00', 1),
('VP015', 'NV016', 'LVP012', '2024-10-05 10:10:00', 1),
('VP016', 'NV018', 'LVP003', '2024-10-06 08:30:00', 1),
('VP017', 'NV019', 'LVP008', '2024-10-07 09:05:00', 1),
('VP018', 'NV020', 'LVP009', '2024-10-08 11:00:00', 1),
('VP019', 'NV011', 'LVP001', '2024-10-03 08:33:00', 1),
('VP020', 'NV002', 'LVP001', '2024-10-26 08:30:00', 1);
GO

-- ### NHÓM 6: PHỤ THUỘC NHÓM 5 ###

-- Bảng: san_pham_trong_chi_nhanh (20)
INSERT INTO san_pham_trong_chi_nhanh (ma_chi_nhanh, ma_san_pham, so_luong) VALUES
('CN001', 'SP001', 50),
('CN002', 'SP001', 50),
('CN001', 'SP005', 30),
('CN006', 'SP004', 100),
('CN007', 'SP004', 100),
('CN004', 'SP003', 10),
('CN006', 'SP002', 40),
('CN008', 'SP002', 20),
('CN002', 'SP006', 25),
('CN003', 'SP008', 30),
('CN011', 'SP011', 50),
('CN012', 'SP012', 30),
('CN013', 'SP013', 20),
('CN014', 'SP014', 100),
('CN015', 'SP015', 15),
('CN016', 'SP016', 80),
('CN017', 'SP017', 10),
('CN018', 'SP018', 40),
('CN019', 'SP019', 5),
('CN020', 'SP020', 60);
GO

-- Bảng: san_pham_trong_kho_tong (20)
INSERT INTO san_pham_trong_kho_tong (ma_kho, ma_san_pham, so_luong) VALUES
('KHO01', 'SP001', 500),
('KHO01', 'SP005', 300),
('KHO02', 'SP002', 400),
('KHO02', 'SP004', 1000),
('KHO02', 'SP007', 350),
('KHO03', 'SP003', 100),
('KHO03', 'SP010', 200),
('KHO04', 'SP002', 150),
('KHO05', 'SP008', 300),
('KHO01', 'SP006', 250),
('KHO06', 'SP011', 300),
('KHO07', 'SP012', 200),
('KHO08', 'SP013', 100),
('KHO09', 'SP014', 500),
('KHO10', 'SP015', 80),
('KHO11', 'SP016', 400),
('KHO12', 'SP017', 50),
('KHO13', 'SP018', 150),
('KHO14', 'SP019', 30),
('KHO15', 'SP020', 250);
GO

-- Bảng: phieu_nhap_kho (20)
INSERT INTO phieu_nhap_kho (ma_phieu_nhap, ma_kho, ma_san_pham, ma_nhan_vien_kiem_tra, so_luong, don_gia) VALUES
('PN001', 'KHO01', 'SP001', 'NV001', 500, 20000000),
('PN002', 'KHO01', 'SP005', 'NV001', 300, 9000000),
('PN003', 'KHO02', 'SP002', 'NV002', 550, 11000000),
('PN004', 'KHO02', 'SP004', 'NV002', 1000, 28000000),
('PN005', 'KHO02', 'SP007', 'NV002', 350, 13000000),
('PN006', 'KHO03', 'SP003', 'NV003', 100, 50000000),
('PN007', 'KHO03', 'SP010', 'NV003', 200, 7000000),
('PN008', 'KHO05', 'SP008', 'NV006', 300, 6000000),
('PN009', 'KHO01', 'SP006', 'NV001', 250, 40000000),
('PN010', 'KHO06', 'SP011', 'NV004', 300, 22000000),
('PN011', 'KHO07', 'SP012', 'NV005', 200, 9000000),
('PN012', 'KHO08', 'SP013', 'NV010', 100, 7500000),
('PN013', 'KHO09', 'SP014', 'NV010', 500, 900000),
('PN014', 'KHO10', 'SP015', 'NV010', 80, 4500000),
('PN015', 'KHO11', 'SP016', 'NV012', 400, 600000),
('PN016', 'KHO12', 'SP017', 'NV013', 50, 20000000),
('PN017', 'KHO13', 'SP018', 'NV015', 150, 7000000),
('PN018', 'KHO14', 'SP019', 'NV016', 30, 52000000),
('PN019', 'KHO15', 'SP020', 'NV019', 250, 1200000),
('PN020', 'KHO04', 'SP002', 'NV007', 150, 11000000);
GO

-- Bảng: phieu_xuat_kho (20)
INSERT INTO phieu_xuat_kho (ma_phieu_xuat, ma_kho, ma_san_pham, ma_chi_nhanh_nhap, ma_nhan_vien_kiem_tra, so_luong) VALUES
('PX001', 'KHO01', 'SP001', 'CN001', 'NV001', 50),
('PX002', 'KHO01', 'SP001', 'CN002', 'NV001', 50),
('PX003', 'KHO01', 'SP005', 'CN001', 'NV001', 30),
('PX004', 'KHO02', 'SP004', 'CN006', 'NV002', 100),
('PX005', 'KHO02', 'SP004', 'CN007', 'NV002', 100),
('PX006', 'KHO03', 'SP003', 'CN004', 'NV003', 10),
('PX007', 'KHO02', 'SP002', 'CN006', 'NV002', 40),
('PX008', 'KHO04', 'SP002', 'CN008', 'NV007', 20),
('PX009', 'KHO01', 'SP006', 'CN002', 'NV001', 25),
('PX010', 'KHO05', 'SP008', 'CN003', 'NV006', 30),
('PX011', 'KHO06', 'SP011', 'CN011', 'NV004', 50),
('PX012', 'KHO07', 'SP012', 'CN012', 'NV005', 30),
('PX013', 'KHO08', 'SP013', 'CN005', 'NV010', 20),
('PX014', 'KHO09', 'SP014', 'CN009', 'NV010', 100),
('PX015', 'KHO10', 'SP015', 'CN010', 'NV010', 15),
('PX016', 'KHO11', 'SP016', 'CN012', 'NV012', 80),
('PX017', 'KHO12', 'SP017', 'CN013', 'NV013', 10),
('PX018', 'KHO13', 'SP018', 'CN014', 'NV014', 40),
('PX019', 'KHO14', 'SP019', 'CN015', 'NV015', 5),
('PX020', 'KHO15', 'SP020', 'CN020', 'NV019', 60);
GO

-- Bảng: chi_tiet_hoa_don (20)
INSERT INTO chi_tiet_hoa_don (ma_hoa_don, ma_san_pham, ma_khuyen_mai, so_luong, don_gia,gia_goc , ngay_gio_in) VALUES
('HD001', 'SP001', 'KM001', 1, 25000000,28000000, '2024-10-20 09:30:15'),
('HD002', 'SP002', NULL, 1, 14000000,25000000, '2024-10-20 11:15:45'),
('HD003', 'SP004', 'KM003', 1, 35000000,25000000, '2024-10-21 14:05:20'),
('HD004', 'SP005', NULL, 2, 11500000,25000000, '2024-10-21 16:40:00'),
('HD005', 'SP003', NULL, 1, 58000000,25000000, '2024-10-22 08:55:10'),
('HD006', 'SP010', 'KM010', 1, 8500000,25000000, '2024-10-22 10:20:30'),
('HD007', 'SP009', 'KM002', 1, 1800000,25000000, '2024-10-23 11:00:00'),
('HD008', 'SP006', 'KM005', 1, 45000000,25000000, '2024-10-23 15:10:05'),
('HD009', 'SP008', NULL, 2, 7500000,25000000, '2024-10-24 10:00:00'),
('HD010', 'SP007', NULL, 1, 16000000,25000000, '2024-10-25 09:00:00'),
('HD011', 'SP011', NULL, 1, 28000000,25000000, '2024-10-26 10:00:00'),
('HD012', 'SP012', 'KM012', 1, 11000000,25000000, '2024-10-26 11:00:00'),
('HD013', 'SP013', NULL, 1, 9500000, 25000000,'2024-10-27 12:00:00'),
('HD014', 'SP014', 'KM014', 2, 1200000,25000000, '2024-10-27 13:00:00'),
('HD015', 'SP015', 'KM015', 1, 6000000,25000000, '2024-10-28 14:00:00'),
('HD016', 'SP016', NULL, 3, 800000,25000000, '2024-10-28 15:00:00'),
('HD017', 'SP017', 'KM017', 1, 23000000,25000000, '2024-10-29 16:00:00'),
('HD018', 'SP018', NULL, 1, 8500000,25000000, '2024-10-29 17:00:00'),
('HD019', 'SP019', 'KM008', 1, 60000000,25000000, '2024-10-30 18:00:00'),
('HD020', 'SP020', NULL, 1, 1500000,25000000, '2024-10-31 19:00:00');
GO

-- ### NHÓM 7: CẬP NHẬT RÀNG BUỘC VÒNG ###

-- Cập nhật nhân viên quản lý cho khu_vuc (sau khi đã có nhân viên)
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV001';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV002';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV003';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV004';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV005';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV004' WHERE ma_khu_vuc = 'KV006';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV004' WHERE ma_khu_vuc = 'KV007';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV004' WHERE ma_khu_vuc = 'KV008';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV010' WHERE ma_khu_vuc = 'KV009';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV001' WHERE ma_khu_vuc = 'KV010';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV020' WHERE ma_khu_vuc = 'KV011';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV010' WHERE ma_khu_vuc = 'KV012';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV006' WHERE ma_khu_vuc = 'KV013';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV007' WHERE ma_khu_vuc = 'KV014';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV020' WHERE ma_khu_vuc = 'KV015';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV020' WHERE ma_khu_vuc = 'KV016';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV007' WHERE ma_khu_vuc = 'KV017';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV007' WHERE ma_khu_vuc = 'KV018';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV010' WHERE ma_khu_vuc = 'KV019';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV001' WHERE ma_khu_vuc = 'KV020';
GO

-- Cập nhật nhân viên quản lý cho kho_tong (sau khi đã có nhân viên)
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV001' WHERE ma_kho = 'KHO01';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV002' WHERE ma_kho = 'KHO02';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV003' WHERE ma_kho = 'KHO03';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV007' WHERE ma_kho = 'KHO04';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV006' WHERE ma_kho = 'KHO05';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV004' WHERE ma_kho = 'KHO06';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV005' WHERE ma_kho = 'KHO07';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV010' WHERE ma_kho = 'KHO08';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV010' WHERE ma_kho = 'KHO09';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV010' WHERE ma_kho = 'KHO10';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV012' WHERE ma_kho = 'KHO11';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV013' WHERE ma_kho = 'KHO12';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV015' WHERE ma_kho = 'KHO13';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV016' WHERE ma_kho = 'KHO14';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV019' WHERE ma_kho = 'KHO15';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV014' WHERE ma_kho = 'KHO16';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV014' WHERE ma_kho = 'KHO17';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV014' WHERE ma_kho = 'KHO18';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV001' WHERE ma_kho = 'KHO19';
UPDATE kho_tong SET nhan_vien_quan_ly = 'NV004' WHERE ma_kho = 'KHO20';
GO