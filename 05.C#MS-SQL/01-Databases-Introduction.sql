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
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Title] NVARCHAR(100) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
[CopyrightYear] INT NOT NULL, 
[Length] INT NOT NULL,
[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
[CategoryId] INT  FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Rating] FLOAT NOT NULL,
[Notes] VARCHAR(200) NULL 
);

INSERT INTO [Directors]([DirectorName], [Notes])
VALUES
('Steven Spielberg','film director'),
('James Cameron','film director'),
('Quentin Tarantino','film director'),
('Martin Scorsese','film director'),
('Christopher Nolan','film director')

INSERT INTO [Genres](GenreName, [Notes])
VALUES
('Action','High-octane films featuring fight scenes'),
('Adventure','Focus on journeys'),
('Comedy','Films designed to make the audience laugh'),
('Drama','Driven stories that explore emotional'),
('Horror','Films designed to provoke fear')

INSERT INTO [Categories]([CategoryName],[Notes])
VALUES 
('Feature film', NULL),
('Short film', NULL),
('TV series', NULL),
('Documentary', NULL),
('Concert film', NULL)

INSERT INTO [Movies]([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating],[Notes])
VALUES 
('The Dark Knight',5,2008,120,1,1,9.5,NULL),
('Schindler List',1,1993,125,1,4,9.7,NULL),
('Terminator 2',2,1991,110,1,1,8.2,NULL),
('Kill Bill',3,2003,100,1,1,8.3,NULL),
('Goodfellas',4,1990,97,1,1,9.8,NULL)

--14 Car Rental Database
USE [CarRental]

CREATE DATABASE [CarRental]

CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] INT NOT NULL,
[WeeklyRate] INT NOT NULL,
[MonthlyRate] INT NOT NULL,
[WeekendRate] INT NOT NULL
);

CREATE TABLE [Cars]
(
[Id] INT PRIMARY KEY IDENTITY,
[PlateNumber] NVARCHAR(30) NOT NULL,
[Manufacturer] NVARCHAR(20) NOT NULL,
[Model] NVARCHAR(20) NOT NULL,
[CarYear] INT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Doors] TINYINT NOT NULL,
[Picture] VARBINARY(MAX) NULL,
[Condition] VARCHAR(10)NOT NULL,
[Available] BIT NOT NULL
)

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(30) NOT NULL,
[LastName] VARCHAR(30) NOT NULL,
[Title] VARCHAR(30) NULL,
[Notes] VARCHAR(500) NULL
)

CREATE TABLE [Customers]
(
[Id] INT PRIMARY KEY IDENTITY,
[DriverLicenceNumber] NVARCHAR(50) NOT NULL,
[FullName] VARCHAR(50) NOT NULL,
[Address] VARCHAR(100) NULL,
[City] NVARCHAR(25) NOT NULL,
[ZIPCode] NVARCHAR(20) NOT NULL,
[Notes] VARCHAR(500) NULL
)

CREATE TABLE [RentalOrders]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
[TankLevel] TINYINT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT NOT NULL,
[StartDate] DATETIME NOT NULL,
[EndDate] DATETIME NOT NULL,
[TotalDays] TINYINT NOT NULL,
[RateApplied] INT NOT NULL,
[TaxRate] INT NOT NULL,
[OrderStatus] VARCHAR(20) NOT NULL,
[Notes] VARCHAR(20) NULL
)

INSERT INTO [Categories]([CategoryName],[DailyRate],
[WeeklyRate],[MonthlyRate],[WeekendRate])
VALUES
('Economy',100,400,2000,120),
('Compact',110,450,2200,130),
('SUV',130,500,2500,150)

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],
[CarYear],[CategoryId],[Doors],[Picture],[Condition],[Available])
VALUES
('PB1233MP','BMV','520',2020,1,5,NULL,'Fair',1),
('EA9253TP','Tesla','3',2023,2,5,NULL,'Good',1),
('EA9900KK','Tesla','Y',2025,3,5,NULL,'Very Good',1)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES
('Atanas','Petkov','Mr', NULL),
('Petko','Atanasov','Mr', NULL),
('Maria','Petkov','Mrs', NULl)

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address],
                         [City],[ZIPCode])
VALUES
('A1234567890B','Kiril Kehaiov', 'str. Stefan Stambolov 63', 'Plovdiv', '4000'),
('A1234567890A','Kalin Stoqnov', 'str. Georgi Kirkov 10', 'Plovdiv', '4000'),
('A1234567890C','Slavcho Petrov', 'bul. Nikola Vaptsarov 100', 'Plovdiv', '4000')

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId],[TankLevel], [KilometrageStart], [KilometrageEnd],[TotalKilometrage],
[StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate],[OrderStatus], [Notes])
VALUES 
(1,1,1,10, 10000, 20000, 30000,'2025-01-20', '2025-02-20', 30, 10 , 10, 'Processing',NULL),
(2,2,2,10, 12200, 22050, 40000,'2025-02-21', '2025-02-24', 3, 10 , 10, 'Processing',NULL),
(3,3,3,10, 10000, 21150, 50000,'2025-01-22', '2025-01-23', 1, 10 , 10, 'Processing',NULL)

--15 Hotel Database

CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50) NOT NULL,
[LastName] VARCHAR(50) NOT NULL,
[Tital] VARCHAR(10) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

CREATE TABLE [Customers]
(
[AccountNumber] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50) NOT NULL,
[LastName] VARCHAR(50) NOT NULL,
[PhoneNumber] VARCHAR(20) NULL,
[EmergencyName] VARCHAR(50) NOT NULL,
[EmergencyNumber] VARCHAR(20) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

CREATE TABLE [RoomStatus]
(
[RoomStatus] VARCHAR(50) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

CREATE TABLE [RoomTypes]
(
[RoomTypes] VARCHAR(50) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

CREATE TABLE [BedTypes]
(
[BedTypes] VARCHAR(50) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

CREATE TABLE [Rooms]
(
[RoomNumber] SMALLINT PRIMARY KEY IDENTITY,
[RoomType] VARCHAR(30) NOT NULL,
[BedType] VARCHAR(30) NOT NULL,
[Rate] SMALLINT NOT NULL ,
[RoomStatus] VARCHAR(30) NOT NULL,
[Notes] VARCHAR(200) NULL 
)

ALTER TABLE [Rooms]
ALTER COLUMN [RoomType] 

CREATE TABLE [Payments]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
[PaymentDate] DATE NOT NULL,
[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
[FirstDateOccupied] DATE NOT NULL,
[LastDateOccupied] DATE NOT NULL,
[TotalDays] TINYINT NOT NULL,
[AmountCharged] DECIMAL(8,2) NOT NULL,
[TaxRate] TINYINT NOT NULL,
[TaxAmount] INT NOT NULL,
[PaymentTotal] DECIMAL(8,2) NOT NULL,
[Notes] VARCHAR(200) NULL 
)
CREATE TABLE [Occupancies]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
[DateOccupied] DATE NOT NULL,
[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
[RoomNumber] SMALLINT FOREIGN KEY REFERENCES [Rooms] ([RoomNumber]),
[RateApplied] SMALLINT NOT NULL,
[PhoneCharge] DECIMAL(8,2) NULL,
[Notes] VARCHAR(200) NULL 
)

DROP TABLE [RoomStatus]
DROP TABLE [BedTypes]
DROP TABLE [RoomTypes]

SELECT * 
  FROM [RentalOrders]