USE dien_may;
GO

-- ### NHÓM 1: CÁC BẢNG ĐỘC LẬP (KHÔNG CÓ KHÓA NGOẠI) ###

-- Bảng: cap_bac_nhan_vien
INSERT INTO cap_bac_nhan_vien (ma_cap_bac, ten_cap_bac, mo_ta_cap_bac)
VALUES
('CB001', N'Nhân viên', N'Nhân viên bán hàng, kho'),
('CB002', N'Trưởng nhóm', N'Trưởng nhóm kinh doanh'),
('CB003', N'Quản lý', N'Quản lý chi nhánh'),
('CB004', N'Giám đốc', N'Giám đốc khu vực'),
('CB005', N'Kế toán', N'Nhân viên phòng kế toán'),
('CB006', N'Kỹ thuật', N'Nhân viên bảo hành, kỹ thuật'),
('CB007', N'Thực tập', N'Thực tập sinh'),
('CB008', N'Bảo vệ', N'Nhân viên an ninh'),
('CB009', N'Tạp vụ', N'Nhân viên vệ sinh'),
('CB010', N'Giám đốc CN', N'Giám đốc chi nhánh');
GO

-- Bảng: khu_vuc (Tạm thời để nhan_vien_quan_ly là NULL để tránh lỗi vòng)
INSERT INTO khu_vuc (ma_khu_vuc, ten_khu_vuc, nhan_vien_quan_ly)
VALUES
('KV001', N'Miền Bắc', NULL),
('KV002', N'Miền Trung', NULL),
('KV003', N'Miền Nam', NULL),
('KV004', N'Tây Nguyên', NULL),
('KV005', N'Đồng bằng SCL', NULL),
('KV006', N'Đông Bắc Bộ', NULL),
('KV007', N'Tây Bắc Bộ', NULL),
('KV008', N'Bắc Trung Bộ', NULL),
('KV009', N'Nam Trung Bộ', NULL),
('KV010', N'Hà Nội', NULL);
GO

-- Bảng: loai_hang
INSERT INTO loai_hang (ma_loai_hang, ten_loai_hang, mo_ta)
VALUES
('LH001', N'Tivi', N'Các loại tivi thông minh, 4K, 8K'),
('LH002', N'Tủ lạnh', N'Tủ lạnh gia đình, side-by-side'),
('LH003', N'Máy giặt', N'Máy giặt cửa trước, cửa trên'),
('LH004', N'Điều hòa', N'Điều hòa 1 chiều, 2 chiều'),
('LH005', N'Điện thoại', N'Điện thoại thông minh'),
('LH006', N'Laptop', N'Máy tính xách tay'),
('LH007', N'Âm thanh', N'Loa, tai nghe, amply'),
('LH008', N'Gia dụng nhỏ', N'Nồi cơm, lò vi sóng, máy xay'),
('LH009', N'Máy ảnh', N'Máy ảnh DSLR, Mirrorless'),
('LH010', N'Phụ kiện', N'Cáp sạc, pin dự phòng, chuột');
GO

-- Bảng: loai_thuong
INSERT INTO loai_thuong (ma_loai_thuong, loai_yeu_cau, yeu_cau, muc_thuong)
VALUES
('LT001', N'Doanh số', 500000000, 5000000),
('LT002', N'KPI', 100, 2000000),
('LT003', N'Chuyên cần', 26, 500000),
('LT004', N'Thâm niên', 5, 3000000),
('LT005', N'Sáng kiến', 1, 1000000),
('LT006', N'Hỗ trợ', 10, 300000),
('LT007', N'Tết', 0, 10000000),
('LT008', N'Lễ 30/4', 0, 1000000),
('LT009', N'Quốc Khánh', 0, 1000000),
('LT010', N'NV Xuất sắc', 1, 5000000);
GO

