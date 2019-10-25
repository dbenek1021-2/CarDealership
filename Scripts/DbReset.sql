<<<<<<< HEAD
USE master
GO

USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Purchase;
	DELETE FROM Customer;
	DELETE FROM States;
	DELETE FROM PurchaseType;
	DELETE FROM Special;
	DELETE FROM Car;
	DELETE FROM CarModel;
	DELETE FROM CarMake;
	DELETE FROM CarType;
	DELETE FROM Interior;
	DELETE FROM BodyStyle;
	DELETE FROM Transmission;
	DELETE FROM Color;
	DELETE FROM AspNetRoles;
	DELETE FROM AspNetUsers;

INSERT INTO States(StateId, StateName)
	VALUES('AZ', 'Arizona'),
		('CA', 'California'),
		('OH', 'Ohio');

SET IDENTITY_INSERT PurchaseType ON;

INSERT INTO PurchaseType(PurchaseTypeId, PurchaseTypeName)
	VALUES(1, 'Bank Finance'),
		(2, 'Cash'),
		(3, 'Dealer Finance');

SET IDENTITY_INSERT PurchaseType OFF;

SET IDENTITY_INSERT Special ON;

INSERT INTO Special(SpecialId, SpecialTitle, SpecialDescription)
	VALUES(1, 'Zero Down!', 'Ut varius metus porttitor, aliquet nulla non, varius risus. Aenean a est vitae justo malesuada fermentum. Donec malesuada in elit et aliquam. Aenean ut vehicula lectus, non feugiat nulla.'),
		(2, 'Used Car Deals', 'Aenean pharetra magna et est imperdiet sodales. Nullam non turpis id sem pellentesque volutpat a in odio. Nam aliquet neque at ullamcorper imperdiet. Donec interdum enim sed mauris interdum, sed vehicula enim tincidunt.'),
		(3, 'First Time Buyer Special', 'Sed pretium ullamcorper urna. Aliquam finibus ipsum tristique erat interdum, ac suscipit dolor tincidunt.'),
		(4, 'No Credit? No Problem!', 'Nam aliquet neque at ullamcorper imperdiet. Nullam non turpis id sem pellentesque volutpat a in odio. Aliquam finibus ipsum tristique erat interdum, ac suscipit dolor tincidunted vehicula enim tincidunt.');

SET IDENTITY_INSERT Special OFF;

SET IDENTITY_INSERT CarMake ON;

INSERT INTO CarMake(CarMakeId, MakeName, [User], DateAdded)
	VALUES(1, 'Chrysler','admin123@test.com', '2015-02-02 02:02:02'),
		(2, 'Honda','admin123@test.com', '2015-02-02 02:02:02'),
		(3, 'Toyota','admin123@test.com', '2014-02-02 02:02:02'),
		(4, 'Acura','admin123@test.com', '2006-02-02 02:02:02'),
		(5, 'Buick','admin123@test.com', '2007-02-02 02:02:02'),
		(6, 'Hyundai','admin123@test.com', '2000-02-02 02:02:02'),
		(7, 'Dodge','admin123@test.com', '2000-02-02 02:02:02'),
		(8, 'Lincoln','admin123@test.com', '2002-02-02 02:02:02'),
		(9, 'Volkswagen','admin123@test.com', '2010-02-02 02:02:02'),
		(10, 'Porsche','admin123@test.com', '2010-02-02 02:02:02');

SET IDENTITY_INSERT CarMake OFF;

SET IDENTITY_INSERT CarModel ON;

INSERT INTO CarModel(CarModelId, CarMakeId, ModelName, [User], DateAdded)
	VALUES(1, 1, 'PT Cruiser','testing123@test.com', '2015-02-02 02:02:02'),
		(2, 2, 'Civic','testing123@test.com', '2015-02-02 02:02:02'),
		(3, 3, 'Camry','testing123@test.com', '2015-02-02 02:02:02'),
		(4, 3, 'Corolla','testing123@test.com', '2015-02-02 02:02:02'),
		(5, 2, 'Accord','testing123@test.com', '2015-02-02 02:02:02'),
		(6, 6, 'Kona','testing123@test.com', '2015-02-02 02:02:02'),
		(7, 7, 'Dakota','testing123@test.com', '2015-02-02 02:02:02'),
		(8, 8, 'Nautilus','testing123@test.com', '2015-02-02 02:02:02'),
		(9, 9, 'Beetle','testing123@test.com', '2015-02-02 02:02:02'),
		(10, 10, 'Cayman','testing123@test.com', '2015-02-02 02:02:02');

