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
--
select * from LoaiMon
select * from Mon
select * from Ban
--------------------------------------------------------------17-7
select * from nhanvien
INSERT INTO NhanVien(TenDangNhap,HoTen,MatKhau,HoatDong,DiaChi,SoDienThoai) VALUES('truong',N'Bùi Vũ Trường','123',1,N'Quảng Ngãi','0345689285')