-- Bảng: loai_vi_pham
INSERT INTO loai_vi_pham (ma_loai_vi_pham, mo_ta_vi_pham, muc_do_vi_pham, muc_phat)
VALUES
('LVP001', N'Đi trễ', 1, 100000),
('LVP002', N'Về sớm', 1, 100000),
('LVP003', N'Quên đồng phục', 1, 50000),
('LVP004', N'Sai quy trình', 2, 500000),
('LVP005', N'Gây thất thoát', 3, 2000000),
('LVP006', N'Nghỉ không phép', 2, 300000),
('LVP007', N'Ăn vặt', 1, 20000),
('LVP008', N'Sử dụng ĐT', 1, 50000),
('LVP009', N'Thái độ xấu', 3, 1000000),
('LVP010', N'Mất vệ sinh', 1, 50000);
GO

-- Bảng: nha_cung_cap
INSERT INTO nha_cung_cap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi_nha_cung_cap)
VALUES
('NCC001', N'Digiworld', N'Quận 1, TP. HCM'),
('NCC002', N'FPT Synnex', N'Cầu Giấy, Hà Nội'),
('NCC003', N'Petrosetco', N'Quận 3, TP. HCM'),
('NCC004', N'Viettel Distribution', N'Hoàn Kiếm, Hà Nội'),
('NCC005', N'Thế Giới Di Động', N'Quận 9, TP. HCM'),
('NCC006', N'Phúc Anh', N'Đống Đa, Hà Nội'),
('NCC007', N'An Phát PC', N'Hai Bà Trưng, Hà Nội'),
('NCC008', N'Song Tấn', N'Tân Bình, TP. HCM'),
('NCC009', N'Lê Phụng', N'Quận 10, TP. HCM'),
('NCC010', N'Ánh Minh', N'Đà Nẵng');
GO

-- Bảng: nha_san_xuat
INSERT INTO nha_san_xuat (ma_nha_san_xuat, ten_nha_san_xuat, dia_chi_nha_san_xuat)
VALUES
('NSX001', N'Samsung', N'Hàn Quốc'),
('NSX002', N'LG', N'Hàn Quốc'),
('NSX003', N'Sony', N'Nhật Bản'),
('NSX004', N'Apple', N'Hoa Kỳ'),
('NSX005', N'Panasonic', N'Nhật Bản'),
('NSX006', N'Xiaomi', N'Trung Quốc'),
('NSX007', N'Dell', N'Hoa Kỳ'),
('NSX008', N'HP', N'Hoa Kỳ'),
('NSX009', N'Asus', N'Đài Loan'),
('NSX010', N'Bose', N'Hoa Kỳ');
GO

-- Bảng: xep_hang
INSERT INTO xep_hang (ma_hang, ten_hang, yeu_cau, uu_dai)
VALUES
('XH001', N'Đồng', 5000000, 0.01),
('XH002', N'Bạc', 15000000, 0.02),
('XH003', N'Vàng', 50000000, 0.03),
('XH004', N'Bạch kim', 100000000, 0.05),
('XH005', N'Kim cương', 500000000, 0.07),
('XH006', N'Thành viên', 0, 0),
('XH007', N'VIP', 200000000, 0.06),
('XH008', N'Đối tác', 0, 0.1),
('XH009', N'VVIP', 1000000000, 0.1),
('XH010', N'Member', 1000000, 0.005);
GO

-- ### NHÓM 2: PHỤ THUỘC NHÓM 1 ###

