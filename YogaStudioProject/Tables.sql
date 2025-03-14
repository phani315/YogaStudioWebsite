CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Ph_num] [nvarchar](10) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[Role] [nvarchar](10) NOT NULL
	)
	

CREATE TABLE [dbo].[Class_Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ReservationDate] [nvarchar](20) NOT NULL,
	[Canclestatus] [bit] NULL
	)


CREATE TABLE [dbo].[Class_WaitingList](
	[WaitingListID] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ReservationDate] [nvarchar](20) NOT NULL
	)


CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InstructorName] [nvarchar](100) NULL,
	[StartTime] [nvarchar](50) NOT NULL,
	[EndTime] [nvarchar](50) NOT NULL,
	[ClassDateForm] [nvarchar](20) NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[CurrentCapacity] [int] NULL,
	[WaitingList] [int] NULL,
	[ClassDescription] [nvarchar](2000) NULL,
	[ClassDateTo] [nvarchar](20) NOT NULL,
	[Price] [int] NOT NULL,
	[ClassLevel] [nvarchar](50) NOT NULL,
	[CancellationDeadline] [nvarchar](20) NOT NULL,
	[StudioId] [int] NOT NULL
	)
	

CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Ph_num] [nvarchar](10) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[Role] [nvarchar](10) NOT NULL,
	[StudioId] [int] NULL
	)


CREATE TABLE [dbo].[Instructor](
	[StudioId] [int] NOT NULL,
	[InstructorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Ph_num] [nvarchar](10) NOT NULL,
	[YearOfExperience] [int] NULL
	)


CREATE TABLE [dbo].[Studio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zipcode] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[StudioOwner] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[StartDate] [nvarchar](50) NOT NULL
	)


CREATE TABLE [dbo].[Workshop](
	[WorkshopId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InstructorName] [nvarchar](100) NOT NULL,
	[StartTime] [nvarchar](50) NOT NULL,
	[EndTime] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [int] NOT NULL,
	[Prerequisites] [nvarchar](200) NULL,
	[EquipmentRequired] [nvarchar](200) NULL,
	[RegistrationDeadline] [nvarchar](20) NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[CurrentCapacity] [int] NOT NULL,
	[CancellationDeadline] [nvarchar](20) NOT NULL,
	[WorkshopDate] [nvarchar](20) NOT NULL,
	[StudioId] [int] NOT NULL,
	[WaitingList] [int] NOT NULL
	)

CREATE TABLE [dbo].[Workshop_Registration](
	[RegistrationID] [int] IDENTITY(1,1) NOT NULL,
	[WorkshopId] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[RegistrationDate] [nvarchar](50) NOT NULL
	)


CREATE TABLE [dbo].[Workshop_WaitingList](
	[WaitingListID] [int] IDENTITY(1,1) NOT NULL,
	[WorkshopId] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[RegistrationDate] [nvarchar](50) NOT NULL
	)

