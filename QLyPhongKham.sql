create database QLPhongKham
use QLPhongKham
go 
create table Dangnhap
(
 taikhoan varchar(45),
 matkhau varchar(45),
 )
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
 create table LoaiNhanVien
 (
  MaLoaiNhanVien varchar(10) primary key not null,
  TenLoaiNhanVien varchar(45),
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
  MaLoaiNhanVien varchar(10) references LoaiNhanVien(MaLoaiNhanVien), /*Nhan vien co the la bac si, thu ngan, thu kho*/
 )
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
create table DonThuoc
(
 MaDT varchar(10) primary key not null,
 MaThuoc varchar(10),
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
INSERT INTO Dangnhap(taikhoan,matkhau)
 VALUES('ADMIN','ADMIN')