-- Bảng: chi_nhanh
INSERT INTO chi_nhanh (ma_chi_nhanh, ten_chi_nhanh, dia_chi, khu_vuc)
VALUES
('CN001', N'Hà Nội 1', N'123 Bà Triệu, Hà Nội', 'KV010'),
('CN002', N'Hà Nội 2', N'456 Cầu Giấy, Hà Nội', 'KV010'),
('CN003', N'Hải Phòng', N'789 Lê Lợi, Hải Phòng', 'KV006'),
('CN004', N'Đà Nẵng', N'101 Nguyễn Văn Linh, Đà Nẵng', 'KV009'),
('CN005', N'Nha Trang', N'202 Trần Phú, Nha Trang', 'KV009'),
('CN006', N'HCM 1', N'303 Nguyễn Trãi, Q1, TP. HCM', 'KV003'),
('CN007', N'HCM 2', N'404 Lê Văn Sỹ, Q3, TP. HCM', 'KV003'),
('CN008', N'Cần Thơ', N'505 Nguyễn Văn Cừ, Cần Thơ', 'KV005'),
('CN009', N'Buôn Ma Thuột', N'606 Lý Thường Kiệt, BMT', 'KV004'),
('CN010', N'Vinh', N'707 Quang Trung, Vinh', 'KV008');
GO

-- Bảng: khach_hang
INSERT INTO khach_hang (ma_khach_hang, ho_ten_khach_hang, sdt, diachi, xep_hang, diem)
VALUES
('KH001', N'Nguyễn Văn An', '0905111222', N'Hà Nội', 'XH003', 5500),
('KH002', N'Trần Thị Bình', '0913222333', N'TP. HCM', 'XH002', 2000),
('KH003', N'Lê Hoàng Cường', '0987333444', N'Đà Nẵng', 'XH001', 800),
('KH004', N'Phạm Mỹ Duyên', '0979444555', N'Cần Thơ', 'XH006', 50),
('KH005', N'Võ Minh Hải', '0935555666', N'Hải Phòng', 'XH004', 12000),
('KH006', N'Đỗ Gia Hân', '0909666777', N'TP. HCM', 'XH003', 6000),
('KH007', N'Hoàng Tuấn Kiệt', '0918777888', N'Nha Trang', 'XH001', 600),
('KH008', N'Lý Thu Thảo', '0947888999', N'Hà Nội', 'XH002', 1700),
('KH009', N'Bùi Chí Thanh', '0903999000', N'Bình Dương', 'XH006', 0),
('KH010', N'Mai Anh Thư', '0908000111', N'Vũng Tàu', 'XH005', 51000);
GO

-- Thêm dữ liệu cho Sản phẩm (Đã bao gồm thoi_gian_bao_hanh)
INSERT INTO san_pham (ma_san_pham, ten_san_pham, ma_nha_san_xuat, ma_nha_cung_cap, khoi_luong, thoi_gian_bao_hanh, gia_tien, ngay_san_xuat)
VALUES
('SP001', N'Tivi Samsung QLED 4K 55 inch', 'NSX001', 'NCC001', 20.5, 24, 25000000, '2024-01-15'),
('SP002', N'Tủ lạnh LG Inverter 315L', 'NSX002', 'NCC002', 65.0, 24, 14000000, '2024-02-10'),
('SP003', N'Máy ảnh Sony A7M4', 'NSX003', 'NCC003', 0.65, 12, 58000000, '2023-11-20'),
('SP004', N'iPhone 16 Pro Max 256GB', 'NSX004', 'NCC004', 0.22, 12, 35000000, '2024-09-30'),
('SP005', N'Điều hòa Panasonic 12000BTU', 'NSX005', 'NCC001', 30.0, 24, 11500000, '2024-03-05'),
('SP006', N'Laptop Dell XPS 15', 'NSX007', 'NCC002', 1.8, 12, 45000000, '2024-05-01'),
('SP007', N'Máy giặt Samsung AI 10kg', 'NSX001', 'NCC005', 70.0, 24, 16000000, '2024-04-12'),
('SP008', N'Loa Bose SoundLink Revolve+', 'NSX010', 'NCC008', 0.9, 12, 7500000, '2023-12-25'),
('SP009', N'Nồi cơm điện Xiaomi', 'NSX006', 'NCC006', 3.5, 6, 1800000, '2024-01-30'),
('SP010', N'Tai nghe Sony WH-1000XM5', 'NSX003', 'NCC003', 0.25, 12, 8500000, '2024-06-10');
GO

