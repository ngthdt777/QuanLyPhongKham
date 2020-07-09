create database QLPhongKham
go
set dateformat  dmy
use QLPhongKham
go 
create table Dangnhap
(
 taikhoan varchar(45),
 matkhau varchar(45),
 chucvi tinyint,
)
 --drop table Dangnhap
create table BenhNhan
( 
 MaBN varchar(10) primary key not null,
 TenBN varchar(40),
 SoDT char(10),
 GioiTinh varchar(5),
 DiaChi varchar(45),
 NgSinh datetime,
 NgKham datetime,
 TrieuChung varchar(100),
 KetLuanBenh varchar(100),
 BaoHiem varchar(45),
)

 -------------------------------------INSERT BENHNHAN------------------------------------------------
 INSErt into BenhNhan values ('BN001','Nguyen Thanh Cong','0945165187','Nam','784 Truong Chinh, Q1, Tp.Ho Chi Minh','28-01-1987','01-03-2020','Ho, dau hong','Nhiem Covid19', 'Bao Hiem Nhan Tho')
 INSErt into BenhNhan values ('BN002','Van Cong Vinh','0945958874','Nam','82/9 Truong Cong Dinh,Q8, Tp.Ho Chi Minh','2-2-1994','01-03-2020','Dau co chan trai','Trat khop co chan trai', 'Bao Hiem Phuong')
 INSErt into BenhNhan values ('BN003','Tran Nhu Y ','0913785945','Nu','84 Do Xuan Hop,Q9 Tp.Ho Chi Minh','9-5-1999','08-03-2020','Dau nua dau','Chan thuong nao do va dap', 'Khong co')
 INSErt into BenhNhan values ('BN004','Tang Thu Hue','0918754784','Nu','899 Binh Loi, Tp.Ho Chi Minh','15-09-1984','03-03-2020','Ngat Xiu, hon me','Co the mat suc nhin an', 'Bao Hiem Truong')
 INSErt into BenhNhan values ('BN005','Tran Minh Tho','0945966669','Nam','11/78/7 Pasteur,Q1 Tp.Ho Chi Minh','6-9-1970','05-03-2020','Ho, dau hong','Nhiem Covid19', 'Bao Hiem Nhan Tho')
 
  
 -----------------------------------------------------------------------------------------------

 create table LoaiNhanVien
 (
  MaLoaiNhanVien varchar(10) primary key not null,
  TenLoaiNhanVien varchar(45),
)
 
 --------------------------INSERT LOAINHANVIEN-------------------------------------
 INSERT INTO LoaiNhanVien values('3','Le Tan')
 INSERT INTO LoaiNhanVien values('2','Bac Si')
 INSERT INTO LoaiNhanVien values('4','Thu Kho')


 ------------------------------------------------------------------------------
 create table NhanVien
 (
  MaNV varchar(10) primary key not null,
  TenNV varchar(40),
  SoDT char(10),
  GioiTinh varchar(5),
  DiaChi varchar(45),
  NgSinh datetime,
  NgVaoLam datetime,
  MaLoaiNhanVien varchar(10) references LoaiNhanVien(MaLoaiNhanVien), /*Nhan vien co the la bac si, thu ngan, thu kho*/
)

create table PKB (
MaPKB varchar(10) primary key not null,
MaBN varchar(10) foreign key references BenhNhan(MaBN) not null,
MaNV varchar(10) foreign key references NhanVien(MaNV) not null,
NgayKham datetime not null,
ChuanDoan nvarchar(max)
)

 -----------------------------INSERT NHANVIEN-------------------------------------------------

 Insert into NHANVIEN values ('NV001','Nguyen Van A','0918359847','Nam','Q7, Tp.Ho Chi Minh','15-2-1987','01-01-2020','3')
 Insert into NHANVIEN values ('NV002','Nguyen Thi Lanh','0918359877','Nu','P5, Vung Tau','17-8-1985','01-01-2020','3')

 Insert into NHANVIEN values ('NV003','Nguyen Tien Truong','0918359847','Nam','Q7, Tp.Ho Chi Minh','15-2-1987','01-01-2020','2')
 Insert into NHANVIEN values ('NV004','Tran Minh Chien','0948975485','Nam','Q73, Tp.Ho Chi Minh','8-9-1975','01-01-2020','2')
 Insert into NHANVIEN values ('NV005','Trinh Chung Cuong','0915145145','Nam','Q76, Tp.Ho Chi Minh','22-8-1969','01-01-2020','2')

 -------------------------------------------------------------------------------------

 create table Thuoc
