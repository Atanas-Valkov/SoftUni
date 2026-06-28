CREATE DATABASE [NationalTouristSitesOfBulgaria]

USE [NationalTouristSitesOfBulgaria]

GO 

CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL 
)

CREATE TABLE [Locations]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Municipality] VARCHAR(50) NULL,
[Province] VARCHAR(50) NULL 
)

CREATE TABLE [Sites]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
[LocationId] INT FOREIGN KEY REFERENCES [Locations]([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Establishment] VARCHAR(15) NULL
)

CREATE TABLE [Tourists]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Age] INT NOT NULL CHECK ([Age] BETWEEN 0 AND 120),
[PhoneNumber] VARCHAR(20) NOT NULL,
[Nationality] VARCHAR(30) NOT NULL,
[Reward] VARCHAR(20) NULL
)

CREATE TABLE [SitesTourists]
(
[TouristId] INT FOREIGN KEY REFERENCES [Sites]([Id]) NOT NULL,
[SiteId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
PRIMARY KEY([TouristId],[SiteId])
)

CREATE TABLE [BonusPrizes]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
)




CREATE TABLE [TouristsBonusPrizes]
(
[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes]([Id]) NOT NULL,
PRIMARY KEY([TouristId],[BonusPrizeId])
)

--2.	Insert

INSERT INTO [Tourists]([Name],[Age],[PhoneNumber],[Nationality],[Reward])
VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh',         48, '+447911844141', 'UK',       NULL),
('Martin Smith',       29, '+353863818592', 'Ireland',  'Bronze badge'),
('Svilen Dobrev',      49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova',     38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO [Sites]([Name],[LocationId],[CategoryId],[Establishment])
VALUES
(N'Ustra fortress',                  90, 7, N'X'),
(N'Karlanovo Pyramids',              65, 7, NULL),
(N'The Tomb of Tsar Sevt',           63, 8, N'V BC'),
(N'Sinite Kamani Natural Park',      17, 1, NULL),
(N'St. Petka of Bulgaria – Rupite',  92, 6, N'1994');

--3.	Update


--4.	Delete


--5.	Tourists

  SELECT [t].[Name],
         [t].[Age],
         [t].[PhoneNumber],
         [t].[Nationality]
    FROM [Tourists]
      AS [t]
ORDER BY [Nationality] ASC,
         [Age] DESC,
         [Name] ASC

--6.	Sites with Their Location and Category

  SELECT [s].[Name],
         [l].[Name],
         [s].[Establishment],
         [c].[Name]
    FROM [Sites]
      AS [s]
    JOIN [Locations]
      AS [l]
      ON [s].[LocationId] = [l].[Id]
    JOIN [Categories]
      AS [c]
      ON [s].[CategoryId] = [c].[Id]
ORDER BY [c].[Name] DESC,
         [l].[Name] ASC

-- 7.	Count of Sites in Sofia Province

  SELECT [l].[Province],
         [l].[Municipality],
         [l].[Name],
         COUNT([l].[Name])
      AS [CountOfSites]
    FROM [Locations]
      AS [l]
    JOIN [Sites]
      AS [s]
      ON [s].[LocationId] = [l].[Id]
   WHERE [l].[Province] = 'Sofia' 
GROUP BY [l].[Province],
         [l].[Municipality],
         [l].[Name]
ORDER BY [CountOfSites] DESC,
         [l].[Name] ASC
    
--8.	Tourist Sites established BC

    
  SELECT [s].[Name],
         [l].[Name],
         [l].[Municipality],
         [l].[Province],
         [s].[Establishment]
    FROM [Sites]
      AS [s]
    JOIN [Locations]
      AS [l]
      ON [s].[LocationId] = [l].[Id]
   WHERE [l].[Name] LIKE '[^B, ^M, ^D]%'
     AND [s].[Establishment] LIKE '%BC'
ORDER BY [s].[Name] ASC

--9.	Tourists with their Bonus Prizes

   SELECT [t].[Name],
          [t].[Age],
          [t].[PhoneNumber],
          [t].[Nationality],
          ISNULL([bp].[Name], '(no bonus prize)')
       AS [Reward]
     FROM [Tourists]
       AS [t]
LEFT JOIN [TouristsBonusPrizes]
       AS [tbp]
       ON [tbp].[TouristId] = [t].[Id]
LEFT JOIN [BonusPrizes]
       AS [bp]
       ON [tbp].[BonusPrizeId] = [bp].[Id]
 ORDER BY [t].[Name] ASC

 --10.	Tourists visiting History and Archaeology sites

  SELECT DISTINCT
         SUBSTRING([t].[Name],CHARINDEX(' ', [t].[Name]) + 1,LEN([t].[Name]))
      AS [LastName],
         [t].[Nationality],
         [t].[Age],
         [t].[PhoneNumber]
    FROM [Tourists]
      AS [t]
    JOIN [SitesTourists]
      AS [st]
      ON [st].[TouristId] = [t].[Id]
    JOIN [Sites]
      AS [s]
      ON [st].[SiteId] = [s].[Id]
    JOIN [Categories]
      AS [c]
      ON [s].[CategoryId] = [c].[Id]
   WHERE [c].[Name] = 'History and archaeology'
ORDER BY [LastName]

--11.	Tourists Count on a Tourist Site

GO

     CREATE 
   FUNCTION [udf_GetTouristsCountOnATouristSite](@Site VARCHAR(100))
RETURNS INT
         AS 
      BEGIN
             DECLARE @result INT 
           
              SELECT @result = COUNT([t].[Id])
                FROM [Tourists]
                  AS [t]
                JOIN [SitesTourists]
                  AS [st]
                  ON [st].[TouristId] = [t].[Id]
                JOIN [Sites]
                  AS [s]
                  ON [st].[SiteId] = [s].[Id]
               WHERE [s].[Name] = @Site

              RETURN @result
     
        END 

GO

SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Regional History Museum – Vratsa')

GO           

--12.	Annual Reward Lottery

   CREATE
       OR
    ALTER
PROCEDURE [dbo].[usp_AnnualRewardLottery] @TouristName NVARCHAR(30)
       AS
    BEGIN
          
            SELECT [t].[Name],
                   CASE 
                       WHEN COUNT([t].[Name]) >= 100  THEN 'Gold badge'
                       WHEN COUNT([t].[Name]) >= 50  THEN 'Silver badge'
                       WHEN COUNT([t].[Name]) >= 25  THEN 'Bronze badge'
                    END 
                AS [Reward]
              FROM [Tourists]
                AS [t]
              JOIN [SitesTourists]
                AS [st]
                ON [st].[TouristId] = [t].[Id]
              JOIN [Sites]
                AS [s]
                ON [st].[SiteId] = [s].[Id]
             WHERE [t].[Name] = @TouristName
          GROUP BY [t].[Name]
      END

GO 

EXEC [dbo].[usp_AnnualRewardLottery] 'Gerhild Lutgard'

GO 



