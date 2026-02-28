USE [SoftUni]

GO 

--1 Employees with Salary Above 35000

   CREATE 
PROCEDURE [usp_GetEmployeesSalaryAbove35000]
        AS 
           (
               SELECT [FirstName]
                   AS [First Name],
                      [LastName]
                   AS [Last Name]
                 FROM [Employees]
                WHERE [Salary] > 35000
           )

EXEC [usp_GetEmployeesSalaryAbove35000]

GO 

--2 Employees with Salary Above Number

   CREATE 
PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @SalaryAboveOrEqual DECIMAL(18,4)
       AS 
            (
               SELECT [FirstName]
                   AS [First Name],
                      [LastName]
                   AS [Last Name]
                 FROM [Employees]
                WHERE [Salary] >= @SalaryAboveOrEqual
            )

EXEC [usp_GetEmployeesSalaryAboveNumber] @SalaryAboveOrEqual = 48100

GO 

--3 Town Names Starting With


   CREATE
PROCEDURE [usp_GetTownsStartingWith] @StartingWith  NVARCHAR(50)
       AS
       BEGIN
       
            SELECT [Name] 
                AS [Towns]
              FROM [Towns]
             WHERE [Name] LIKE @StartingWith + '%'
       END 
      
       EXEC [usp_GetTownsStartingWith] @StartingWith = b

GO 

--4 Employees from Town



    CREATE 
  PROCEDURE [usp_GetEmployeesFromTown] @TowneName VARCHAR(50)
         AS 
         BEGIN 
          SELECT [e].[FirstName],
         [e].[LastName]
    FROM [Towns]
      AS [t]
    JOIN [Addresses]
      AS [a]
      ON [t].TownID = [a].TownID
    JOIN [Employees]
      AS [e]
      ON [a].[AddressID] = [e].[AddressID]
   WHERE [Name] = @TowneName
         END 

         EXEC [usp_GetEmployeesFromTown] @TowneName = 'Sofia'

GO 

--5 Salary Level Function

     CREATE FUNCTION [ufn_GetSalaryLevel]( @salary DECIMAL(18,4))
RETURNS NVARCHAR(10) 
                  AS 
               BEGIN
               DECLARE @result NVARCHAR(10);
               SET @result = 
                        CASE 
                             WHEN @salary < 30000 THEN 'Low'
                             WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
                             WHEN @salary > 50000 THEN 'High'
                         END 
                      RETURN @result
                  END
 
GO 
  

    SELECT [Salary],
           [dbo].[ufn_GetSalaryLevel]([Salary])
        AS [Salary Level]
    FROM [Employees]

GO 

--6 Employees by Salary Level

   CREATE 
PROCEDURE [dbo].[usp_EmployeesBySalaryLevel] @LevelOfSalary NVARCHAR(10)
       AS
    BEGIN
            SELECT [FirstName]
                AS [First Name],
                   [LastName]
                AS [Last Name]
              FROM [Employees]
             WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @LevelOfSalary
      END
GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'

GO 

--7 Define Function

SELECT [FirstName]
  FROM [Employees]
 WHERE CHARINDEX('guy',[Firstname])>0


 GO 

     CREATE 
   FUNCTION [ufn_IsWordComprised] (@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
         AS
      BEGIN 
            DECLARE @index INT = 1
            DECLARE @currentChar CHAR(1)

              WHILE @index <= LEN(@word)
              BEGIN 
                    SET @currentChar = SUBSTRING(@word,@index,1)
                    SET @index += 1 
                     IF CHARINDEX(@currentChar,@setOfLetters) <= 0
                  BEGIN 
                 RETURN 0
                    END 
                END 
                 RETURN 1      
        END 

GO 

SELECT [dbo].[ufn_IsWordComprised] ('oistmiahf', 'Sofia')
SELECT [dbo].[ufn_IsWordComprised] ('oistmiahf', 'halves')
SELECT [dbo].[ufn_IsWordComprised] ('bobr', 'Rob')
SELECT [dbo].[ufn_IsWordComprised] ('pppp', 'Guy')

GO 

--8 Delete Employees and Departments

   CREATE
       OR
    ALTER
PROCEDURE [usp_DeleteEmployeesFromDepartment](@departmentId INT) 
       AS
    BEGIN

            DECLARE @copyOfEmployeesToDelete TABLE ([ID] INT)
        INSERT INTO @copyOfEmployeesToDelete
             SELECT [EmployeeID]
               FROM [Employees]
              WHERE [DepartmentID] = @departmentId

             DELETE 
               FROM [EmployeesProjects]
              WHERE [EmployeeID] IN ( SELECT * FROM @copyOfEmployeesToDelete)
                                  
             UPDATE [Employees]
                SET [ManagerID] = NULL 
              WHERE [ManagerID] IN ( SELECT * FROM @copyOfEmployeesToDelete)

        ALTER TABLE [Departments]
       ALTER COLUMN [ManagerID] INT

             UPDATE [Departments]
                SET [ManagerID] = NULL
              WHERE [ManagerID] IN (SELECT * FROM @copyOfEmployeesToDelete)

             DELETE 
               FROM [Employees]
              WHERE [DepartmentID] = @departmentId

             DELETE 
               FROM [Departments]
              WHERE [DepartmentID] = @departmentId

             SELECT COUNT(*)
               FROM [Employees]
              WHERE [DepartmentID] = @departmentId

	END

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 7

    GO 