SET IDENTITY_INSERT CarModel OFF;

SET IDENTITY_INSERT CarType ON;

INSERT INTO CarType(TypeId, TypeName)
	VALUES(1, 'New'),
		(2, 'Used');

SET IDENTITY_INSERT CarType OFF;

SET IDENTITY_INSERT Interior ON;

INSERT INTO Interior(InteriorId, InteriorName)
	VALUES(1, 'Black'),
		(2, 'Tan'),
		(3, 'Leather');

SET IDENTITY_INSERT Interior OFF;

SET IDENTITY_INSERT BodyStyle ON;

INSERT INTO BodyStyle(BodyStyleId, BodyStyleName)
	VALUES(1, 'Car'),
		(2, 'SUV'),
		(3, 'Truck'),
		(4, 'Van');

SET IDENTITY_INSERT BodyStyle OFF

SET IDENTITY_INSERT Transmission ON;

INSERT INTO Transmission(TransmissionId, TransmissionName)
	VALUES(1, 'Automatic'),
		(2, 'Manual');

SET IDENTITY_INSERT Transmission OFF;

SET IDENTITY_INSERT Color ON;

INSERT INTO Color(ColorId, ColorName)
	VALUES(1, 'Black'),
		(2, 'White'),
		(3, 'Silver'),
		(4, 'Sky Blue'),
		(5, 'Cherry Red'),
		(6, 'Sunny Yellow'),
		(7, 'Lime Green'),
		(8, 'Plum Purple'),
		(9, 'Ocean Blue'),
		(10, 'Sunset Orange');

SET IDENTITY_INSERT Color OFF;

SET IDENTITY_INSERT Car ON;

