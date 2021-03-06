USE [master]
GO
CREATE DATABASE [REHBERAPI]
/****** Object:  Table [dbo].[Telefonlar] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefonlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelefonNo] [char](10) NULL,
	[TelefonAdı] [nvarchar](100) NULL,
 CONSTRAINT [PK_Telefonlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Telefonlar] ON
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (1, N'5538569565', N'Güneş Yıldırım')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (2, N'2167531362', N'Hasan Yankıcı')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (3, N'5376541234', N'Yeşim Salkım')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (4, N'3546248524', N'Yusuf Çoban')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (5, N'2657412596', N'Ayşin Yanardağ')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (6, N'5312579235', N'Hakkı Başoğlu')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (7, N'5512458565', N'Yasin Gündoğdu')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (8, N'2167531596', N'Selim Kaptan')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (9, N'4538523495', N'Mustafa Akan')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (10, N'5869631242', N'Haşmet Sağlık')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (11, N'5328439213', N'Şemsi Akbulut')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (12, N'5312768452', N'Orhan Paralı')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (13, N'5389536428', N'Baran Kumsal')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (14, N'3528459578', N'Fırat Yaşar')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (15, N'5558452565', N'Şehmuz Orman')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (16, N'5556255515', N'Yusuf Baranoğlu')
INSERT [dbo].[Telefonlar] ([ID], [TelefonNo], [TelefonAdı]) VALUES (17, N'5523452356', N'Haşmet Güney')
SET IDENTITY_INSERT [dbo].[Telefonlar] OFF
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 07/17/2020 14:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserKey] [uniqueidentifier] NULL,
	[UserRole] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON
INSERT [dbo].[Kullanicilar] ([ID], [UserName], [UserKey], [UserRole]) VALUES (1, N'User1', N'f8df25af-ec10-4e02-b27b-176de37686ad', N'Admin')
INSERT [dbo].[Kullanicilar] ([ID], [UserName], [UserKey], [UserRole]) VALUES (2, N'User2', N'1ce3db54-6723-43be-96f2-50398ec85c36', N'Manager')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
/****** Object:  Default [DF_Kullanicilar_UserKey]    Script Date: 07/17/2020 14:24:04 ******/
ALTER TABLE [dbo].[Kullanicilar] ADD  CONSTRAINT [DF_Kullanicilar_UserKey]  DEFAULT (newid()) FOR [UserKey]
GO
