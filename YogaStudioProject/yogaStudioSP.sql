SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[AddClass](
@Name nvarchar(100) ,
@InstructorName nvarchar(100),
@StartTime nvarchar(50),
@EndTime nvarchar(50),
@ClassDateForm nvarchar(20),
@MaxCapacity int,
@CurrentCapacity int,
@WaitingList int,
@Description nvarchar(200),
@ClassDateTo nvarchar(20),
@Price int,
@ClassLevel nvarchar(50),
@CancellationDeadline nvarchar(20),
@StudioId int
)
AS
Begin
Insert Into Classes(Name,InstructorName,StartTime,EndTime,ClassDateForm,MaxCapacity,CurrentCapacity,WaitingList,Description,ClassDateTo,Price,ClassLevel,CancellationDeadline,StudioId) values
					(@Name,@InstructorName,@StartTime,@EndTime,@ClassDateForm,@MaxCapacity,@CurrentCapacity,@WaitingList,@Description,@ClassDateTo,@Price,@ClassLevel,@CancellationDeadline,@StudioId)

select * from Classes
End





GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 31-03-2024 13:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[AddClient](
@Name nvarchar(100) ,
@Email nvarchar(100),
@PhoneNumber nvarchar(10),
@Gender nvarchar(10),
@password nvarchar(20),
@StudioId int
)
AS
Begin
Insert Into Client (Name,Email,Ph_num,Gender,password,Role,StudioId) values
(@Name,@Email,@PhoneNumber,@Gender,@password,'Client',@StudioId)

select * from Client
End


