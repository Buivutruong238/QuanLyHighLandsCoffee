CREATE DATABASE QuanLyQuanCafe_UDTM
GO

USE QuanLyQuanCafe_UDTM
GO

--NHA CUNG CAP
CREATE TABLE NhaCungCap
(
	MaNhaCungCap VARCHAR(100) NOT NULL PRIMARY KEY,
	TenNhaCungCap NVARCHAR(100),
	DiaChi NVARCHAR(1000),
	SoDienThoai NVARCHAR(100)
)
GO
--NGUYEN LIEU NHAP
CREATE TABLE NguyenLieuNhap
(
	MaNguyenLieu VARCHAR(100) NOT NULL PRIMARY KEY,
	TenNguyenLieu NVARCHAR(100),
	DonViTinh NVARCHAR(100),
	SoLuong FLOAT,
	DonGia MONEY
)
GO
--PHIEU NHAP
CREATE TABLE PhieuNhap
(
	MaPhieuNhap VARCHAR(100) NOT NULL PRIMARY KEY,
	MaNhaCungCap VARCHAR(100),
	NgayNhap DATETIME,
	ThanhTien MONEY
)
GO
ALTER TABLE PhieuNhap
ADD NguoiLap VARCHAR(100)
GO
--CHI TIET PHIEU NHAP
CREATE TABLE ChiTietPhieuNhap
(
	MaPhieuNhap VARCHAR(100) NOT NULL,
	MaNguyenLieu VARCHAR(100) NOT NULL,
	DonGia MONEY,
	SoLuong FLOAT
	CONSTRAINT PK_CTPN PRIMARY KEY(MaPhieuNhap,MaNguyenLieu)
)
GO
--
ALTER TABLE PhieuNhap ADD CONSTRAINT FK_PhieuNhap_MaNCC FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
GO
ALTER TABLE PhieuNhap ADD CONSTRAINT FK_PhieuNhap_NguoiLap FOREIGN KEY (NguoiLap) REFERENCES NhanVien(TenDangNhap)
GO
ALTER TABLE ChiTietPhieuNhap ADD CONSTRAINT FK_CTPN_MAPN FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap)
GO
ALTER TABLE ChiTietPhieuNhap ADD CONSTRAINT FK_CTPN_MANL FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieuNhap(MaNguyenLieu)
GO
---------------------------------------------------------------------------------------------------------------------------
--Danh Muc Man Hinh
CREATE TABLE DM_ManHinh
(
	MaManHinh VARCHAR(100) NOT NULL PRIMARY KEY,
	TenManHinh NVARCHAR(100)
)
--Nhan Vien
CREATE TABLE NhanVien
(
	TenDangNhap VARCHAR(100) NOT NULL PRIMARY KEY,
	HoTen NVARCHAR(100),
	MatKhau VARCHAR(1000) NOT NULL,
	HoatDong BIT DEFAULT 1, -- 1: true - 0: false
	DiaChi NVARCHAR(1000),
	SoDienThoai NVARCHAR(100)
)
--Nhom Nhan Vien
CREATE TABLE NhomNhanVien
(
	MaNhomNhanVien VARCHAR(100) NOT NULL PRIMARY KEY,
	TenNhomNhanVien NVARCHAR(100),
	GhiChu NVARCHAR(1000)
)
--QL_NhanVienNhomNhanVien
CREATE TABLE QL_NhanVienNhomNhanVien
(
	TenDangNhap VARCHAR(100) NOT NULL,
	MaNhomNhanVien VARCHAR(100) NOT NULL,
	GhiChu NVARCHAR(1000),
	CONSTRAINT PK_NVNNV PRIMARY KEY(TenDangNhap,MaNhomNhanVien)
)
--QL_PhanQuyen
CREATE TABLE QL_PhanQuyen
(
	MaNhomNhanVien VARCHAR(100) NOT NULL,
	MaManHinh VARCHAR(100) NOT NULL,
	CoQuyen BIT DEFAULT 0 -- 1: true - 0: false
	CONSTRAINT PK_QLPQ PRIMARY KEY(MaNhomNhanVien,MaManHinh)
)
--
ALTER TABLE QL_NhanVienNhomNhanVien ADD CONSTRAINT FK_NVNNV_TenDN FOREIGN KEY (TenDangNhap) REFERENCES NhanVien(TenDangNhap)
GO
ALTER TABLE QL_NhanVienNhomNhanVien ADD CONSTRAINT FK_NVNNV_MaNNV FOREIGN KEY (MaNhomNhanVien) REFERENCES NhomNhanVien(MaNhomNhanVien)
GO
ALTER TABLE QL_PhanQuyen ADD CONSTRAINT FK_PQ_MaNNV FOREIGN KEY (MaNhomNhanVien) REFERENCES NhomNhanVien(MaNhomNhanVien)
GO
ALTER TABLE QL_PhanQuyen ADD CONSTRAINT FK_PQ_MaMH FOREIGN KEY (MaManHinh) REFERENCES DM_ManHinh(MaManHinh)
GO
---------------------------------------------------------------------------------------------------------------------------
--LoaiMon
CREATE TABLE LoaiMon
(
	MaLoaiMon INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TenLoaiMon NVARCHAR(1000)
)
GO
--Món
CREATE TABLE Mon
(
	MaMon INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TenMon NVARCHAR(1000),
	GiaBan FLOAT,
	MaLoaiMon INT --khóa ngoại đến bảng LoaiMon  
)
GO
--Bàn
CREATE TABLE Ban
(
	MaSoBan INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TenBan NVARCHAR(100),
	TrangThai BIT DEFAULT 0  -- 0 : Trống || 1: Có người
)
GO
--Hóa Đơn
CREATE TABLE HoaDon
(
	MaHoaDon INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TimeCheckIn DATETIME NOT NULL DEFAULT GETDATE(),
	TimeCheckOut DATETIME,
	TrangThai INT DEFAULT 0,	-- 1: Đã thanh toán , 0: chưa thanh toán (mặc định là chưa tt)
	MaSoBan INT,					--khóa ngoại đến bảng BÀN
	NguoiLap VARCHAR(100),       --Khóa ngoại đến bảng (TaiKhoan) để biết nhân viên nào đã lập hóa đơn này
	TongTien MONEY,
	GiamGia INT
)
GO
--Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon
(
	MaHoaDon INT NOT NULL,
	MaMon INT NOT NULL,
	SoLuong INT DEFAULT 0,
	CONSTRAINT PK_CTHD PRIMARY KEY(MaHoaDon,MaMon)
)
GO
--
ALTER TABLE Mon ADD CONSTRAINT FK_MON_MLMon FOREIGN KEY (MaLoaiMon) REFERENCES LoaiMon(MaLoaiMon)
GO
ALTER TABLE HoaDon ADD CONSTRAINT FK_HOADON_BAN FOREIGN KEY (MaSoBan) REFERENCES Ban(MaSoBan)
Go
ALTER TABLE HoaDon ADD CONSTRAINT FK_HOADON_NguoiLap FOREIGN KEY (NguoiLap) REFERENCES NhanVien(TenDangNhap)
GO
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_CTHD_MaHD FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
GO
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_CTHD_MaMon FOREIGN KEY (MaMon) REFERENCES Mon(MaMon)
GO
---------------------------------------------------------------------------------------------------------------
--Nhập dữ liệu
SET IDENTITY_INSERT LoaiMon ON;
INSERT INTO LoaiMon(MaLoaiMon, TenLoaiMon) VALUES 
	(1, N'Freeze'),
	(2, N'Cà phê'),
	(3, N'Trà'),
	(4, N'Bánh mì'),
	(5, N'Khác');
