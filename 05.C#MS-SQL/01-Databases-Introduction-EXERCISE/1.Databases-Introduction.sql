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

CREATE TABLE [Users]
(
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) NOT NULL, 
[Password] VARCHAR(26) NOT NULL, 
[ProfilePicture] VARBINARY(MAX),
 CHECK (DATALENGTH([ProfilePicture])<=900000),
[LastLoginTime] DATETIME2 NOT NULL,
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
--09 Change Primary Key

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC077D0C3A8A

ALTER TABLE [Users]
ADD PRIMARY KEY ([Id], [Username])

GO
--10 Add Check Constraint

ALTER TABLE [Users]
ADD CHECK(LEN([Password])>=5)

GO
--11 Set Default Value of a Field

ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT(SYSDATETIME()) FOR [LastLoginTime]

GO 
--12 Set Unique Field

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__77222459A2890A6F 

ALTER TABLE [Users]
ADD PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT UQ_Users_At_Least3Symbols 
UNIQUE ([Username])

ALTER TABLE [Users]
ADD CHECK (LEN([Username])>=3)

GO 
--13 Movies Database
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[DirectorName] NVARCHAR(200) NOT NULL,
[Notes] NVARCHAR(1000) NULL
);

CREATE TABLE [Genres]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(1000) NULL
);

CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(1000) NULL
);

CREATE TABLE [Movies]
(
[Id] INT PRIMARY KEY IDENTITY(1,1)
[Title] NVARCHAR(100) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL,
[CopyrightYear] DATE NOT NULL, 
[Length]
[GenreId]
[CategoryId]
[Rating]
[Notes]
);

-- TEST 
-- TEST 
-- TEST 