-- Bảng: khuyen_mai
INSERT INTO khuyen_mai (ma_khuyen_mai, giam_gia, ma_loai_hang, ngay_bat_dau, ngay_ket_thuc)
VALUES
('KM001', 0.1, 'LH001', '2024-10-01 00:00:00', '2024-10-31 23:59:59'),
('KM002', 0.15, 'LH008', '2024-11-01 00:00:00', '2024-11-15 23:59:59'),
('KM003', 0.05, 'LH005', '2024-09-01 00:00:00', '2024-09-30 23:59:59'),
('KM004', 0.2, 'LH003', '2024-12-01 00:00:00', '2024-12-31 23:59:59'),
('KM005', 500000, 'LH006', '2024-10-15 00:00:00', '2024-11-15 23:59:59'),
('KM006', 0.1, 'LH002', '2024-10-20 00:00:00', '2024-11-20 23:59:59'),
('KM007', 0.3, 'LH010', '2024-11-11 00:00:00', '2024-11-11 23:59:59'),
('KM008', 1000000, 'LH009', '2024-01-01 00:00:00', '2024-12-31 23:59:59'),
('KM009', 0.1, 'LH004', '2024-06-01 00:00:00', '2024-08-30 23:59:59'),
('KM010', 0.05, 'LH007', '2024-10-01 00:00:00', '2024-10-15 23:59:59');
GO

-- Bảng: nhan_vien
INSERT INTO nhan_vien (ma_nhan_vien, ho_va_ten, ma_cap_bac, so_dien_thoai, dia_chi_thuong_tru, ma_chi_nhanh, trang_thai)
VALUES
('NV001', N'Nguyễn Văn Hùng', 'CB003', '0912345678', N'Ba Đình, Hà Nội', 'CN001', 1),
('NV002', N'Trần Thị Thu', 'CB001', '0987654321', N'Quận 1, TP. HCM', 'CN006', 1),
('NV003', N'Lê Văn Luyện', 'CB001', '0905123456', N'Hải Châu, Đà Nẵng', 'CN004', 1),
('NV004', N'Phạm Thị Mai', 'CB005', '0933456789', N'Cầu Giấy, Hà Nội', 'CN002', 1),
('NV005', N'Võ Minh Đức', 'CB006', '0977890123', N'Quận 3, TP. HCM', 'CN007', 1),
('NV006', N'Hoàng Thị Kim', 'CB002', '0915678901', N'Lê Chân, Hải Phòng', 'CN003', 1),
('NV007', N'Đỗ Bá Phước', 'CB001', '0908901234', N'Ninh Kiều, Cần Thơ', 'CN008', 1),
('NV008', N'Bùi Thu Trang', 'CB007', '0945123789', N'Ba Đình, Hà Nội', 'CN001', 1),
('NV009', N'Lý Văn Toàn', 'CB004', '0909555888', N'Thủ Đức, TP. HCM', 'CN006', 0),
('NV010', N'Mai Ngọc Anh', 'CB010', '0902789456', N'Sơn Trà, Đà Nẵng', 'CN004', 1);
GO

-- ### NHÓM 3: PHỤ THUỘC NHÓM 2 ###

-- Bảng: kho_tong
INSERT INTO kho_tong (ma_kho, nhan_vien_quan_ly, ten_kho, dia_chi, suc_chua)
VALUES
('KHO01', 'NV001', N'Kho Tổng Miền Bắc', N'Từ Liêm, Hà Nội', 5000),
('KHO02', 'NV002', N'Kho Tổng Miền Nam', N'Bình Chánh, TP. HCM', 7000),
('KHO03', 'NV003', N'Kho Tổng Miền Trung', N'Liên Chiểu, Đà Nẵng', 4000),
('KHO04', 'NV007', N'Kho ĐBSCL', N'Cái Răng, Cần Thơ', 3000),
('KHO05', 'NV006', N'Kho Hải Phòng', N'Hải An, Hải Phòng', 2500),
('KHO06', 'NV004', N'Kho Phụ Hà Nội', N'Long Biên, Hà Nội', 1500),
('KHO07', 'NV005', N'Kho Phụ HCM', N'Quận 12, TP. HCM', 2000),
('KHO08', 'NV010', N'Kho Nha Trang', N'Diên Khánh, Nha Trang', 1000),
('KHO09', 'NV001', N'Kho Tây Nguyên', N'Cư Mgar, BMT', 1000),
('KHO10', 'NV004', N'Kho Nghệ An', N'TP. Vinh', 1200);
GO

