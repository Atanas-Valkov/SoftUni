--01 Create Database
CREATE DATABASE [Minions]

USE [Minions] 

GO

--02 Create Tables
CREATE TABLE [Minions](
[Id] INT PRIMARY KEY,
[Name] VARCHAR(100) NOT NULL,
[Age] SMALLINT NOT NULL
);

CREATE TABLE [Towns] (
[Id] INT PRIMARY KEY,
[Name] VARCHAR(100) NOT NULL
);

GO

--03 Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL

ALTER TABLE [Minions]
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO

--04 Insert Records in Both Tables
INSERT INTO [Towns]([Id], [Name])
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna');

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

GO

--05 Truncate Table Minions
TRUNCATE TABLE [Minions];

GO 

--06 Drop All Tables
DROP TABLE [Minions];
DROP TABLE [Towns];

--07 Create Table People
CREATE TABLE [People]
(
[Id] INT PRIMARY KEY IDENTITY,  
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX) NULL,
[Height] DECIMAL(5,2) NULL,
[Weight] DECIMAL(5,2) NULL,
[Gender] CHAR(1) NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX) NULL
);
INSERT INTO [People]([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
(N'Георги', 12000, 180, 80, 'm', '1983-12-05',N'Разработчик'),
(N'Иван', 11000 , 190, 90, 'm', '2001-09-09',N'Дизайнер'),
(N'Светлана', 34000, 171, 53, 'f','2003-12-05',N'Банкер'),
(N'Мишо', 40000, 195, 96, 'm','1980-01-09',N'Баскетболист'),
(N'Снежана', 99999, 162, 65, 'f','1963-05-06',N'Пенсионер');

GO 
--08 Create Table Users
--TRUNCATE TABLE [Users];
--DROP TABLE [Users];
CREATE TABLE [Users]
(
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) UNIQUE  NOT NULL, 
[Password] VARCHAR(26) NOT NULL, 
[ProfilePicture] VARBINARY(MAX),
 CHECK (DATALENGTH([ProfilePicture])<=900000),
[LastLoginTime] DATETIME2 NULL,
[IsDeleted] BIT,
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture],[IsDeleted])
VALUES 
('Mexican', '123456', NULL, 1),
('Bulgarian', '123457', NULL, 1),
('American', '123458', NULL, 1),
('Italian', '123459', NULL, 1),
('German', '123459', NULL, 1)

GO

--Test !!! 
--Test !!! 
--Test !!! 
--Test !!! 
--Test !!! 
--Test !!! 
GO 

GO 



