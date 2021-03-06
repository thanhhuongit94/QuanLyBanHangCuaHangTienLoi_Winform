CREATE database [QuanLyCuaHangCoffee]
go
USE [QuanLyCuaHangCoffee]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[maLoai] [nvarchar](50) NOT NULL,
	[tenLoai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tenLoai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[levelUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateLoaiSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------USER----------------------------------------------------
----Lay toan bo du lieu bang Users
--CREATE PROCEDURE  sp_SelectAllUsers
--AS
--BEGIN
--	SELECT * FROM dbo.Users;
--END
--exec sp_SelectAllUsers

----Lay 1 user theo dieu kien
--CREATE PROCEDURE  sp_SelectOneUser(
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username AND password = @password AND levelUser = @levelUser;
--END
--exec sp_SelectOneUser 'huongntt', '123456', 1;

----Tim kiem 1 user theo username
--CREATE PROC sp_SearchUserByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username;
--END

--Insert du lieu vao bang Users
--CREATE PROCEDURE sp_InsertUsers (
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM dbo.Users WHERE username = @username)
--	BEGIN
--		INSERT INTO dbo.Users(username, password, levelUser) VALUES(@username, @password, 2); 
--	END
--END

----Update du lieu vao bang Users(Chi duoc update password)
--CREATE PROCEDURE sp_UpdateUser( 
-- @username nvarchar(50),
--	@password nvarchar(20)
--)
--AS
--BEGIN
--		UPDATE dbo.UserS SET password = @password WHERE username = @username;
--END

----Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin)
--CREATE PROCEDURE sp_DeleteUser( 
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
--END

----Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin va tai khoan cua 1 nhan vien nao do dang co o trong danh sach)
--CREATE PROCEDURE sp_DeleteUserNoEmpoyee( 
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF not exists(SELECT * FROM dbo.NhanVien WHERE username = @username)
--	BEGIN
--	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
--	END
--END


-------------------------------------------NHANVIEN----------------------------------------------------

----Lay het danh sach nhan vien
--CREATE PROC sp_SelectAllNhanVien
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien ORDER BY maNV ASC;
--END

----Tim 1 nhan vien theo CMND
--CREATE PROC sp_SelectOneNhanVienByCMND(
--	@CMND nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE CMND = @CMND;
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV = @maNV;
--END

----Tim 1 nhan vien theo dia chi
--CREATE PROC sp_SelectNhanVienByAddress(
--	@diaChi nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE diaChi LIKE '%' +  @diaChi + '%';
--END

----Insert du lieu vao bang NhanVien
--CREATE PROC sp_InsertNhanVien(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12),
--	@heSoLuong float,
--	@luongCB float,
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.NhanVien WHERE CMND = @CMND)
--	BEGIN
--		INSERT INTO dbo.NhanVien (maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username) 
--				VALUES (@maNV, @tenNV, @gioiTinh, @CMND, @diaChi, @SDT, @heSoLuong, @luongCB, @username);
--	END
--END

----Update du lieu bang NhanVien
--CREATE PROC sp_UpdateNhanVien(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12),
--	@heSoLuong float,
--	@luongCB float
--)
--AS
--BEGIN
--		UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT, heSoLuong = @heSoLuong, luongCB = @luongCB WHERE maNV = @maNV;
--END

----Delete du lieu cua nhan vien theo ma nhan vien
--CREATE PROC sp_DeleteNhanVien (
--	@maNV nvarchar(50) 
--)
--AS
--BEGIN
--	DELETE FROM dbo.NhanVien WHERE maNV = @maNV;
--END

----Tim 1 nhan vien theo ten nhan vien
--CREATE PROC sp_SelectNhanVienByLIKEtenNV(
--	@tenNV nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE tenNV LIKE '%' +  @tenNV + '%';
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienLIKEMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV LIKE '%' + @maNV + '%';
--END

----Tim 1 nhan vien theo username 
--CREATE PROC sp_SearchNhanVienByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE username = @username;
--END

------Update du lieu NhanVien khong cho phep update hesoluong, luong co ban
--CREATE PROC sp_UpdateNhanVienLoaiTruLuongCB_HSLuong(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12)
--)
--AS
--BEGIN
--	UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT WHERE maNV = @maNV;
--END
-------------------------------------------LOAISANPHAM----------------------------------------------------
----Lay toan bo du lieu bang LoaiSanPham
--CREATE PROC sp_SelectAllLoaiSanPham
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham;
--END

----Tim 1 LoaiSanPham theo MALOAI
--CREATE PROC sp_SearchLoaiSanPhamByID (
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE maLoai = @maLoai;
--END

----Tim 1 LoaiSanPham theo TENLOAI
--CREATE PROC sp_SearchLoaiSPByName (
--	@tenLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE tenLoai = @tenLoai;
--END

----Insert du lieu vao bang LoaiSanPham
--CREATE PROC sp_InsertLoaiSanPham(
--	@maLoai nvarchar(50),
--	@tenLoai nvarchar(50)
--)
--AS 
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.LoaiSanPham WHERE maLoai = @maLoai OR tenLoai = @tenLoai)
--	BEGIN
--		INSERT INTO dbo.LoaiSanPham (maLoai, tenLoai) VALUES (@maLoai, @tenLoai);
--	END
--END

--Update du lieu vao bang LoaiSanPham
CREATE PROC [dbo].[sp_UpdateLoaiSanPham](
	@maLoai nvarchar(50),
	@tenLoai nvarchar(50)
)
AS 
BEGIN
		UPDATE dbo.LoaiSanPham SET maLoai = @maLoai, tenLoai = @tenLoai WHERE maLoai = @maLoai;
END

----Delete du lieu trong bang LoaiSanPham
--CREATE PROC sp_DeleteLoaiSanPham(
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN 
--	IF NOT EXISTS(SELECT * FROM SanPham WHERE maLoaiSP = @maLoai)
--	BEGIN
--		DELETE FROM dbo.LoaiSanPham WHERE maLoai = @maLoai;
--	END
--END

--Sap xep danh sach loai san pham tang dan theo ma loai
--CREATE PROC sp_SortLoaiSanPhamByMaLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY maLoai ASC
--END

----Sap xep danh sach loai san pham tang dan theo ten loai
--CREATE PROC sp_SortLoaiSanPhamByTenLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY tenLoai ASC
--END

-------------------------------------------SANPHAM----------------------------------------------------
----TAO PROCEDURE CHO BANG SAN PHAM
----Lay tat ca du lieu trong bang SanPham
--CREATE PROC sp_SelectAllSanPham
--AS
--BEGIN
--	SELECT * FROM SanPham;
--END

----Tim 1 san pham theo MASANPHAM
--CREATE PROC sp_SearchSanPhamByID
--(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE maSP = @maSP;
--END

----Tim 1 san pham theo TENSANPHAM
--CREATE PROC sp_SearchSanPhamByName
--(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE tenSP = @tenSP;
--END

----Insert du lieu vao bang SANPHAM
--CREATE PROC sp_InsertSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE maSP = @maSP OR tenSP = @tenSP)
--	BEGIN
--		INSERT INTO dbo.SanPham (maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES (@maSP, @tenSP, @donGia, @soLuong, @tinhTrang, @maLoaiSP);
--	END
--END

----Update du lieu cho bang SANPHAM
--CREATE PROC sp_UpdateSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE tenSP = @tenSP)
--	BEGIN
--		UPDATE dbo.SanPham SET maSP = @maSP, tenSP = @tenSP, donGia = @donGia, soLuong = @soLuong, tinhTrang = @tinhTrang, maLoaiSP = @maLoaiSP WHERE maSP = @maSP;
--	END
--END

----Delete du lieu bang SanPham bang ma san pham
--CREATE PROC sp_DeleteSanPham(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.SanPham WHERE maSP = @maSP;
--END

--Delete du lieu bang SanPham theo ma loai san pham
--CREATE PROC sp_DeleteSanPhamByMaLoai(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Sap xep danh sach tang dan theo ma san pham
--CREATE PROC sp_SortSanPhamASCByMaSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY maSP ASC;
--END
--EXEC sp_SortSanPhamASCByMaSP;

----Sap xep danh sach tang dan theo ten san pham
--CREATE PROC sp_SortSanPhamASCByTenSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY tenSP ASC;
--END
--EXEC sp_SortSanPhamASCByTenSP;

--Search san pham co ten san pham dung LIKE
--CREATE PROC sp_SearchSanPhamByLikeProduct_name(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE tenSP LIKE '%' + @tenSP+ '%';
--END
--EXEC sp_SearchSanPhamByLikeProduct_name 'Coffee'

----Tim san pham theo ma loai san pham
--CREATE PROC sp_SearchSanPhamByMaLoaiSP(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Update du lieu cho bang SANPHAM(chi update so luong)
--CREATE PROC sp_UpdateSoLuongSanPham
--(
--	@maSP nvarchar(50),
--	@soLuong int
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET soLuong = @soLuong WHERE maSP = @maSP;
--END

----Update du lieu cho bang SANPHAM(chi update tinh trang)
--CREATE PROC sp_UpdateTinhTrangSanPham
--(
--	@maSP nvarchar(50),
--	@tinhTrang nvarchar(70)
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET tinhTrang = @tinhTrang WHERE maSP = @maSP;
--END
-------------------------------------------HOADON----------------------------------------------------
----Lay tat ca ca hoa don
--CREATE PROC sp_SelectAllHoaDon
--AS
--BEGIN
--	SELECT * FROM dbo.HoaDon;
--END

----Lay hoa don co tong tien bang 0
--CREATE PROC sp_SearchHoaDonByTongTien
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien = 0;
--END

----Lay hoa don theo ma nhan vien
--CREATE PROC sp_SelectHoaDonByMaNV(
	--@maNV nvarchar(50);
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Insert Hoa don
--CREATE PROC sp_InsertHoaDon(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	INSERT INTO dbo.HoaDon (maNV, tongTien) VALUES (@maNV, 0);
--END

----Update Hoa don
--CREATE PROC sp_UpdateHoaDon(
--	@maHD int,
--	@maNV nvarchar(50),
--	@tongTien float
--)
--AS
--BEGIN
--	UPDATE dbo.HoaDon SET maNV = @maNV , tongTien = @tongTien WHERE maHD = @maHD;
--END

----Search hoa don theo ma nhan vien
--CREATE PROC sp_SearchHoaDonByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Tim hoa don co tong tien > 0
--CREATE PROC sp_SearchHoaDonTongTienLonHon_0
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien != 0;
--END

----Tim hoa don bang ma hoa don
--CREATE PROC sp_SearchHoaDonByMaHD(
--	@maHD int
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maHD = @maHD;
--END
-------------------------------------------CHITIETHOADON----------------------------------------------------
----Lay cac chi tiet hoa don theo MAHOADON
--CREATE PROC sp_SelectChiTietHDByInvoiceID
--(
--	@maHD int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.ChiTietHoaDon WHERE maHD = @maHD;
--END

--Insert du lieu vao bang ChiTietHoaDon
--CREATE PROC sp_InsertChiTietHD
--(
--	@maHD int,
--	@maSP nvarchar(50),
--	@donGia float,
--	@soLuong int,
--	@thanhTien float
--)
--AS
--BEGIN
--	INSERT INTO dbo.ChiTietHoaDon (maHD, maSP, donGia, soLuong, thanhTien) VALUES (@maHD, @maSP, @donGia, @soLuong, @thanhTien);
--END

----Update du lieu bang ChiTietHoaDon
--CREATE PROC sp_UpdateChiTietHD
--(
--	@maHD int,
--	@maSP nvarchar(50),
--	@soLuong int,
--	@thanhTien float
--)
--AS
--BEGIN
--	UPDATE dbo.ChiTietHoaDon SET soLuong = @soLuong, thanhTien = @thanhTien WHERE maHD = @maHD AND maSP = @maSP;
--END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Update du lieu vao bang Users(Chi duoc update password)
CREATE PROCEDURE [dbo].[sp_UpdateUser]( 
 @username nvarchar(50),
	@password nvarchar(20)
)
AS
BEGIN
		UPDATE dbo.UserS SET password = @password WHERE username = @username;
END
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[maSP] [nvarchar](50) NOT NULL,
	[tenSP] [nvarchar](100) NOT NULL,
	[donGia] [float] NOT NULL,
	[soLuong] [int] NOT NULL,
	[tinhTrang] [nvarchar](70) NOT NULL,
	[maLoaiSP] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tenSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNV] [nvarchar](50) NOT NULL,
	[tenNV] [nvarchar](100) NOT NULL,
	[gioiTinh] [varchar](3) NOT NULL,
	[CMND] [nvarchar](50) NOT NULL,
	[diaChi] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](12) NULL,
	[heSoLuong] [float] NOT NULL,
	[luongCB] [float] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchLoaiSPByName]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 LoaiSanPham theo TENLOAI
CREATE PROC [dbo].[sp_SearchLoaiSPByName] (
	@tenLoai nvarchar(50)
)
AS
BEGIN
	SELECT * FROM LoaiSanPham WHERE tenLoai = @tenLoai;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchLoaiSanPhamByID]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SearchLoaiSanPhamByID] (
	@maLoai nvarchar(50)
)
AS
BEGIN
	SELECT * FROM LoaiSanPham WHERE maLoai = @maLoai;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchUserByUsername]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim kiem 1 user theo username
CREATE PROC [dbo].[sp_SearchUserByUsername](
	@username nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.Users WHERE username = @username;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLoaiSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_InsertLoaiSanPham](
	@maLoai nvarchar(50),
	@tenLoai nvarchar(50)
)
AS 
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.LoaiSanPham WHERE maLoai = @maLoai OR tenLoai = @tenLoai)
	BEGIN
		INSERT INTO dbo.LoaiSanPham (maLoai, tenLoai) VALUES (@maLoai, @tenLoai);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllLoaiSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SelectAllLoaiSanPham]
AS
BEGIN
	SELECT * FROM LoaiSanPham;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUsers]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUsers] (
	@username nvarchar(50),
	@password nvarchar(20),
	@levelUser int
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dbo.Users WHERE username = @username)
	BEGIN
		INSERT INTO dbo.Users(username, password, levelUser) VALUES(@username, @password, 2); 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllUsers]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[sp_SelectAllUsers]
AS
BEGIN
	SELECT * FROM dbo.Users;
END
exec sp_SelectAllUsers
GO
/****** Object:  StoredProcedure [dbo].[sp_SortLoaiSanPhamByTenLoai]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sap xep danh sach loai san pham tang dan theo ten loai
CREATE PROC [dbo].[sp_SortLoaiSanPhamByTenLoai]
AS
BEGIN 
	SELECT * FROM LoaiSanPham ORDER BY tenLoai ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SortLoaiSanPhamByMaLoai]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SortLoaiSanPhamByMaLoai]
AS
BEGIN 
	SELECT * FROM LoaiSanPham ORDER BY maLoai ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectOneUser]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lay 1 user theo dieu kien
CREATE PROCEDURE  [dbo].[sp_SelectOneUser](
	@username nvarchar(50),
	@password nvarchar(20),
	@levelUser int
)
AS
BEGIN
	SELECT * FROM dbo.Users WHERE username = @username AND password = @password AND levelUser = @levelUser;
END
exec sp_SelectOneUser 'huongntt', '123456', 1;
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectOneNhanVienByCMND]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo CMND
CREATE PROC [dbo].[sp_SelectOneNhanVienByCMND](
	@CMND nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE CMND = @CMND;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectNhanVienLIKEMaNV]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo MaNV
CREATE PROC [dbo].[sp_SelectNhanVienLIKEMaNV](
	@maNV nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE maNV LIKE '%' + @maNV + '%';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectNhanVienByMaNV]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo MaNV
CREATE PROC [dbo].[sp_SelectNhanVienByMaNV](
	@maNV nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE maNV = @maNV AND maNV != 'Admin';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectNhanVienByLIKEtenNV]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo ten nhan vien
CREATE PROC [dbo].[sp_SelectNhanVienByLIKEtenNV](
	@tenNV nvarchar(100)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE tenNV LIKE '%' +  @tenNV + '%';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectNhanVienByAddress]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo dia chi
CREATE PROC [dbo].[sp_SelectNhanVienByAddress](
	@diaChi nvarchar(100)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE diaChi LIKE '%' +  @diaChi + '%';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SortSanPhamASCByTenSP]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sap xep danh sach tang dan theo ten san pham
CREATE PROC [dbo].[sp_SortSanPhamASCByTenSP]
AS
BEGIN
	SELECT * FROM dbo.SanPham ORDER BY tenSP ASC;
END
EXEC sp_SortSanPhamASCByTenSP;
GO
/****** Object:  StoredProcedure [dbo].[sp_SortSanPhamASCByMaSP]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Sap xep danh sach tang dan theo ma san pham
CREATE PROC [dbo].[sp_SortSanPhamASCByMaSP]
AS
BEGIN
	SELECT * FROM dbo.SanPham ORDER BY maSP ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SelectAllSanPham]
AS
BEGIN
	SELECT * FROM SanPham;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllNhanVien]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lay het danh sach nhan vien
CREATE PROC [dbo].[sp_SelectAllNhanVien]
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE maNV != 'Admin' ORDER BY maNV ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_InsertSanPham]
(
	@maSP nvarchar(50),
	@tenSP nvarchar(100),
	@donGia float,
	@soLuong int,
	@tinhTrang nvarchar(70),
	@maLoaiSP nvarchar(50)
)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE maSP = @maSP OR tenSP = @tenSP)
	BEGIN
		INSERT INTO dbo.SanPham (maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES (@maSP, @tenSP, @donGia, @soLuong, @tinhTrang, @maLoaiSP);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNhanVien]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_InsertNhanVien](
	@maNV nvarchar(50),
	@tenNV nvarchar(100),
	@gioiTinh nvarchar(3),
	@CMND nvarchar(50),
	@diaChi nvarchar(100),
	@SDT nvarchar(12),
	@heSoLuong float,
	@luongCB float,
	@username nvarchar(50)
)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.NhanVien WHERE CMND = @CMND)
	BEGIN
		INSERT INTO dbo.NhanVien (maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username) 
				VALUES (@maNV, @tenNV, @gioiTinh, @CMND, @diaChi, @SDT, @heSoLuong, @luongCB, @username);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin va khong duoc xoa user cua nhan vien dang ton tai)
CREATE PROCEDURE [dbo].[sp_DeleteUser]( 
	@username nvarchar(50)
)
AS
BEGIN
	IF not exists(SELECT * FROM dbo.NhanVien WHERE username = @username)
	BEGIN
	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSanPhamByMaLoai]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DeleteSanPhamByMaLoai](
	@maLoaiSP nvarchar(50)
)
AS
BEGIN
	DELETE FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteNhanVien]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete du lieu cua nhan vien theo ma nhan vien
CREATE PROC [dbo].[sp_DeleteNhanVien] (
	@maNV nvarchar(50) 
)
AS
BEGIN
	DELETE FROM dbo.NhanVien WHERE maNV = @maNV;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteLoaiSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DeleteLoaiSanPham](
	@maLoai nvarchar(50)
)
AS
BEGIN 
	IF NOT EXISTS(SELECT * FROM SanPham WHERE maLoaiSP = @maLoai)
	BEGIN
		DELETE FROM dbo.LoaiSanPham WHERE maLoai = @maLoai;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchSanPhamByName]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SearchSanPhamByName]
(
	@tenSP nvarchar(100)
)
AS
BEGIN
	SELECT * FROM SanPham WHERE tenSP = @tenSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchSanPhamByMaLoaiSP]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim san pham theo ma loai san pham
CREATE PROC [dbo].[sp_SearchSanPhamByMaLoaiSP](
	@maLoaiSP nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchSanPhamByLikeProduct_name]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SearchSanPhamByLikeProduct_name](
	@tenSP nvarchar(100)
)
AS
BEGIN
	SELECT * FROM dbo.SanPham WHERE tenSP LIKE '%' + @tenSP+ '%';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchSanPhamByID]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SearchSanPhamByID]
(
	@maSP nvarchar(50)
)
AS
BEGIN
	SELECT * FROM SanPham WHERE maSP = @maSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchNhanVienByUsername]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim 1 nhan vien theo username 
CREATE PROC [dbo].[sp_SearchNhanVienByUsername](
	@username nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.NhanVien WHERE username = @username;
END
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[maHD] [int] IDENTITY(1,1) NOT NULL,
	[maNV] [nvarchar](50) NULL,
	[tongTien] [float] NOT NULL,
	[ngayLapHD] [datetime] NULL,
	[ghiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTinhTrangSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Update du lieu cho bang SANPHAM(chi update tinh trang)
CREATE PROC [dbo].[sp_UpdateTinhTrangSanPham]
(
	@maSP nvarchar(50),
	@tinhTrang nvarchar(70)
)
AS
BEGIN
	UPDATE dbo.SanPham SET tinhTrang = @tinhTrang WHERE maSP = @maSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSoLuongSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Update du lieu cho bang SANPHAM(chi update so luong)
CREATE PROC [dbo].[sp_UpdateSoLuongSanPham]
(
	@maSP nvarchar(50),
	@soLuong int
)
AS
BEGIN
	UPDATE dbo.SanPham SET soLuong = @soLuong WHERE maSP = @maSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_UpdateSanPham]
(
	@maSP nvarchar(50),
	@tenSP nvarchar(100),
	@donGia float,
	@soLuong int,
	@tinhTrang nvarchar(70),
	@maLoaiSP nvarchar(50)
)
AS
BEGIN

		UPDATE dbo.SanPham SET maSP = @maSP, tenSP = @tenSP, donGia = @donGia, soLuong = @soLuong, tinhTrang = @tinhTrang, maLoaiSP = @maLoaiSP WHERE maSP = @maSP;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateNhanVienLoaiTruLuongCB_HSLuong]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----Update du lieu NhanVien khong cho phep update hesoluong, luong co ban
CREATE PROC [dbo].[sp_UpdateNhanVienLoaiTruLuongCB_HSLuong](
	@maNV nvarchar(50),
	@tenNV nvarchar(100),
	@gioiTinh nvarchar(3),
	@CMND nvarchar(50),
	@diaChi nvarchar(100),
	@SDT nvarchar(12)
)
AS
BEGIN
	UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT WHERE maNV = @maNV;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateNhanVien]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------USER----------------------------------------------------
----Lay toan bo du lieu bang Users
--CREATE PROCEDURE  sp_SelectAllUsers
--AS
--BEGIN
--	SELECT * FROM dbo.Users;
--END
--exec sp_SelectAllUsers

----Lay 1 user theo dieu kien
--CREATE PROCEDURE  sp_SelectOneUser(
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username AND password = @password AND levelUser = @levelUser;
--END
--exec sp_SelectOneUser 'huongntt', '123456', 1;

----Tim kiem 1 user theo username
--CREATE PROC sp_SearchUserByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username;
--END

--Insert du lieu vao bang Users
--CREATE PROCEDURE sp_InsertUsers (
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM dbo.Users WHERE username = @username)
--	BEGIN
--		INSERT INTO dbo.Users(username, password, levelUser) VALUES(@username, @password, 2); 
--	END
--END

----Update du lieu vao bang Users(Chi duoc update password)
--CREATE PROCEDURE sp_UpdateUser( 
-- @username nvarchar(50),
--	@password nvarchar(20)
--)
--AS
--BEGIN
--		UPDATE dbo.UserS SET password = @password WHERE username = @username;
--END

----Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin)
--CREATE PROCEDURE sp_DeleteUser( 
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
--END

----Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin va tai khoan cua 1 nhan vien nao do dang co o trong danh sach)
--CREATE PROCEDURE sp_DeleteUserNoEmpoyee( 
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF not exists(SELECT * FROM dbo.NhanVien WHERE username = @username)
--	BEGIN
--	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
--	END
--END


-------------------------------------------NHANVIEN----------------------------------------------------

----Lay het danh sach nhan vien
--CREATE PROC sp_SelectAllNhanVien
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien ORDER BY maNV ASC;
--END

----Tim 1 nhan vien theo CMND
--CREATE PROC sp_SelectOneNhanVienByCMND(
--	@CMND nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE CMND = @CMND;
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV = @maNV;
--END

----Tim 1 nhan vien theo dia chi
--CREATE PROC sp_SelectNhanVienByAddress(
--	@diaChi nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE diaChi LIKE '%' +  @diaChi + '%';
--END

----Insert du lieu vao bang NhanVien
--CREATE PROC sp_InsertNhanVien(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12),
--	@heSoLuong float,
--	@luongCB float,
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.NhanVien WHERE CMND = @CMND)
--	BEGIN
--		INSERT INTO dbo.NhanVien (maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username) 
--				VALUES (@maNV, @tenNV, @gioiTinh, @CMND, @diaChi, @SDT, @heSoLuong, @luongCB, @username);
--	END
--END

--Update du lieu bang NhanVien
CREATE PROC [dbo].[sp_UpdateNhanVien](
	@maNV nvarchar(50),
	@tenNV nvarchar(100),
	@gioiTinh nvarchar(3),
	@CMND nvarchar(50),
	@diaChi nvarchar(100),
	@SDT nvarchar(12),
	@heSoLuong float,
	@luongCB float
)
AS
BEGIN
		UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT, heSoLuong = @heSoLuong, luongCB = @luongCB WHERE maNV = @maNV;
END

----Delete du lieu cua nhan vien theo ma nhan vien
--CREATE PROC sp_DeleteNhanVien (
--	@maNV nvarchar(50) 
--)
--AS
--BEGIN
--	DELETE FROM dbo.NhanVien WHERE maNV = @maNV;
--END

----Tim 1 nhan vien theo ten nhan vien
--CREATE PROC sp_SelectNhanVienByLIKEtenNV(
--	@tenNV nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE tenNV LIKE '%' +  @tenNV + '%';
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienLIKEMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV LIKE '%' + @maNV + '%';
--END

----Tim 1 nhan vien theo username 
--CREATE PROC sp_SearchNhanVienByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE username = @username;
--END

------Update du lieu NhanVien khong cho phep update hesoluong, luong co ban
--CREATE PROC sp_UpdateNhanVienLoaiTruLuongCB_HSLuong(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12)
--)
--AS
--BEGIN
--	UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT WHERE maNV = @maNV;
--END
-------------------------------------------LOAISANPHAM----------------------------------------------------
----Lay toan bo du lieu bang LoaiSanPham
--CREATE PROC sp_SelectAllLoaiSanPham
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham;
--END

----Tim 1 LoaiSanPham theo MALOAI
--CREATE PROC sp_SearchLoaiSanPhamByID (
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE maLoai = @maLoai;
--END

----Tim 1 LoaiSanPham theo TENLOAI
--CREATE PROC sp_SearchLoaiSPByName (
--	@tenLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE tenLoai = @tenLoai;
--END

----Insert du lieu vao bang LoaiSanPham
--CREATE PROC sp_InsertLoaiSanPham(
--	@maLoai nvarchar(50),
--	@tenLoai nvarchar(50)
--)
--AS 
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.LoaiSanPham WHERE maLoai = @maLoai OR tenLoai = @tenLoai)
--	BEGIN
--		INSERT INTO dbo.LoaiSanPham (maLoai, tenLoai) VALUES (@maLoai, @tenLoai);
--	END
--END

----Update du lieu vao bang LoaiSanPham
--CREATE PROC sp_UpdateLoaiSanPham(
--	@maLoai nvarchar(50),
--	@tenLoai nvarchar(50)
--)
--AS 
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.LoaiSanPham WHERE tenLoai = @tenLoai)
--	BEGIN
--		UPDATE dbo.LoaiSanPham SET maLoai = @maLoai, tenLoai = @tenLoai WHERE maLoai = @maLoai;
--	END
--END

----Delete du lieu trong bang LoaiSanPham
--CREATE PROC sp_DeleteLoaiSanPham(
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN 
--	DELETE FROM dbo.LoaiSanPham WHERE maLoai = @maLoai;
--END

--Sap xep danh sach loai san pham tang dan theo ma loai
--CREATE PROC sp_SortLoaiSanPhamByMaLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY maLoai ASC
--END

----Sap xep danh sach loai san pham tang dan theo ten loai
--CREATE PROC sp_SortLoaiSanPhamByTenLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY tenLoai ASC
--END

-------------------------------------------SANPHAM----------------------------------------------------
----TAO PROCEDURE CHO BANG SAN PHAM
----Lay tat ca du lieu trong bang SanPham
--CREATE PROC sp_SelectAllSanPham
--AS
--BEGIN
--	SELECT * FROM SanPham;
--END

----Tim 1 san pham theo MASANPHAM
--CREATE PROC sp_SearchSanPhamByID
--(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE maSP = @maSP;
--END

----Tim 1 san pham theo TENSANPHAM
--CREATE PROC sp_SearchSanPhamByName
--(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE tenSP = @tenSP;
--END

----Insert du lieu vao bang SANPHAM
--CREATE PROC sp_InsertSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE maSP = @maSP OR tenSP = @tenSP)
--	BEGIN
--		INSERT INTO dbo.SanPham (maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES (@maSP, @tenSP, @donGia, @soLuong, @tinhTrang, @maLoaiSP);
--	END
--END

----Update du lieu cho bang SANPHAM
--CREATE PROC sp_UpdateSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE tenSP = @tenSP)
--	BEGIN
--		UPDATE dbo.SanPham SET maSP = @maSP, tenSP = @tenSP, donGia = @donGia, soLuong = @soLuong, tinhTrang = @tinhTrang, maLoaiSP = @maLoaiSP WHERE maSP = @maSP;
--	END
--END

----Delete du lieu bang SanPham bang ma san pham
--CREATE PROC sp_DeleteSanPham(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.SanPham WHERE maSP = @maSP;
--END

--Delete du lieu bang SanPham theo ma loai san pham
--CREATE PROC sp_DeleteSanPhamByMaLoai(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Sap xep danh sach tang dan theo ma san pham
--CREATE PROC sp_SortSanPhamASCByMaSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY maSP ASC;
--END
--EXEC sp_SortSanPhamASCByMaSP;

----Sap xep danh sach tang dan theo ten san pham
--CREATE PROC sp_SortSanPhamASCByTenSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY tenSP ASC;
--END
--EXEC sp_SortSanPhamASCByTenSP;

--Search san pham co ten san pham dung LIKE
--CREATE PROC sp_SearchSanPhamByLikeProduct_name(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE tenSP LIKE '%' + @tenSP+ '%';
--END
--EXEC sp_SearchSanPhamByLikeProduct_name 'Coffee'

----Tim san pham theo ma loai san pham
--CREATE PROC sp_SearchSanPhamByMaLoaiSP(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Update du lieu cho bang SANPHAM(chi update so luong)
--CREATE PROC sp_UpdateSoLuongSanPham
--(
--	@maSP nvarchar(50),
--	@soLuong int
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET soLuong = @soLuong WHERE maSP = @maSP;
--END

----Update du lieu cho bang SANPHAM(chi update tinh trang)
--CREATE PROC sp_UpdateTinhTrangSanPham
--(
--	@maSP nvarchar(50),
--	@tinhTrang nvarchar(70)
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET tinhTrang = @tinhTrang WHERE maSP = @maSP;
--END
-------------------------------------------HOADON----------------------------------------------------
----Lay tat ca ca hoa don
--CREATE PROC sp_SelectAllHoaDon
--AS
--BEGIN
--	SELECT * FROM dbo.HoaDon;
--END

----Lay hoa don co tong tien bang 0
--CREATE PROC sp_SearchHoaDonByTongTien
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien = 0;
--END

----Lay hoa don theo ma nhan vien
--CREATE PROC sp_SelectHoaDonByMaNV(
	--@maNV nvarchar(50);
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Insert Hoa don
--CREATE PROC sp_InsertHoaDon(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	INSERT INTO dbo.HoaDon (maNV, tongTien) VALUES (@maNV, 0);
--END

----Update Hoa don
--CREATE PROC sp_UpdateHoaDon(
--	@maHD int,
--	@maNV nvarchar(50),
--	@tongTien float
--)
--AS
--BEGIN
--	UPDATE dbo.HoaDon SET maNV = @maNV , tongTien = @tongTien WHERE maHD = @maHD;
--END

----Search hoa don theo ma nhan vien
--CREATE PROC sp_SearchHoaDonByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Tim hoa don co tong tien > 0
--CREATE PROC sp_SearchHoaDonTongTienLonHon_0
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien != 0;
--END

----Tim hoa don bang ma hoa don
--CREATE PROC sp_SearchHoaDonByMaHD(
--	@maHD int
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maHD = @maHD;
--END
-------------------------------------------CHITIETHOADON----------------------------------------------------
----Lay cac chi tiet hoa don theo MAHOADON
--CREATE PROC sp_SelectChiTietHDByInvoiceID
--(
--	@maHD int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.ChiTietHoaDon WHERE maHD = @maHD;
--END

--Insert du lieu vao bang ChiTietHoaDon
--CREATE PROC sp_InsertChiTietHD
--(
--	@maHD int,
--	@maSP nvarchar(50),
--	@donGia float,
--	@soLuong int,
--	@thanhTien float
--)
--AS
--BEGIN
--	INSERT INTO dbo.ChiTietHoaDon (maHD, maSP, donGia, soLuong, thanhTien) VALUES (@maHD, @maSP, @donGia, @soLuong, @thanhTien);
--END

----Update du lieu bang ChiTietHoaDon
--CREATE PROC sp_UpdateChiTietHD
--(
--	@maHD int,
--	@maSP nvarchar(50),
--	@soLuong int,
--	@thanhTien float
--)
--AS
--BEGIN
--	UPDATE dbo.ChiTietHoaDon SET soLuong = @soLuong, thanhTien = @thanhTien WHERE maHD = @maHD AND maSP = @maSP;
--END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateHoaDon]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Update Hoa don
CREATE PROC [dbo].[sp_UpdateHoaDon](
	@maHD int,
	@maNV nvarchar(50),
	@tongTien float,
	@ngayLapHD datetime,
	@ghiChu nvarchar(100)
)
AS
BEGIN
	UPDATE dbo.HoaDon SET maNV = @maNV , tongTien = @tongTien, ngayLapHD = @ngayLapHD, ghiChu = @ghiChu WHERE maHD = @maHD;
END
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 05/25/2018 11:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[maHD] [int] NOT NULL,
	[maSP] [nvarchar](50) NOT NULL,
	[donGia] [float] NOT NULL,
	[soLuong] [int] NOT NULL,
	[thanhTien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maHD] ASC,
	[maSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchHoaDonTongTienLonHon_0]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim hoa don co tong tien > 0
CREATE PROC [dbo].[sp_SearchHoaDonTongTienLonHon_0]
AS
BEGIN 
	SELECT * FROM dbo.HoaDon WHERE tongTien != 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchHoaDonByTongTien]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lay hoa don co tong tien bang 0
CREATE PROC [dbo].[sp_SearchHoaDonByTongTien]
AS
BEGIN 
	SELECT * FROM dbo.HoaDon WHERE tongTien = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchHoaDonByMaNV]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Search hoa don theo ma nhan vien
CREATE PROC [dbo].[sp_SearchHoaDonByMaNV](
	@maNV nvarchar(50)
)
AS
BEGIN
	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchHoaDonByMaHD]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tim hoa don bang ma hoa don
CREATE PROC [dbo].[sp_SearchHoaDonByMaHD](
	@maHD int
)
AS
BEGIN 
	SELECT * FROM dbo.HoaDon WHERE maHD = @maHD;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteHoaDonByMaNV]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----Delete hoa don theo ma nhan vien
CREATE PROC [dbo].[sp_DeleteHoaDonByMaNV](
	@maNV nvarchar(50)
)
AS
BEGIN
	IF EXISTS (SELECT * FROM HoaDon WHERE tongTien = 0 AND maNV = @maNV)
		BEGIN
			UPDATE HoaDon SET maNV = 'Admin' WHERE tongTien = 0;
		END
	ELSE
		BEGIN
			DELETE FROM HoaDon WHERE maNV = @maNV;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteHoaDonByMaHD]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete hoa don theo ma hoa don
CREATE PROC [dbo].[sp_DeleteHoaDonByMaHD](
	@maHD int
)
AS
BEGIN
	DELETE FROM HoaDon WHERE maHD = @maHD; 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertHoaDon]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Insert Hoa don
CREATE PROC [dbo].[sp_InsertHoaDon](
	@maNV nvarchar(50),
	@ngayLapHD datetime,
	@ghiChu nvarchar(100)
)
AS
BEGIN
	INSERT INTO dbo.HoaDon (maNV, tongTien, ngayLapHD, ghiChu) VALUES (@maNV, 0, @ngayLapHD, @ghiChu);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllHoaDon]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------USER----------------------------------------------------
----Lay toan bo du lieu bang Users
--CREATE PROCEDURE  sp_SelectAllUsers
--AS
--BEGIN
--	SELECT * FROM dbo.Users;
--END
--exec sp_SelectAllUsers

----Lay 1 user theo dieu kien
--CREATE PROCEDURE  sp_SelectOneUser(
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username AND password = @password AND levelUser = @levelUser;
--END
--exec sp_SelectOneUser 'huongntt', '123456', 1;

----Tim kiem 1 user theo username
--CREATE PROC sp_SearchUserByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.Users WHERE username = @username;
--END

--Insert du lieu vao bang Users
--CREATE PROCEDURE sp_InsertUsers (
--	@username nvarchar(50),
--	@password nvarchar(20),
--	@levelUser int
--)
--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM dbo.Users WHERE username = @username)
--	BEGIN
--		INSERT INTO dbo.Users(username, password, levelUser) VALUES(@username, @password, 2); 
--	END
--END

----Update du lieu vao bang Users(Chi duoc update password)
--CREATE PROCEDURE sp_UpdateUser( 
-- @username nvarchar(50),
--	@password nvarchar(20)
--)
--AS
--BEGIN
--		UPDATE dbo.UserS SET password = @password WHERE username = @username;
--END

----Delete du lieu vao bang Users(khong duoc phep xoa tai khoan cua admin va khong duoc xoa user cua nhan vien dang ton tai)
--CREATE PROCEDURE sp_DeleteUser( 
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF not exists(SELECT * FROM dbo.NhanVien WHERE username = @username)
--	BEGIN
--	DELETE FROM dbo.Users WHERE username = @username AND @username != 'huongntt';
--	END
--END

-------------------------------------------NHANVIEN----------------------------------------------------

----Lay het danh sach nhan vien
--CREATE PROC sp_SelectAllNhanVien
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV != 'Admin' ORDER BY maNV ASC;
--END

----Tim 1 nhan vien theo CMND
--CREATE PROC sp_SelectOneNhanVienByCMND(
--	@CMND nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE CMND = @CMND;
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV = @maNV AND maNV != 'Admin';
--END

----Tim 1 nhan vien theo dia chi
--CREATE PROC sp_SelectNhanVienByAddress(
--	@diaChi nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE diaChi LIKE '%' +  @diaChi + '%';
--END

----Insert du lieu vao bang NhanVien
--CREATE PROC sp_InsertNhanVien(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12),
--	@heSoLuong float,
--	@luongCB float,
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.NhanVien WHERE CMND = @CMND)
--	BEGIN
--		INSERT INTO dbo.NhanVien (maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username) 
--				VALUES (@maNV, @tenNV, @gioiTinh, @CMND, @diaChi, @SDT, @heSoLuong, @luongCB, @username);
--	END
--END

----Update du lieu bang NhanVien
--CREATE PROC sp_UpdateNhanVien(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12),
--	@heSoLuong float,
--	@luongCB float
--)
--AS
--BEGIN
--		UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT, heSoLuong = @heSoLuong, luongCB = @luongCB WHERE maNV = @maNV;
--END

----Delete du lieu cua nhan vien theo ma nhan vien
--CREATE PROC sp_DeleteNhanVien (
--	@maNV nvarchar(50) 
--)
--AS
--BEGIN
--	DELETE FROM dbo.NhanVien WHERE maNV = @maNV;
--END

----Tim 1 nhan vien theo ten nhan vien
--CREATE PROC sp_SelectNhanVienByLIKEtenNV(
--	@tenNV nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE tenNV LIKE '%' +  @tenNV + '%';
--END

----Tim 1 nhan vien theo MaNV
--CREATE PROC sp_SelectNhanVienLIKEMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE maNV LIKE '%' + @maNV + '%';
--END

----Tim 1 nhan vien theo username 
--CREATE PROC sp_SearchNhanVienByUsername(
--	@username nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.NhanVien WHERE username = @username;
--END

------Update du lieu NhanVien khong cho phep update hesoluong, luong co ban
--CREATE PROC sp_UpdateNhanVienLoaiTruLuongCB_HSLuong(
--	@maNV nvarchar(50),
--	@tenNV nvarchar(100),
--	@gioiTinh nvarchar(3),
--	@CMND nvarchar(50),
--	@diaChi nvarchar(100),
--	@SDT nvarchar(12)
--)
--AS
--BEGIN
--	UPDATE dbo.NhanVien SET tenNV = @tenNV, gioiTinh = @gioiTinh, CMND = @CMND, diaChi = @diaChi, SDT = @SDT WHERE maNV = @maNV;
--END
-------------------------------------------LOAISANPHAM----------------------------------------------------
----Lay toan bo du lieu bang LoaiSanPham
--CREATE PROC sp_SelectAllLoaiSanPham
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham;
--END

----Tim 1 LoaiSanPham theo MALOAI
--CREATE PROC sp_SearchLoaiSanPhamByID (
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE maLoai = @maLoai;
--END

----Tim 1 LoaiSanPham theo TENLOAI
--CREATE PROC sp_SearchLoaiSPByName (
--	@tenLoai nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM LoaiSanPham WHERE tenLoai = @tenLoai;
--END

----Insert du lieu vao bang LoaiSanPham
--CREATE PROC sp_InsertLoaiSanPham(
--	@maLoai nvarchar(50),
--	@tenLoai nvarchar(50)
--)
--AS 
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.LoaiSanPham WHERE maLoai = @maLoai OR tenLoai = @tenLoai)
--	BEGIN
--		INSERT INTO dbo.LoaiSanPham (maLoai, tenLoai) VALUES (@maLoai, @tenLoai);
--	END
--END

------Update du lieu vao bang LoaiSanPham
--CREATE PROC sp_UpdateLoaiSanPham(
--	@maLoai nvarchar(50),
--	@tenLoai nvarchar(50)
--)
--AS 
--BEGIN
--	UPDATE dbo.LoaiSanPham SET maLoai = @maLoai, tenLoai = @tenLoai WHERE maLoai = @maLoai;
--END

----Delete du lieu trong bang LoaiSanPham
--CREATE PROC sp_DeleteLoaiSanPham(
--	@maLoai nvarchar(50)
--)
--AS
--BEGIN 
--	IF NOT EXISTS(SELECT * FROM SanPham WHERE maLoaiSP = @maLoai)
--	BEGIN
--		DELETE FROM dbo.LoaiSanPham WHERE maLoai = @maLoai;
--	END
--END

--Sap xep danh sach loai san pham tang dan theo ma loai
--CREATE PROC sp_SortLoaiSanPhamByMaLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY maLoai ASC
--END

----Sap xep danh sach loai san pham tang dan theo ten loai
--CREATE PROC sp_SortLoaiSanPhamByTenLoai
--AS
--BEGIN 
--	SELECT * FROM LoaiSanPham ORDER BY tenLoai ASC
--END

-------------------------------------------SANPHAM----------------------------------------------------
----TAO PROCEDURE CHO BANG SAN PHAM
----Lay tat ca du lieu trong bang SanPham
--CREATE PROC sp_SelectAllSanPham
--AS
--BEGIN
--	SELECT * FROM SanPham;
--END

----Tim 1 san pham theo MASANPHAM
--CREATE PROC sp_SearchSanPhamByID
--(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE maSP = @maSP;
--END

----Tim 1 san pham theo TENSANPHAM
--CREATE PROC sp_SearchSanPhamByName
--(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM SanPham WHERE tenSP = @tenSP;
--END

----Insert du lieu vao bang SANPHAM
--CREATE PROC sp_InsertSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS (SELECT * FROM dbo.SanPham WHERE maSP = @maSP OR tenSP = @tenSP)
--	BEGIN
--		INSERT INTO dbo.SanPham (maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES (@maSP, @tenSP, @donGia, @soLuong, @tinhTrang, @maLoaiSP);
--	END
--END

----Update du lieu cho bang SANPHAM
--CREATE PROC sp_UpdateSanPham
--(
--	@maSP nvarchar(50),
--	@tenSP nvarchar(100),
--	@donGia float,
--	@soLuong int,
--	@tinhTrang nvarchar(70),
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--		UPDATE dbo.SanPham SET maSP = @maSP, tenSP = @tenSP, donGia = @donGia, soLuong = @soLuong, tinhTrang = @tinhTrang, maLoaiSP = @maLoaiSP WHERE maSP = @maSP;
--END

----Delete du lieu bang SanPham bang ma san pham
--CREATE PROC sp_DeleteSanPham(
--	@maSP nvarchar(50)
--)
--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM ChiTietHoaDon WHERE maSP = @maSP)
--	BEGIN
--		DELETE FROM dbo.SanPham WHERE maSP = @maSP;
--	END
--END

--Delete du lieu bang SanPham theo ma loai san pham
--CREATE PROC sp_DeleteSanPhamByMaLoai(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	DELETE FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Sap xep danh sach tang dan theo ma san pham
--CREATE PROC sp_SortSanPhamASCByMaSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY maSP ASC;
--END
--EXEC sp_SortSanPhamASCByMaSP;

----Sap xep danh sach tang dan theo ten san pham
--CREATE PROC sp_SortSanPhamASCByTenSP
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham ORDER BY tenSP ASC;
--END
--EXEC sp_SortSanPhamASCByTenSP;

--Search san pham co ten san pham dung LIKE
--CREATE PROC sp_SearchSanPhamByLikeProduct_name(
--	@tenSP nvarchar(100)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE tenSP LIKE '%' + @tenSP+ '%';
--END
--EXEC sp_SearchSanPhamByLikeProduct_name 'Coffee'

----Tim san pham theo ma loai san pham
--CREATE PROC sp_SearchSanPhamByMaLoaiSP(
--	@maLoaiSP nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.SanPham WHERE maLoaiSP = @maLoaiSP;
--END

----Update du lieu cho bang SANPHAM(chi update so luong)
--CREATE PROC sp_UpdateSoLuongSanPham
--(
--	@maSP nvarchar(50),
--	@soLuong int
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET soLuong = @soLuong WHERE maSP = @maSP;
--END

----Update du lieu cho bang SANPHAM(chi update tinh trang)
--CREATE PROC sp_UpdateTinhTrangSanPham
--(
--	@maSP nvarchar(50),
--	@tinhTrang nvarchar(70)
--)
--AS
--BEGIN
--	UPDATE dbo.SanPham SET tinhTrang = @tinhTrang WHERE maSP = @maSP;
--END
-------------------------------------------HOADON----------------------------------------------------
--Lay tat ca ca hoa don
CREATE PROC [dbo].[sp_SelectAllHoaDon]
AS
BEGIN
	SELECT * FROM dbo.HoaDon WHERE tongTien != 0 ORDER BY maHD ASC ;
END

----Lay hoa don co tong tien bang 0
--CREATE PROC sp_SearchHoaDonByTongTien
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien = 0;
--END

----Tim hoa don theo ma nhan vien
--CREATE PROC sp_SelectHoaDonByMaNV(
	--@maNV nvarchar(50);
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Insert Hoa don
--CREATE PROC sp_InsertHoaDon(
--	@maNV nvarchar(50),
--	@ngayLapHD datetime,
--	@ghiChu nvarchar(100)
--)
--AS
--BEGIN
--	INSERT INTO dbo.HoaDon (maNV, tongTien, ngayLapHD, ghiChu) VALUES (@maNV, 0, @ngayLapHD, @ghiChu);
--END

----Update Hoa don
--CREATE PROC sp_UpdateHoaDon(
--	@maHD int,
--	@maNV nvarchar(50),
--	@tongTien float,
--	@ngayLapHD datetime,
--	@ghiChu nvarchar(100)
--)
--AS
--BEGIN
--	UPDATE dbo.HoaDon SET maNV = @maNV , tongTien = @tongTien, ngayLapHD = @ngayLapHD, ghiChu = @ghiChu WHERE maHD = @maHD;
--END

----Search hoa don theo ma nhan vien
--CREATE PROC sp_SearchHoaDonByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	SELECT * FROM dbo.HoaDon WHERE maNV = @maNV;
--END

----Tim hoa don co tong tien > 0
--CREATE PROC sp_SearchHoaDonTongTienLonHon_0
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE tongTien != 0;
--END

----Tim hoa don bang ma hoa don
--CREATE PROC sp_SearchHoaDonByMaHD(
--	@maHD int
--)
--AS
--BEGIN 
--	SELECT * FROM dbo.HoaDon WHERE maHD = @maHD;
--END

------Delete hoa don theo ma nhan vien
--CREATE PROC sp_DeleteHoaDonByMaNV(
--	@maNV nvarchar(50)
--)
--AS
--BEGIN
--	IF EXISTS (SELECT * FROM HoaDon WHERE tongTien = 0 AND maNV = @maNV)
--		BEGIN
--			UPDATE HoaDon SET maNV = 'Admin' WHERE tongTien = 0;
--		END
--	ELSE
--		BEGIN
--			DELETE FROM HoaDon WHERE maNV = @maNV;
--		END
--END

----Delete hoa don theo ma hoa don
--CREATE PROC sp_DeleteHoaDonByMaHD(
--	@maHD int
--)
--AS
--BEGIN
--	DELETE FROM HoaDon WHERE maHD = @maHD; 
--END

-------------------------------------------CHITIETHOADON----------------------------------------------------
------Lay danh sach chi tiet hoa don
--CREATE PROC sp_SelectChiTietHD
--AS
--BEGIN
--	SELECT * FROM dbo.ChiTietHoaDon ORDER BY maHD ASC;
--END

----Lay cac chi tiet hoa don theo MAHOADON
--CREATE PROC sp_SelectChiTietHDByInvoiceID
--(
--	@maHD int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.ChiTietHoaDon WHERE maHD = @maHD;
--END

--Insert du lieu vao bang ChiTietHoaDon
--CREATE PROC sp_InsertChiTietHD
--(
--	@maHD int,
--	@maSP nvarchar(50),
--	@donGia float,
--	@soLuong int,
--	@thanhTien float
--)
--AS
--BEGIN
--	INSERT INTO dbo.ChiTietHoaDon (maHD, maSP, donGia, soLuong, thanhTien) VALUES (@maHD, @maSP, @donGia, @soLuong, @thanhTien);
--END

----Tim chi tiet hoa don theo ma hoa don
--CREATE PROC sp_SelectChiTietHDByInvoiceID
--(
--	@maHD int
--)
--AS
--BEGIN
--	SELECT * FROM dbo.ChiTietHoaDon WHERE maHD = @maHD;
--END

----Xoa chi tiet hoa don theo ma hoa don
--CREATE PROC sp_DeleteChiTietHDByMaHD(
--	@maHD int
--)
--AS
--BEGIN
--	DELETE FROM ChiTietHoaDon WHERE maHD = @maHD;
--END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectChiTietHDByInvoiceID]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SelectChiTietHDByInvoiceID]
(
	@maHD int
)
AS
BEGIN
	SELECT * FROM dbo.ChiTietHoaDon WHERE maHD = @maHD;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectChiTietHD]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----Lay danh sach chi tiet hoa don
CREATE PROC [dbo].[sp_SelectChiTietHD]
AS
BEGIN
	SELECT * FROM dbo.ChiTietHoaDon ORDER BY maHD ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertChiTietHD]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Insert du lieu vao bang ChiTietHoaDon
CREATE PROC [dbo].[sp_InsertChiTietHD]
(
	@maHD int,
	@maSP nvarchar(50),
	@donGia float,
	@soLuong int,
	@thanhTien float
)
AS
BEGIN
	INSERT INTO dbo.ChiTietHoaDon (maHD, maSP, donGia, soLuong, thanhTien) VALUES (@maHD, @maSP, @donGia, @soLuong, @thanhTien);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSanPham]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete du lieu bang SanPham
CREATE PROC [dbo].[sp_DeleteSanPham](
	@maSP nvarchar(50)
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM ChiTietHoaDon WHERE maSP = @maSP)
	BEGIN
		DELETE FROM dbo.SanPham WHERE maSP = @maSP;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteChiTietHDByMaHD]    Script Date: 05/25/2018 11:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Xoa chi tiet hoa don theo ma hoa don
CREATE PROC [dbo].[sp_DeleteChiTietHDByMaHD](
	@maHD int
)
AS
BEGIN
	DELETE FROM ChiTietHoaDon WHERE maHD = @maHD;
END
GO
/****** Object:  Default [DF__HoaDon__tongTien__46B27FE2]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [tongTien]
GO
/****** Object:  ForeignKey [fk_hoadon]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_hoadon] FOREIGN KEY([maHD])
REFERENCES [dbo].[HoaDon] ([maHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [fk_hoadon]
GO
/****** Object:  ForeignKey [fk_sanpham]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [fk_sanpham] FOREIGN KEY([maSP])
REFERENCES [dbo].[SanPham] ([maSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [fk_sanpham]
GO
/****** Object:  ForeignKey [FK__HoaDon__maNV__45BE5BA9]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
/****** Object:  ForeignKey [FK__NhanVien__userna__0519C6AF]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
/****** Object:  ForeignKey [FK__SanPham__maLoaiS__1367E606]    Script Date: 05/25/2018 11:10:23 ******/
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([maLoaiSP])
REFERENCES [dbo].[LoaiSanPham] ([maLoai])
GO




---------------------------------------------------------------------------------------
--INSERT GIA TRI
--Insert vao bang Users
GO
INSERT INTO dbo.Users(username, password, levelUser) VALUES ('huongntt', '123456', 1);
INSERT INTO dbo.Users(username, password, levelUser) VALUES ('phunv01', '123456', 2);
INSERT INTO dbo.Users(username, password, levelUser) VALUES ('huongnv02', '123456', 2);


--Insert bang nhan vien
GO
INSERT INTO dbo.NhanVien(maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username) 
			VALUES ('Admin', N'Admin', '', '0', '', '', 0, 0, 'huongntt');
INSERT INTO dbo.NhanVien(maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username)
			VALUES ('NV01', N'Võ Ngọc Phú', 'Nam', '221456789', N'TP.HCM', '0987899000', 3.15, 3150000, 'phunv01');
INSERT INTO dbo.NhanVien(maNV, tenNV, gioiTinh, CMND, diaChi, SDT, heSoLuong, luongCB, username)
			VALUES ('NV02', N'Nguyễn Thị Thanh Hưởng', 'Nu', '221378656', N'Phú Yên', '0975011240', 3.15, 3150000, 'huongnv02');


--Insert bang LoaiSanPham
GO
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('CF', 'Coffee');
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('TS', N'Trà sữa');
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('NGK', N'Nước giải khát');
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('NETC', N'Nước ép trái cây');
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('SUA', N'Sữa');
INSERT INTO dbo.LoaiSanPham(maLoai, tenLoai) VALUES ('TRA', N'Trà');
--Insert bang SanPham
GO
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('CFSD', N'Coffee sữa đá', 25000, 1000, N'Còn hàng', 'CF');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('CFSN', N'Coffee sữa nóng', 25000, 900, N'Còn hàng', 'CF');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('CFD', N'Coffee đen', 23000, 1000, N'Còn hàng', 'CF');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('NET', N'Nước ép táo', 35000, 1000, N'Còn hàng', 'NETC');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('NEC', N'Nước ép cam', 35000, 5000, N'Còn hàng', 'NETC');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('TSD', N'Trà sữa dâu', 20000, 1500, N'Còn hàng', 'TS');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('TSTC', N'Trà sữa trân châu', 20000, 800, N'Còn hàng', 'TS');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('NS', N'Nước suối', 5000, 2000, N'Còn hàng', 'NGK');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('STD', N'Sting dâu', 10000, 2000, N'Còn hàng', 'NGK');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('C2', N'C2', 8000, 500, N'Còn hàng', 'NGK');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('DRT', N'Dr Thanh', 9000, 800, N'Còn hàng', 'NGK');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('TG', N'Trà gừng', 15000, 1500, N'Còn hàng', 'TRA');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('TC', N'Trà chanh', 15000, 400, N'Còn hàng', 'TRA');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('SVNM', N'Sữa vinamilk', 20000, 1000, N'Còn hàng', 'SUA');
INSERT INTO dbo.SanPham(maSP, tenSP, donGia, soLuong, tinhTrang, maLoaiSP) VALUES ('SN', N'Sữa nóng', 20000, 700, N'Còn hàng', 'SUA');

--Insert bang HoaDon(Bang nay bat buoc co san 1 hoa don truoc)
GO
INSERT INTO dbo.HoaDon(maNV, tongTien, ngayLapHD, ghiChu) VALUES('Admin', 0, 01/01/2000, '');