-- Bảng: tai_khoan (Giả sử cột 'quyen' tham chiếu đến ma_cap_bac)
INSERT INTO tai_khoan (ma_nhan_vien, mat_khau, quyen)
VALUES
('NV001', 'pass123', 'CB003'),
('NV002', 'pass123', 'CB001'),
('NV003', 'pass123', 'CB001'),
('NV004', 'pass123', 'CB005'),
('NV005', 'pass123', 'CB006'),
('NV006', 'pass123', 'CB002'),
('NV007', 'pass123', 'CB001'),
('NV008', 'pass123', 'CB007'),
('NV009', 'pass123', 'CB004'),
('NV010', 'pass123', 'CB010');
GO

-- Bảng: diem_danh
INSERT INTO diem_danh (ma_diem_danh, ma_nhan_vien, thoi_gian_vao, thoi_gian_ra)
VALUES
('DD001', 'NV001', '2024-10-24 07:58:00', '2024-10-24 17:02:00'),
('DD002', 'NV002', '2024-10-24 08:30:00', '2024-10-24 18:01:00'),
('DD003', 'NV003', '2024-10-24 08:29:00', '2024-10-24 17:59:00'),
('DD004', 'NV004', '2024-10-24 08:01:00', '2024-10-24 17:05:00'),
('DD005', 'NV005', '2024-10-24 08:00:00', '2024-10-24 17:00:00'),
('DD006', 'NV001', '2024-10-25 07:55:00', '2024-10-25 17:03:00'),
('DD007', 'NV002', '2024-10-25 08:35:00', '2024-10-25 18:00:00'),
('DD008', 'NV003', '2024-10-25 08:28:00', '2024-10-25 18:02:00'),
('DD009', 'NV004', '2024-10-25 07:59:00', '2024-10-25 17:01:00'),
('DD010', 'NV005', '2024-10-25 08:02:00', '2024-10-25 17:00:00');
GO

-- Bảng: luong
INSERT INTO luong (ma_phieu_luong, ma_nhan_vien, luong_co_ban, he_so, thang_luong, thuong, phat)
VALUES
('PL001', 'NV001', 12000000, 1.5, '2024-09-01', 2000000, 0),
('PL002', 'NV002', 7000000, 1.0, '2024-09-01', 500000, 100000),
('PL003', 'NV003', 7000000, 1.0, '2024-09-01', 0, 0),
('PL004', 'NV004', 10000000, 1.2, '2024-09-01', 500000, 0),
('PL005', 'NV005', 9000000, 1.3, '2024-09-01', 0, 50000),
('PL006', 'NV006', 9000000, 1.2, '2024-09-01', 1000000, 0),
('PL007', 'NV007', 7000000, 1.0, '2024-09-01', 0, 200000),
('PL008', 'NV008', 4000000, 1.0, '2024-09-01', 0, 0),
('PL009', 'NV009', 20000000, 2.0, '2024-09-01', 5000000, 0),
('PL010', 'NV010', 15000000, 1.6, '2024-09-01', 3000000, 0);
GO

