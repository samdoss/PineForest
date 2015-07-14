USE [PineForest]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomType_1] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomType]) VALUES (1, N'Economy')
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomType]) VALUES (2, N'Deluxe')
INSERT [dbo].[RoomType] ([RoomTypeID], [RoomType]) VALUES (3, N'Super Deluxe')
SET IDENTITY_INSERT [dbo].[RoomType] OFF
/****** Object:  Table [dbo].[RoomPrice]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomPrice](
	[RoomPriceID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[DiscountPercentage] [int] NULL,
	[ValidFrom] [date] NULL,
	[ValidTo] [date] NULL,
	[AuditID] [int] NULL,
	[AuditDate] [date] NULL,
 CONSTRAINT [PK_RoomPrice] PRIMARY KEY CLUSTERED 
(
	[RoomPriceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](10) NOT NULL,
	[RoomTypeID] [int] NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (1, N'Room 1', 2)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (2, N'Room 2', 1)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (3, N'Room 3', 3)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (4, N'Room 4', 1)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (5, N'Room 5', 3)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (6, N'Room 6', 2)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (7, N'Room 7', 2)
INSERT [dbo].[Room] ([RoomID], [RoomNo], [RoomTypeID]) VALUES (8, N'Room 8', 3)
SET IDENTITY_INSERT [dbo].[Room] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Guest')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'RegisteredUser')
/****** Object:  Table [dbo].[Login]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[LoginMailID] [varchar](300) NULL,
	[LoginMobileNo] [varchar](20) NULL,
	[IsAuthenticated] [bit] NULL,
	[AuthenticationCode] [varchar](8) NULL,
	[AuthenticationDate] [date] NULL,
	[LogininIpAddress] [varchar](20) NULL,
	[geolocation] [varchar](30) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([LoginID], [RoleID], [LoginMailID], [LoginMobileNo], [IsAuthenticated], [AuthenticationCode], [AuthenticationDate], [LogininIpAddress], [geolocation]) VALUES (1, 1, N'samdoss@live.com', N'9789017256', 1, N'555545', CAST(0x6E390B00 AS Date), N'61.62.42.54', N'544.455,0.545')
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[ContactUs]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactUs](
	[ContactUsID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[EmailID] [varchar](50) NULL,
	[MobileNumber] [varchar](15) NULL,
	[Comment] [varchar](500) NULL,
	[AuditDate] [date] NULL,
	[IpAddress] [varchar](50) NULL,
	[GeoLocation] [varchar](50) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ContactUsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 07/14/2015 10:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[LoginID] [int] NOT NULL,
	[RegistrationID] [varchar](20) NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[BookingName] [varchar](75) NOT NULL,
	[BookingFrom] [date] NOT NULL,
	[BookingTo] [date] NOT NULL,
	[CheckInTime] [varchar](10) NULL,
	[CheckOutTime] [varchar](10) NULL,
	[NoofAdults] [int] NOT NULL,
	[NoofChildrens] [int] NOT NULL,
	[AdditionalBed] [int] NOT NULL,
	[Proofverification] [varchar](100) NULL,
	[Remarks] [varchar](300) NULL,
	[EmailID] [varchar](150) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[RoomTypeID] [int] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[AmountPerday] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[IpAddress] [varchar](20) NULL,
	[GeoLocation] [varchar](150) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spGetLoginAuthentication]    Script Date: 07/14/2015 10:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetLoginAuthentication]
(
		 @LoginEmailIDorMobileNo Varchar(300)
) 
AS
BEGIN
	SET NOCOUNT ON;
	 SELECT LoginID, LoginMailID, LoginMobileNo, IsAuthenticated, AuthenticationCode,
	 AuthenticationDate, LogininIpAddress, geolocation,	 
	 U.RoleID, ISNULL(R.RoleName,'') AS RoleName
	 FROM [Login] U
	 Inner JOIN Role R ON U.RoleID = R.RoleID	
	 WHERE LoginMailID = @LoginEmailIDorMobileNo or LoginMobileNo=@LoginEmailIDorMobileNo
	 	 
	 --ISNULL(E.DOB,GETDATE()) AS DOB, ISNULL(F.[Name],'') As SpouseName, ISNULL(E.WeddingDate,GETDATE()) AS WeddingDate,
	 --ISNULL(C.CompanyName,' t. Ltd.') AS CompanyName, ISNULL(E.FName,'') + ' ' + ISNULL(E.LName,'') + ' ' + ISNULL(E.Initial,'') AS EmployeeName,
	 --U.IsSuperUser, ISNULL(DF.DateFormatValue,'dd/MM/yyyy') AS DateFormatValue,
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLogin]    Script Date: 07/14/2015 10:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetLogin]
(
		 @LoginEmailIDorMobileNo Varchar(300)
) 
AS
BEGIN
	SET NOCOUNT ON;
	 SELECT LoginID, LoginMailID, LoginMobileNo, IsAuthenticated, AuthenticationCode,
	 AuthenticationDate, LogininIpAddress, geolocation,	 
	 U.RoleID, ISNULL(R.RoleName,'') AS RoleName
	 FROM [Login] U
	 Inner JOIN Role R ON U.RoleID = R.RoleID	
	 WHERE IsAuthenticated = 1 and (LoginMailID = @LoginEmailIDorMobileNo or LoginMobileNo=@LoginEmailIDorMobileNo)
	 	 
	 --ISNULL(E.DOB,GETDATE()) AS DOB, ISNULL(F.[Name],'') As SpouseName, ISNULL(E.WeddingDate,GETDATE()) AS WeddingDate,
	 --ISNULL(C.CompanyName,' t. Ltd.') AS CompanyName, ISNULL(E.FName,'') + ' ' + ISNULL(E.LName,'') + ' ' + ISNULL(E.Initial,'') AS EmployeeName,
	 --U.IsSuperUser, ISNULL(DF.DateFormatValue,'dd/MM/yyyy') AS DateFormatValue,
END
GO
