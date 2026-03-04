
CREATE DATABASE [RailwaysDb]

GO 

USE [RailwaysDb]
USE [master]

GO 

--1 DDL (30 pts)

CREATE TABLE [Passengers]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [Towns]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Trains]
(
[Id] INT PRIMARY KEY IDENTITY,
[HourOfDeparture] VARCHAR(5) NOT NULL,
[HourOfArrival] VARCHAR(5) NOT NULL,
[DepartureTownId] INT FOREIGN KEY REFERENCES [Towns] ([Id]) NOT NULL,
[ArrivalTownId] INT FOREIGN KEY REFERENCES [Towns] ([Id]) NOT NULL
)

CREATE TABLE [RailwayStations]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES [Towns] ([Id]) NOT NULL
)

CREATE TABLE [Tickets]
(
[Id] INT PRIMARY KEY IDENTITY,
[Price] DECIMAL(10,2) NOT NULL,
[DateOfDeparture] Date NOT NULL,
[DateOfArrival] Date NOT NULL,
[TrainId] INT FOREIGN KEY REFERENCES [Trains] ([Id]) NOT NULL,
[PassengerId] INT FOREIGN KEY REFERENCES [Passengers] ([Id]) NOT NULL
)

CREATE TABLE [MaintenanceRecords]
(
[Id] INT PRIMARY KEY IDENTITY,
[DateOfMaintenance] Date NOT NULL,
[Details] VARCHAR(200) NOT NULL,
[TrainId] INT FOREIGN KEY REFERENCES [Trains] ([Id]) NOT NULL
)

CREATE TABLE [TrainsRailwayStations]
(
[TrainId] INT FOREIGN KEY REFERENCES [Trains] ([Id]) NOT NULL,
[RailwayStationId] INT FOREIGN KEY REFERENCES [RailwayStations] ([Id]) NOT NULL,
PRIMARY KEY ([TrainId],[RailwayStationId])
)

--2 Insert

INSERT INTO [Trains]([HourOfDeparture], [HourOfArrival], [DepartureTownId], [ArrivalTownId])
VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5)

INSERT INTO [Tickets]([Price], [DateOfDeparture], [DateOfArrival], [TrainId], [PassengerId])
VALUES
(90.00,  '2023-12-01', '2023-12-01', 36,  1),
(115.00, '2023-08-02', '2023-08-02', 37,  2),
(160.00, '2023-08-03', '2023-08-03', 38,  3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00,  '2023-09-02', '2023-09-03', 40, 22)

INSERT INTO [TrainsRailwayStations]([TrainId], [RailwayStationId])
VALUES
(36, 1),
(36, 4),
(36, 31),
(36, 57),
(36, 7),

(37, 60),
(37, 16),
(37, 13),
(37, 54),

(38, 10),
(38, 50),
(38, 52),
(38, 22),

(39, 3),
(39, 31),
(39, 19),
(39, 68),

(40, 41),
(40, 7),
(40, 52),
(40, 13)








--5 Tickets by Price and Date of Departure

  SELECT [DateOfDeparture],
         [Price]
      AS [TicketPrice]
    FROM [Tickets]
ORDER BY [Price] ASC,
         [DateOfDeparture] DESC 

GO

--6 Passengers with their Tickets

  SELECT [p].[Name]
      AS [PassengerName],
         [t].[Price]
      AS [TicketPrice],
         [t].[DateOfDeparture],
         [tr].[Id]
    FROM [Tickets]
      AS [t]
    JOIN [Passengers]
      AS [p]
      ON [p].[Id] = [t].[PassengerId]
    JOIN [Trains]
      AS [tr]
      ON [tr].[Id] = [t].[TrainId]
ORDER BY [t].[Price] DESC,
         [p].[Name] ASC

GO 

--7 Railway Stations without Passing Trains

   SELECT [t].[Name]
       AS [Town],
          [rs].[Name]
       AS [RailwayStation]
     FROM [RailwayStations]
       AS [rs]
     JOIN [Towns]
       AS [t]
       ON [t].[Id] = [rs].[TownId]
LEFT JOIN [TrainsRailwayStations]
       AS [trs]
       ON [rs].[Id] = [trs].[RailwayStationId]
    WHERE [trs].[TrainId] IS NULL
 ORDER BY [t].[Name] ASC,
          [rs].[Name]ASC

GO 

--8 First 3 Trains Between 8:00 and 8:59

    SELECT TOP (3) *
      FROM (
              SELECT [tr].[Id]
                  AS [TrainId],
                     [tr].[HourOfDeparture],
                     [ti].[Price]
                  AS [TicketPrice],
                     [to].[Name]
                  AS [Destination]
                FROM [Trains]
                  AS [tr]
                JOIN [Tickets]
                  AS [ti]
                  ON [tr].[Id] = [ti].[TrainId]
                JOIN [Towns]
                  AS [to]
                  ON [to].[Id] = [tr].[ArrivalTownId]
               WHERE CAST([tr].[HourOfDeparture] AS TIME) >= '08:00'
                AND CAST([tr].[HourOfDeparture] AS TIME) < '09:00'
           ) as [TrainsBetween8:00And8:59]
     WHERE [TrainsBetween8:00And8:59].[TicketPrice] > 50.00
  ORDER BY [TrainsBetween8:00And8:59].[TicketPrice] ASC

GO 

--9 Count of Passengers Paid More Than Average With Arrival Towns

  SELECT [to].[Name]
      AS [TownName],
         COUNT([ti].[PassengerId])
      AS [PassengersCount]
    FROM [Tickets]
      AS [ti]
    JOIN [Trains]
      AS [tr]
      ON [tr].[Id] = [ti].[TrainId]
    JOIN [Towns]
      AS [to]
      ON [to].[Id] = [tr].[ArrivalTownId]
   WHERE [ti].[Price] >
       (
           SELECT AVG([Price])
             FROM [Tickets]
       )
 GROUP BY [to].[Name]
 ORDER BY [to].[Name] ASC 

 GO 

 --10 Maintenance Inspection with Town










 --11 Towns with Trains

 GO 
     CREATE 
         OR
      ALTER 
   FUNCTION [dbo].udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
         AS
      BEGIN

                DECLARE @Result INT

                 SELECT @Result = COUNT(*) 
                   FROM [Trains]
                     AS [tr]
                   JOIN [Towns]
                     AS [to]
                     ON [to].[Id] = [tr].[DepartureTownId]
                     OR [to].[Id] = [tr].[ArrivalTownId]
                  WHERE [to].[Name] = @name
             
                  RETURN @Result

        END

GO 

   SELECT [dbo].[udf_TownsWithTrains]('Paris')     

GO 

-- 12 Search Passenger Travelling to Specific Town

   CREATE
       OR
    ALTER
PROCEDURE [usp_SearchByTown](@townName VARCHAR(30))  
       AS
    BEGIN
              SELECT [p].[Name]
                  AS [PassengerName],
                     [DateOfDeparture],
                     [HourOfDeparture]
                FROM [Tickets]
                  AS [ti]
                JOIN [Passengers]
                  AS [p]
                  ON [p].[Id] = [ti].[PassengerId]
                JOIN [Trains]
                  AS [tr]
                  ON [tr].[Id] = [ti].[TrainId]
                JOIN [Towns]
                  AS [to]
                  ON [to].[Id] = [tr].[ArrivalTownId]
               WHERE [to].[Name] = @townName 
            ORDER BY [ti].[DateOfDeparture] DESC,
                     [p].[Name]

	  END

GO 

EXEC [usp_SearchByTown] 'Berlin'

GO 