-- Bảng: vi_pham
INSERT INTO vi_pham (ma_vi_pham, ma_nhan_vien, ma_loai_vi_pham, thoi_gian_vi_pham, trang_thai)
VALUES
('VP001', 'NV002', 'LVP001', '2024-10-24 08:30:00', 1),
('VP002', 'NV007', 'LVP001', '2024-10-23 08:40:00', 1),
('VP003', 'NV007', 'LVP002', '2024-10-23 16:30:00', 1),
('VP004', 'NV003', 'LVP003', '2024-10-22 09:00:00', 1),
('VP005', 'NV008', 'LVP008', '2024-10-21 10:30:00', 0),
('VP006', 'NV005', 'LVP004', '2024-10-20 14:15:00', 1),
('VP007', 'NV002', 'LVP001', '2024-10-25 08:35:00', 1),
('VP008', 'NV009', 'LVP006', '2024-10-19 08:00:00', 1),
('VP009', 'NV003', 'LVP001', '2024-10-25 08:28:00', 0),
('VP010', 'NV001', 'LVP007', '2024-10-18 11:00:00', 1);
GO

-- Bảng: thuong
INSERT INTO thuong (ma_thuong, ma_nhan_vien, ma_loai_thuong, trang_thai, thoi_gian_thuong)
VALUES
('T001', 'NV001', 'LT002', 1, '2024-10-01 09:00:00'),
('T002', 'NV002', 'LT003', 1, '2024-10-01 09:00:00'),
('T003', 'NV006', 'LT001', 1, '2024-10-01 09:00:00'),
('T004', 'NV004', 'LT003', 1, '2024-10-01 09:00:00'),
('T005', 'NV005', 'LT005', 0, '2024-10-05 15:00:00'),
('T006', 'NV009', 'LT001', 1, '2024-10-01 09:00:00'),
('T007', 'NV010', 'LT002', 1, '2024-10-01 09:00:00'),
('T008', 'NV001', 'LT004', 1, '2024-09-20 10:00:00'),
('T009', 'NV003', 'LT006', 0, '2024-09-15 11:00:00'),
('T010', 'NV002', 'LT006', 1, '2024-09-18 14:00:00');
GO

-- Bảng: nghi_viec
INSERT INTO nghi_viec (ma_nghi_viec, nhan_vien_nghi_viec, ly_do, thoi_gian_cho_nghi)
VALUES
('NVL001', 'NV009', N'Lý do cá nhân', '2024-09-30 17:00:00'),
('NVL002', 'NV008', N'Hết hạn thực tập', '2024-10-31 17:00:00'),
('NVL003', 'NV007', N'Vi phạm nhiều lần', '2024-09-15 17:00:00'),
-- Thêm 7 dòng null hoặc nhân viên đang làm (chưa có quyết định nghỉ)
('NVL004', 'NV001', NULL, NULL),
('NVL005', 'NV002', NULL, NULL),
('NVL006', 'NV003', NULL, NULL),
('NVL007', 'NV004', NULL, NULL),
('NVL008', 'NV005', NULL, NULL),
('NVL009', 'NV006', NULL, NULL),
('NVL010', 'NV010', NULL, NULL);
GO

-- Bảng: san_pham_loai_hang (Nối sản phẩm với loại hàng)
INSERT INTO san_pham_loai_hang (ma_san_pham, ma_loai_hang)
VALUES
('SP001', 'LH001'),
('SP002', 'LH002'),
('SP003', 'LH009'),
('SP004', 'LH005'),
('SP005', 'LH004'),
('SP006', 'LH006'),
('SP007', 'LH003'),
('SP008', 'LH007'),
('SP009', 'LH008'),
('SP010', 'LH007');
GO

-- Bảng: hoa_don
INSERT INTO hoa_don (ma_hoa_don, ma_nhan_vien_lap, ma_khach_hang, ngay_lap)
VALUES
('HD001', 'NV002', 'KH001', '2024-10-20 09:30:15'),
('HD002', 'NV003', 'KH002', '2024-10-20 11:15:45'),
('HD003', 'NV002', 'KH004', '2024-10-21 14:05:20'),
('HD004', 'NV007', 'KH005', '2024-10-21 16:40:00'),
('HD005', 'NV006', 'KH010', '2024-10-22 08:55:10'),
('HD006', 'NV002', 'KH001', '2024-10-22 10:20:30'),
('HD007', 'NV003', 'KH003', '2024-10-23 11:00:00'),
('HD008', 'NV005', 'KH008', '2024-10-23 15:10:05'),
('HD009', 'NV002', 'KH007', '2024-10-24 10:00:00'),
('HD010', 'NV006', 'KH006', '2024-10-25 09:00:00');
GO

