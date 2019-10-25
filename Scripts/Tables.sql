<<<<<<< HEAD
USE master
GO

USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'ContactUs')
	DROP TABLE ContactUs;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CustomerPurchase')
	DROP TABLE CustomerPurchase;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Customer')
	DROP TABLE Customer;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Purchase')
	DROP TABLE Purchase;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'PurchaseType')
	DROP TABLE PurchaseType;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Car')
	DROP TABLE Car;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Interior')
	DROP TABLE Interior;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Color')
	DROP TABLE Color;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Transmission')
	DROP TABLE Transmission;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'BodyStyle')
	DROP TABLE BodyStyle;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarType')
	DROP TABLE CarType;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarModel')
	DROP TABLE CarModel;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarMake')
	DROP TABLE CarMake;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Special')
	DROP TABLE Special;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'States')
	DROP TABLE States;
GO

CREATE TABLE States (
	StateId char(2) not null primary key,
	StateName varchar(15) not null
)

CREATE TABLE Special (
	SpecialId int identity(1,1) primary key not null,
	SpecialTitle nvarchar(40) not null,
	SpecialDescription nvarchar(500) not null
)

CREATE TABLE CarMake (
	CarMakeId int identity(1,1) primary key not null,
	MakeName nvarchar(60) not null,
	[User] nvarchar(128) not null,
	DateAdded datetime not null default(getdate())
)

CREATE TABLE CarModel (
	CarModelId int identity(1,1) primary key not null,
	CarMakeId int foreign key references CarMake(CarMakeId) not null,
	ModelName nvarchar(60) not null,
	[User] nvarchar(128) not null,
	DateAdded datetime not null default(getdate())
)

CREATE TABLE CarType (
	TypeId int identity(1,1) primary key not null,
	TypeName nvarchar(40) not null
)

CREATE TABLE BodyStyle (
	BodyStyleId int identity(1,1) primary key not null,
	BodyStyleName nvarchar(40) not null
)

CREATE TABLE Transmission (
	TransmissionId int identity(1,1) primary key not null,
	TransmissionName nvarchar(40) not null
)

CREATE TABLE Color (
	ColorId int identity(1,1) primary key not null,
	ColorName nvarchar(40) not null
)

CREATE TABLE Interior (
	InteriorId int identity(1,1) primary key not null,
	InteriorName nvarchar(40) not null
)

CREATE TABLE Car (
	CarId int identity(1,1) primary key not null,
	[Year] int not null,
	CarMakeId int foreign key references CarMake(CarMakeId) not null,
	CarModelId int foreign key references CarModel(CarModelId) not null,
	TypeId int foreign key references CarType(TypeId) not null,
	BodyStyleId int foreign key references BodyStyle(BodyStyleId) not null,
	TransmissionId int foreign key references Transmission(TransmissionId) not null,
	ColorId int foreign key references Color(ColorId) not null,
	InteriorId int foreign key references Interior(InteriorId) not null,
	Mileage decimal(10,2) not null,
	VINnumber nvarchar(40) not null,
	SalePrice decimal(8,0) not null,
	MSRP decimal(8,0) not null,
	CarDescription nvarchar(500) null,
	ImageFileName varchar(50),
	IsFeatured bit,
	IsPurchased bit
)

CREATE TABLE PurchaseType (
	PurchaseTypeId int identity(1,1) primary key not null,
	PurchaseTypeName nvarchar(40) not null
)

CREATE TABLE Purchase (
	PurchaseId int identity(1,1) primary key not null,
	CarId int foreign key references Car(CarId) not null,
	PurchasePrice decimal(10,2) not null,
	PurchaseTypeId int foreign key references PurchaseType(PurchaseTypeId) not null,
	SalesPerson nvarchar(30) not null,
	DatePurchased datetime not null default(getdate())
)

CREATE TABLE Customer (
	CustomerId int identity(1,1) primary key,
	CarId int foreign key references Car(CarId) not null,
	[Name] nvarchar(75) not null,
	Address1 varchar(50) not null,
	Address2 varchar(50) null,
	City varchar(30) not null,
	StateId char(2) foreign key references States(StateId) not null,
	ZipCode int not null,
	Phone nvarchar(25) not null,
	Email nvarchar(50) not null
)

CREATE TABLE CustomerPurchase (
	CustomerPurchaseId int identity(1,1) primary key,
	CustomerId int foreign key references Customer(CustomerId) not null,
	PurchaseId int foreign key references Purchase(PurchaseId) not null
)

