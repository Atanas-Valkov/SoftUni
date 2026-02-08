--1 Find Names of All Employees by First Name
 USE [SoftUni]
 
GO 

 SELECT [FirstName],
        [LastName]
   FROM [Employees]
  WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'
 
GO 
 
 --2 Find Names of All Employees by Last Name 
       
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

GO 

 --3 Find First Names of All Employees

 SELECT [FirstName]
   FROM [Employees]
  WHERE [DepartmentID] IN (3,10)
    AND DATEPART(year,[HireDate]) BETWEEN '1995' AND '2005'

GO 

--4 Find All Employees Except Engineers
 
SELECT  [FirstName],
        [LastName]
   FROM [Employees]
  WHERE LOWER([JobTitle]) NOT LIKE '%engineer%'

GO 

--5 Find Towns with Name Length

   SELECT [Name]
     FROM [Towns]
    WHERE LEN([Name]) IN (5,6)
 ORDER BY [Name] ASC

GO 

--6 Find Towns Starting With
 
  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]
 
GO 

 --7 Find Towns Not Starting With

  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE SUBSTRING([Name],1,1) NOT IN ('R','B','D')
ORDER BY [Name] ASC

GO 

--8 Create View Employees Hired After 2000 Year

CREATE VIEW [V_EmployeesHiredAfter2000]
         AS
     SELECT [FirstName],
            [LastName]
       FROM [Employees]
      WHERE YEAR([HireDate]) > 2000

GO

--9 Length of Last Name
  
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

GO

--10 Rank Employees by Salary

  SELECT [EmployeeID],
         [FirstName],
         [LastName],
         [Salary],
         DENSE_RANK() OVER 
         (
         PARTITION BY [Salary]
         ORDER BY [EmployeeID] ASC 
         ) 
      AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

GO 

--11 Find All Employees with Rank 2

  SELECT [X].[EmployeeID],
         [X].[FirstName],
         [X].[LastName],
         [X].[Salary],
         [X].[Rank]
    FROM
(
  SELECT [EmployeeID],
         [FirstName],
         [LastName],
         [Salary],
         DENSE_RANK() OVER 
         (
         PARTITION BY [Salary]
         ORDER BY [EmployeeID] ASC 
         ) 
      AS [Rank] 
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
 )    AS [X]
   WHERE [X].[Rank] = 2 
ORDER BY [X].[Salary] DESC


GO

--12 Countries Holding 'A' 3 or More Times

USE Geography

GO

  SELECT [CountryName],
         [IsoCode]
    FROM [Countries] 
      AS c 
   WHERE LEN(c.[CountryName]) - LEN(REPLACE(c.[CountryName], 'A', '')) >= 3
ORDER BY [IsoCode]

GO 
--13 Mix of Peak and River Names

  SELECT p.[PeakName],
         r.[RiverName],
         LOWER(CONCAT((p.[PeakName]), STUFF(r.[RiverName], 1, 1, '')))    
      AS [Mix]
    FROM [Peaks]
      AS p,
         [Rivers]
      AS r
   WHERE LOWER(RIGHT(p.[PeakName],1)) = LOWER(LEFT(r.[RiverName],1))
ORDER BY [Mix] 

GO 

--14 Games from 2011 and 2012 Year

USE [Diablo]

GO 

SELECT TOP (50) [Name],
              FORMAT([Start], 'yyyy-MM-dd') 
           AS [Start]
         FROM [Games]
        WHERE YEAR([Start]) = 2011 OR YEAR([Start]) = 2012
     ORDER BY [Start], [Name]

GO 

--15 User Email Providers

  SELECT [Username],
         SUBSTRING([Email],CHARINDEX('@',[Email]) + 1,LEN([Email]))
      AS [Email Provider]
    FROM [Users]
ORDER BY [Email],[Username]

GO 

--16 Get Users with IP Address Like Pattern

  SELECT [Username],
         [IpAddress]
      AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

GO 

--17 Show All Games with Duration and Part of the Day

  SELECT [Name]
      AS [Game],
    CASE
    WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
    WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
    ELSE 'Evening'
     END
      AS [Part of the Day],
    CASE
    WHEN [Duration] <=3 THEN 'Extra Short'
    WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
    WHEN [Duration] > 6 THEN 'Long'
    ELSE 'Extra Long'
     END
      AS [Duration]
    FROM [Games]
ORDER BY [Game],[Duration]


SELECT *
  FROM [Games] 
  ORDER BY [Name] ASC