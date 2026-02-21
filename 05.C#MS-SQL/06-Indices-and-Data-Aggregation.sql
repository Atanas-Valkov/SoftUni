--1 Records' Count
USE [Gringotts]

  SELECT COUNT([Id])
      AS [Count]
    FROM [WizzardDeposits]

GO 

--2 Longest Magic Wand

  SELECT TOP (1)
         [MagicWandSize]
      AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [MagicWandSize] 
ORDER BY [MagicWandSize] DESC

GO 

--3 Longest Magic Wand Per Deposit Groups

  SELECT [DepositGroup]
      AS [d],
         MAX([MagicWandSize])
      AS [LongestMagicWand]
    FROM [WizzardDeposits]

GROUP BY [DepositGroup]

GO 

--4 Smallest Deposit Group Per Magic Wand Size

SELECT TOP (10)
           [DepositGroup]
        AS [d]
      FROM [WizzardDeposits]
  GROUP BY [DepositGroup]
  ORDER BY AVG([MagicWandSize])

GO 

--5 Deposits Sum

  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

GO 

--6 Deposits Sum for Ollivander Family


  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator]  = 'Ollivander family'
GROUP BY [DepositGroup]

GO 

--7 Deposits Filter

  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

GO 

--8 Deposit Charge


  SELECT [DepositGroup],
         [MagicWandCreator],
         MIN([DepositCharge])
      AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup] ASC

GO 

--9 Age Groups

  SELECT [AgeGroup],
          COUNT([GroupingByAge].AgeGroup)
      AS [WizardCount]
    FROM 
            (
              SELECT 
               CASE 
                     WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
                     WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                     WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
                     WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
                     WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
                     WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                     WHEN [Age] >= 61 THEN '[61+]'
                     ELSE NULL
                END 
                 AS [AgeGroup]
               FROM [WizzardDeposits]
            )AS [GroupingByAge]
GROUP BY [GroupingByAge].AgeGroup

GO 

--10 First Letter

  SELECT [FirstLetter]
    FROM 
           (
            SELECT SUBSTRING([FirstName],1,1)
                AS [FirstLetter]
              FROM [WizzardDeposits]
             WHERE [DepositGroup] = 'Troll Chest'
           ) AS [FirstLetterTempQuery]
GROUP BY [FirstLetterTempQuery].FirstLetter

GO 

--11 Average Interest 

  SELECT [DepositGroup],
         [IsDepositExpired],
         AVG([w].[DepositInterest])
      AS [AverageInterest]
    FROM [WizzardDeposits]
      AS [w]
   WHERE [w].[DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup],[IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC

GO 

--12 *Rich Wizard, Poor Wizard

SELECT SUM([sq].Difference)
  FROM 
        (
          SELECT [host].[FirstName]
      AS [Host Wizard],
         [host].[DepositAmount]
      AS [Host Wizard Deposit],
         [gest].[FirstName]
      AS [Guest Wizard],
         [gest].[DepositAmount]
      AS [Guest Wizard Deposit],
         [host].[DepositAmount] - [gest].[DepositAmount]
      AS [Difference]
    FROM [WizzardDeposits]
      AS [host]
    JOIN [WizzardDeposits]
      AS [gest]
      ON [gest].[Id] = [host].[Id] + 1
        ) AS [sq]

--other solution
USE [Gringotts]

  SELECT SUM([Host Wizard Deposit] - [Guest Wizard Deposit]) 
    FROM 
            (
                SELECT [FirstName]
                    AS [Host Wizard],
                       [DepositAmount]
                    AS [Host Wizard Deposit],
                       LEAD([FirstName]) OVER(ORDER BY [ID])
                    AS [Guest Wizard],
                       LEAD([DepositAmount]) OVER(ORDER BY [ID])
                    AS [Guest Wizard Deposit]
                  FROM [WizzardDeposits]
            ) 
       AS [sq]
    WHERE [Guest Wizard] IS NOT NULL

GO 

--13 Departments Total Salaries

USE [SoftUni]

  SELECT [DepartmentID],
         SUM(Salary)
      AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

GO 

--14 Employees Minimum Salaries

  SELECT [DepartmentID],
         MIN([Salary])
      AS [MinimumSalary]
    FROM [Employees]
   WHERE [HireDate] > 2000-01-01
GROUP BY [DepartmentID]
  HAVING [DepartmentID] IN (2, 5, 7)

GO

--15 Employees Average Salaries

  SELECT *
    INTO [#SalaryMoreThen3000TempTable]
    FROM [Employees]
   WHERE [Salary] > 30000

  DELETE 
    FROM [#SalaryMoreThen3000TempTable]
   WHERE [ManagerID] = 42 

   UPDATE [#SalaryMoreThen3000TempTable]
   SET [Salary] += 5000
   WHERE [DepartmentID] = 1 

   SELECT [DepartmentID],
          AVG([Salary])
       AS [AverageSalary]
     FROM [#SalaryMoreThen3000TempTable]
 GROUP BY [DepartmentID]

 GO 