-- Bảng: bao_hanh
INSERT INTO bao_hanh (ma_bao_hanh, ma_san_pham, ma_khach_hang, nhan_vien_bao_hanh, ly_do, ngay_gui, ngay_xong, hoan_thanh)
VALUES
('BH001', 'SP001', 'KH001', 'NV005', N'Màn hình bị sọc', '2024-10-01 10:00:00', '2024-10-05 14:00:00', 1),
('BH002', 'SP006', 'KH004', 'NV005', N'Không lên nguồn', '2024-10-02 11:00:00', '2024-10-07 17:00:00', 1),
('BH003', 'SP003', 'KH010', 'NV005', N'Lỗi lấy nét', '2024-10-03 14:30:00', '2024-10-10 10:00:00', 1),
('BH004', 'SP010', 'KH008', 'NV005', N'Rè một bên tai', '2024-10-05 09:00:00', NULL, 0),
('BH005', 'SP002', 'KH002', 'NV005', N'Kém lạnh', '2024-10-06 16:00:00', '2024-10-08 11:00:00', 1),
('BH006', 'SP007', 'KH006', 'NV005', N'Kêu to khi vắt', '2024-10-07 08:30:00', NULL, 0),
('BH007', 'SP004', 'KH005', 'NV005', N'Lỗi FaceID', '2024-10-10 13:00:00', '2024-10-12 13:00:00', 1),
('BH008', 'SP001', 'KH001', 'NV005', N'Lỗi kết nối wifi', '2024-10-11 15:00:00', NULL, 0),
('BH009', 'SP008', 'KH003', 'NV005', N'Pin nhanh hết', '2024-10-12 11:00:00', '2024-10-13 17:00:00', 1),
('BH010', 'SP005', 'KH007', 'NV005', N'Chảy nước', '2024-10-15 10:00:00', '2024-10-15 16:00:00', 1);
GO

-- ### NHÓM 4: PHỤ THUỘC NHÓM 3 ###

-- Bảng: san_pham_trong_kho_tong
INSERT INTO san_pham_trong_kho_tong (ma_kho, ma_san_pham, so_luong)
VALUES
('KHO01', 'SP001', 500),
('KHO01', 'SP005', 300),
('KHO02', 'SP002', 400),
('KHO02', 'SP004', 1000),
('KHO02', 'SP007', 350),
('KHO03', 'SP003', 100),
('KHO03', 'SP010', 200),
('KHO04', 'SP002', 150),
('KHO05', 'SP008', 300),
('KHO01', 'SP006', 250);
GO

-- Bảng: phieu_nhap_kho (Nhập hàng vào kho tổng)
INSERT INTO phieu_nhap_kho (ma_phieu_nhap, ma_kho, ma_san_pham, ma_nhan_vien_kiem_tra, so_luong, don_gia)
VALUES
('PN001', 'KHO01', 'SP001', 'NV001', 500, 20000000),
('PN002', 'KHO01', 'SP005', 'NV001', 300, 9000000),
('PN003', 'KHO02', 'SP002', 'NV002', 400, 11000000),
('PN004', 'KHO02', 'SP004', 'NV002', 1000, 28000000),
('PN005', 'KHO02', 'SP007', 'NV002', 350, 13000000),
('PN006', 'KHO03', 'SP003', 'NV003', 100, 50000000),
('PN007', 'KHO03', 'SP010', 'NV003', 200, 7000000),
('PN008', 'KHO04', 'SP002', 'NV007', 150, 11000000),
('PN009', 'KHO05', 'SP008', 'NV006', 300, 6000000),
('PN010', 'KHO01', 'SP006', 'NV001', 250, 40000000);
GO

