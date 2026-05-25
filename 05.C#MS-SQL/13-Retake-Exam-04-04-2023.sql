CREATE DATABASE [Accounting]

GO

USE [Accounting]

GO 

--1. DDL (30 pts)

CREATE TABLE [Countries]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Addresses]
(
[Id] INT PRIMARY KEY IDENTITY,
[StreetName] VARCHAR (20) NOT NULL,
[StreetNumber] INT NULL,
[PostCode] INT NOT NULL,
[City] NVARCHAR(25) NOT NULL,
[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Vendors]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
[NumberVAT] NVARCHAR(15) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Clients]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
[NumberVAT] NVARCHAR(15) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL 
)

CREATE TABLE [Products]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(35) NOT NULL,
[Price] DECIMAL(18,2) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([Id])  NOT NULL,
)

CREATE TABLE [Invoices]
(
[Id] INT PRIMARY KEY IDENTITY,
[Number] INT UNIQUE NOT NULL,
[IssueDate] DATETIME2 NOT NULL,
[DueDate] DATETIME2 NOT NULL,
[Amount] DECIMAL(18,2) NOT NULL,
[Currency] VARCHAR(5) NOT NULL,
[ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id]) 
)

--2.	Insert

CREATE TABLE [ProductsClients]
(
[ProductId] INT FOREIGN KEY REFERENCES [Products]([Id]),
[ClientId]  INT FOREIGN KEY REFERENCES [Clients]([Id]),
PRIMARY  KEY ([ProductId],[ClientId])
)

INSERT INTO [Products]([Name],[Price],[CategoryId],[VendorId])
VALUES
(N'SCANIA Oil Filter XD01', 78.69, 1, 1),
(N'MAN Air Filter XD01',    97.38, 1, 5),
(N'DAF Light Bulb 05FG87',  55.00, 2, 13),
(N'ADR Shoes 47-47.5',      49.85, 3, 5),
(N'Anti-slip pads S',        5.87, 5, 7);

INSERT INTO [Invoices]([Number],[IssueDate],[DueDate],[Amount],[Currency],[ClientId])  
VALUES
(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19);


--3.	Update


--4.	Delete

--5.	Invoices by Amount and Date

  SELECT [Number],
         [Currency]
    FROM [Invoices]
ORDER BY [Amount] DESC,
         [DueDate] ASC

 --6.	Products by Category

  SELECT [p].[Id],
         [p].[Name],
         [p].[Price],
         [c].[Name]
    FROM [Products]
      AS [p]
    JOIN [Categories]
      AS [c]
      ON [c].[Id] = [p].CategoryId
   WHERE [c].[Name] IN ('ADR', 'Others')
ORDER BY [Price] DESC 
   

--7.  Clients without Products


  SELECT [c].[Id],
         [c].[Name],
         CONCAT([a].[StreetName], ' ',[a].[StreetNumber],', ', [a].[City],', ',[a].[PostCode],', ',[co].[Name])
      AS [Address]
    FROM [Clients]
      AS [c]
LEFT JOIN [ProductsClients]
      AS [pc]
      ON [c].[Id] = [pc].[ClientId]
LEFT JOIN [Products]
      AS [p]
      ON [p].[Id] = [pc].[ProductId]
    JOIN [Addresses]
      AS [a]
      ON [a].[Id] = [c].[AddressId]
    JOIN [Countries]
      AS [co]
      ON [co].[Id] = [a].[CountryId]
   WHERE [p].[Id] IS NULL
ORDER BY [c].[Name] ASC

--8.	First 7 Invoices

  SELECT TOP (7)
         [i].[Number],
         [i].[Amount],
         [c].[Name]
      AS [Client]
    FROM [Invoices]
      AS [i]
    JOIN [Clients]
      AS [c]
      ON [c].[Id] = [i].[ClientId]
   WHERE [i].[IssueDate] < '2023-01-01'AND [i].[Currency] = 'EUR' 
      OR [i].[Amount] > 500 AND CHARINDEX('DE', [c].[NumberVAT]) > 0 
ORDER BY [i].[Number] ASC,
         [i].[Amount] DESC

--9.	Clients with VAT

  SELECT [c].[Name]
      AS [Client],
         MAX([p].[Price])
      AS [Price],
         [c].[NumberVAT]
      AS [VAT Number]
    FROM [Clients]
      AS [c]
    JOIN [ProductsClients]
      AS [pc]
      ON [c].[Id] = [pc].[ClientId]
    JOIN [Products]
      AS [p]
      ON [p].[Id] = [pc].[ProductId]
   WHERE LOWER(RIGHT([c].[Name],2 )) != 'kg'
GROUP BY [c].[Name],
         [c].[NumberVAT]
ORDER BY [Price] DESC

--10.	Product with Clients


--11.	Search for Vendors from a Specific Country


