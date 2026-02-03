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






  /*
  SELECT *
    FROM [Employees]

