CREATE DATABASE [QL]
GO
USE [QL]
GO


/****** Object:  Table [dbo].[Account]    Script Date: 20/07/2022 12:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diem]    Script Date: 20/07/2022 12:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Teacher] [int] NOT NULL,
	[Class] [int] NULL,
	[Subject] [int] NULL,
	[Student] [int] NULL,
	[Q1] [int] NULL,
	[Q2] [int] NULL,
	[Q3] [int] NULL,
 CONSTRAINT [PK_Diem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hocsinh]    Script Date: 20/07/2022 12:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hocsinh](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MSSV] [varchar](50) NULL,
	[Fullname] [varchar](50) NULL,
 CONSTRAINT [PK_Hocsinh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lophoc]    Script Date: 20/07/2022 12:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lophoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lophoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monhoc]    Script Date: 20/07/2022 12:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monhoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
 CONSTRAINT [PK_Monhoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (1, N'chilp', N'123')
INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (2, N'thanhht', N'123')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Diem] ON 

INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (2, 1, 1, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (7, 1, 1, 3, 1, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (8, 1, 1, 3, 2, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (9, 1, 1, 3, 3, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (11, 1, 1, 3, 5, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (12, 1, 1, 3, 7, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (13, 1, 1, 1, 6, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (14, 1, 1, 1, 7, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (16, 1, 1, 1, 5, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (17, 1, 1, 1, 2,NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (18, 1, 1, 2, 1, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (19, 1, 1, 2, 2, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (20, 1, 1, 2, 3, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (21, 1, 1, 2, 4, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([ID], [Teacher], [Class], [Subject], [Student], [Q1], [Q2], [Q3]) VALUES (22, 1, 1, 2, 6, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Diem] OFF
GO
SET IDENTITY_INSERT [dbo].[Hocsinh] ON 

INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (1, N'SV1', N'Nguyen Xuan Thanh')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (2, N'SV2', N'Nguyen Thi Kim Thoa')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (3, N'SV3', N'Pham Dat Thanh')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (4, N'SV4', N'Vu Van Tuyen')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (5, N'SV5', N'Tran Hoang Anh')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (6, N'SV6', N'Kieu Thi Bich Nguyet')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (7, N'SV7', N'Pham Quang Huy')
INSERT [dbo].[Hocsinh] ([ID], [MSSV], [Fullname]) VALUES (8, N'SV8', N'Hoang Tien Thanh')
SET IDENTITY_INSERT [dbo].[Hocsinh] OFF
GO
SET IDENTITY_INSERT [dbo].[Lophoc] ON 

INSERT [dbo].[Lophoc] ([ID], [Code], [Class]) VALUES (1, N'LH1', N'SE1605')
INSERT [dbo].[Lophoc] ([ID], [Code], [Class]) VALUES (2, N'LH2', N'SE1606')
INSERT [dbo].[Lophoc] ([ID], [Code], [Class]) VALUES (3, N'LH3', N'SE1422')
SET IDENTITY_INSERT [dbo].[Lophoc] OFF
GO
SET IDENTITY_INSERT [dbo].[Monhoc] ON 

INSERT [dbo].[Monhoc] ([ID], [Code], [Subject]) VALUES (1, N'MH1', N'PRN211')
INSERT [dbo].[Monhoc] ([ID], [Code], [Subject]) VALUES (2, N'MH2', N'PRJ301')
INSERT [dbo].[Monhoc] ([ID], [Code], [Subject]) VALUES (3, N'MH3', N'PRO192')
INSERT [dbo].[Monhoc] ([ID], [Code], [Subject]) VALUES (4, N'MH4', N'PRF192')
SET IDENTITY_INSERT [dbo].[Monhoc] OFF
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Account] FOREIGN KEY([Teacher])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_Account]
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Hocsinh] FOREIGN KEY([Student])
REFERENCES [dbo].[Hocsinh] ([ID])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_Hocsinh]
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Lophoc] FOREIGN KEY([Class])
REFERENCES [dbo].[Lophoc] ([ID])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_Lophoc]
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD  CONSTRAINT [FK_Diem_Monhoc] FOREIGN KEY([Subject])
REFERENCES [dbo].[Monhoc] ([ID])
GO
ALTER TABLE [dbo].[Diem] CHECK CONSTRAINT [FK_Diem_Monhoc]
GO
