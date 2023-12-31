USE master
GO

CREATE DATABASE [BirdFarmShop]
GO

USE [BirdFarmShop]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitiet]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hoadon] [int] NOT NULL,
	[SanPham] [int] NULL,
	[Soluong] [int] NULL,
	[Gianhap] [int] NULL,
	[Giaban] [int] NULL,
 CONSTRAINT [PK_Chitiet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nguoimua] [int] NOT NULL,
	[Tongtien] [int] NULL,
	[Ngaymua] [date] NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Diachi] [varchar](500) NULL,
	[Sdt] [varchar](50) NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [varchar](50) NULL,
 CONSTRAINT [PK_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Diachi] [varchar](500) NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 08/11/2023 10:04:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenSp] [varchar](50) NULL,
	[Giatien] [int] NULL,
	[Gianhap] [int] NULL,
	[Soluong] [int] NULL,
	[LoaiSP] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [Role]) VALUES (1, N'sa', N'123', 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role]) VALUES (2, N'user1', N'123', 2)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Role]) VALUES (3, N'user2', N'123', 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Chitiet] ON 

INSERT [dbo].[Chitiet] ([ID], [Hoadon], [SanPham], [Soluong], [Gianhap], [Giaban]) VALUES (1024, 1012, 1, 3, 9000, 9000)
INSERT [dbo].[Chitiet] ([ID], [Hoadon], [SanPham], [Soluong], [Gianhap], [Giaban]) VALUES (1025, 1012, 7, 7, 8500, 9000)
SET IDENTITY_INSERT [dbo].[Chitiet] OFF
GO
SET IDENTITY_INSERT [dbo].[Hoadon] ON 

INSERT [dbo].[Hoadon] ([ID], [Nguoimua], [Tongtien], [Ngaymua]) VALUES (1012, 2, 90000, CAST(N'2023-11-07' AS Date))
SET IDENTITY_INSERT [dbo].[Hoadon] OFF
GO
INSERT [dbo].[Khachhang] ([ID], [Name], [Diachi], [Sdt]) VALUES (2, N'Khach hang 1', N'Kim Ngu, Ha Noi', N'0324232244')
INSERT [dbo].[Khachhang] ([ID], [Name], [Diachi], [Sdt]) VALUES (3, N'Thuy Chung', N'Binh Giang, Hai Duong', N'0332255332')
GO
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([ID], [TenLoai]) VALUES (1, N'Chim Cao Cap')
INSERT [dbo].[LoaiSP] ([ID], [TenLoai]) VALUES (2, N'Chim Binh Thuong')
INSERT [dbo].[LoaiSP] ([ID], [TenLoai]) VALUES (3, N'Do Ca nhan')
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
GO
INSERT [dbo].[Nhanvien] ([ID], [Name], [SDT], [Diachi]) VALUES (1, N'Diep Trang', N'09331122', N'Ha Noi')
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (1, N'Vet 7 mau', 10000, 9000, 66, 1)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (2, N'Chim Chao mao dot bien', 12000, 9500, 68, 1)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (3, N'Chim Se', 14000, 10000, 0, 2)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (4, N'Chim Sau', 20000, 12000, 0, 3)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (5, N'Bim Bip', 15000, 12000, 100, 3)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (6, N'Chim Cuc cu', 5000, 2000, 79, 1)
INSERT [dbo].[SanPham] ([ID], [TenSp], [Giatien], [Gianhap], [Soluong], [LoaiSP]) VALUES (7, N'Chim Tu hu', 10000, 8500, 85, 2)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[Chitiet]  WITH CHECK ADD  CONSTRAINT [FK_Chitiet_Hoadon] FOREIGN KEY([Hoadon])
REFERENCES [dbo].[Hoadon] ([ID])
GO
ALTER TABLE [dbo].[Chitiet] CHECK CONSTRAINT [FK_Chitiet_Hoadon]
GO
ALTER TABLE [dbo].[Chitiet]  WITH CHECK ADD  CONSTRAINT [FK_Chitiet_SanPham] FOREIGN KEY([SanPham])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[Chitiet] CHECK CONSTRAINT [FK_Chitiet_SanPham]
GO
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Khachhang] FOREIGN KEY([Nguoimua])
REFERENCES [dbo].[Khachhang] ([ID])
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Khachhang]
GO
ALTER TABLE [dbo].[Khachhang]  WITH CHECK ADD  CONSTRAINT [FK_Khachhang_Account] FOREIGN KEY([ID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Khachhang] CHECK CONSTRAINT [FK_Khachhang_Account]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Account] FOREIGN KEY([ID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Account]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSP] FOREIGN KEY([LoaiSP])
REFERENCES [dbo].[LoaiSP] ([ID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSP]
GO