INSERT INTO Car (CarId, [Year], CarMakeId, CarModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, Mileage,
					 VINnumber, SalePrice, MSRP, CarDescription, ImageFileName, IsFeatured, IsPurchased)
	VALUES (1, 2012, 1, 1, 2, 1, 1, 9, 1, 25000, '1HGBH41JXMN109186', 15000, 16000, 'This is a good car', 'inventory-1.jpg', 1, 0),
			(2, 2019, 2, 2, 1, 1, 1, 3, 1, 900, '1HGGT41JXMN109187', 12000, 14000, 'This is an ok car', 'inventory-2.jpg', 1, 0),
			(3, 2012, 3, 3, 2, 1, 1, 5, 1, 13000, '1HGGT41JXMN109156', 14300, 15000, 'This is a great car', 'inventory-3.jpg', 0, 0),
			(4, 2015, 1, 1, 2, 1, 1, 8, 1, 13000, '1HGGT41JXMN109157', 14600, 16000, 'This is a gangster car', 'inventory-4.jpg', 1, 0),
			(5, 2020, 2, 5, 1, 1, 1, 1, 1, 500, '1HGGT41JXMN109180', 35000, 45000, 'This is a new car', 'inventory-5.jpg', 0, 0),
			(6, 2011, 3, 4, 2, 1, 1, 2, 1, 13000, '1HGGT41JXMN109182', 13000, 14000, 'This is a car', 'inventory-6.jpg', 0, 0),
			(7, 2018, 3, 4, 2, 1, 1, 2, 1, 12500, '1HGGT41JXMN109183', 15000, 16500, 'This is a car', 'inventory-7.jpg', 0, 0),
			(8, 2011, 7, 7, 2, 3, 1, 1, 1, 30000, '1HGGT41JXMN109155', 30000, 35000, 'This is a good truck', 'inventory-8.jpg', 0, 0),
			(9, 2008, 9, 9, 2, 1, 1, 6, 1, 200000, '1HGGT41JXMN109185', 9000, 9500, 'This is a beetle, not to be confused with a "bug"', 'inventory-9.jpg', 1, 0),
			(10, 2016, 6, 6, 2, 2, 1, 7, 1, 105500, '1HGGT41JXMN109190', 20000, 23000, 'This is a nice SUV. Cool color too', 'inventory-10.jpg', 1, 0),
			(11, 2011, 8, 8, 2, 2, 1, 5, 1, 120000, '1HGGT41JXMN109191', 14000, 14400, 'This is a really nice SUV. Gets you from point A to point B', 'inventory-11.jpg', 0, 0),
			(12, 2020, 10, 10, 1, 1, 2, 4, 2, 400, '1HGGT41JXMN109192', 51000, 52000, 'This is a sweet ride! Enjoy the sun', 'inventory-12.jpg', 0, 0),
			(13, 2006, 1, 1, 2, 1, 1, 5, 1, 25000, '1HGBH41JXMN109186', 15000, 16000, 'This is a good, old car. Surprisingly roomy!', 'inventory-13.jpg', 0, 0),
			(14, 2019, 2, 2, 1, 1, 1, 3, 1, 850, '1HGGT41JXMN109187', 12000, 14000, 'This is an ok car', 'inventory-14.jpg', 0, 0),
			(15, 2012, 3, 3, 2, 1, 1, 5, 1, 13000, '1HGGT41JXMN109188', 14300, 15000, 'This is a great car', 'inventory-15.jpg', 0, 0),
			(16, 2008, 1, 1, 2, 1, 1, 3, 1, 13000, '1HGGT41JXMN109189', 14600, 16000, 'This is another gangster car, but with a convertible top', 'inventory-16.jpg', 0, 0),
			(17, 2020, 2, 5, 1, 1, 1, 1, 1, 400, '1HGGT41JXMN109180', 35000, 45000, 'This is a new car', 'inventory-17.jpg', 0, 0),
			(18, 2011, 3, 4, 2, 1, 1, 2, 1, 13000, '1HGGT41JXMN109182', 13000, 14000, 'This is a car', 'inventory-18.jpg', 0, 0),
			(19, 2018, 3, 4, 2, 1, 1, 4, 1, 12500, '1HGGT41JXMN109183', 15000, 16300, 'This is a car', 'inventory-19.jpg', 0, 0),
			(20, 2011, 7, 7, 2, 3, 1, 1, 1, 40000, '1HGGT41JXMN109182', 29000, 35000, 'This is a really good truck. Very cherry... but black', 'inventory-20.jpg', 0, 0),
			(21, 2019, 9, 9, 1, 1, 1, 10, 1, 300, '1HGGT41JXMN109185', 26000, 2800, 'This is a beetle. Very new, great interior, and super stylish for driving off into the sunset', 'inventory-21.jpg', 0, 0),
			(22, 2019, 6, 6, 1, 2, 1, 2, 1, 500, '1HGGT41JXMN109172', 33000, 35000, 'This is a nice SUV. Great pick-up and stylish for the cool soccer moms', 'inventory-22.jpg', 0, 0),
			(23, 2011, 8, 8, 2, 2, 1, 5, 1, 120000, '1HGGT41JXMN109173', 13000, 14000, 'This is a really nice SUV. Gets you from point A to point B', 'inventory-23.jpg', 0, 0),
			(24, 2020, 10, 10, 1, 1, 2, 2, 2, 400, '1HGGT41JXMN109174', 52000, 54000, 'This is a sweet ride that will make you feel free!', 'inventory-24.jpg', 0, 0),
			(25, 2019, 9, 9, 1, 1, 1, 4, 1, 8000, '1HGGT41JXMN109175', 29000, 29500, 'This is a beetle convertable. Great car to pick up your pumpkin spiced lattes in', 'inventory-25.jpg', 0, 0),
			(26, 2000, 7, 7, 2, 3, 1, 9, 1, 400000, '1HGGT41JXMN109176', 16530, 17000, 'This is a good truck. Pretty old but still in great shape', 'inventory-26.jpg', 0, 0),
			(27, 2005, 7, 7, 2, 3, 1, 5, 1, 300000, '1HGGT41JXMN109177', 18000, 18500, 'This is a very nice truck. It is old but very reliable', 'inventory-27.jpg', 0, 0),
			(28, 2019, 6, 6, 1, 2, 1, 3, 1, 900, '1HGGT41JXMN109171', 32000, 33500, 'This is a nice SUV. If you want to look cool and have a mom car, this is the one for you', 'inventory-28.jpg', 0, 0),
			(29, 2019, 6, 6, 1, 2, 1, 2, 1, 1000, '1HGGT41JXMN109170', 43000, 46000, 'This is a nice SUV. If you want to look cool and have a mom car, this is the one may be for you', 'inventory-29.jpg', 0, 0),
			(30, 2020, 6, 6, 1, 2, 1, 7, 1, 500, '1HGGT41JXMN109169', 45000, 47000, 'This is a nice SUV. Apparently, this SUV looks good in lime green', 'inventory-30.jpg', 1, 0);


SET IDENTITY_INSERT Car OFF;

