USE master
GO

USE GuildCars
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'HomePageFS')
BEGIN
   DROP PROCEDURE HomePageFS
END
GO
CREATE PROCEDURE HomePageFS
	AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, c.ColorId, c.InteriorId, c.Mileage, c.MSRP, c.SalePrice, c.VINnumber, c.ImageFileName, c.IsFeatured
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	CROSS JOIN Special
	WHERE c.IsFeatured = 1
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetStates')
BEGIN
   DROP PROCEDURE GetStates
END
GO
CREATE PROCEDURE GetStates
	AS
	SELECT *
	FROM States
	ORDER BY StateName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetPurchaseType')
BEGIN
   DROP PROCEDURE GetPurchaseType
END
GO
CREATE PROCEDURE GetPurchaseType
	AS
	SELECT *
	FROM PurchaseType p
	ORDER BY PurchaseTypeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllFeatured')
BEGIN
   DROP PROCEDURE GetAllFeatured
END
GO
CREATE PROCEDURE GetAllFeatured
	AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE IsFeatured = 1
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllByCarId')
BEGIN
   DROP PROCEDURE GetAllByCarId
END
GO
CREATE PROCEDURE GetAllByCarId (
	@CarId int
)
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE c.CarId = @CarId
	ORDER BY MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllByMake')
BEGIN
   DROP PROCEDURE GetAllByMake
END
GO
CREATE PROCEDURE GetAllByMake (
	@MakeName nvarchar(60)
)
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE a.MakeName = @MakeName
	ORDER BY MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllByModel')
BEGIN
   DROP PROCEDURE GetAllByModel
END
GO
CREATE PROCEDURE GetAllByModel (
	@ModelName nvarchar(60)
)
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE o.ModelName = @ModelName
	ORDER BY MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllByYear')
BEGIN
   DROP PROCEDURE GetAllByYear
END
GO
CREATE PROCEDURE GetAllByYear (
	@Year nvarchar(60)
)
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	ORDER BY MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllSpecials')
BEGIN
   DROP PROCEDURE GetAllSpecials
END
GO
CREATE PROCEDURE GetAllSpecials
AS
	SELECT *
	FROM Special
	ORDER BY SpecialTitle
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarModelsByMakeId')
BEGIN
   DROP PROCEDURE GetCarModelsByMakeId
END
GO
CREATE PROCEDURE GetCarModelsByMakeId (
	@CarMakeId int
)
AS
	SELECT mo.ModelName, mo.CarModelId
	FROM CarModel mo
	WHERE mo.CarMakeId = @CarMakeId
	ORDER BY ModelName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarMake')
BEGIN
   DROP PROCEDURE GetCarMake
END
GO
CREATE PROCEDURE GetCarMake
AS
	SELECT *
	FROM CarMake
	ORDER BY MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarMakeWithUser')
BEGIN
   DROP PROCEDURE GetCarMakeWithUser
END
GO
CREATE PROCEDURE GetCarMakeWithUser
AS
	SELECT c.CarMakeId, c.MakeName, c.DateAdded
	FROM CarMake c
	ORDER BY c.MakeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarModel')
BEGIN
   DROP PROCEDURE GetCarModel
END
GO
CREATE PROCEDURE GetCarModel
AS
	SELECT *
	FROM CarModel
	ORDER BY ModelName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarModelWithUser')
BEGIN
   DROP PROCEDURE GetCarModelWithUser
END
GO
CREATE PROCEDURE GetCarModelWithUser
AS
	SELECT c.CarModelId, c.CarMakeId, c.ModelName, c.DateAdded
	FROM CarModel c
	LEFT JOIN CarMake m on c.CarMakeId = m.CarMakeId
	ORDER BY c.ModelName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetCarType')
BEGIN
   DROP PROCEDURE GetCarType
END
GO
CREATE PROCEDURE GetCarType
AS
	SELECT *
	FROM CarType
	ORDER BY TypeName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetBodyStyle')