CREATE TABLE ContactUs (
	ContactUsId int identity(1,1) primary key not null,
	[Name] nvarchar(60) not null,
	Email nvarchar(60) not null,
	Phone nvarchar(15) not null,
	[Message] nvarchar(500) null
=======
USE master
GO

USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'ContactUs')
	DROP TABLE ContactUs;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CustomerPurchase')
	DROP TABLE CustomerPurchase;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Customer')
	DROP TABLE Customer;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Purchase')
	DROP TABLE Purchase;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'PurchaseType')
	DROP TABLE PurchaseType;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Car')
	DROP TABLE Car;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Interior')
	DROP TABLE Interior;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Color')
	DROP TABLE Color;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Transmission')
	DROP TABLE Transmission;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'BodyStyle')
	DROP TABLE BodyStyle;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarType')
	DROP TABLE CarType;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarModel')
	DROP TABLE CarModel;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'CarMake')
	DROP TABLE CarMake;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Special')
	DROP TABLE Special;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'States')
	DROP TABLE States;
GO

CREATE TABLE States (
	StateId char(2) not null primary key,
	StateName varchar(15) not null
)

CREATE TABLE Special (
	SpecialId int identity(1,1) primary key not null,
	SpecialTitle nvarchar(40) not null,
	SpecialDescription nvarchar(500) not null
)

CREATE TABLE CarMake (
	CarMakeId int identity(1,1) primary key not null,
	MakeName nvarchar(60) not null,
	[User] nvarchar(128) not null,
	DateAdded datetime not null default(getdate())
)

CREATE TABLE CarModel (
	CarModelId int identity(1,1) primary key not null,
	CarMakeId int foreign key references CarMake(CarMakeId) not null,
	ModelName nvarchar(60) not null,
	[User] nvarchar(128) not null,
	DateAdded datetime not null default(getdate())
)

CREATE TABLE CarType (
	TypeId int identity(1,1) primary key not null,
	TypeName nvarchar(40) not null
)

CREATE TABLE BodyStyle (
	BodyStyleId int identity(1,1) primary key not null,
	BodyStyleName nvarchar(40) not null
)

CREATE TABLE Transmission (
	TransmissionId int identity(1,1) primary key not null,
	TransmissionName nvarchar(40) not null
)

CREATE TABLE Color (
	ColorId int identity(1,1) primary key not null,
	ColorName nvarchar(40) not null
)

CREATE TABLE Interior (
	InteriorId int identity(1,1) primary key not null,
	InteriorName nvarchar(40) not null
)

CREATE TABLE Car (
	CarId int identity(1,1) primary key not null,
	[Year] int not null,
	CarMakeId int foreign key references CarMake(CarMakeId) not null,
	CarModelId int foreign key references CarModel(CarModelId) not null,
	TypeId int foreign key references CarType(TypeId) not null,
	BodyStyleId int foreign key references BodyStyle(BodyStyleId) not null,
	TransmissionId int foreign key references Transmission(TransmissionId) not null,
	ColorId int foreign key references Color(ColorId) not null,
	InteriorId int foreign key references Interior(InteriorId) not null,
	Mileage decimal(10,2) not null,
	VINnumber nvarchar(40) not null,
	SalePrice decimal(8,0) not null,
	MSRP decimal(8,0) not null,
	CarDescription nvarchar(500) null,
	ImageFileName varchar(50),
	IsFeatured bit,
	IsPurchased bit
)

CREATE TABLE PurchaseType (
	PurchaseTypeId int identity(1,1) primary key not null,
	PurchaseTypeName nvarchar(40) not null
)

CREATE TABLE Purchase (
	PurchaseId int identity(1,1) primary key not null,
	CarId int foreign key references Car(CarId) not null,
	PurchasePrice decimal(10,2) not null,
	PurchaseTypeId int foreign key references PurchaseType(PurchaseTypeId) not null,
	SalesPerson nvarchar(30) not null,
	DatePurchased datetime not null default(getdate())
)

CREATE TABLE Customer (
	CustomerId int identity(1,1) primary key,
	CarId int foreign key references Car(CarId) not null,
	[Name] nvarchar(75) not null,
	Address1 varchar(50) not null,
	Address2 varchar(50) null,
	City varchar(30) not null,
	StateId char(2) foreign key references States(StateId) not null,
	ZipCode int not null,
	Phone nvarchar(25) not null,
	Email nvarchar(50) not null
)

CREATE TABLE CustomerPurchase (
	CustomerPurchaseId int identity(1,1) primary key,
	CustomerId int foreign key references Customer(CustomerId) not null,
	PurchaseId int foreign key references Purchase(PurchaseId) not null
)

CREATE TABLE ContactUs (
	ContactUsId int identity(1,1) primary key not null,
	[Name] nvarchar(60) not null,
	Email nvarchar(60) not null,
	Phone nvarchar(15) not null,
	[Message] nvarchar(500) null
>>>>>>> c9f84ce8c94242b6f8be6ae0254d947f3c17c225
)