USE [QLPhongKham]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaBN] [varchar](10) NOT NULL,
	[TenBN] [varchar](40) NULL,
	[SoDT] [char](10) NULL,
	[GioiTinh] [varchar](5) NULL,
	[DiaChi] [varchar](45) NULL,
	[NgSinh] [datetime] NULL,
	[NgKham] [datetime] NULL,
	[TrieuChung] [varchar](100) NULL,
	[KetLuanBenh] [varchar](100) NULL,
	[BaoHiem] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaHD] [varchar](10) NULL,
	[MADT] [varchar](10) NULL,
	[SL] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTPN]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPN](
	[MaCTPN] [int] NOT NULL,
	[MaPN] [int] NOT NULL,
	[MaThuoc] [varchar](10) NOT NULL,
	[TenThuoc] [varchar](45) NULL,
	[SoLuong] [int] NULL,
	[NSX] [datetime] NULL,
	[HSD] [datetime] NULL,
	[NCC] [varchar](45) NULL,
	[Gia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dangnhap]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dangnhap](
	[taikhoan] [varchar](45) NULL,
	[matkhau] [varchar](45) NULL,
	[chucvi] [tinyint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonThuoc]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonThuoc](
	[MaDT] [varchar](10) NOT NULL,
	[MaThuoc] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[MaNV] [varchar](10) NULL,
	[MaBN] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [varchar](10) NOT NULL,
	[MaDT] [varchar](10) NULL,
	[NgHD] [datetime] NULL,
	[TriGia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [varchar](10) NOT NULL,
	[TenLoaiNhanVien] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](10) NOT NULL,
	[TenNV] [varchar](40) NULL,
	[SoDT] [char](10) NULL,
	[GioiTinh] [varchar](5) NULL,
	[DiaChi] [varchar](45) NULL,
	[NgSinh] [datetime] NULL,
	[NgVaoLam] [datetime] NULL,
	[MaLoaiNhanVien] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhNhap]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhNhap](
	[MaPN] [int] NOT NULL,
	[NgPhieuNhap] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PKB]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PKB](
	[MaPKB] [varchar](10) NOT NULL,
	[MaBN] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NOT NULL,
	[NgKham] [datetime] NULL,
	[ChuanDoan] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPKB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thuoc]    Script Date: 7/11/2020 1:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[MaThuoc] [varchar](10) NOT NULL,
	[TenThuoc] [varchar](45) NULL,
	[SoLuong] [int] NULL,
	[NSX] [datetime] NULL,
	[HSD] [datetime] NULL,
	[NCC] [varchar](45) NULL,
	[Gia] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN001', N'Nguyen Thanh Cong', N'0945165187', N'Nam', N'784 Truong Chinh, Q1, Tp.Ho Chi Minh', CAST(N'1987-01-28T00:00:00.000' AS DateTime), CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN002', N'Van Cong Vinh', N'0945958874', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1994-02-02T00:00:00.000' AS DateTime), CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Dau co chan trai', N'Trat khop co chan trai', N'Bao Hiem Phuong')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN003', N'Tran Nhu Y ', N'0913785946', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1999-09-05T00:00:00.000' AS DateTime), CAST(N'2020-08-03T00:00:00.000' AS DateTime), N'Dau nua dau', N'Chan thuong nao do va dap', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN005', N'Nguyen Van Buoc', N'0945165187', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1985-07-13T00:00:00.000' AS DateTime), CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau tim', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN006', N'Nguyen Thanh Hien', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1993-04-16T00:00:00.000' AS DateTime), CAST(N'2020-03-16T00:00:00.000' AS DateTime), N'Dau cu', N'Thu dam qua nhieu', N'Bao hiem NBA')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN007', N'Ho Truong Khang', N'0945165187', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1994-09-26T00:00:00.000' AS DateTime), CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau hong', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN008', N'Tran Tuan Thanh', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1998-01-14T00:00:00.000' AS DateTime), CAST(N'2020-03-16T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN009', N'Nguyen Tran Mila', N'0918754784', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1989-11-16T00:00:00.000' AS DateTime), CAST(N'2020-03-20T00:00:00.000' AS DateTime), N'Dau nua dau', N'Chan thuong nao do va dap', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN010', N'Nguyen Hoang Duy', N'0945165187', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1999-06-04T00:00:00.000' AS DateTime), CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau tim', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN011', N'Vo Thanh Hau', N'0918754784', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1999-05-27T00:00:00.000' AS DateTime), CAST(N'2020-04-02T00:00:00.000' AS DateTime), N'Ngat Xiu, hon me', N'Co the mat suc nhin an', N'Bao Hiem Truong')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN012', N'Ngo Duc Thang', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1986-03-03T00:00:00.000' AS DateTime), CAST(N'2020-04-06T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN013', N'Le Tan Phi', N'0945165187', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1995-01-02T00:00:00.000' AS DateTime), CAST(N'2020-05-06T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgKham], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN014', N'Mia Khalid', N'0945165187', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1996-02-26T00:00:00.000' AS DateTime), CAST(N'2020-07-07T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'ADMIN', N'ADMIN', 1)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0001', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0002', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0003', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0002', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0002', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0003', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tk0001', N'1', 4)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tk0001', N'1', 4)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tk0001', N'1', 4)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0001', N'1', 2)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'2', N'Bac Si')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'3', N'Le Tan')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'4', N'Thu Kho')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'BS001', N'Nguyen Tien Truong', N'0918359847', N'Nam', N'Q7, Tp.Ho Chi Minh', CAST(N'1987-02-15T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'2')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'BS002', N'Tran Minh Chien', N'0948975485', N'Nam', N'Q73, Tp.Ho Chi Minh', CAST(N'1975-09-08T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'2')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TK001', N'Trinh Chung Cuong', N'0915145145', N'Nam', N'Q76, Tp.Ho Chi Minh', CAST(N'1969-08-22T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'4')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TT001', N'Nguyen Van A', N'0918359847', N'Nam', N'Q7, Tp.Ho Chi Minh', CAST(N'1987-02-15T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'3')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TT002', N'Nguyen Thi Lanh', N'0918359877', N'Nu', N'P5, Vung Tau', CAST(N'1985-08-17T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'3')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB001', N'BN001', N'BS001', CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Ho, dau hong')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB002', N'BN002', N'BS001', CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'Dau co chan trai')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB003', N'BN014', N'BS001', CAST(N'2020-07-07T00:00:00.000' AS DateTime), N'Ho, dau hong')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB004', N'BN003', N'BS002', CAST(N'2020-03-08T00:00:00.000' AS DateTime), N'Dau nua dau')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB006', N'BN005', N'BS001', CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau tim')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB007', N'BN006', N'BS001', CAST(N'2020-03-16T00:00:00.000' AS DateTime), N'Dau cu')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB008', N'BN007', N'BS002', CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau hong')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB009', N'BN008', N'BS002', CAST(N'2020-03-16T00:00:00.000' AS DateTime), N'Ho, dau hong')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB010', N'BN009', N'BS002', CAST(N'2020-03-20T00:00:00.000' AS DateTime), N'Dau nua dau')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB011', N'BN010', N'BS001', CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Dau tim')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB012', N'BN011', N'BS002', CAST(N'2020-04-02T00:00:00.000' AS DateTime), N'Ngat Xiu, hon me')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB013', N'BN012', N'BS002', CAST(N'2020-04-06T00:00:00.000' AS DateTime), N'Ho, dau hong')
