<<<<<<< HEAD
USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE Name='GuildCars')
DROP DATABASE GuildCars
GO

CREATE DATABASE GuildCars
GO

USE GuildCars
=======
USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE Name='GuildCars')
DROP DATABASE GuildCars
GO

CREATE DATABASE GuildCars
GO

USE GuildCars
>>>>>>> c9f84ce8c94242b6f8be6ae0254d947f3c17c225
GO