SET IDENTITY_INSERT LoaiMon OFF;

SET IDENTITY_INSERT Mon ON;
INSERT INTO Mon(MaMon, MaLoaiMon, TenMon, GiaBan) VALUES
	(1, 1, N'Phin Sữa Đá', 29000),
	(2, 1, N'Phin Đen Đá', 29000),
	(3, 1, N'Phin Đen Nóng', 29000),
	(4, 1, N'Phin Sữa Nóng', 29000),
	(5, 1, N'Mocha Macchiato', 59000),
	(6, 1, N'Espresso', 44000),
	(7, 1, N'Americano', 44000),
	(8, 1, N'Latte', 54000),
	(9, 2, N'Caramel Phin Freeze', 49000),
	(10, 2, N'Classic Phin Freeze', 49000),
	(11, 2, N'Freeze Trà Xanh', 49000),
	(12, 2, N'Cookies & Cream', 49000),
	(13, 2, N'Freeze Sô-cô-la', 49000),
	(14, 3, N'Trà Sen Vàng', 39000),
	(15, 3, N'Trà Thạch Vải', 39000),
	(16, 3, N'Trà Thạch Đào', 39000),
	(17, 3, N'Trà Thanh Đào', 39000),
	(18, 4, N'Thịt nướng', 19000),
	(19, 4, N'Xíu mại', 19000),
	(20, 4, N'Gà Xé Nước Tương', 19000),
	(21, 4, N'Chả lụa xá xíu', 19000),
	(22, 5, N'Bánh Mousse Cacao', 29000),
	(23, 5, N'Bánh Sô-cô-la Highlands', 29000),
	(24, 5, N'Bánh Caramel Phô Mai', 29000),
	(25, 5, N'Bánh Mousse Đào', 29000);
