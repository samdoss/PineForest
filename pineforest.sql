USE [PineForest]
GO
/****** Object:  StoredProcedure [dbo].[spAddEditLogin]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spAddEditLogin]
GO
/****** Object:  StoredProcedure [dbo].[spAddEditPineBooking]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spAddEditPineBooking]
GO
/****** Object:  StoredProcedure [dbo].[spAddLogErrorMessageToDB]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spAddLogErrorMessageToDB]
GO
/****** Object:  StoredProcedure [dbo].[spGetLogin]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spGetLogin]
GO
/****** Object:  StoredProcedure [dbo].[spGetLoginAuthentication]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spGetLoginAuthentication]
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomCostOnPeriodDaysByCheckInCheckOut]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spGetRoomCostOnPeriodDaysByCheckInCheckOut]
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomTypeAvailableCount]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spGetRoomTypeAvailableCount]
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomTypes]    Script Date: 07/22/2015 10:49:49 ******/
DROP PROCEDURE [dbo].[spGetRoomTypes]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 07/22/2015 10:49:44 ******/
DROP TABLE [dbo].[Booking]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 07/22/2015 10:49:44 ******/
DROP TABLE [dbo].[ContactUs]
GO
/****** Object:  Table [dbo].[ErrorMessageLog]    Script Date: 07/22/2015 10:49:44 ******/
DROP TABLE [dbo].[ErrorMessageLog]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 07/22/2015 10:49:44 ******/
DROP TABLE [dbo].[Login]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/22/2015 10:49:43 ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 07/22/2015 10:49:43 ******/
DROP TABLE [dbo].[Room]
GO
/****** Object:  Table [dbo].[RoomPrice]    Script Date: 07/22/2015 10:49:43 ******/
DROP TABLE [dbo].[RoomPrice]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 07/22/2015 10:49:43 ******/
DROP TABLE [dbo].[RoomType]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 07/22/2015 10:49:43 ******/
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
/****** Object:  Table [dbo].[RoomPrice]    Script Date: 07/22/2015 10:49:43 ******/
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
SET IDENTITY_INSERT [dbo].[RoomPrice] ON
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (2, 1, 2000, 5, CAST(0x233A0B00 AS Date), CAST(0x413A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (3, 2, 2800, 10, CAST(0x233A0B00 AS Date), CAST(0x413A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (4, 3, 3400, 5, CAST(0x233A0B00 AS Date), CAST(0x413A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (5, 1, 2500, 10, CAST(0x423A0B00 AS Date), CAST(0x5F3A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (6, 2, 3000, 0, CAST(0x423A0B00 AS Date), CAST(0x5F3A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
INSERT [dbo].[RoomPrice] ([RoomPriceID], [RoomTypeID], [Price], [DiscountPercentage], [ValidFrom], [ValidTo], [AuditID], [AuditDate]) VALUES (7, 3, 3800, 20, CAST(0x423A0B00 AS Date), CAST(0x5F3A0B00 AS Date), 1, CAST(0x2A3A0B00 AS Date))
SET IDENTITY_INSERT [dbo].[RoomPrice] OFF
/****** Object:  Table [dbo].[Room]    Script Date: 07/22/2015 10:49:43 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 07/22/2015 10:49:43 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 07/22/2015 10:49:44 ******/
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
	[AuditDate] [datetime] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([LoginID], [RoleID], [LoginMailID], [LoginMobileNo], [IsAuthenticated], [AuthenticationCode], [AuthenticationDate], [LogininIpAddress], [geolocation], [AuditDate]) VALUES (1, 1, N'samdoss1@live.com', N'9789017256', 1, N'555545', CAST(0x6E390B00 AS Date), N'61.62.42.54', N'544.455,0.545', NULL)
INSERT [dbo].[Login] ([LoginID], [RoleID], [LoginMailID], [LoginMobileNo], [IsAuthenticated], [AuthenticationCode], [AuthenticationDate], [LogininIpAddress], [geolocation], [AuditDate]) VALUES (2, 2, N'samdoss@gmail.com', N'', 0, N'x2a7dc', NULL, N'http://myphpapps.com', N'http://myphpapps.com.cws10.my-', CAST(0x0000A4D6009E545E AS DateTime))
INSERT [dbo].[Login] ([LoginID], [RoleID], [LoginMailID], [LoginMobileNo], [IsAuthenticated], [AuthenticationCode], [AuthenticationDate], [LogininIpAddress], [geolocation], [AuditDate]) VALUES (18, 2, N'samdoss@live.com', N'', 1, N'g9ab42', CAST(0x363A0B00 AS Date), N'61.3.227.77', N'Lon: 80.283302Lat: 13.0833', CAST(0x0000A4DB0184F958 AS DateTime))
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  Table [dbo].[ErrorMessageLog]    Script Date: 07/22/2015 10:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ErrorMessageLog](
	[ErrorMessageLogID] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](100) NULL,
	[ClassName] [varchar](100) NULL,
	[EventName] [varchar](100) NOT NULL,
	[ErrorMessage] [varchar](2000) NOT NULL,
	[AuditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorMessageLog] PRIMARY KEY CLUSTERED 
(
	[ErrorMessageLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 07/22/2015 10:49:44 ******/
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
/****** Object:  Table [dbo].[Booking]    Script Date: 07/22/2015 10:49:44 ******/
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
	[FeesandTax] [int] NOT NULL,
	[TotalAmount] [int] NULL,
	[PaidAmount] [int] NULL,
	[IpAddress] [varchar](20) NULL,
	[GeoLocation] [varchar](150) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentByUsing] [varchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomTypes]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRoomTypes]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT RoomTypeID, RoomType
	 FROM RoomType
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomTypeAvailableCount]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spGetRoomTypeAvailableCount]
(
	@RoomTypeID		int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(RoomTypeID) RoomCount
	FROM Room
	where RoomTypeID = @RoomTypeID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRoomCostOnPeriodDaysByCheckInCheckOut]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRoomCostOnPeriodDaysByCheckInCheckOut]
(
	@RoomTypeID			INT,
	@CheckIN			DATETIME,
	@CheckOUT			DATETIME
)
AS
BEGIN	

	SELECT RoomPriceID, [Price] ,[DiscountPercentage]
	FROM RoomPrice 
	WHERE RoomTypeID = @RoomTypeID 
	AND @CheckIN BETWEEN ValidFrom AND ValidTo 	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLoginAuthentication]    Script Date: 07/22/2015 10:49:49 ******/
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
/****** Object:  StoredProcedure [dbo].[spGetLogin]    Script Date: 07/22/2015 10:49:49 ******/
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
/****** Object:  StoredProcedure [dbo].[spAddLogErrorMessageToDB]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddLogErrorMessageToDB]
(
	@PageName		varchar(100),
	@ClassName		varchar(100),
	@EventName		varchar(100),
	@ErrorMessage	varchar(2000)
)
AS
BEGIN
	INSERT INTO ErrorMessageLog (PageName, ClassName, EventName, ErrorMessage, AuditDate)
	VALUES(@PageName, @ClassName, @EventName, @ErrorMessage,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[spAddEditPineBooking]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddEditPineBooking]
(
		@BookingID	int,
		@LoginID	int,
		@RegistrationID	varchar(20)  = NULL,
		@BookingDate	datetime  = NULL,
		@BookingName	varchar(75)  = NULL,
		@BookingFrom	date  = NULL,
		@BookingTo	date  = NULL,
		@CheckInTime	varchar(10)  = NULL,
		@CheckOutTime	varchar(10)  = NULL,
		@NoofAdults	int,
		@NoofChildrens	int,
		@AdditionalBed	int,
		@Proofverification	varchar(100)  = NULL,
		@Remarks	varchar(300)  = NULL,
		@EmailID	varchar(150)  = NULL,
		@PhoneNumber	varchar(15)  = NULL,
		@RoomTypeID	int,
		@RoomNo	int,
		@AmountPerday	int,
		@Discount	int,
		@FeesandTax	int,
		@TotalAmount	int,
		@PaidAmount	int,
		@IpAddress	varchar(20)  = NULL,
		@GeoLocation	varchar(150)  = NULL,

		@AddEditOption		INT --0 Add,  1 Edit/Modify	
)
AS
BEGIN
	SET NOCOUNT ON;	
	IF @AddEditOption = 0
	BEGIN
		INSERT INTO Booking
			( 
				LoginID, RegistrationID,
				BookingDate, BookingName, BookingFrom,
				BookingTo, CheckInTime, CheckOutTime,
				NoofAdults, NoofChildrens, AdditionalBed,
				Proofverification, Remarks, EmailID,
				PhoneNumber, RoomTypeID, RoomNo,
				AmountPerday, Discount, FeesandTax,
				TotalAmount, PaidAmount, IpAddress,
				GeoLocation
			)
		VALUES 
			(				
				@LoginID, @RegistrationID,
				GETDATE(), @BookingName, @BookingFrom,
				@BookingTo, @CheckInTime, @CheckOutTime,
				@NoofAdults, @NoofChildrens, @AdditionalBed,
				@Proofverification, @Remarks, @EmailID,
				@PhoneNumber, @RoomTypeID, @RoomNo,
				@AmountPerday, @Discount, @FeesandTax,
				@TotalAmount, @PaidAmount, @IpAddress,
				@GeoLocation
				
			)
			IF @@ERROR > 0 GOTO PROBLEM
			RETURN @@Identity
	END
	ELSE IF @AddEditOption = 1
	BEGIN
			UPDATE Booking SET 
			PaidAmount = @PaidAmount
			WHERE BookingID=@BookingID
				
			IF @@ERROR > 0 GOTO PROBLEM	
			RETURN @BookingID
	END

PROBLEM:
	RETURN -1
END
GO
/****** Object:  StoredProcedure [dbo].[spAddEditLogin]    Script Date: 07/22/2015 10:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddEditLogin]
(
	
	@LoginID			int,
	@RoleID				int,
	@LoginMailID		varchar(300)  = NULL,
	@LoginMobileNo		varchar(20)  = NULL,
	@IsAuthenticated	bit,
	@AuthenticationCode	varchar(8)  = NULL,
	@AuthenticationDate	date  = NULL,
	@LogininIpAddress	varchar(20)  = NULL,
	@geolocation		varchar(30)  = NULL,	

	@AddEditOption		INT --0 Add,  1 Edit/Modify	
)
AS
BEGIN
	SET NOCOUNT ON;

	IF @RoleID = 0
	BEGIN
		SET @RoleID = 2
	END

	IF @AddEditOption = 0
	BEGIN
		INSERT INTO [Login]
			( 
				RoleID, LoginMailID, LoginMobileNo, IsAuthenticated, AuthenticationCode,
				AuthenticationDate, LogininIpAddress, geolocation, AuditDate
			)
		VALUES 
			(
				@RoleID, @LoginMailID, @LoginMobileNo, @IsAuthenticated, @AuthenticationCode,
				GETDATE(), @LogininIpAddress, @geolocation, GetDate() 
			)
			IF @@ERROR > 0 GOTO PROBLEM
			RETURN @@Identity
	END
	ELSE IF @AddEditOption = 1
	BEGIN
			UPDATE [Login] SET 
			IsAuthenticated = @IsAuthenticated, AuthenticationDate=Getdate() 
			WHERE LoginID=@LoginID
				
			IF @@ERROR > 0 GOTO PROBLEM	
			RETURN @LoginID
	END

PROBLEM:
	RETURN -1
END
GO