=======
USE master
GO

USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Purchase;
	DELETE FROM Customer;
	DELETE FROM States;
	DELETE FROM PurchaseType;
	DELETE FROM Special;
	DELETE FROM Car;
	DELETE FROM CarModel;
	DELETE FROM CarMake;
	DELETE FROM CarType;
	DELETE FROM Interior;
	DELETE FROM BodyStyle;
	DELETE FROM Transmission;
	DELETE FROM Color;
	DELETE FROM AspNetRoles;
	DELETE FROM AspNetUsers;

INSERT INTO States(StateId, StateName)
	VALUES('AZ', 'Arizona'),
		('CA', 'California'),
		('OH', 'Ohio');

SET IDENTITY_INSERT PurchaseType ON;

INSERT INTO PurchaseType(PurchaseTypeId, PurchaseTypeName)
	VALUES(1, 'Bank Finance'),
		(2, 'Cash'),
		(3, 'Dealer Finance');

SET IDENTITY_INSERT PurchaseType OFF;

SET IDENTITY_INSERT Special ON;

INSERT INTO Special(SpecialId, SpecialTitle, SpecialDescription)
	VALUES(1, 'Zero Down!', 'Ut varius metus porttitor, aliquet nulla non, varius risus. Aenean a est vitae justo malesuada fermentum. Donec malesuada in elit et aliquam. Aenean ut vehicula lectus, non feugiat nulla.'),
		(2, 'Used Car Deals', 'Aenean pharetra magna et est imperdiet sodales. Nullam non turpis id sem pellentesque volutpat a in odio. Nam aliquet neque at ullamcorper imperdiet. Donec interdum enim sed mauris interdum, sed vehicula enim tincidunt.'),
		(3, 'First Time Buyer Special', 'Sed pretium ullamcorper urna. Aliquam finibus ipsum tristique erat interdum, ac suscipit dolor tincidunt.'),
		(4, 'No Credit? No Problem!', 'Nam aliquet neque at ullamcorper imperdiet. Nullam non turpis id sem pellentesque volutpat a in odio. Aliquam finibus ipsum tristique erat interdum, ac suscipit dolor tincidunted vehicula enim tincidunt.');

SET IDENTITY_INSERT Special OFF;

SET IDENTITY_INSERT CarMake ON;

INSERT INTO CarMake(CarMakeId, MakeName, [User], DateAdded)
	VALUES(1, 'Chrysler','admin123@test.com', '2015-02-02 02:02:02'),
		(2, 'Honda','admin123@test.com', '2015-02-02 02:02:02'),
		(3, 'Toyota','admin123@test.com', '2014-02-02 02:02:02'),
		(4, 'Acura','admin123@test.com', '2006-02-02 02:02:02'),
		(5, 'Buick','admin123@test.com', '2007-02-02 02:02:02'),
		(6, 'Hyundai','admin123@test.com', '2000-02-02 02:02:02'),
		(7, 'Dodge','admin123@test.com', '2000-02-02 02:02:02'),
		(8, 'Lincoln','admin123@test.com', '2002-02-02 02:02:02'),
		(9, 'Volkswagen','admin123@test.com', '2010-02-02 02:02:02'),
		(10, 'Porsche','admin123@test.com', '2010-02-02 02:02:02');

SET IDENTITY_INSERT CarMake OFF;

SET IDENTITY_INSERT CarModel ON;

INSERT INTO CarModel(CarModelId, CarMakeId, ModelName, [User], DateAdded)
	VALUES(1, 1, 'PT Cruiser','testing123@test.com', '2015-02-02 02:02:02'),
		(2, 2, 'Civic','testing123@test.com', '2015-02-02 02:02:02'),
		(3, 3, 'Camry','testing123@test.com', '2015-02-02 02:02:02'),
		(4, 3, 'Corolla','testing123@test.com', '2015-02-02 02:02:02'),
		(5, 2, 'Accord','testing123@test.com', '2015-02-02 02:02:02'),
		(6, 6, 'Kona','testing123@test.com', '2015-02-02 02:02:02'),
		(7, 7, 'Dakota','testing123@test.com', '2015-02-02 02:02:02'),
		(8, 8, 'Nautilus','testing123@test.com', '2015-02-02 02:02:02'),
		(9, 9, 'Beetle','testing123@test.com', '2015-02-02 02:02:02'),
		(10, 10, 'Cayman','testing123@test.com', '2015-02-02 02:02:02');