(
  MaThuoc varchar(10) primary key not null,
  TenThuoc varchar(45),
  SoLuong int,
  NSX datetime,
  HSD datetime,
  NCC varchar(45),
  Gia money,
)

---------------------------------------INSERT THUOC---------------------------------------------

Insert into Thuoc values ('TH001','Amoxcillin','60','11-1-2019','11-1-2030','Coopmart','25000')
Insert into Thuoc values ('TH002','Ampicillin','80','11-3-2019','11-1-2030','Coopmart','25000')
Insert into Thuoc values ('TH003','Cefalexin','80','20-01-2019','20-1-2030','Vinmart','27000')
Insert into Thuoc values ('TH004',' Cefadroxin 500mg','80','01-01-2020','01-1-2030','Vinmart','35000')
Insert into Thuoc values ('TH005','Augmentin 625mg','60','01-01-2020','01-1-2030','Vinmart','30000')
Insert into Thuoc values ('TH006','Klamentin 625mg','60','01-01-2020','01-1-2030','Hogward','30000')
Insert into Thuoc values ('TH007','Azithromycin 250mg','90','11-1-2019','11-1-2030','Hogward','45000')
Insert into Thuoc values ('TH008','Clarythromycin 250mg','80','11-1-2019','11-1-2030','Hogward','120000')
Insert into Thuoc values ('TH009','Cefpodoxim 100mg','80','11-1-2019','11-1-2030','Hogward','20000')
Insert into Thuoc values ('TH010','Augmentin 1g','80','11-1-2019','11-1-2030','Coopmart','20000')




----------------------------------------------------------------------------------
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
Gia money,
)

create table DonThuoc
(
 MaDT varchar(10) primary key not null,
 MaThuoc varchar(10) not null references Thuoc(MaThuoc),
 TenThuoc varchar(45),
 SoLuong int,
 MaNV varchar(10) references NhanVien(MaNV),
 MaBN varchar(10) references BenhNhan(MaBN),
)

create table HoaDon
(
 MaHD varchar(10) primary key not null,
 MaDT varchar(10) references DonThuoc(MaDT),
 NgHD datetime,
 TriGia money,
)

create table CTHD
( 
 MaHD varchar(10) references HoaDon(MaHD),
 MADT varchar(10) references DonThuoc(MaDT),
 SL int,
)

-------------------------------------------------------------------------------------
INSERT INTO Dangnhap
 VALUES('ADMIN','ADMIN',1)
 /*------------------------------------- Tai khoan Tiep tan*/
INSERT INTO Dangnhap
 VALUES('tt0001','1',3)
 INSERT INTO Dangnhap
 VALUES('tt0002','1',3)
 INSERT INTO Dangnhap
 VALUES('tt0003','1',3)
  /*------------------------------------- Tai khoan Bac si*/
 INSERT INTO Dangnhap
 VALUES('bs0001','1',2)
 INSERT INTO Dangnhap
 VALUES('bs0002','1',2)
 INSERT INTO Dangnhap
 VALUES('bs0003','1',2)
  /*------------------------------------- Tai khoan Thu kho*/
 INSERT INTO Dangnhap
 VALUES('tk0001','1',4)
 INSERT INTO Dangnhap
 VALUES('tk0001','1',4)
 INSERT INTO Dangnhap
 VALUES('tk0001','1',4)


 /*----------------------------------------------------------------------*/


 SELECT * FROM BenhNhan

 SELECT * FROM Thuoc

 SELECT * FROM BenhNhan WHERE GioiTinh = 'Nam'