GO
/****** Object:  StoredProcedure [dbo].[AddInstructor]    Script Date: 31-03-2024 13:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[AddInstructor](
@StudioId int ,
@Name nvarchar(100),
@Email nvarchar(100),
@PhoneNumber nvarchar(10),
@YearOfExperience int 
)
AS
Begin
Insert Into Instructor (StudioId,Name,Email,Ph_num,YearOfExperience) values
(@StudioId,@Name,@Email,@PhoneNumber,@YearOfExperience)

select * from Instructor
End


GO
/****** Object:  StoredProcedure [dbo].[AddStudio]    Script Date: 31-03-2024 13:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[AddStudio](
@Name nvarchar(100),
@Address nvarchar(200),
@City nvarchar(50),
@State nvarchar(50),
@Zipcode INT,
@Email nvarchar(100),
@StudioOwner nvarchar(100),
@Description nvarchar(200),
@StartDate nvarchar(20),
@Password nvarchar(20),
@role nvarchar(20)
)
AS
Begin
Insert into Studio(Name,Address,City,State,Zipcode,Email,StudioOwner,Description,StartDate,Password,role)
values(@Name,@Address,@City,@State,@Zipcode,@Email,@StudioOwner,@Description,@StartDate,@Password,@role)
End



GO
/****** Object:  StoredProcedure [dbo].[AddWorkshop]    Script Date: 31-03-2024 13:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[AddWorkshop](
@Name nvarchar(100) ,
@InstructorName nvarchar(100),
@StartTime nvarchar(50),
@EndTime nvarchar(50),
@Description nvarchar(200),
@Price int,
@Prerequisites nvarchar(200),
@EquipmentRequired nvarchar(200),
@RegistrationDeadline nvarchar(20),
@MaxCapacity int,
@CurrentCapacity int,
@CancellationDeadline nvarchar(20),
@WorkshopDate nvarchar(20),
@StudioId int,
@WaitingList int
)
AS
Begin
Insert Into Workshop (Name,InstructorName,StartTime,EndTime,Description,Price,Prerequisites,EquipmentRequired,RegistrationDeadline,MaxCapacity,CurrentCapacity,CancellationDeadline,WorkshopDate,StudioId,WaitingList) values
(@Name,@InstructorName,@StartTime,@EndTime,@Description,@Price,@Prerequisites,@EquipmentRequired,@RegistrationDeadline,@MaxCapacity,@CurrentCapacity,@CancellationDeadline,@WorkshopDate,@StudioId,@WaitingList)

select * from Workshop
End



GO
/****** Object:  StoredProcedure [dbo].[Cancle_Cls_WS]    Script Date: 31-03-2024 13:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Cancle_Cls_WS](
@Id int,
@ClientId int,
@Type nvarchar(20)
)
AS
Begin
if(@Type ='Workshop')
Begin
  if Exists (select ClientID, WorkshopId from  Workshop_Registration where  ClientID=@ClientId and WorkshopId=@Id)
  Begin
     Delete from Workshop_Registration where ClientID=@ClientId and WorkshopId=@Id
     
     Insert into Workshop_Registration (WorkshopId,ClientID,RegistrationDate) 
     (select top 1 WorkshopId,ClientID,RegistrationDate  from Workshop_WaitingList where WorkshopId=@Id)
     
     Delete from Workshop_Registration where ClientID =(select top 1 ClientID from Workshop_WaitingList where WorkshopId=@Id)
  End
  
  Else
    Delete from Workshop_WaitingList where ClientID=@ClientId and WorkshopId=@Id
End

else if(@Type='Class')
Begin
 if Exists (select ClientID, ClassId from  Class_Reservation where  ClientID=@ClientId and ClassId=@Id)
  Begin
     Delete from Class_Reservation where ClientID=@ClientId and ClassId=@Id
     
     Insert into Class_Reservation (ClassId,ClientID,ReservationDate) 
     (select top 1 ClassId,ClientID,ReservationDate  from Class_WaitingList where ClassId=@Id)
     
     Delete from Class_WaitingList where ClientID =(select top 1 ClientID from Class_WaitingList where ClassId=@Id)
  End
  
  Else
    Delete from Class_WaitingList where ClientID=@ClientId and ClassId=@Id
End
END



GO
/****** Object:  StoredProcedure [dbo].[ClassReservation_List]    Script Date: 31-03-2024 13:11:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[ClassReservation_List](
@ClientId int
)
AS
Begin
select cls.* from Class_Reservation cw
join Classes cls ON cw.ClassId=cls.ClassId
where cw.ClientId =@ClientId
END




GO
/****** Object:  StoredProcedure [dbo].[Course_Reservation]    Script Date: 31-03-2024 13:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Course_Reservation](
@course nvarchar(20),
@Id INT,
@ClientID INT,
@RegistrationDate Date
) --ReservationID	ClassId	ClientId	ReservationDate
AS
BEGIN
If @course = 'Classes'
Begin
Insert into Class_Reservation (ClassId,ClientID,ReservationDate) Values
(@Id,@ClientID,@RegistrationDate)
End
Else If @course ='Workshop'
Begin
Insert into Workshop_Registration(WorkshopId,ClientID,RegistrationDate) Values
(@Id,@ClientID,@RegistrationDate)
End
END


GO
/****** Object:  StoredProcedure [dbo].[Dashboard]    Script Date: 31-03-2024 13:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Dashboard]
    @StudioId INT
AS
BEGIN
    SELECT
        (SELECT COUNT(*) FROM Classes WHERE StudioId = @StudioId) AS ClassCount,
        (SELECT COUNT(*) FROM Workshop WHERE StudioId = @StudioId) AS WorkshopCount,
        (SELECT COUNT(*) FROM Instructor WHERE StudioId = @StudioId) AS InstructorCount,
        (SELECT COUNT(*) FROM Client WHERE StudioId = @StudioId) AS ClientCount
END

EXEC Dashboard @StudioId = 2;

GO
/****** Object:  StoredProcedure [dbo].[GetAllClasses]    Script Date: 31-03-2024 13:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetAllClasses]
@studioId INT
AS
Begin
select * from Classes c where c.StudioId=@studioId
End


GO
/****** Object:  StoredProcedure [dbo].[GetallClasses_Client]    Script Date: 31-03-2024 13:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetallClasses_Client](
@StudioId int,
@ClientId int
)
AS
Begin
select * from Classes where StudioId=@StudioId and ClassId NOT IN(select ClassId from Class_Reservation where ClientId=@ClientId) and ClassId NOT IN(select ClassId from Class_WaitingList where ClientId=@ClientId)

END


GO
/****** Object:  StoredProcedure [dbo].[GetAllClients]    Script Date: 31-03-2024 13:12:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [GetAllClients]
    @studioId INT
AS
BEGIN

    SELECT *
    FROM Client c
    WHERE c.StudioId = @studioId;
END;

EXEC [GetAllWorkshop] @studioId = 8;

GO
/****** Object:  StoredProcedure [dbo].[GetAllInstructors]    Script Date: 31-03-2024 13:12:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetAllInstructors]
    @studioId INT

AS
Begin
select * from Instructor i where i.StudioId=@studioId
End


GO
/****** Object:  StoredProcedure [dbo].[GetAllWorkshop]    Script Date: 31-03-2024 13:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetAllWorkshop]
    @studioId INT

AS
Begin
select * from Workshop w where w.StudioId=@studioId
End


GO
/****** Object:  StoredProcedure [dbo].[GetallWorkshops_Client]    Script Date: 31-03-2024 13:13:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetallWorkshops_Client](
@StudioId int,
@ClientId int
)
AS
Begin
select * from Workshop where StudioId=@StudioId and WorkshopId NOT IN(select WorkshopId from Workshop_Registration where ClientId=@ClientId) and WorkshopId NOT IN(select WorkshopId from Workshop_WaitingList where ClientId=@ClientId)
END


GO
/****** Object:  StoredProcedure [dbo].[GetLogindetails]    Script Date: 31-03-2024 13:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetLogindetails](
@Email nvarchar(100),
@password nvarchar(20)
)
AS
Begin
if exists (select * from Studio where Email=@Email and password=@password)
Begin
select * from Studio where Email=@Email and password=@password
End
else if exists (select * from Client where Email=@Email and password=@password)
Begin
select * from Client where Email=@Email and password=@password
End
End



GO
/****** Object:  StoredProcedure [dbo].[Getstudio]    Script Date: 31-03-2024 13:13:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[Getstudio]
AS
Begin
select * from Studio
End


GO
/****** Object:  StoredProcedure [dbo].[RemoveClass]    Script Date: 31-03-2024 13:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[RemoveClass](
@ClassId Int
)
AS
Begin
Delete from Classes where ClassId=@ClassId
select * from Classes
End


GO
/****** Object:  StoredProcedure [dbo].[RemoveClient]    Script Date: 31-03-2024 13:14:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[RemoveClient](
@ClientId Int
)
AS
Begin
Delete from Client where ClientID=@ClientId
select * from Client
End


GO
/****** Object:  StoredProcedure [dbo].[RemoveInstructor]    Script Date: 31-03-2024 13:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[RemoveInstructor](
@InstructorID Int
)
AS
Begin
Delete from Instructor where InstructorID=@InstructorID
select * from Instructor
End


GO
/****** Object:  StoredProcedure [dbo].[RemoveWorkshop]    Script Date: 31-03-2024 13:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[RemoveWorkshop](
@WorkshopId Int
)
AS
Begin
Delete from Workshop where WorkshopId=@WorkshopId
select * from Workshop
End


GO
/****** Object:  StoredProcedure [dbo].[Reservation_Class]    Script Date: 31-03-2024 13:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Reservation_Class](
    @ClassId INT,
    @ClientId INT
)
AS
BEGIN
    DECLARE @Capacity INT, @MaxCapacity INT, @Waiting INT

    SELECT @Capacity = CurrentCapacity, @MaxCapacity = MaxCapacity, @Waiting = WaitingList
    FROM Classes
    WHERE ClassId = @ClassId

    IF (@Capacity < @MaxCapacity)
    BEGIN
        BEGIN TRANSACTION;

        INSERT INTO Class_Reservation (ClassId, ClientId, ReservationDate)
        VALUES (@ClassId, @ClientId, GETDATE())

        UPDATE Classes SET CurrentCapacity = @Capacity + 1 WHERE ClassId = @ClassId

        COMMIT TRANSACTION;

        SELECT 'Registration successful' AS Status
    END
    ELSE IF (@Waiting < @MaxCapacity) -- Check if waiting list has space
    BEGIN
        BEGIN TRANSACTION;

        INSERT INTO Class_WaitingList (ClassId, ClientId, ReservationDate)
        VALUES (@ClassId, @ClientId, GETDATE())

        UPDATE Classes SET WaitingList = @Waiting + 1 WHERE ClassId = @ClassId

        COMMIT TRANSACTION;

        SELECT 'Added to waiting list' AS Status
    END
    ELSE
    BEGIN
        SELECT 'Class is full and waiting list is full' AS Status
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Reservation_Workshop]    Script Date: 31-03-2024 13:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Reservation_Workshop](
@WorkshopId int,
@ClientId int
)
AS
Begin
declare @Capacity int, @MaxCapacity int,@Waiting int
set @Capacity = (select CurrentCapacity from Workshop where WorkshopId=@WorkshopId)
set @MaxCapacity =(select MaxCapacity from Workshop where WorkshopId=@WorkshopId)
set @Waiting =(select  WaitingList from Workshop where WorkshopId=@WorkshopId)
If(@Capacity<@MaxCapacity)
Begin
print'If'
Insert into Workshop_Registration (WorkshopId,ClientId,RegistrationDate)
values(@WorkshopId,@ClientId,GETDATE())

Update Workshop set CurrentCapacity=@Capacity + 1
End

Else
Begin
print'else'
Insert into Workshop_WaitingList (WorkshopId,ClientId,RegistrationDate)
values(@WorkshopId,@ClientId,GETDATE())

update Workshop set WaitingList=@Waiting+1
End
End


GO
/****** Object:  StoredProcedure [dbo].[UpdateClass]    Script Date: 31-03-2024 13:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateClass](
@ClassId Int,
@Name nvarchar(100) ,
@InstructorName nvarchar(100),
@StartTime nvarchar(50),
@EndTime nvarchar(50),
@ClassDateForm nvarchar(20),
@MaxCapacity int,
@CurrentCapacity int,
@WaitingList int,
@Description nvarchar(200),
@ClassDateTo nvarchar(20),
@Price int,
@ClassLevel nvarchar(50),
@CancellationDeadline nvarchar(20),
@StudioId int
)
AS
Begin
Update Classes set Name=@Name,InstructorName=@InstructorName,StartTime=@StartTime,EndTime=@EndTime,ClassDateForm=@ClassDateForm,
MaxCapacity=@MaxCapacity,CurrentCapacity=@CurrentCapacity,WaitingList=@WaitingList,Description=@Description,ClassDateTo=@ClassDateTo,
Price=@Price,ClassLevel=@ClassLevel,CancellationDeadline=@CancellationDeadline,StudioId=@StudioId
where ClassId=@ClassId
select * from Classes
End


GO
/****** Object:  StoredProcedure [dbo].[UpdateClient]    Script Date: 31-03-2024 13:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateClient](
@ClientId Int,
@Name nvarchar(100) ,
@Email nvarchar(100),
@PhoneNumber nvarchar(10),
@Gender nvarchar(10),
@password nvarchar(20),
@StudioId int
)
AS
Begin
Update client set Name=@Name,Email=@Email,Ph_num=@PhoneNumber,Gender=@Gender,password=@password,StudioId=@StudioId where ClientID=@ClientId
select * from Client
End


GO
/****** Object:  StoredProcedure [dbo].[UpdateInstructor]    Script Date: 31-03-2024 13:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateInstructor](
@StudioId int,
@InstructorID Int,
@Name nvarchar(100) ,
@Email nvarchar(100),
@PhoneNumber nvarchar(10),
@YearOfExperience int
)
AS
Begin
Update Instructor set StudioId=@StudioId, Name=@Name,Email=@Email,Ph_num=@PhoneNumber,@YearOfExperience=@YearOfExperience where InstructorID=@InstructorID
select * from Instructor
End


GO
/****** Object:  StoredProcedure [dbo].[UpdateWorkshop]    Script Date: 31-03-2024 13:15:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateWorkshop](
@WorkshopId Int,
@Name nvarchar(100) ,
@InstructorName nvarchar(100),
@StartTime nvarchar(50),
@EndTime nvarchar(50),
@Description nvarchar(200),
@Price int,
@Prerequisites nvarchar(200),
@EquipmentRequired nvarchar(200),
@RegistrationDeadline nvarchar(20),
@MaxCapacity int,
@CurrentCapacity int,
@CancellationDeadline nvarchar(20),
@WorkshopDate nvarchar(20),
@StudioId int,
@WaitingList int
)
AS
Begin
Update Workshop set Name=@Name,InstructorName=@InstructorName,StartTime=@StartTime,EndTime=@EndTime,
Description=@Description,Price=@Price,Prerequisites=@Prerequisites,EquipmentRequired=@EquipmentRequired,
RegistrationDeadline=@RegistrationDeadline,MaxCapacity=@MaxCapacity,CurrentCapacity=@CurrentCapacity,CancellationDeadline=@CancellationDeadline,WorkshopDate=@WorkshopDate,StudioId=@StudioId,WaitingList =@WaitingList
where WorkshopId=@WorkshopId
select * from Workshop
End


GO
/****** Object:  StoredProcedure [dbo].[WorkshopReservation_List]    Script Date: 31-03-2024 13:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[WorkshopReservation_List](
@ClientId int
)
AS
Begin
select ws.* from Workshop_Registration wr
join Workshop ws ON wr.WorkshopId=ws.WorkshopId
where wr.ClientId =@ClientId
END


GO

ALTER TABLE Studio
ADD password VARCHAR(255);


ALTER TABLE Studio
ADD role VARCHAR(255);

ALTER PROCEDURE [GetClientNamesFromWaitingList]
    @classId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT c.Name AS ClientName
    FROM Class_WaitingList cw
    Left JOIN Client c ON cw.ClientId = c.ClientID
    WHERE cw.ClassId = @classId;
END;

EXEC GetClientNamesFromWaitingList @classId = 6;