BEGIN
   DROP PROCEDURE GetBodyStyle
END
GO
CREATE PROCEDURE GetBodyStyle
AS
	SELECT *
	FROM BodyStyle
	ORDER BY BodyStyleName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetTransmission')
BEGIN
   DROP PROCEDURE GetTransmission
END
GO
CREATE PROCEDURE GetTransmission
AS
	SELECT *
	FROM Transmission
	ORDER BY TransmissionName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetColor')
BEGIN
   DROP PROCEDURE GetColor
END
GO
CREATE PROCEDURE GetColor
AS
	SELECT *
	FROM Color
	ORDER BY ColorName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetInterior')
BEGIN
   DROP PROCEDURE GetInterior
END
GO
CREATE PROCEDURE GetInterior
AS
	SELECT *
	FROM Interior
	ORDER BY InteriorName
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecialById')
BEGIN
   DROP PROCEDURE GetSpecialById
END
GO
CREATE PROCEDURE GetSpecialById (
	@SpecialId int
)
AS
	SELECT *
	FROM Special
	WHERE SpecialId = @SpecialId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaveImageToCar')
BEGIN
   DROP PROCEDURE SaveImageToCar
END
GO
CREATE PROCEDURE SaveImageToCar
	@CarId int,
	@ImageFileName varchar(50)
AS
	UPDATE Car
	SET ImageFileName = @ImageFileName
	WHERE CarId = @CarId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddVehicle')
BEGIN
   DROP PROCEDURE AddVehicle
END
GO
CREATE PROCEDURE AddVehicle
	@Year int,
	@CarMakeId int,
	@CarModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage decimal(10,2),
	@VINnumber nvarchar(40),
	@SalePrice decimal(8,0),
	@MSRP decimal(8,0),
	@CarDescription nvarchar(500),
	@ImageFileName varchar(50),
	@IsFeatured bit,
	@IsPurchased bit
AS
	INSERT INTO Car ([Year], CarMakeId, CarModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, Mileage, VINnumber, SalePrice, MSRP, CarDescription, ImageFileName, IsFeatured, IsPurchased)
	VALUES (@Year, @CarMakeId, @CarModelId, @TypeId, @BodyStyleId, @TransmissionId, @ColorId, @InteriorId, @Mileage, @VINnumber, @SalePrice, @MSRP, @CarDescription, @ImageFileName, @IsFeatured, @IsPurchased);

	SELECT @@IDENTITY AS CarId;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EditVehicle')
BEGIN
   DROP PROCEDURE EditVehicle
END
GO
CREATE PROCEDURE EditVehicle (
	@CarId int,
	@Year int,
	@CarMakeId int,
	@CarModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage decimal(10,2),
	@VINnumber nvarchar(40),
	@SalePrice decimal(8,0),
	@MSRP decimal(8,0),
	@CarDescription nvarchar(500),
	@ImageFileName varchar(50),
	@IsFeatured bit,
	@IsPurchased bit
)
AS
BEGIN
	UPDATE Car
	SET [Year] = @Year,
		CarMakeId = @CarMakeId,
		CarModelId = @CarModelId,
		BodyStyleId = @BodyStyleId,
		TransmissionId = @TransmissionId,
		ColorId = @ColorId,
		InteriorId = @InteriorId,
		Mileage = @Mileage,
		VINnumber = @VINnumber,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		CarDescription = @CarDescription,
		ImageFileName = @ImageFileName,
		IsFeatured = @IsFeatured,
		IsPurchased = @IsPurchased
	WHERE CarId = @CarId
END
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteVehicle')
BEGIN
    DROP PROCEDURE DeleteVehicle
END
GO
CREATE PROCEDURE DeleteVehicle (
	@CarId int
)
AS
	DELETE FROM Car
	WHERE CarId = @CarId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddVehicleMake')
BEGIN
   DROP PROCEDURE AddVehicleMake
