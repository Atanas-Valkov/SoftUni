CREATE DATABASE [ShoesApplicationDatabase]

GO 

USE [ShoesApplicationDatabase]

GO 

CREATE TABLE [Users]
(
[Id] INT PRIMARY KEY IDENTITY,
[Username] NVARCHAR(50) UNIQUE NOT NULL,
[FullName] NVARCHAR(100) NOT NULL,
[PhoneNumber] NVARCHAR(15) NULL,
[Email] NVARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE [Brands]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Sizes]
(
[Id] INT PRIMARY KEY IDENTITY,
[EU] DECIMAL(5,2) NOT NULL,
[US] DECIMAL(5,2) NOT NULL,
[UK] DECIMAL(5,2) NOT NULL,
[CM] DECIMAL(5,2) NOT NULL,
[IN] DECIMAL(5,2) NOT NULL
)

CREATE TABLE [Shoes]
(
[Id] INT PRIMARY KEY IDENTITY,
[Model] NVARCHAR(30) NOT NULL,
[Price] DECIMAL(10,2) NOT NULL,
[BrandId] INT FOREIGN KEY REFERENCES [Brands] ([Id]) NOT NULL
)

CREATE TABLE [Orders]
(
[Id] INT PRIMARY KEY IDENTITY,
[ShoeId] INT FOREIGN KEY REFERENCES [Shoes] ([Id]) NOT NULL,
[SizeId] INT FOREIGN KEY REFERENCES [Sizes] ([Id]) NOT NULL,
[UserId] INT FOREIGN KEY REFERENCES [Users] ([Id]) NOT NULL
)

CREATE TABLE [ShoesSizes]
(
[ShoeId] INT FOREIGN KEY REFERENCES [Shoes] ([Id]) NOT NULL,
[SizeId] INT FOREIGN KEY REFERENCES [Sizes] ([Id]) NOT NULL,
PRIMARY KEY ([ShoeId],[SizeId])
)

GO 

--2 Insert

INSERT INTO [Brands]([Name])
VALUES
('Timberland'),
('Birkenstock')

INSERT INTO [Shoes] ([Model], [Price], [BrandId]) 
VALUES 
('Reaxion Pro', 150.00, 12),
('Laurel Cort Lace-Up', 160.00, 12),
('Perkins Row Sandal', 170.00, 12),
('Arizona', 80.00, 13),
('Ben Mid Dip', 85.00, 13),
('Gizeh', 90.00, 13)

INSERT INTO [ShoesSizes] ([ShoeId], [SizeId])
VALUES
(70, 1),
(70, 2),
(70, 3),
(71, 2),
(71, 3),
(71, 4),
(72, 4),
(72, 5),
(72, 6),
(73, 1),
(73, 3),
(73, 5),
(74, 2),
(74, 4),
(74, 6),
(75, 1),
(75, 2),
(75, 3)

INSERT INTO [Orders] ([ShoeId], [SizeId], [UserId])
VALUES
(70, 2, 15),
(71, 3, 17),
(72, 6, 18),
(73, 5, 4),
(74, 4, 7),
(75, 1, 11)





--5 Orders By Price of the Shoe
 
  SELECT [Model]
      AS [ShoeModel],
         [Price]
    FROM [Orders]
      AS [o]
    JOIN [Shoes]
      AS [s]
      ON [s].[Id] = [o].ShoeId
ORDER BY [Price] DESC,
         [Model] ASC

--6 Shoes With Their Brand
  
  SELECT [b].[Name]
      AS [BrandName],
         [s].[Model]
      AS [ShoesCount]
    FROM [Shoes]
      AS [s]
    JOIN [Brands]
      AS [b]
      ON [b].[Id] = [s].BrandId
ORDER BY [b].[Name] ASC,
         [s].[Model]

--7 Top 10 Users By Total Money Spent

 SELECT TOP (10)
        [u].[Id],
        [u].[FullName],
        [x].[TotalPrice]
   FROM [Users]
     AS [u]
   JOIN
                  (
                      SELECT [o].[UserId],
                             SUM([s].[Price]) AS [TotalPrice]
                        FROM [Orders]
                          AS [o]
                        JOIN [Shoes]
                          AS [s]
                          ON [s].[Id] = [o].[ShoeId]
                    GROUP BY [o].[UserId]
                  )
      AS [x]
      ON [x].[UserId] = [u].[Id]
ORDER BY [x].[TotalPrice] DESC,
         [u].[FullName] ASC 

--8 Average Price Of Orders


   SELECT [u].[Username]
       AS [Username],
          [u].[Email],
          FORMAT([AveragePriceOfOrders].[AvgPrice], 'F2')
       AS [AvgPrice]
     FROM [Users]
       AS [u]
     JOIN (
                SELECT [o].[UserId],
                       AVG([s].[Price])
                    AS [AvgPrice]
                  FROM [Orders]
                    AS [o]
                  JOIN [Shoes]
                    AS [s]
                    ON [s].[Id] = [o].[ShoeId]
              GROUP BY [o].[UserId]
                HAVING COUNT(*)>2
          ) 
       AS [AveragePriceOfOrders]
       ON [u].[Id] = [AveragePriceOfOrders].[UserId]
 ORDER BY [AveragePriceOfOrders].[AvgPrice] DESC
          