SET IDENTITY_INSERT CarModel OFF;

SET IDENTITY_INSERT CarType ON;

INSERT INTO CarType(TypeId, TypeName)
	VALUES(1, 'New'),
		(2, 'Used');

SET IDENTITY_INSERT CarType OFF;

SET IDENTITY_INSERT Interior ON;

INSERT INTO Interior(InteriorId, InteriorName)
	VALUES(1, 'Black'),
		(2, 'Tan'),
		(3, 'Leather');

SET IDENTITY_INSERT Interior OFF;

SET IDENTITY_INSERT BodyStyle ON;

INSERT INTO BodyStyle(BodyStyleId, BodyStyleName)
	VALUES(1, 'Car'),
		(2, 'SUV'),
		(3, 'Truck'),
		(4, 'Van');

SET IDENTITY_INSERT BodyStyle OFF

SET IDENTITY_INSERT Transmission ON;

INSERT INTO Transmission(TransmissionId, TransmissionName)
	VALUES(1, 'Automatic'),
		(2, 'Manual');

SET IDENTITY_INSERT Transmission OFF;

SET IDENTITY_INSERT Color ON;

INSERT INTO Color(ColorId, ColorName)
	VALUES(1, 'Black'),
		(2, 'White'),
		(3, 'Silver'),
		(4, 'Sky Blue'),
		(5, 'Cherry Red'),
		(6, 'Sunny Yellow'),
		(7, 'Lime Green'),
		(8, 'Plum Purple'),
		(9, 'Ocean Blue'),
		(10, 'Sunset Orange');

SET IDENTITY_INSERT Color OFF;

SET IDENTITY_INSERT Car ON;

