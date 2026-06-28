CREATE DATABASE [Zoo]

USE [Zoo]

CREATE TABLE [Owners]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[PhoneNumber] VARCHAR(15) NOT NULL,
[Address] VARCHAR(50) NULL
)

CREATE TABLE [AnimalTypes]
(
[Id] INT PRIMARY KEY IDENTITY,
[AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE [Cages]
(
[Id] INT PRIMARY KEY IDENTITY,
[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [Animals]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
[BirthDate] DATE NOT NULL ,
[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id]) NULL,
[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [AnimalsCages]
(
[CageId] INT FOREIGN KEY REFERENCES [Cages]([Id]) NOT NULL,
[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]) NOT NULL, 
PRIMARY KEY ([CageId],[AnimalId])
)

CREATE TABLE [VolunteersDepartments]
(
[Id] INT PRIMARY KEY IDENTITY,
[DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Volunteers]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[PhoneNumber] VARCHAR(15) NOT NULL,
[Address] VARCHAR(50) NULL,
[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]) NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
)

--2.	Insert

INSERT INTO [Animals]([Name],[BirthDate],[OwnerId],[AnimalTypeId])
VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4);

INSERT INTO [Volunteers]([Name],[PhoneNumber],[Address],[AnimalId],[DepartmentId])
VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5);

--3.	Update

--4.	Delete

--5.	Volunteers

  SELECT [Name],
         [PhoneNumber],
         [Address],
         [AnimalId],
         [DepartmentId]
    FROM [Volunteers]
ORDER BY [Name] ASC,
         [AnimalId] ASC,
         [DepartmentId] ASC

--6.	Animals data

  SELECT [a].[Name],
         [at].[AnimalType],
         FORMAT(CAST([a].[BirthDate] as DATE),'dd.MM.yyyy')
      AS [BirthDate]
    FROM [Animals]
      AS [a]
    JOIN [AnimalTypes]
      AS [at]
      ON [a].[AnimalTypeId] = [at].[Id]
ORDER BY [a].[Name]


--7.	Owners and Their Animals

  SELECT TOP(5)
         [o].[Name],
         COUNT([a].[id])
      AS [CountOfAnimals]
    FROM [Owners]
      AS [o]
    JOIN [Animals]
      AS [a]
      ON [a].[OwnerId] = [o].[Id]
GROUP BY [o].[Name]
ORDER BY [CountOfAnimals] DESC,
         [o].[Name] ASC 

--8.	Owners, Animals and Cages

  SELECT CONCAT_WS('-', [o].[Name], [a].[Name])
      AS [OwnersAnimals],
         [o].[PhoneNumber],
         [c].[Id]
      AS [CageId]
    FROM [Owners]
      AS [o]
    JOIN [Animals]
      AS [a]
      ON [a].[OwnerId] = [o].[Id]
    JOIN [AnimalsCages]
      AS [ac]
      ON [ac].[AnimalId] = [a].[Id]
    JOIN [Cages]
      AS [c]
      ON [c].[Id] = [ac].[CageId]
    JOIN [AnimalTypes]
      AS [at]
      ON [at].[Id] = [a].[AnimalTypeId]
   WHERE [at].[AnimalType] = 'Mammals'
ORDER BY [o].[Name] ASC,
         [a].[Name] DESC

--9.	Volunteers in Sofia

  SELECT [v].[Name],
         [v].[PhoneNumber],
         SUBSTRING([v].[Address], CHARINDEX(',',[v].[Address]) + 1, LEN([v].[Address]))
      AS [Address]
    FROM [Volunteers]
      AS [v]
    JOIN [VolunteersDepartments]
      AS [vd]
      ON [v].[DepartmentId] = [vd].[Id]
   WHERE [vd].[DepartmentName] = 'Education program assistant'
     AND CHARINDEX('Sofia', [v].[Address]) > 0
ORDER BY [v].[Name] ASC 

--10.	Animals for Adoption

   SELECT [a].[Name],
          YEAR([a].[BirthDate])
       AS [BirthYear],
          [at].[AnimalType]
     FROM [Animals]
       AS [a]
LEFT JOIN [AnimalTypes]
       AS [at]
       ON [a].[AnimalTypeId] = [at].[Id]
    WHERE [a].[OwnerId] IS NULl
      AND [a].[BirthDate] >= '2018-01-01'
      and [at].[AnimalType] != 'Birds'
 ORDER BY [a].[Name] ASC

--11.	All Volunteers in a Department
GO

     CREATE 
   FUNCTION [udf_GetVolunteersCountFromADepartment](@VolunteersDepartment VARCHAR(30))
RETURNS INT
         AS 
      BEGIN
             DECLARE @result INT 
           
              SELECT @result = COUNT([v].[Id]) 
                FROM [Volunteers]
                  AS [v]
                JOIN [VolunteersDepartments]
                  AS [vd]
                  ON [v].[DepartmentId] = [vd].[Id]
               WHERE [vd].[DepartmentName] = @VolunteersDepartment
          
              RETURN @result
     
        END 

GO

SELECT [dbo].[udf_GetVolunteersCountFromADepartment]('Education program assistant')

GO       

--12.	Animals with Owner or Not

GO

   CREATE
       OR
    ALTER
PROCEDURE [dbo].[usp_AnimalsWithOwnersOrNot] @AnimalName NVARCHAR(30)
       AS
    BEGIN
             SELECT [a].[Name],
                    CASE 
                        WHEN [OwnerId] IS NULL THEN 'For adoption'
                        WHEN [OwnerId] IS NOT NULL THEN [o].[Name]
                    END
                 AS [OwnersName]
               FROM [Animals]
                 AS [a]
          LEFT JOIN [Owners]
                 AS [o]
                 ON [a].[OwnerId] = [o].[Id]
              WHERE [a].[Name] = @AnimalName
       
      END

GO 

EXEC [dbo].[usp_AnimalsWithOwnersOrNot] 'Pumpkinseed Sunfish'

GO 

