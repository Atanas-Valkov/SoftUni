========================CONSTRAINT=====================================
1. FOREIGN KEY - Налагса връзка към друга таблица(PK/UNIQUE); контрол при delete/update

ALTER TABLE [Minions]
ADD CONSTRAINT FK_Minions_Towns
FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

2 . PRIMARY KEY - Уникален индификатор за ред; UNIQUE + NOT NULL ; 1 PK на таблица 

ALTER TABLE [Users]
ADD CONSTRAINT PK_Minions_Users
ADD PRIMARY KEY ([Id], [Username])

3. UNIQUE - Забранява дублиране на стойности в колоната ; много UNIQUE ; допуска NULL

CREATE TABLE Users
(
    [Id] INT IDENTITY PRIMARY KEY,                                          | ALTER TABLE dbo.Users
    [Username] NVARCHAR(50) NOT NULL,                               | ADD CONSTRAINT UQ_Users_Username
    Email NVARCHAR(255) NULL,                                               | UNIQUE (Username);
    CONSTRAINT UQ_Users_Username UNIQUE (Username),   | 
    CONSTRAINT UQ_Users_Email UNIQUE (Email)                   |
);

4. CHECK - Валидира стойноста по условие (домейн правило)

ALTER TABLE People                              |       ALTER TABLE People
ADD CONSTRAINT CK_People_Age        |       ADD CONSTRAINT CK_People_Age
CHECK (Age BETWEEN 0 AND 120);      |       CHECK (Age > 10);

5. DEFAULT - Слага стойност по подразбиране при INSERT, ако не подадеш стойност 

ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT(SYSDATETIME()) FOR [LastLoginTime]

6. NOT NULL - Колоната не ниже да е NULL	(Задължително поле)

[Name] VARCHAR(100) NOT NULL,

======================Типове данни за дата/час=============================
1. DATE – date in range 0001-01-01 through 9999-12-31
2. DATETIME – date and time with precision of 1/300 sec
3. DATETIME2 – type that has a larger date range
4. SMALLDATETIME – date and time (1 minute precision)
5. TIME – defines a time of a day (no time zone)
6. DATETIMEOFFSET – date and time that has time zone








DDL (Data Definition Language)
1) CREATE - създаване
  
     1.1)======================CREATE DATABASE==================================== 
	       CREATE DATABASE Orders;
	 
     1.2) ======================CREATE TABLE=================================
	       CREATE TABLE Users
	 
     1.3) =================CREATE TABLE (колони, типове, IDENTITY)==============================
	        CREATE TABLE Users
            (
            [Id] INT IDENTITY(1,1) NOT NULL,
            [UserId] INT NOT NULL,
            [Total] DECIMAL(12,2) NOT NULL,
            CONSTRAINT PK_Orders PRIMARY KEY (Id),
            CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
            );
	
	1.4)  =================CREATE TABLE с FK (връзка)============================
	       CREATE VIEW UserOrders
           AS
           SELECT u.Id, u.Username, o.Id AS OrderId, o.Total              ?!?!?!?!
           FROM dbo.Users u 
           JOIN dbo.Orders o ON o.UserId = u.Id;
		   
	1.5)	 =================CREATE UNIQUE constraint (UK / UQ)=======================  
	
2) ALTER - промяна по структората на таблицата 
 
    2.1) ==================ALTER TABLE — добавяне на колона======================
	       ALTER TABLE Users
           ADD Phone NVARCHAR(30) NULL;
		   
    2.2) ==================ALTER TABLE — промяна на тип / дължина=================
	       ALTER TABLE dbo.Users
           ALTER COLUMN Username NVARCHAR(80) NOT NULL;
		   
	2.3) ================ALTER TABLE — добавяне/махане на constraint ===============
	      
		  --Добавяне CHECK:
		  ALTER TABLE dbo.Orders
          ADD CONSTRAINT CK_Orders_Total_Positive CHECK (Total >= 0);
		  
		  --Премахване constraint (пример):
		  ALTER TABLE dbo.Orders
          DROP CONSTRAINT CK_Orders_Total_Positive;
		  
	2.4)======ALTER VIEW / ALTER PROCEDURE / ALTER FUNCTION / ALTER TRIGGER===========
	
	      SQL Server няма стандартно CREATE OR REPLACE, затова:
          --първо CREATE ...
          --после променяш с ALTER ...
		  
		  ALTER VIEW dbo.vw_UserOrders
          AS
          SELECT u.Id, u.Username, o.Id AS OrderId, o.Total 
          FROM dbo.Users u
          LEFT JOIN dbo.Orders o ON o.UserId = u.Id;
		  
3) DROP - изтриване на обекти (структура)		 
     
	3.1) ------------DROP TABLE / VIEW / PROCEDURE / FUNCTION / TRIGGER / INDEX-----------------------
	
	      DROP TABLE dbo.Orders;

          DROP VIEW dbo.vw_UserOrders;

          DROP PROCEDURE dbo.usp_CreateUser;

          DROP FUNCTION dbo.ufn_OrderCountByUser;

          DROP TRIGGER dbo.trg_Orders_NoNegativeTotal;
	
4) TRUNCATE - “изчистване” на таблица (DDL-подобно)	

    4.1) =TRUNCATE трие всички редове много бързо, без WHERE и обикновено ресетва IDENTITY.=
	 
	      TRUNCATE TABLE dbo.Orders;
		  
		  --Важно:
          --Не става ако има FK, които сочат към тази таблица.
          --Не може да трие частично (няма WHERE).
		  
===========================Правила==========================================

Правила при FK     ||    PK → 1 на таблица PK = UNIQUE + NOT NULL.
                               ||    
ON DELETE              ||   FK → сочи към PK или UNIQUE.    
ON UPDATE             ||   
							   ||    UNIQUE → уникалност, може много.
CASCADE                ||
							   ||    CHECK → валидира логика (>= 0, BETWEEN, IN…).
SET NULL                ||
							   ||    NOT NULL → задължително поле.
SET DEFAULT          ||   
							   ||   
NO ACTION             ||

-----------------------------------------------------------------------------------------------------------------------------

[COLUMN_NAME] DATATYPE CONSTRAINT 
                                                              |-> PK , FK , NOT NULL, UNIQUE , CHECK , DEFAULT, IDENTITY
							
------------------------------------------------------------------------------------------------------------------------------
  
1) Релацията ни пази да не се добавят данни който ги няма в базата(невалидни данни)
2) Правило за INSERT whit FK: 
    1. Започваме с таблицата която няма FK
	2. Ако няма такава таблица се започва с NULL-able FK(защото на мястото на FK e NULL)
	




ад
адад
ад
ададас