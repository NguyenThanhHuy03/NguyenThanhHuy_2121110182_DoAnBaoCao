CREATE DATABASE QLBH
GO

USE QLBH
GO

CREATE TABLE tblChatLieu
(
    MaChatLieu NVARCHAR(50) PRIMARY KEY,
    TenChatLieu NVARCHAR(100)
)
GO

CREATE TABLE tblHang
(
    MaHang NVARCHAR(50) PRIMARY KEY,
    TenHang NVARCHAR(100),
    MaChatLieu NVARCHAR(50),
    SoLuong INT,
    DonGiaNhap NVARCHAR(20),
    DonGiaBan NVARCHAR(20),
    Anh NVARCHAR(255),
    GhiChu NVARCHAR(255)
)
GO

CREATE TABLE tblHDBan
(
    MaHDBan NVARCHAR(50) PRIMARY KEY,
    MaNhanVien NVARCHAR(50),
    NgayBan DATETIME,
    MaKhach NVARCHAR(50),
    TenKhach NVARCHAR(100),
    MaHang NVARCHAR(50),
    TenHang NVARCHAR(100),
    SoLuong INT,
    ThanhTien NVARCHAR(20)
)
GO

CREATE TABLE tblKhach (
    MaKhach NVARCHAR(50) PRIMARY KEY,
    TenKhach NVARCHAR(100),
    DiaChi NVARCHAR(100),
    DienThoai NVARCHAR(20)
);
GO

CREATE TABLE tblNhanVien (
    MaNhanVien NVARCHAR(50) PRIMARY KEY,
    TenNhanVien NVARCHAR(100),
    GioiTinh BIT,
    DiaChi NVARCHAR(100),
    DienThoai NVARCHAR(20),
    NgaySinh DATETIME
);
GO


CREATE TABLE Users
(
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(50)
);
GO

CREATE TABLE tblThuongHieu
(
	MaThuongHieu NVARCHAR(50) PRIMARY KEY,
    TenThuongHieu NVARCHAR(100),
	GhiChu NVARCHAR(255),
	Anh NVARCHAR(255)
)
GO