--9 Running Shoes Analysis

WITH [cte_RunningShoesMoreThenThreeSizes]
  AS
     (
  SELECT [s].[Id],
         COUNT([ss].[SizeId])
      AS [SizeCount]
    FROM [ShoesSizes]
      AS [ss] 
    JOIN [Sizes]
      AS [sz]
      ON [sz].[Id] = [ss].[SizeId]
    JOIN [Shoes]
      AS [s]
      ON [s].[Id] = [ss].[ShoeId]
   WHERE CHARINDEX('Run',[s].[Model]) > 0
GROUP BY [s].[Id],
         [s].[Model],
         [s].[BrandId]
  HAVING COUNT(DISTINCT [ss].[SizeId]) > 3
     )

  SELECT [b].[Name]
      AS [BrandName],
         COUNT([cte].[Id])
      AS [ModelsCount],
      SUM([cte].[SizeCount])
   AS [TotalDistinctSizesAcrossModels],
      STRING_AGG([s].[Model], ', ') WITHIN GROUP (ORDER BY [s].[Model])
   AS [Models]
    FROM [Brands] 
      AS [b]
    JOIN [Shoes]
      AS [s]
      ON [b].[Id] = [s].[BrandId]
    JOIN [cte_RunningShoesMoreThenThreeSizes]
      AS [cte]
      ON [s].[Id] = [cte].[Id]
GROUP BY [b].[Name]

GO 

--10 Phone Including Digits 345

  SELECT [u].[FullName],
         [u].[PhoneNumber],
         [sh].[Price]
      AS [OrderPrice],
         [sh].[Id]
      AS [ShoeId],
         [b].[Id]
      AS [BrandId],      --'45.00EU/10.00US/7.50UK'
        CONCAT([si].[EU], 'EU/',[si].[US], 'US/',[si].[UK], 'UK')
    FROM [Orders]
      AS [o]
    JOIN [Users]
      AS [u]
      ON [u].[Id] = [o].[UserId]
    JOIN [Shoes]
      AS [sh]
      ON [sh].[Id] = [o].[ShoeId]
    JOIN [Brands]
      AS [b]
      ON [b].[Id] = [sh].[BrandId]
    JOIN [Sizes]
      AS [si]
      ON [si].[Id] = [o].[SizeId]
   WHERE CHARINDEX('345', [u].[PhoneNumber]) > 0 
ORDER BY [sh].[Model] ASC 

--11 Find All Orders By Email Address

GO 

     CREATE 
         OR
      ALTER 
   FUNCTION [dbo].[udf_OrdersByEmail](@email NVARCHAR(100))
RETURNS INT
         AS
      BEGIN

                DECLARE @Result INT;

                 SELECT @Result = COUNT(*)

                   FROM [Users]
                     AS [u]
                   JOIN [Orders]
                     AS [o]
                     ON [u].[Id] = [o].UserId
                  WHERE CHARINDEX(@email,[u].[Email]) > 0;
    RETURN @Result;

END

GO

SELECT [dbo].[udf_OrdersByEmail]('sstewart@example.com')

GO

--12 Shoe Details By Size (optional Brand filter)

   CREATE
       OR
    ALTER
PROCEDURE [usp_SearchByShoeSize]
(
@shoeSize DECIMAL(5,2),
@brandName NVARCHAR(50) = NULL
) 
       AS
    BEGIN
                SELECT [sh].[Model]
                    AS [ModelName],
                       [u].[FullName]
                    AS [UserFullName],
                       CASE
                           WHEN [sh].[Price] < 100 THEN 'Low'
                           WHEN [sh].[Price] BETWEEN 100 AND 200 THEN 'Medium'
                           ELSE 'High'
                        END
                    AS [PriceLevel],
                       [b].[Name]
                    AS [BrandName],
                       [si].[EU]
                    AS [SizeEU]
                  FROM [Orders]
                    AS [o]
                  JOIN [Shoes]
                    AS [sh]
                    ON [sh].[Id] = [o].[ShoeId]
                  JOIN [Users]
                    AS [u]
                    ON [u].Id = [o].UserId
                  JOIN [Sizes]
                    AS [si]
                    ON [si].[Id] = [o].[SizeId]
                  JOIN [Brands]
                    AS [b]
                    ON [b].[Id] = [sh].[BrandId]
                 WHERE [si].[EU] = @shoeSize 
                   AND (@brandName IS NULL OR [b].[Name] = @brandName)
              ORDER BY [b].[Name],
                       [u].[FullName]
	  END

GO 

EXEC [usp_SearchByShoeSize] 39.00, 'New Balance'
EXEC usp_SearchByShoeSize 
GO 