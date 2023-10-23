CREATE DATABASE QLQCF
GO
USE QLQCF
GO
CREATE TABLE NGUOIDUNG
( TAIKHOAN NVARCHAR(50) PRIMARY KEY,
  MATKHAU NVARCHAR(50) not null,
  CHUCDANH NVARCHAR(50) not null)
GO
CREATE TABLE NHANVIEN
( MANV NVARCHAR(50) PRIMARY KEY,
  TENNV NVARCHAR(50),
  NGAYSINH DATE,
  GIOITINH NVARCHAR(50),
  DIACHI NVARCHAR(50),
  SDT NVARCHAR(50),
  LUONG FLOAT,
  ANHNV NVARCHAR(50))
GO
CREATE TABLE NHACUNGCAP
( MANCC NVARCHAR(50) PRIMARY KEY,
  TENNCC NVARCHAR(100),
  DIACHI NVARCHAR(50),
  SDT NVARCHAR(50))
GO
CREATE TABLE KHACHHANG
( ID NVARCHAR(50) PRIMARY KEY,
  TENKH NVARCHAR(50),
  DIACHI NVARCHAR(50),
  SDT NVARCHAR(50),
  ANHKH NVARCHAR(50))
GO
CREATE TABLE HANG
(MAHANG NVARCHAR(50) PRIMARY KEY,
 TENHANG NVARCHAR(100),
 SOLUONG int,
 HSD DATE,
 DONVITINH NVARCHAR(50),
 DONGIA FLOAT)
GO
CREATE TABLE PHIEUNHAP
	  ( MAPHIEUNHAP NVARCHAR(50) PRIMARY KEY,
	  MANCC NVARCHAR(50) FOREIGN KEY REFERENCES NHACUNGCAP(MANCC),
	  MANV NVARCHAR(50) FOREIGN KEY REFERENCES NHANVIEN(MANV),
	  NGAYNHAP DATE,
	  TONGTIEN FLOAT)
GO
 CREATE TABLE CHITIETPHIEUNHAP
	   (MAPHIEUNHAP NVARCHAR(50) FOREIGN KEY (MAPHIEUNHAP) REFERENCES PHIEUNHAP(MAPHIEUNHAP),
		MAHANG NVARCHAR(50) FOREIGN KEY REFERENCES HANG(MAHANG),
		PRIMARY KEY (MAPHIEUNHAP,MAHANG),
	    SOLUONG INT)
GO
CREATE TABLE PHIEUXUAT
	  ( MAPHIEUXUAT NVARCHAR(50) primary key,
	   MANV NVARCHAR(50) FOREIGN KEY REFERENCES NHANVIEN(MANV),
	   NGAYXUAT DATE)
GO
CREATE TABLE CHITIETPHIEUXUAT
( MAPHIEUXUAT NVARCHAR(50) FOREIGN KEY REFERENCES PHIEUXUAT(MAPHIEUXUAT),
  MAHANG NVARCHAR(50) FOREIGN KEY REFERENCES HANG(MAHANG),
  SOLUONG INT,
  primary key (MAPHIEUXUAT,MAHANG))
GO
CREATE TABLE SANPHAM
	( MASP NVARCHAR(50) PRIMARY KEY,
	TENSP NVARCHAR(100),
	MOTA NVARCHAR(50),
	DONGIA FLOAT,
	ANHSP NVARCHAR(50))
GO
 CREATE TABLE HOADON
	 ( MAHD NVARCHAR(50) PRIMARY KEY,
	  MANV NVARCHAR(50) FOREIGN KEY REFERENCES NHANVIEN(MANV),
	  NGAYLAP DATE,
	  THANHTIEN FLOAT)
GO
CREATE TABLE CHITIETHOADON
	 (MAHD NVARCHAR(50) FOREIGN KEY REFERENCES HOADON(MAHD),
	 MASP NVARCHAR(50) FOREIGN KEY REFERENCES SANPHAM(MASP),
	 SOLUONG INT,
	 GIATIEN FLOAT,
	 primary key (MAHD,MASP))
GO
CREATE TABLE DONHANG
( MADH NVARCHAR(50) PRIMARY KEY,
  ID NVARCHAR(50) FOREIGN KEY REFERENCES KHACHHANG(ID),
  NGAYDAT DATE,
  TONGTIENTT FLOAT)
GO 
CREATE TABLE CHITIETDONHANG
(MADH NVARCHAR(50) FOREIGN KEY REFERENCES DONHANG(MADH),
 MASP NVARCHAR(50) FOREIGN KEY REFERENCES SANPHAM(MASP),
 SOLUONG INT,
 GIATIEN FLOAT
 PRIMARY KEY (MADH,MASP))