INSERT [dbo].[PKB] ([MaPKB], [MaBN], [MaNV], [NgKham], [ChuanDoan]) VALUES (N'PKB014', N'BN013', N'BS001', CAST(N'2020-05-06T00:00:00.000' AS DateTime), N'Ho, dau hong')
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'', N'', 0, CAST(N'2020-05-07T00:00:00.000' AS DateTime), CAST(N'2020-05-07T00:00:00.000' AS DateTime), N'', 0.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH001', N'Amoxcillin', 150, CAST(N'2019-01-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Coopmart', 25000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH002', N'Ampicillin', 80, CAST(N'2019-03-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Coopmart', 25000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH003', N'Cefalexin', 80, CAST(N'2019-01-20T00:00:00.000' AS DateTime), CAST(N'2030-01-20T00:00:00.000' AS DateTime), N'Vinmart', 27000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH004', N' Cefadroxin 500mg', 80, CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2030-01-01T00:00:00.000' AS DateTime), N'Vinmart', 35000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH005', N'Augmentin 625mg', 60, CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2030-01-01T00:00:00.000' AS DateTime), N'Vinmart', 30000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH006', N'Klamentin 625mg', 60, CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2030-01-01T00:00:00.000' AS DateTime), N'Hogward', 30000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH007', N'Azithromycin 250mg', 90, CAST(N'2019-01-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Hogward', 45000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH008', N'Clarythromycin 250mg', 80, CAST(N'2019-01-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Hogward', 120000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH009', N'Cefpodoxim 100mg', 80, CAST(N'2019-01-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Hogward', 20000.0000)
INSERT [dbo].[Thuoc] ([MaThuoc], [TenThuoc], [SoLuong], [NSX], [HSD], [NCC], [Gia]) VALUES (N'TH010', N'Augmentin 1g', 80, CAST(N'2019-01-11T00:00:00.000' AS DateTime), CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'Coopmart', 20000.0000)
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MADT])
REFERENCES [dbo].[DonThuoc] ([MaDT])
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[CTPN]  WITH CHECK ADD FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhNhap] ([MaPN])
GO
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD FOREIGN KEY([MaBN])
REFERENCES [dbo].[BenhNhan] ([MaBN])
GO
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonThuoc]  WITH CHECK ADD FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaDT])
REFERENCES [dbo].[DonThuoc] ([MaDT])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaLoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[PKB]  WITH CHECK ADD FOREIGN KEY([MaBN])
REFERENCES [dbo].[BenhNhan] ([MaBN])
GO
