USE [QuanLyQuanCafe_UDTM]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaSoBan] [int] IDENTITY(1,1) NOT NULL,
	[TenBan] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSoBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaMon] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaPhieuNhap] [varchar](100) NOT NULL,
	[MaNguyenLieu] [varchar](100) NOT NULL,
	[DonGia] [money] NULL,
	[SoLuong] [float] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTPN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DM_ManHinh]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DM_ManHinh](
	[MaManHinh] [varchar](100) NOT NULL,
	[TenManHinh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[TimeCheckIn] [datetime] NOT NULL,
	[TimeCheckOut] [datetime] NULL,
	[TrangThai] [int] NULL,
	[MaSoBan] [int] NULL,
	[NguoiLap] [varchar](100) NULL,
	[TongTien] [money] NULL,
	[GiamGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiMon]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMon](
	[MaLoaiMon] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiMon] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mon]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mon](
	[MaMon] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](1000) NULL,
	[GiaBan] [float] NULL,
	[MaLoaiMon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguyenLieuNhap]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguyenLieuNhap](
	[MaNguyenLieu] [varchar](100) NOT NULL,
	[TenNguyenLieu] [nvarchar](100) NULL,
	[DonViTinh] [nvarchar](100) NULL,
	[DonGia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [varchar](100) NOT NULL,
	[TenNhaCungCap] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](1000) NULL,
	[SoDienThoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[TenDangNhap] [varchar](100) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[MatKhau] [varchar](1000) NOT NULL,
	[HoatDong] [bit] NULL,
	[DiaChi] [nvarchar](1000) NULL,
	[SoDienThoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhomNhanVien]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhomNhanVien](
	[MaNhomNhanVien] [varchar](100) NOT NULL,
	[TenNhomNhanVien] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhomNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [varchar](100) NOT NULL,
	[MaNhaCungCap] [varchar](100) NULL,
	[NgayNhap] [datetime] NULL,
	[ThanhTien] [money] NULL,
	[NguoiLap] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QL_NhanVienNhomNhanVien]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QL_NhanVienNhomNhanVien](
	[TenDangNhap] [varchar](100) NOT NULL,
	[MaNhomNhanVien] [varchar](100) NOT NULL,
	[GhiChu] [nvarchar](1000) NULL,
 CONSTRAINT [PK_NVNNV] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC,
	[MaNhomNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QL_PhanQuyen]    Script Date: 8/5/2020 8:55:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QL_PhanQuyen](
	[MaNhomNhanVien] [varchar](100) NOT NULL,
	[MaManHinh] [varchar](100) NOT NULL,
	[CoQuyen] [bit] NULL,
 CONSTRAINT [PK_QLPQ] PRIMARY KEY CLUSTERED 
(
	[MaNhomNhanVien] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ban] ON 

INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (1, N'Bàn 1', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (2, N'Bàn 2', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (3, N'Bàn 3', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (4, N'Bàn 4', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (5, N'Bàn 5', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (6, N'Bàn 6', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (7, N'Bàn 7', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (8, N'Bàn 8', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (9, N'Bàn 9', 0)
INSERT [dbo].[Ban] ([MaSoBan], [TenBan], [TrangThai]) VALUES (10, N'Bàn 10', 0)
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

INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon]) VALUES (1, N'Freeze')
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon]) VALUES (2, N'Cà phê')
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon]) VALUES (3, N'Trà')
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon]) VALUES (4, N'Bánh mì')
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon]) VALUES (5, N'Khác')
SET IDENTITY_INSERT [dbo].[LoaiMon] OFF
SET IDENTITY_INSERT [dbo].[Mon] ON 

INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (1, N' Phin sữa đá', 59000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (2, N'Phin Đen Đá', 29000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (3, N'Phin Đen Nóng', 29000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (4, N'Phin Sữa Nóng', 29000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (5, N'Mocha Macchiato', 59000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (6, N'Espresso', 44000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (7, N'Americano', 44000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (8, N'Latte', 54000, 1)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (9, N'Caramel Phin Freeze', 49000, 2)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (10, N'Classic Phin Freeze', 49000, 2)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (11, N'Freeze Trà Xanh', 49000, 2)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (12, N'Cookies & Cream', 49000, 2)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (13, N'Freeze Sô-cô-la', 49000, 2)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (14, N'Trà Sen Vàng', 39000, 3)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (15, N'Trà Thạch Vải', 39000, 3)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (16, N'Trà Thạch Đào', 39000, 3)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (17, N'Trà Thanh Đào', 39000, 3)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (18, N'Thịt nướng', 19000, 4)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (19, N'Xíu mại', 19000, 4)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (20, N'Gà Xé Nước Tương', 19000, 4)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (21, N'Chả lụa xá xíu', 19000, 4)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (22, N'Bánh Mousse Cacao', 29000, 5)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (23, N'Bánh Sô-cô-la Highlands', 29000, 5)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (24, N'Bánh Caramel Phô Mai', 29000, 5)
INSERT [dbo].[Mon] ([MaMon], [TenMon], [GiaBan], [MaLoaiMon]) VALUES (25, N'Bánh Mousse Đào', 29000, 5)
SET IDENTITY_INSERT [dbo].[Mon] OFF
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
INSERT [dbo].[NhanVien] ([TenDangNhap], [HoTen], [MatKhau], [HoatDong], [DiaChi], [SoDienThoai]) VALUES (N'truong', N'Bùi Vũ Trường', N'123', 1, N'Quảng Ngãi', N'0345689285')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000001', N'NCC00002', CAST(0x0000AC0E012E99A5 AS DateTime), 1500000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000002', N'NCC00002', CAST(0x0000AC0E012EFBC0 AS DateTime), 890000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000003', N'NCC00006', CAST(0x0000AC0E012F7DC2 AS DateTime), 960000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000004', N'NCC00001', CAST(0x0000AC0E01318506 AS DateTime), 1000000.0000, N'truong')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhaCungCap], [NgayNhap], [ThanhTien], [NguoiLap]) VALUES (N'PN000005', N'NCC00001', CAST(0x0000AC0E0131E8CC AS DateTime), 146000.0000, N'truong')
ALTER TABLE [dbo].[Ban] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [TimeCheckIn]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [HoatDong]
GO
ALTER TABLE [dbo].[QL_PhanQuyen] ADD  DEFAULT ((0)) FOR [CoQuyen]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_MaHD] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_MaHD]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_MaMon] FOREIGN KEY([MaMon])
REFERENCES [dbo].[Mon] ([MaMon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_MaMon]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_MANL] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieuNhap] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPN_MANL]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_MAPN] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPN_MAPN]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_BAN] FOREIGN KEY([MaSoBan])
REFERENCES [dbo].[Ban] ([MaSoBan])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HOADON_BAN]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NguoiLap] FOREIGN KEY([NguoiLap])
REFERENCES [dbo].[NhanVien] ([TenDangNhap])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HOADON_NguoiLap]
GO
ALTER TABLE [dbo].[Mon]  WITH CHECK ADD  CONSTRAINT [FK_MON_MLMon] FOREIGN KEY([MaLoaiMon])
REFERENCES [dbo].[LoaiMon] ([MaLoaiMon])
GO
ALTER TABLE [dbo].[Mon] CHECK CONSTRAINT [FK_MON_MLMon]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_MaNCC] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_MaNCC]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NguoiLap] FOREIGN KEY([NguoiLap])
REFERENCES [dbo].[NhanVien] ([TenDangNhap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NguoiLap]
GO
ALTER TABLE [dbo].[QL_NhanVienNhomNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NVNNV_MaNNV] FOREIGN KEY([MaNhomNhanVien])
REFERENCES [dbo].[NhomNhanVien] ([MaNhomNhanVien])
GO
ALTER TABLE [dbo].[QL_NhanVienNhomNhanVien] CHECK CONSTRAINT [FK_NVNNV_MaNNV]
GO
ALTER TABLE [dbo].[QL_NhanVienNhomNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NVNNV_TenDN] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NhanVien] ([TenDangNhap])
GO
ALTER TABLE [dbo].[QL_NhanVienNhomNhanVien] CHECK CONSTRAINT [FK_NVNNV_TenDN]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PQ_MaMH] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[DM_ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_PQ_MaMH]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PQ_MaNNV] FOREIGN KEY([MaNhomNhanVien])
REFERENCES [dbo].[NhomNhanVien] ([MaNhomNhanVien])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_PQ_MaNNV]
GO
