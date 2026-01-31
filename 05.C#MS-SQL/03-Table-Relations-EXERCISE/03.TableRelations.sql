USE [Demo]

GO

--1 One-To-One Relationship

CREATE TABLE [Passports]
(
[PassportID] INT PRIMARY KEY IDENTITY(101,1),
[PassportNumber] VARCHAR(8) NOT NULL
)

CREATE TABLE [Persons]
(
[PersonID] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(20) NOT NULL,
[Salary] DECIMAL(18,2) NOT NULL,
[PassportID] INT FOREIGN KEY ([PassportID]) REFERENCES [Passports] ([PassportID])
)

INSERT INTO [Passports]([PassportNumber])
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons]([FirstName],[Salary],[PassportID])
VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200,101)

GO

--2 One-To-Many Relationship

CREATE TABLE [Manufacturers]
(
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(40) NOT NULL,
[EstablishedOn] DATE NOT NULL,
)

CREATE TABLE [Models]
(
[ModelID] INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(40) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers] ([ManufacturerID]) NOT NULL 
)

INSERT INTO [Manufacturers]([Name],[EstablishedOn])
VALUES 
('BMW','1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

INSERT INTO [Models]([Name],[ManufacturerID])
VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

GO 

--3 Many-To-Many Relationship

CREATE TABLE [Students]
(
[StudentID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
[ExamID] INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(50) NOT NULL
)


CREATE TABLE [StudentsExams]
(
[StudentID] INT FOREIGN KEY([StudentID]) REFERENCES Students ([StudentID]),
[ExamID] INT FOREIGN KEY([ExamID]) REFERENCES Exams ([ExamID])
CONSTRAINT [PK_StudentsExams] PRIMARY KEY ([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams]([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID],[ExamID])
VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

GO 

--4 Self-Referencing 

CREATE TABLE [Teachers]
(
[TeacherID] INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(50) NOT NULL,
[ManagerID] INT FOREIGN KEY ([ManagerID]) REFERENCES [Teachers]([TeacherID]) NULL
)

INSERT INTO [Teachers]([Name], [ManagerID])
VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)

GO

--5 Online Store Database

CREATE DATABASE [OnlineShop]

USE [OnlineShop]

CREATE TABLE [Cities]
(
[CityID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [ItemTypes]
(
[ItemTypeID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
[CustomerID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Birthday] DATE NULL,
[CityID] INT FOREIGN KEY ([CityID]) REFERENCES [Cities]([CityID])
)

CREATE TABLE [Items]
(
[ItemID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[ItemTypeID] INT FOREIGN KEY ([ItemTypeID]) REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [Orders]
(
[OrderID] INT PRIMARY KEY IDENTITY,
[CustomerID] INT FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [OrderItems]
(
[OrderID] INT FOREIGN KEY ([OrderID]) REFERENCES [Orders]([OrderID]),
[ItemID] INT FOREIGN KEY ([ItemID]) REFERENCES [Items]([ItemID])
CONSTRAINT [PK_OrderItems_11] PRIMARY KEY ([OrderID], [ItemID])
)







--SELECT * 
  --FROM [Teachers]





