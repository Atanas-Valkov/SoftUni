CREATE DATABASE [TouristAgency]

GO 

USE [TouristAgency]
USE [master]
GO 

CREATE TABLE [Countries]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Tourists]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL,
[PhoneNumber] VARCHAR(20) NOT NULL,
[Email] VARCHAR(80) NULL,
[CountryId] INT FOREIGN KEY REFERENCES [Countries] ([Id]) NOT NULL
)

CREATE TABLE [Destinations]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[CountryId] INT FOREIGN KEY REFERENCES [Countries] ([Id]) NOT NULL
)

CREATE TABLE [Hotels]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[DestinationId] INT FOREIGN KEY REFERENCES [Destinations] ([Id]) NOT NULL
)

CREATE TABLE [Rooms]
(
[Id] INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(40) NOT NULL,
[Price] DECIMAL(18,2) NOT NULL,
[BedCount] INT CHECK ([BedCount] > 0 AND [BedCount] <= 10) NOT NULL
)

CREATE TABLE [HotelsRooms]
(
[HotelId] INT FOREIGN KEY REFERENCES [Hotels] ([Id]) NOT NULL,
[RoomId] INT FOREIGN KEY REFERENCES [Rooms] ([Id]) NOT NULL,
PRIMARY KEY ([HotelId], [RoomId])
)

CREATE TABLE [Bookings]
(
[Id] INT PRIMARY KEY IDENTITY,
[ArrivalDate] DATETIME2 NOT NULL,
[DepartureDate] DATETIME2 NOT NULL,
[AdultsCount] INT CHECK ([AdultsCount] > 0 AND [AdultsCount] < 11) NOT NULL,
[ChildrenCount] INT CHECK ([ChildrenCount] >= 0 AND [ChildrenCount] <= 9) NOT NULL,
[TouristId] INT FOREIGN KEY REFERENCES [Tourists] ([Id]) NOT NULL,
[HotelId] INT FOREIGN KEY REFERENCES [Hotels] ([Id]) NOT NULL,
[RoomId] INT FOREIGN KEY REFERENCES [Rooms] ([Id]) NOT NULL
)

--2 

INSERT INTO [Tourists]([Name], [PhoneNumber], [Email], [CountryId])
VALUES
('John Rivers',     '653-551-1555', 'john.rivers@example.com',     6),
('Adeline Aglaé',   '122-654-8726', 'adeline.aglae@example.com',   2),
('Sergio Ramirez',  '233-465-2876', 's.ramirez@example.com',       3),
('Johan Müller',    '322-876-9826', 'j.muller@example.com',        7),
('Eden Smith',      '551-874-2234', 'eden.smith@example.com',      6)

INSERT  INTO [Bookings]([ArrivalDate], [DepartureDate], [AdultsCount], [ChildrenCount], [TouristId], [HotelId], [RoomId])
VALUES
('2024-03-01', '2024-03-11', 1, 0, 21,  3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24,  6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)







GO 
--5 

  SELECT FORMAT([ArrivalDate], 'yyyy-MM-dd')
      AS [ArrivalDate],
         [b].[AdultsCount],
         [b].[ChildrenCount]
    FROM [Bookings]
      AS [b]
    JOIN [Rooms]
      AS [r]
      ON [r].[Id] = [b].[RoomId]
ORDER BY [r].[Price] DESC,
         [b].[ArrivalDate] ASC

GO 

--6


  SELECT
         [h].[Id],
         [h].[Name]
    FROM [Hotels]
      AS [h]
    JOIN [Bookings]
      AS [b]
      ON [h].[Id] = [b].[HotelId]
   WHERE [h].[Id] IN
                   (
                     SELECT  [hr].[HotelId]
                     FROM    [HotelsRooms] AS [hr]
                     JOIN    [Rooms]       AS [r]
                             ON [r].[Id] = [hr].[RoomId]
                     WHERE   [r].[Type] = 'VIP Apartment'
                   )
