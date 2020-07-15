create database QLPhongKham
go
set dateformat  dmy
use QLPhongKham
go 
create table Dangnhap
(
 taikhoan varchar(45),
 matkhau varchar(45),
 chucvi tinyint
)

create table BenhNhan
( 
 MaBN varchar(10) primary key not null,
 TenBN varchar(40),
 SoDT char(10),
 GioiTinh varchar(5),
 DiaChi varchar(45),
 NgSinh datetime,
 TrieuChung varchar(100),
 KetLuanBenh varchar(100),
 BaoHiem varchar(45)
)

 create table LoaiNhanVien
 (
  MaLoaiNhanVien varchar(10) primary key not null,
  TenLoaiNhanVien varchar(45)
)

 create table NhanVien
 (
  MaNV varchar(10) primary key not null,
  TenNV varchar(40),
  SoDT char(10),
  GioiTinh varchar(5),
  DiaChi varchar(45),
  NgSinh datetime,
  NgVaoLam datetime,
  MaLoaiNhanVien varchar(10) references LoaiNhanVien(MaLoaiNhanVien) /*Nhan vien co the la bac si, thu ngan, thu kho*/
)

create table PKB (
MaPKB varchar(10) primary key not null,
MaBN varchar(10) foreign key references BenhNhan(MaBN) not null,
MaNV varchar(10) foreign key references NhanVien(MaNV) not null,
NgKham datetime not null,
ChuanDoan nvarchar(max)
)

 create table Thuoc
(
  MaThuoc varchar(10) primary key not null,
  TenThuoc varchar(45),
  SoLuong int,
  NSX datetime,
  HSD datetime,
  NCC varchar(45),
  Gia money
)

create table PhNhap (
MaPN int primary key not null,
NgPhieuNhap datetime
)

create table CTPN (
MaCTPN int primary key not null,
MaPN int foreign key references PhNhap(MaPN) not null,
MaThuoc varchar(10) not null,
TenThuoc varchar(45),
SoLuong int,
NSX datetime,
HSD datetime,
NCC varchar(45),
Gia money
)

create table DonThuoc
(
 MaDT int primary key not null,
 NgDT datetime not null,
 MaNV varchar(10) references NhanVien(MaNV),
 MaBN varchar(10) references BenhNhan(MaBN)
)

create table CTDT
(
MaCTDT int primary key not null,
MaDT int foreign key  references DonThuoc(MaDT) not null,
MaThuoc varchar(10) not null references Thuoc(MaThuoc),
SoLuong int
)