-- Bảng: phieu_xuat_kho (Xuất hàng từ kho tổng về chi nhánh)
INSERT INTO phieu_xuat_kho (ma_phieu_xuat, ma_kho, ma_san_pham, ma_chi_nhanh_nhap, ma_nhan_vien_kiem_tra, so_luong)
VALUES
('PX001', 'KHO01', 'SP001', 'CN001', 'NV001', 50),
('PX002', 'KHO01', 'SP001', 'CN002', 'NV001', 50),
('PX003', 'KHO01', 'SP005', 'CN001', 'NV001', 30),
('PX004', 'KHO02', 'SP004', 'CN006', 'NV002', 100),
('PX005', 'KHO02', 'SP004', 'CN007', 'NV002', 100),
('PX006', 'KHO03', 'SP003', 'CN004', 'NV003', 10),
('PX007', 'KHO02', 'SP002', 'CN006', 'NV002', 40),
('PX008', 'KHO04', 'SP002', 'CN008', 'NV007', 20),
('PX009', 'KHO01', 'SP006', 'CN002', 'NV001', 25),
('PX010', 'KHO05', 'SP008', 'CN003', 'NV006', 30);
GO

-- Bảng: san_pham_trong_chi_nhanh (Cập nhật số lượng ở chi nhánh sau khi xuất kho)
INSERT INTO san_pham_trong_chi_nhanh (ma_chi_nhanh, ma_san_pham, so_luong)
VALUES
('CN001', 'SP001', 50),
('CN002', 'SP001', 50),
('CN001', 'SP005', 30),
('CN006', 'SP004', 100),
('CN007', 'SP004', 100),
('CN004', 'SP003', 10),
('CN006', 'SP002', 40),
('CN008', 'SP002', 20),
('CN002', 'SP006', 25),
('CN003', 'SP008', 30);
GO

-- Bảng: chi_tiet_hoa_don
INSERT INTO chi_tiet_hoa_don (ma_hoa_don, ma_san_pham, ma_khuyen_mai, so_luong, don_gia, ngay_gio_in)
VALUES
('HD001', 'SP001', 'KM001', 1, 25000000, '2024-10-20 09:30:15'),
('HD002', 'SP002', NULL, 1, 14000000, '2024-10-20 11:15:45'),
('HD003', 'SP004', 'KM003', 1, 35000000, '2024-10-21 14:05:20'),
('HD004', 'SP005', NULL, 2, 11500000, '2024-10-21 16:40:00'),
('HD005', 'SP003', NULL, 1, 58000000, '2024-10-22 08:55:10'),
('HD006', 'SP010', 'KM010', 1, 8500000, '2024-10-22 10:20:30'),
('HD007', 'SP009', 'KM002', 1, 1800000, '2024-10-23 11:00:00'),
('HD008', 'SP006', 'KM005', 1, 45000000, '2024-10-23 15:10:05'),
('HD009', 'SP008', NULL, 2, 7500000, '2024-10-24 10:00:00'),
('HD010', 'SP007', NULL, 1, 16000000, '2024-10-25 09:00:00');
GO

-- ### NHÓM 5: CẬP NHẬT RÀNG BUỘC VÒNG ###

-- Cập nhật nhân viên quản lý cho khu_vuc (sau khi đã có nhân viên)
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV001';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV002';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV009' WHERE ma_khu_vuc = 'KV003';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV001' WHERE ma_khu_vuc = 'KV004';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV001' WHERE ma_khu_vuc = 'KV005';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV010' WHERE ma_khu_vuc = 'KV006';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV010' WHERE ma_khu_vuc = 'KV007';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV003' WHERE ma_khu_vuc = 'KV008';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV003' WHERE ma_khu_vuc = 'KV009';
UPDATE khu_vuc SET nhan_vien_quan_ly = 'NV004' WHERE ma_khu_vuc = 'KV010';
GO