GROUP BY [h].[Id], [h].[Name]
ORDER BY COUNT([b].[Id]) DESC

--7

   SELECT [t].[Id],
          [t].[Name],
          [t].[PhoneNumber]
     FROM [Tourists]
       AS [t]
LEFT JOIN [Bookings]
       AS [b]
       ON [t].[Id] = [b].[TouristId]
    WHERE [b].[Id] IS NULL
 ORDER BY [t].[Name] ASC 

--8

  SELECT TOP 10
         [h].[Name]
      AS [HotelName],
         [d].[Name]
      AS [DestinationName],
         [c].[Name]
      AS [CountryName]
    FROM [Bookings]
      AS [b]
    JOIN [Hotels]
      AS [h]
      ON [h].[Id] = [b].[HotelId]
    JOIN [Destinations]
      AS [d]
      ON [d].[id] = [h].[DestinationId]
    JOIN [Countries]
      AS [c]
      ON [c].[Id] = [d].[CountryId]
   WHERE [b].[ArrivalDate] < '2023-12-31'
     AND [h].[Id] % 2 = 1
ORDER BY [c].[Name] ASC,
         [b].[ArrivalDate] ASC

GO 

--9

  SELECT [h].[Name]
      AS [HotelName],
         [r].[Price]
      AS [RoomPrice]
    FROM [Tourists]
      AS [t]
    JOIN [Bookings]
      AS [b]
      ON [t].[Id] = [b].[TouristId]
    JOIN [Hotels]
      AS [h]
      ON [h].[Id] = [b].[HotelId]
    JOIN [Rooms]
      AS [r]
      ON [r].[Id] = [b].[RoomId]
   WHERE [t].[Name] NOT LIKE '%EZ'
ORDER BY [r].[Price] DESC 

GO 

--10
 
  SELECT [h].[Name]
         AS [HotelName],
         SUM(
            [r].[Price] * DATEDIFF(DAY, [b].[ArrivalDate], [b].[DepartureDate])
            )
      AS [HotelRevenue]
    FROM [Bookings]
      AS [b]
    JOIN [Hotels]
      AS [h]
      ON [h].[Id] = [b].[HotelId]
    JOIN [Rooms]
      AS [r]
      ON [r].[Id] = [b].[RoomId]
GROUP BY [h].[Name] 
ORDER BY [HotelRevenue] DESC 

GO

--11

     CREATE 
         OR
      ALTER 
   FUNCTION [udf_RoomsWithTourists](@name VARCHAR(40))
RETURNS INT
         AS
      BEGIN

             DECLARE @Result INT

            SELECT @Result = SUM([b].[AdultsCount]) + SUM([b].[ChildrenCount]) 
               FROM [Bookings]
                 AS [b]
               JOIN [Rooms]
                 AS [r]
                 ON [r].[id] = [b].[RoomId]
              WHERE [r].[Type] = @name
             RETURN @Result
        END
GO 

   SELECT [dbo].[udf_RoomsWithTourists]('Double Room')  

GO 
       
--12

   CREATE
       OR
    ALTER
PROCEDURE [usp_SearchByCountry](@country NVARCHAR(50))  
       AS
    BEGIN
              SELECT [t].[Name],
                     [t].[PhoneNumber],
                     [t].[Email],
                     COUNT(*)
                  AS [CountOfBookings]
                FROM [Tourists]
                  AS [t]
                JOIN [Bookings]
                  AS [b]
                  ON [t].[Id] = [b].[TouristId]
                JOIN [Countries]
                  AS [c]
                  ON [c].[Id] = [t].[CountryId]
               WHERE [c].[Name] = @country
            GROUP BY [t].[Name],
                     [t].[PhoneNumber],
                     [t].[Email]
            ORDER BY [t].[Name] ASC 

	  END

GO 

EXEC [usp_SearchByCountry] 'Greece'

GO 
