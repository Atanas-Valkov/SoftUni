USE [SoftUni]

GO 

--1 Employee Address

  SELECT TOP (5) 
         [e].EmployeeID,
         [e].JobTitle,
         [e].AddressID,
         [a].AddressText 
    FROM [Employees]
      AS [e]
    JOIN [Addresses]
      AS [a]
      ON [e].AddressID = [a].AddressID
ORDER BY [a].AddressID

GO 

--2 Addresses with Towns

SELECT TOP (50)
       [e].[FirstName],
       [e].[LastName],
       [t].[Name]
    AS [Town],
       [a].[AddressText]
  FROM [Employees]
    AS [e]
  JOIN [Addresses]
    AS [a]
    ON [e].[AddressID] = [a].AddressID
  JOIN [Towns]
    AS [t]
    ON [a].TownID = [t].TownID 
ORDER BY [e].FirstName,[e].LastName

GO 

--3 Sales Employee

   SELECT [e].[EmployeeID],
          [e].[FirstName],
          [e].[LastName],
          [d].[Name]
       AS [DepartmentName]
     FROM [Employees]
       AS [e]
LEFT JOIN [Departments]
       AS [d]
       ON [e].[DepartmentID] = [d].[DepartmentID]
    WHERE [d].[Name] = 'Sales'   
 ORDER BY [EmployeeID] ASC 

 GO 
 
 --4 Employee Departments

  SELECT TOP (5)
         [e].[EmployeeID],
         [e].[FirstName],
         [e].[Salary],
         [d].[Name]
      AS [DepartmentName]
    FROM [Employees]
      AS [e]
    JOIN [Departments]
      AS [d]
      ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [e].[Salary] > 15000
ORDER BY [d].[DepartmentID] ASC

GO

--5 Employees Without Project

SELECT TOP (3)
           [e].[EmployeeID],
           [e].[FirstName]
      FROM [Employees]
        AS [e]
 LEFT JOIN [EmployeesProjects]
        AS [ep]
        ON [ep].[EmployeeID] = [e].[EmployeeID]
     WHERE [ep].[ProjectID] IS NULL 

GO

--6 Employees Hired After

  SELECT [e].[FirstName],
         [e].[LastName],
         [e].[HireDate],
         [d].[Name]
      AS [DepName]
    FROM [Employees]
      AS [e]
    JOIN [Departments]
      AS [d]
      ON [e].[DepartmentID] = [d].DepartmentID
   WHERE [HireDate] > '1.1.1999'
     AND [d].[Name] IN ('Sales','Finance')
ORDER BY [HireDate] ASC

GO

--7 Employees with Project

SELECT TOP (5)
           [e].[EmployeeID],
           [e].[FirstName],
           [p].[Name]
        AS [ProjectName]
      FROM [EmployeesProjects]
        AS [ep]
      JOIN [Employees]
        AS [e]
        ON [e].[EmployeeID] = [ep].[EmployeeID]
      JOIN [Projects]
        AS [p]
        ON [ep].ProjectID = [p].[ProjectID]
     WHERE [p].[StartDate] > '2002-08-13'
       AND [p].[EndDate] IS NULL 
  ORDER BY [e].[EmployeeID] ASC

  GO 

--8 Employee 24

   SELECT [e].[EmployeeID],
          [e].[FirstName],
          CASE
              WHEN [p].[StartDate] >= '2005'THEN NULL
              ELSE [p].[Name]
          END
       AS [ProjectName]
     FROM [Projects]
       AS [p]
LEFT JOIN [EmployeesProjects]
       AS [ep]
       ON [p].[ProjectID] = [ep].ProjectID
LEFT JOIN [Employees]
       AS [e]
       ON [ep].EmployeeID = [e].EmployeeID
    WHERE [e].[EmployeeID] = 24

GO 

--9 Employee Manager

   SELECT [e].[EmployeeID],
          [e].[FirstName],
          [e].[ManagerID],
          [m].[FirstName]
       AS [ManagerName]
     FROM [Employees]
       AS [e]
LEFT JOIN [Employees]
       AS [m]
       ON [e].[ManagerID] = [m].[EmployeeID]
    WHERE [e].ManagerID IN (3,7)
 ORDER BY [e].[EmployeeID]

GO 

--10 Employees Summary

SELECT TOP (50)
           [e].[EmployeeID],
           CONCAT_WS(' ', [e].[FirstName],[e].[LastName])
        AS [EmployeeName],
           CONCAT_WS(' ',[m].[FirstName], [m].[LastName])
        AS [ManagerName],
           [d].[Name]
        AS [DepartmentName]
      FROM [Employees]
        AS [e]
 LEFT JOIN [Employees]
        AS [m]
        ON [e].[ManagerID] = [m].[EmployeeID]
 LEFT JOIN [Departments]
        AS [d]
        ON [e].[DepartmentID] = [d].[DepartmentID]
  ORDER BY [e].EmployeeID ASC

GO

--11 Min Average Salary

SELECT TOP (1)
         AVG([Salary])
      AS [MinAverageSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [MinAverageSalary]

GO 

--12 Highest Peaks in Bulgaria
USE [Geography]

  SELECT [c].[CountryCode],
         [m].[MountainRange],
         [p].[PeakName],
         [p].[Elevation]
    FROM [MountainsCountries]
      AS [mc]
    JOIN [Countries]
      AS [c]
      ON [mc].[CountryCode] = [c].[CountryCode]
    JOIN [Mountains]
      AS [m]
      ON [mc].[MountainId] = [m].[Id]
    JOIN [Peaks]
      AS [p]
      ON [p].[MountainId] = [m].[Id]
   WHERE [mc].[CountryCode] = 'BG'
     AND [p].[Elevation] > '2835'
ORDER BY [p].[Elevation] DESC

GO 

--13 Count Mountain Ranges

    SELECT [c].CountryCode,
           COUNT([mc].MountainId)
        AS [MountainRanges]
      FROM [Countries]
        AS [c]
 LEFT JOIN [MountainsCountries]
        AS [mc]
        ON [mc].[CountryCode] = [c].[CountryCode]
 LEFT JOIN [Mountains]
        AS [m]
        ON [mc].[MountainId] = [m].Id
     WHERE [c].[CountryName] IN ('United States', 'Russia', 'Bulgaria')
  GROUP BY [c].[CountryCode]

GO

--14 Countries With or Without Rivers

SELECT TOP (5)
           [c].CountryName,
           [r].[RiverName]
      FROM [Countries]
        AS [c]
 LEFT JOIN [CountriesRivers]
        AS [cr]
        ON [cr].[CountryCode] = [c].[CountryCode] 
 LEFT JOIN [Rivers]
        AS [r]
        ON [cr].[RiverId] = [r].[Id]
     WHERE [c].[ContinentCode] = 'AF'
  ORDER BY [c].[CountryName]

GO 

--15 *Continents and Currencies










  SELECT * 
    FROM [Rivers]

  SELECT * 
    FROM [CountriesRivers]

  SELECT * 
    FROM [Countries]