INSERT INTO Car (CarId, [Year], CarMakeId, CarModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, Mileage,
					 VINnumber, SalePrice, MSRP, CarDescription, ImageFileName, IsFeatured, IsPurchased)
	VALUES (1, 2012, 1, 1, 2, 1, 1, 9, 1, 25000, '1HGBH41JXMN109186', 15000, 16000, 'This is a good car', 'inventory-1.jpg', 1, 0),
			(2, 2019, 2, 2, 1, 1, 1, 3, 1, 900, '1HGGT41JXMN109187', 12000, 14000, 'This is an ok car', 'inventory-2.jpg', 1, 0),
			(3, 2012, 3, 3, 2, 1, 1, 5, 1, 13000, '1HGGT41JXMN109156', 14300, 15000, 'This is a great car', 'inventory-3.jpg', 0, 0),
			(4, 2015, 1, 1, 2, 1, 1, 8, 1, 13000, '1HGGT41JXMN109157', 14600, 16000, 'This is a gangster car', 'inventory-4.jpg', 1, 0),
			(5, 2020, 2, 5, 1, 1, 1, 1, 1, 500, '1HGGT41JXMN109180', 35000, 45000, 'This is a new car', 'inventory-5.jpg', 0, 0),
			(6, 2011, 3, 4, 2, 1, 1, 2, 1, 13000, '1HGGT41JXMN109182', 13000, 14000, 'This is a car', 'inventory-6.jpg', 0, 0),
			(7, 2018, 3, 4, 2, 1, 1, 2, 1, 12500, '1HGGT41JXMN109183', 15000, 16500, 'This is a car', 'inventory-7.jpg', 0, 0),
			(8, 2011, 7, 7, 2, 3, 1, 1, 1, 30000, '1HGGT41JXMN109155', 30000, 35000, 'This is a good truck', 'inventory-8.jpg', 0, 0),
			(9, 2008, 9, 9, 2, 1, 1, 6, 1, 200000, '1HGGT41JXMN109185', 9000, 9500, 'This is a beetle, not to be confused with a "bug"', 'inventory-9.jpg', 1, 0),
			(10, 2016, 6, 6, 2, 2, 1, 7, 1, 105500, '1HGGT41JXMN109190', 20000, 23000, 'This is a nice SUV. Cool color too', 'inventory-10.jpg', 1, 0),
			(11, 2011, 8, 8, 2, 2, 1, 5, 1, 120000, '1HGGT41JXMN109191', 14000, 14400, 'This is a really nice SUV. Gets you from point A to point B', 'inventory-11.jpg', 0, 0),
			(12, 2020, 10, 10, 1, 1, 2, 4, 2, 400, '1HGGT41JXMN109192', 51000, 52000, 'This is a sweet ride! Enjoy the sun', 'inventory-12.jpg', 0, 0),
			(13, 2006, 1, 1, 2, 1, 1, 5, 1, 25000, '1HGBH41JXMN109186', 15000, 16000, 'This is a good, old car. Surprisingly roomy!', 'inventory-13.jpg', 0, 0),
			(14, 2019, 2, 2, 1, 1, 1, 3, 1, 850, '1HGGT41JXMN109187', 12000, 14000, 'This is an ok car', 'inventory-14.jpg', 0, 0),
			(15, 2012, 3, 3, 2, 1, 1, 5, 1, 13000, '1HGGT41JXMN109188', 14300, 15000, 'This is a great car', 'inventory-15.jpg', 0, 0),
			(16, 2008, 1, 1, 2, 1, 1, 3, 1, 13000, '1HGGT41JXMN109189', 14600, 16000, 'This is another gangster car, but with a convertible top', 'inventory-16.jpg', 0, 0),
			(17, 2020, 2, 5, 1, 1, 1, 1, 1, 400, '1HGGT41JXMN109180', 35000, 45000, 'This is a new car', 'inventory-17.jpg', 0, 0),
			(18, 2011, 3, 4, 2, 1, 1, 2, 1, 13000, '1HGGT41JXMN109182', 13000, 14000, 'This is a car', 'inventory-18.jpg', 0, 0),
			(19, 2018, 3, 4, 2, 1, 1, 4, 1, 12500, '1HGGT41JXMN109183', 15000, 16300, 'This is a car', 'inventory-19.jpg', 0, 0),
			(20, 2011, 7, 7, 2, 3, 1, 1, 1, 40000, '1HGGT41JXMN109182', 29000, 35000, 'This is a really good truck. Very cherry... but black', 'inventory-20.jpg', 0, 0),
			(21, 2019, 9, 9, 1, 1, 1, 10, 1, 300, '1HGGT41JXMN109185', 26000, 2800, 'This is a beetle. Very new, great interior, and super stylish for driving off into the sunset', 'inventory-21.jpg', 0, 0),
			(22, 2019, 6, 6, 1, 2, 1, 2, 1, 500, '1HGGT41JXMN109172', 33000, 35000, 'This is a nice SUV. Great pick-up and stylish for the cool soccer moms', 'inventory-22.jpg', 0, 0),
			(23, 2011, 8, 8, 2, 2, 1, 5, 1, 120000, '1HGGT41JXMN109173', 13000, 14000, 'This is a really nice SUV. Gets you from point A to point B', 'inventory-23.jpg', 0, 0),
			(24, 2020, 10, 10, 1, 1, 2, 2, 2, 400, '1HGGT41JXMN109174', 52000, 54000, 'This is a sweet ride that will make you feel free!', 'inventory-24.jpg', 0, 0),
			(25, 2019, 9, 9, 1, 1, 1, 4, 1, 8000, '1HGGT41JXMN109175', 29000, 29500, 'This is a beetle convertable. Great car to pick up your pumpkin spiced lattes in', 'inventory-25.jpg', 0, 0),
			(26, 2000, 7, 7, 2, 3, 1, 9, 1, 400000, '1HGGT41JXMN109176', 16530, 17000, 'This is a good truck. Pretty old but still in great shape', 'inventory-26.jpg', 0, 0),
			(27, 2005, 7, 7, 2, 3, 1, 5, 1, 300000, '1HGGT41JXMN109177', 18000, 18500, 'This is a very nice truck. It is old but very reliable', 'inventory-27.jpg', 0, 0),
			(28, 2019, 6, 6, 1, 2, 1, 3, 1, 900, '1HGGT41JXMN109171', 32000, 33500, 'This is a nice SUV. If you want to look cool and have a mom car, this is the one for you', 'inventory-28.jpg', 0, 0),
			(29, 2019, 6, 6, 1, 2, 1, 2, 1, 1000, '1HGGT41JXMN109170', 43000, 46000, 'This is a nice SUV. If you want to look cool and have a mom car, this is the one may be for you', 'inventory-29.jpg', 0, 0),
			(30, 2020, 6, 6, 1, 2, 1, 7, 1, 500, '1HGGT41JXMN109169', 45000, 47000, 'This is a nice SUV. Apparently, this SUV looks good in lime green', 'inventory-30.jpg', 1, 0);


SET IDENTITY_INSERT Car OFF;

>>>>>>> c9f84ce8c94242b6f8be6ae0254d947f3c17c225
END