create table HoaDon
(
 MaHD varchar(10) primary key not null,
 MaDT int references DonThuoc(MaDT) not null,
 NgHD datetime,
 TriGia money
)

 -------------------------------------INSERT BENHNHAN------------------------------------------------
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN001', N'Nguyen Thanh Cong', N'0945165187', N'Nam', N'784 Truong Chinh, Q1, Tp.Ho Chi Minh', CAST(N'1987-01-28T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN002', N'Van Cong Vinh', N'0945958874', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1994-02-02T00:00:00.000' AS DateTime), N'Dau co chan trai', N'Trat khop co chan trai', N'Bao Hiem Phuong')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN003', N'Tran Nhu Y ', N'0913785946', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1999-09-05T00:00:00.000' AS DateTime), N'Dau nua dau', N'Chan thuong nao do va dap', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN005', N'Nguyen Van Buoc', N'0945165187', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1985-07-13T00:00:00.000' AS DateTime), N'Dau tim', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN006', N'Nguyen Thanh Hien', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1993-04-16T00:00:00.000' AS DateTime), N'Dau cu', N'Thu dam qua nhieu', N'Bao hiem NBA')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN007', N'Ho Truong Khang', N'0945165187', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1994-09-26T00:00:00.000' AS DateTime), N'Dau hong', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN008', N'Tran Tuan Thanh', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1998-01-14T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN009', N'Nguyen Tran Mila', N'0918754784', N'Nam', N'82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh', CAST(N'1989-11-16T00:00:00.000' AS DateTime), N'Dau nua dau', N'Chan thuong nao do va dap', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN010', N'Nguyen Hoang Duy', N'0945165187', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1999-06-04T00:00:00.000' AS DateTime), N'Dau tim', N'', N'Khong co')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN011', N'Vo Thanh Hau', N'0918754784', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1999-05-27T00:00:00.000' AS DateTime), N'Ngat Xiu, hon me', N'Co the mat suc nhin an', N'Bao Hiem Truong')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN012', N'Ngo Duc Thang', N'0918754784', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1986-03-03T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN013', N'Le Tan Phi', N'0945165187', N'Nu', N'84 Do Xuan Hop,Q9 Tp.Ho Chi Minh', CAST(N'1995-01-02T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
INSERT [dbo].[BenhNhan] ([MaBN], [TenBN], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [TrieuChung], [KetLuanBenh], [BaoHiem]) VALUES (N'BN014', N'Mia Khalid', N'0945165187', N'Nam', N'11/78/7 Pasteur,Q1 Tp.Ho Chi Minh', CAST(N'1996-02-26T00:00:00.000' AS DateTime), N'Ho, dau hong', N'Nhiem Covid19', N'Bao Hiem Nhan Tho')
 
  
 -----------------------------------------------------------------------------------------------


 
 --------------------------INSERT LOAINHANVIEN-------------------------------------
 INSERT INTO LoaiNhanVien values('3','Le Tan')
 INSERT INTO LoaiNhanVien values('2','Bac Si')
 INSERT INTO LoaiNhanVien values('4','Thu Kho')


 ------------------------------------------------------------------------------

---------------------------------------------------------

 -----------------------------INSERT NHANVIEN-------------------------------------------------

INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'BS001', N'Nguyen Tien Truong', N'0918359847', N'Nam', N'Q7, Tp.Ho Chi Minh', CAST(N'1987-02-15T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'2')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'BS002', N'Tran Minh Chien', N'0948975485', N'Nam', N'Q73, Tp.Ho Chi Minh', CAST(N'1975-09-08T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'2')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TK001', N'Trinh Chung Cuong', N'0915145145', N'Nam', N'Q76, Tp.Ho Chi Minh', CAST(N'1969-08-22T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'4')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TT001', N'Nguyen Van A', N'0918359847', N'Nam', N'Q7, Tp.Ho Chi Minh', CAST(N'1987-02-15T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'3')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [SoDT], [GioiTinh], [DiaChi], [NgSinh], [NgVaoLam], [MaLoaiNhanVien]) VALUES (N'TT002', N'Nguyen Thi Lanh', N'0918359877', N'Nu', N'P5, Vung Tau', CAST(N'1985-08-17T00:00:00.000' AS DateTime), CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'3')
 -------------------------------------------------------------------------------------

----------------------------------------------------



----------------------------------------------------------------------------------------
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





---------------------------------------INSERT THUOC---------------------------------------------

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




----------------------------------------------------------------------------------


--------------------------------------------------------
INSERT INTO DonThuoc VALUES (00001,CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'BS001',N'BN001')
INSERT INTO DonThuoc VALUES (00002,CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'BS001',N'BN002')
INSERT INTO DonThuoc VALUES (00003,CAST(N'2020-07-07T00:00:00.000' AS DateTime),N'BS001',N'BN003' )
INSERT INTO DonThuoc VALUES (00004,CAST(N'2020-03-08T00:00:00.000' AS DateTime),N'BS002',N'BN003')
INSERT INTO DonThuoc VALUES (00005,CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'BS001', N'BN005')

INSERT INTO DonThuoc VALUES (00006,CAST(N'2020-03-16T00:00:00.000' AS DateTime),N'BS001',N'BN006')
INSERT INTO DonThuoc VALUES (00007,CAST(N'2020-03-16T00:00:00.000' AS DateTime), N'BS002',N'BN007')
INSERT INTO DonThuoc VALUES (00008,CAST(N'2020-03-15T00:00:00.000' AS DateTime),N'BS002',N'BN008')
INSERT INTO DonThuoc VALUES (00009,CAST(N'2020-03-16T00:00:00.000' AS DateTime),N'BS002', N'BN009' )
INSERT INTO DonThuoc VALUES (00010, CAST(N'2020-03-20T00:00:00.000' AS DateTime), N'BS001', N'BN010')