END
GO
CREATE PROCEDURE AddVehicleMake (
	@MakeName nvarchar(60),
	@User nvarchar(40)
)
AS
	INSERT INTO CarMake(MakeName, [User], DateAdded)
	VALUES (@MakeName, @User, CURRENT_TIMESTAMP);

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddVehicleModel')
BEGIN
   DROP PROCEDURE AddVehicleModel
END
GO
CREATE PROCEDURE AddVehicleModel (
	@ModelName nvarchar(60),
	@MakeId int,
	@User nvarchar(128)
)
AS
	INSERT INTO CarModel(ModelName, [User], DateAdded, CarMakeId)
	VALUES (@ModelName, @User, CURRENT_TIMESTAMP, @MakeId);

GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddSpecial')
BEGIN
   DROP PROCEDURE AddSpecial
END
GO
CREATE PROCEDURE AddSpecial
	@SpecialTitle nvarchar(40),
	@SpecialDescription nvarchar(500)
AS
	INSERT INTO Special(SpecialTitle, SpecialDescription)
	VALUES (@SpecialTitle, @SpecialDescription);

GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteSpecial')
BEGIN
    DROP PROCEDURE DeleteSpecial
END
GO
CREATE PROCEDURE DeleteSpecial (
	@SpecialId int
)
AS
	DELETE FROM Special
	WHERE SpecialId = @SpecialId
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetNewInventory')
BEGIN
    DROP PROCEDURE GetNewInventory
END
GO
CREATE PROCEDURE GetNewInventory
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE c.Mileage <= 1000 AND c.IsPurchased = 0
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUsedInventory')
BEGIN
    DROP PROCEDURE GetUsedInventory
END
GO
CREATE PROCEDURE GetUsedInventory
AS
	SELECT c.CarId, c.[Year], a.CarMakeId, a.MakeName, o.CarModelId, o.ModelName, ty.TypeId, ty.TypeName, b.BodyStyleId, b.BodyStyleName, t.TransmissionId, t.TransmissionName, co.ColorId, co.ColorName, i.InteriorId, i.InteriorName, c.Mileage, c.VINnumber, c.SalePrice, c.MSRP, c.CarDescription, c.ImageFileName, c.IsFeatured, c.IsPurchased
	FROM Car c
	LEFT JOIN CarMake a on c.CarMakeId = a.CarMakeId
	LEFT JOIN CarModel o on c.CarModelId = o.CarModelId
	LEFT JOIN CarType ty on c.TypeId = ty.TypeId
	LEFT JOIN BodyStyle b on c.BodyStyleId = b.BodyStyleId
	LEFT JOIN Transmission t on c.TransmissionId = t.TransmissionId
	LEFT JOIN Color co on c.ColorId = co.ColorId
	LEFT JOIN Interior i on c.InteriorId = i.InteriorId
	WHERE c.Mileage > 1000 AND c.IsPurchased = 0
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SubmitContactUs')
BEGIN
   DROP PROCEDURE SubmitContactUs
END
GO
CREATE PROCEDURE SubmitContactUs
	@Name nvarchar(60),
	@Email nvarchar(60),
	@Phone nvarchar(15),
	@Message nvarchar(500)
AS
	INSERT INTO ContactUs([Name], Email, Phone, [Message])
	VALUES (@Name, @Email, @Phone, @Message);
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseVehicle')
BEGIN
   DROP PROCEDURE PurchaseVehicle
END
GO
CREATE PROCEDURE PurchaseVehicle
	@CarId int,
	@Name nvarchar(75),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@City varchar(30),
	@StateId char(2),
	@ZipCode int,
	@Phone nvarchar(25),
	@Email nvarchar(50),
	@IsPurchased bit,
	@PurchasePrice decimal(10,2),
	@PurchaseTypeId int,
	@SalesPerson nvarchar(30),
	@DatePurchased datetime