SET IDENTITY_INSERT Mon OFF;
GO

--Nhap lieu table Ban
DECLARE @i INT = 1
WHILE @i <= 10
BEGIN
	INSERT INTO Ban(TenBan) VALUES (N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO
INSERT INTO Ban(TenBan) VALUES (N'Mang về')
--
select * from LoaiMon
select * from Mon
select * from Ban
--------------------------------------------------------------17-7
select * from nhanvien
INSERT INTO NhanVien(TenDangNhap,HoTen,MatKhau,HoatDong,DiaChi,SoDienThoai) VALUES('truong',N'Bùi Vũ Trường','123',1,N'Quảng Ngãi','0345689285')
--------------------------------------------------------------27-7
ALTER TABLE Mon
ADD HinhAnh NVARCHAR(128)

UPDATE Mon SET HinhAnh = 'phin-sua-da.png' WHERE MaMon = '1'
UPDATE Mon SET HinhAnh = 'phin-den-da.png' WHERE MaMon = '2'
UPDATE Mon SET HinhAnh = 'phin-den-nong.png' WHERE MaMon = '3'
UPDATE Mon SET HinhAnh = 'phin-sua-nong.png' WHERE MaMon = '4'
UPDATE Mon SET HinhAnh = 'mocha-macchiato.png' WHERE MaMon = '5'
UPDATE Mon SET HinhAnh = 'espresso.png' WHERE MaMon = '6'
UPDATE Mon SET HinhAnh = 'americano.png' WHERE MaMon = '7'
UPDATE Mon SET HinhAnh = 'latte.png' WHERE MaMon = '8'
UPDATE Mon SET HinhAnh = 'caramel-phin-freeze.png' WHERE MaMon = '9'
UPDATE Mon SET HinhAnh = 'classic-phin-freeze.png' WHERE MaMon = '10'
UPDATE Mon SET HinhAnh = 'freeze-tra-xanh.png' WHERE MaMon = '11'
UPDATE Mon SET HinhAnh = 'cookies-cream.png' WHERE MaMon = '12'
UPDATE Mon SET HinhAnh = 'freeze-socola.png' WHERE MaMon = '13'
UPDATE Mon SET HinhAnh = 'tra-sen-vang.png' WHERE MaMon = '14'
UPDATE Mon SET HinhAnh = 'tra-thach-vai.png' WHERE MaMon = '15'
UPDATE Mon SET HinhAnh = 'tra-thach-dao.png' WHERE MaMon = '16'
UPDATE Mon SET HinhAnh = 'tra-thanh-dao.png' WHERE MaMon = '17'
UPDATE Mon SET HinhAnh = 'thit-nuong.png' WHERE MaMon = '18'
UPDATE Mon SET HinhAnh = 'xiu-mai.png' WHERE MaMon = '19'
UPDATE Mon SET HinhAnh = 'ga-xe-nuoc-tuong.png' WHERE MaMon = '20'
UPDATE Mon SET HinhAnh = 'cha-lua-xa-xiu.png' WHERE MaMon = '21'
UPDATE Mon SET HinhAnh = 'banh-mousse-cacao.png' WHERE MaMon = '22'
UPDATE Mon SET HinhAnh = 'banh-socola-highlands.png' WHERE MaMon = '23'
UPDATE Mon SET HinhAnh = 'banh-caramel-pho-mai.png' WHERE MaMon = '24'
UPDATE Mon SET HinhAnh = 'banh-mousse-dao.png' WHERE MaMon = '25'

select * from NhanVien

select * from Ban
select * from HoaDon
select * from ChiTietHoaDon

select f.TenMon, cthd.SoLuong, f.GiaBan 
from Mon as f, HoaDon as hd, ChiTietHoaDon as cthd 
where hd.MaHoaDon = cthd.MaHoaDon 
		and cthd.MaMon = f.MaMon 
		and hd.MaSoBan = 1                       --1.maban 
		and hd.TrangThai = 0


INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000001', N'Cà Phê', N'Kilogram', 500000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000002', N'Đường', N'Kilogram', 12000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000003', N'Sữa', N'Hộp', 22000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000004', N' Thịt heo', N'Kilogram', 55000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000005', N'Thịt gà', N'Kilogram', 18000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000006', N'Túi trà đào', N'Hộp', 33000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000007', N'Túi trà xanh', N'Hộp', 33000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000008', N'Túi trà vải', N'Hộp', 30000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000009', N'Túi trà sen', N'Hộp', 35000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000010', N'Bột sữa ', N'Kilogram', 25000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000011', N'Socola', N'Kilogram', 80000.0000)
INSERT [dbo].[NguyenLieuNhap] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [DonGia]) VALUES (N'NL000012', N'Bột làm bánh', N'Kilogram', 12000.0000)

INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00001', N'90s Coffee', N'8C, Đường số 2, P. Trường Thọ, Q.Thủ Đức', N'0929899992')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00002', N'Taf Coffee', N'133C Nguyễn Chí Thanh, P. 9, Q. 5', N'0988221133')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00003', N'Cafe Motherland', N'160 Vườn Lài, P. Phú Thọ Hòa, Q. Tân Phú', N'0355667788')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00004', N'Vifoodshop', N'23 Lê Đức Thọ, P. Phú Thọ, Q. Gò Vấp', N'0375025415')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00005', N'Bách Hóa Xanh', N'722 Lê Trọng Tấn, P. Tây Thạnh, Q. Tân Phú', N'0325416658')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai]) VALUES (N'NCC00006', N'Trà Búp Dũng Đạt', N'5/7 Huỳnh Thị Hai, P. Tân Chánh Hiệp, Q.12', N'0959916039')

INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000001', N'NCC00002', CAST(0x0000AC0E012E99A5 AS DateTime), 1500000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000002', N'NCC00002', CAST(0x0000AC0E012EFBC0 AS DateTime), 890000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000003', N'NCC00006', CAST(0x0000AC0E012F7DC2 AS DateTime), 960000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000004', N'NCC00001', CAST(0x0000AC0E01318506 AS DateTime), 1000000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000005', N'NCC00001', CAST(0x0000AC0E0131E8CC AS DateTime), 146000.0000, N'truong')

SET IDENTITY_INSERT [dbo].[Ban] OFF
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000001', N'NL000001', 500000.0000, 3, 1500000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000002', N'NL000002', 12000.0000, 10, 120000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000002', N'NL000003', 22000.0000, 10, 220000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000002', N'NL000004', 55000.0000, 10, 550000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000003', N'NL000006', 33000.0000, 10, 330000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000003', N'NL000007', 33000.0000, 10, 330000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000003', N'NL000008', 30000.0000, 10, 300000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000004', N'NL000001', 500000.0000, 2, 1000000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000005', N'NL000004', 55000.0000, 2, 110000.0000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaNguyenLieu], [DonGia], [SoLuong], [ThanhTien]) VALUES (N'PN000005', N'NL000005', 18000.0000, 2, 36000.0000)
SET IDENTITY_INSERT [dbo].[LoaiMon] ON 