INSERT INTO DonThuoc VALUES (00011,CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'BS002',N'BN011')
INSERT INTO DonThuoc VALUES (00012,CAST(N'2020-04-02T00:00:00.000' AS DateTime), N'BS002', N'BN012')
INSERT INTO DonThuoc VALUES (00013,CAST(N'2020-04-06T00:00:00.000' AS DateTime),N'BS001', N'BN013' )
INSERT INTO DonThuoc VALUES (00014, CAST(N'2020-05-06T00:00:00.000' AS DateTime),N'BS001', N'BN014' )


---------------------------------------------------------





INSERT INTO CTDT VALUES (1,1,'TH003',10)
INSERT INTO CTDT VALUES (2,2,'TH005',2)
INSERT INTO CTDT VALUES (3,3,'TH007',30)
INSERT INTO CTDT VALUES (4,4,'TH010',10)
INSERT INTO CTDT VALUES (5,5,'TH001',4)

INSERT INTO CTDT VALUES (6,6,'TH001',4)
INSERT INTO CTDT VALUES (7,7,'TH005',6)
INSERT INTO CTDT VALUES (8,8,'TH010',5)
INSERT INTO CTDT VALUES (9,9,'TH001',10)
INSERT INTO CTDT VALUES (10,10,'TH002',1)

INSERT INTO CTDT VALUES (11,11,'TH006',2)
INSERT INTO CTDT VALUES (12,12,'TH005',4)
INSERT INTO CTDT VALUES (13,13,'TH009',5)
INSERT INTO CTDT VALUES (14,14,'TH005',5)


-----------------------------------------------------------------
Insert into HoaDon values ('HD001',1,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)
Insert into HoaDon values ('HD002',2,CAST(N'2020-03-01T00:00:00.000' AS DateTime),60000)
Insert into HoaDon values ('HD003',3,CAST(N'2020-03-01T00:00:00.000' AS DateTime),1350000)
Insert into HoaDon values ('HD004',4,CAST(N'2020-03-01T00:00:00.000' AS DateTime),200000)
Insert into HoaDon values ('HD005',5,CAST(N'2020-03-01T00:00:00.000' AS DateTime),100000)

Insert into HoaDon values ('HD006',6,CAST(N'2020-03-01T00:00:00.000' AS DateTime),100000)
Insert into HoaDon values ('HD007',7,CAST(N'2020-03-01T00:00:00.000' AS DateTime),180000)
Insert into HoaDon values ('HD008',8,CAST(N'2020-03-01T00:00:00.000' AS DateTime),100000)
Insert into HoaDon values ('HD009',9,CAST(N'2020-03-01T00:00:00.000' AS DateTime),250000)
Insert into HoaDon values ('HD010',10,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)

Insert into HoaDon values ('HD011',11,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)
Insert into HoaDon values ('HD012',11,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)
Insert into HoaDon values ('HD013',13,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)
Insert into HoaDon values ('HD014',14,CAST(N'2020-03-01T00:00:00.000' AS DateTime),270000)



-------------------------------------------------------------------------------------
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'ADMIN', N'ADMIN', 1)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0001', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0002', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tt0003', N'1', 3)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0001', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0002', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'bs0003', N'1', 2)
INSERT [dbo].[Dangnhap] ([taikhoan], [matkhau], [chucvi]) VALUES (N'tk0001', N'1', 4)


 /*----------------------------------------------------------------------*/

SELECT MaDT,TenNV,TenBN,CAST(DonThuoc.NgDT AS DATE) AS [NgKham] from DonThuoc,NhanVien,BenhNhan
where DonThuoc.MaNV = NhanVien.MaNV and BenhNhan.MaBN = DonThuoc.MaBN 

SELECT CAST(NgDT AS DATE) AS [Ngay],count(MaBN) as [SoBenhNhan], Sum(TriGia) As [Doanh Thu]
FROM DonThuoc,HoaDon Where NgDT between '01-1-2020' and '01-07-2020' and DonThuoc.MaDT= HoaDon.MaDT
group by NgDT
order by NgDT

select count(MaBN) as [SoBN] from DonThuoc,HoaDon Where NgDT between '01-1-2020' and '01-07-2020' and DonThuoc.MaDT= HoaDon.MaDT

select  Sum(convert(int,TriGia,0)) As [Doanh Thu] 
from DonThuoc,HoaDon Where NgDT between '01-1-2020' and '01-07-2020' and DonThuoc.MaDT= HoaDon.MaDT