AS
	INSERT INTO Customer(CarId, [Name], Address1, Address2, City, StateId, ZipCode, Phone, Email)
	VALUES (@CarId, @Name, @Address1, @Address2, @City, @StateId, @ZipCode, @Phone, @Email)
	INSERT INTO Purchase(CarId, PurchasePrice, PurchaseTypeId, SalesPerson, DatePurchased)
	VALUES (@CarId, @PurchasePrice, @PurchaseTypeId, @SalesPerson, CURRENT_TIMESTAMP)
	UPDATE Car
	SET IsPurchased = @IsPurchased
	WHERE CarId = @CarId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'NewInventoryReport')
BEGIN
   DROP PROCEDURE NewInventoryReport
END
GO
CREATE PROCEDURE NewInventoryReport
AS
    SELECT Count(*) AS TotalVehicles, SUM(c.MSRP) as TotalValue, c.[Year], k.MakeName, m.ModelName
    FROM Car c
	INNER JOIN CarModel m on m.CarModelId = c.CarModelId
	INNER JOIN CarMake k on k.CarMakeId = m.CarMakeId
	WHERE c.Mileage <= 1000 AND IsPurchased = 0
	GROUP BY k.MakeName, m.ModelName, c.[Year]
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UsedInventoryReport')
BEGIN
   DROP PROCEDURE UsedInventoryReport
END
GO
CREATE PROCEDURE UsedInventoryReport
AS
    SELECT Count(*) AS TotalVehicles, SUM(c.MSRP) as TotalValue, c.[Year], k.MakeName, m.ModelName
    FROM Car c
	INNER JOIN CarModel m on m.CarModelId = c.CarModelId
	INNER JOIN CarMake k on k.CarMakeId = m.CarMakeId
	WHERE c.Mileage > 1000 AND IsPurchased = 0
	GROUP BY k.MakeName, m.ModelName, c.[Year]
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesReport')
BEGIN
   DROP PROCEDURE SalesReport
END
GO
CREATE PROCEDURE SalesReport
	@User nvarchar (100),
	@StartDate DateTime,
	@EndDate DateTime
AS
    SELECT Count(*) AS TotalVehicles, SUM(p.PurchasePrice) as TotalValue, p.SalesPerson
    FROM Purchase p
	WHERE p.DatePurchased BETWEEN @StartDate AND @EndDate AND p.SalesPerson = ISNULL(@User, p.SalesPerson)
	GROUP BY p.SalesPerson
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AllSalesReports')
BEGIN
   DROP PROCEDURE AllSalesReports
END
GO
CREATE PROCEDURE AllSalesReports
AS
    SELECT Count(*) AS TotalVehicles, SUM(p.PurchasePrice) as TotalValue, p.SalesPerson
    FROM Purchase p
	GROUP BY p.SalesPerson
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesReportByDate')
BEGIN
   DROP PROCEDURE SalesReportByDate
END
GO
CREATE PROCEDURE SalesReportByDate
	@StartDate DateTime,
	@EndDate DateTime
AS
    SELECT Count(*) AS TotalVehicles, SUM(p.PurchasePrice) as TotalValue, p.SalesPerson
    FROM Purchase p
	WHERE p.DatePurchased BETWEEN @StartDate AND @EndDate
	GROUP BY p.SalesPerson
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllUsers')
BEGIN
   DROP PROCEDURE GetAllUsers
END
GO
CREATE PROCEDURE GetAllUsers
AS
    SELECT u.Id, u.Email, u.UserName, r.[Name]
    FROM AspNetUsers u
	LEFT JOIN AspNetUserRoles a ON a.UserId = u.Id
	LEFT JOIN AspNetRoles r ON r.Id = a.RoleId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUserById')
BEGIN
   DROP PROCEDURE GetUserById
END
GO
CREATE PROCEDURE GetUserById
	@Id nvarchar(200)
AS
    SELECT u.Id, u.Email, u.UserName, r.[Name], u.PasswordHash
    FROM AspNetUsers u
	LEFT JOIN AspNetUserRoles a ON a.UserId = u.Id
	LEFT JOIN AspNetRoles r ON r.Id = a.RoleId
	WHERE u.Id = @Id;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUserByName')
