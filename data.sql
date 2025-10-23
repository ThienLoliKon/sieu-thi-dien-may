USE dien_may;
GO

-- Thêm dữ liệu cho Nhà sản xuất (Bảng này phải có dữ liệu trước)
INSERT INTO nha_san_xuat (ma_nha_san_xuat, ten_nha_san_xuat, dia_chi_nha_san_xuat)
VALUES
('NSX001', N'Samsung', N'Seoul, Hàn Quốc'),
('NSX002', N'LG', N'Seoul, Hàn Quốc'),
('NSX003', N'Sony', N'Tokyo, Nhật Bản'),
('NSX004', N'Apple', N'Cupertino, Hoa Kỳ'),
('NSX005', N'Panasonic', N'Osaka, Nhật Bản'),
('NSX006', N'Xiaomi', N'Bắc Kinh, Trung Quốc');
GO

-- Thêm dữ liệu cho Nhà cung cấp (Bảng này cũng phải có dữ liệu trước)
-- (Giả sử bạn đã sửa bảng nha_cung_cap như lưu ý ở trên)
INSERT INTO nha_cung_cap (ma_nha_cung_cap, ten_nha_cung_cap, dia_chi_nha_cung_cap)
VALUES
('NCC001', N'Công ty TNHH Digiworld', N'Quận 1, TP. HCM'),
('NCC002', N'Công ty FPT Synnex', N'Cầu Giấy, Hà Nội'),
('NCC003', N'Công ty TNHH An Phát', N'Hai Bà Trưng, Hà Nội'),
('NCC004', N'Công ty TNHH Thế Giới Di Động', N'Quận 9, TP. HCM');
GO

-- Thêm dữ liệu cho Sản phẩm (Bảng này phụ thuộc vào 2 bảng trên)
INSERT INTO san_pham (ma_san_pham, ten_san_pham, ma_nha_san_xuat, ma_nha_cung_cap, khoi_luong, gia_tien, ngay_san_xuat)
VALUES
('SP001', N'Tivi QLED Samsung 4K 55 inch', 'NSX001', 'NCC001', 15.5, 22500000, '2024-01-15'),
('SP002', N'Tủ lạnh LG Inverter 315 lít', 'NSX002', 'NCC002', 65.0, 13800000, '2024-02-20'),
('SP003', N'Máy ảnh Sony Alpha A7 IV', 'NSX003', 'NCC003', 0.65, 55000000, '2023-11-10'),
('SP004', N'iPhone 16 Pro Max 256GB', 'NSX004', 'NCC002', 0.22, 34000000, '2024-09-30'),
('SP005', N'Điều hòa Panasonic 12000 BTU', 'NSX005', 'NCC001', 28.0, 9800000, '2024-03-05'),
('SP006', N'Tivi OLED Sony 4K 65 inch', 'NSX003', 'NCC002', 21.3, 45900000, '2024-04-12'),
('SP007', N'Laptop Apple MacBook Pro M4', 'NSX004', 'NCC003', 1.6, 62000000, '2024-10-01'),
('SP008', N'Máy lọc không khí Xiaomi Mi 4 Pro', 'NSX006', 'NCC004', 6.8, 4500000, '2024-05-01');
GO
select * from san_pham
select * from nha_cung_cap
select * from nha_san_xuat