BEGIN
   DROP PROCEDURE GetUserByName
END
GO
CREATE PROCEDURE GetUserByName
	@UserName nvarchar(256)
AS
    SELECT u.Id, u.Email, u.UserName, r.[Name], u.PasswordHash
    FROM AspNetUsers u
	LEFT JOIN AspNetUserRoles a ON a.UserId = u.Id
	LEFT JOIN AspNetRoles r ON r.Id = a.RoleId
	WHERE u.UserName = @UserName;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllRoles')
BEGIN
   DROP PROCEDURE GetAllRoles
END
GO
CREATE PROCEDURE GetAllRoles
AS
    SELECT *
    FROM AspNetRoles
	ORDER BY [Name];
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddRoleToUser')
BEGIN
   DROP PROCEDURE AddRoleToUser
END
GO
CREATE PROCEDURE AddRoleToUser
	@UserId nvarchar(128),
	@RoleId nvarchar(128)
AS
	UPDATE AspNetUserRoles
	SET RoleId = @RoleId
	WHERE UserId = @UserId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddUser')
BEGIN
   DROP PROCEDURE AddUser
END
GO
CREATE PROCEDURE AddUser
	@Id nvarchar(128),
	@Email nvarchar(256),
	@EmailConfirmed bit,
	@PasswordHash nvarchar(MAX),
	@SecurityStamp nvarchar(MAX),
	@PhoneNumber nvarchar(MAX),
	@PhoneNumberConfirmed bit,
	@TwoFactorEnabled bit,
	@LockoutEndDateUtc datetime,
	@LockoutEnabled bit,
	@AccessFailedCount int,
	@UserName nvarchar(256)
AS
	INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled,
							LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
	VALUES (@Id, @Email, @EmailConfirmed, @PasswordHash, @SecurityStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled,
			@LockoutEndDateUtc, @LockoutEnabled, @AccessFailedCount, @UserName);

	SELECT Id from AspNetUsers WHERE Email = @Email;

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EditUser')
BEGIN
   DROP PROCEDURE EditUser
END
GO
CREATE PROCEDURE EditUser
	@Id nvarchar(128),
	@Email nvarchar(256),
	@EmailConfirmed bit,
	@PasswordHash nvarchar(MAX),
	@SecurityStamp nvarchar(MAX),
	@PhoneNumber nvarchar(MAX),
	@PhoneNumberConfirmed bit,
	@TwoFactorEnabled bit,
	@LockoutEndDateUtc datetime,
	@LockoutEnabled bit,
	@AccessFailedCount int,
	@UserName nvarchar(256)
AS
	UPDATE AspNetUsers
	SET Email = @Email,
		EmailConfirmed = @EmailConfirmed, 
		PasswordHash = @PasswordHash, 
		SecurityStamp = @SecurityStamp, 
		PhoneNumber = @PhoneNumber, 
		PhoneNumberConfirmed = @PhoneNumberConfirmed, 
		TwoFactorEnabled = @TwoFactorEnabled,		
		LockoutEndDateUtc = @LockoutEndDateUtc,
		LockoutEnabled = @LockoutEnabled,
		AccessFailedCount = @AccessFailedCount,
		UserName = @UserName
	WHERE Id = @Id

GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteUser')
BEGIN
    DROP PROCEDURE DeleteUser
END
GO
CREATE PROCEDURE DeleteUser (
	@Id nvarchar(128)
)
AS
	DELETE FROM AspNetUsers
	WHERE Id = @Id
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ChangePassword')
BEGIN
   DROP PROCEDURE ChangePassword
END
GO
CREATE PROCEDURE ChangePassword (
	@Id nvarchar(128),
	@PasswordHash nvarchar(MAX)
)
AS
	UPDATE AspNetUsers
	SET PasswordHash = @PasswordHash
	WHERE Id = @Id

GO

