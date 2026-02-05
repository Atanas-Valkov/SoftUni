========================CONSTRAINT=====================================
1. FOREIGN KEY - Налага връзка към друга таблица(PK/UNIQUE); контрол при delete/update

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

6. NOT NULL - Колоната не мoже да е NULL	(Задължително поле)

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
     DROP = “махни целия обект таблица”
	3.1) ------------DROP TABLE / VIEW / PROCEDURE / FUNCTION / TRIGGER / INDEX-----------------------
	
	      DROP TABLE dbo.Orders;

          DROP VIEW dbo.vw_UserOrders;

          DROP PROCEDURE dbo.usp_CreateUser;

          DROP FUNCTION dbo.ufn_OrderCountByUser;

          DROP TRIGGER dbo.trg_Orders_NoNegativeTotal;
	
	4) UPDATE (промяна на данни)
├─ Цел: променя стойности в съществуващи редове
├─ Синтаксис:
│  └─ UPDATE <таблица>
│     SET <колона1> = <стойност1>,
│         <колона2> = <стойност2>,
│         ...
│     WHERE <условие>;
├─ Пример (един ред по Id):
│  └─ UPDATE dbo.Employees
│     SET Salary = Salary + 1000
│     WHERE EmployeeID = 5;
├─ Пример (много редове):
│  └─ UPDATE dbo.Employees
│     SET IsDeleted = 1
│     WHERE LastName = 'Ivanov';
├─ Пример с JOIN:
│  └─ UPDATE e
│     SET e.Salary = e.Salary * 1.10
│     FROM dbo.Employees AS e
│     JOIN dbo.Departments AS d ON d.DepartmentID = e.DepartmentID
│     WHERE d.Name = 'Engineering';
└─ Добри практики:
   ├─ Винаги WHERE (иначе обновяваш всички редове!)
   ├─ Първо тествай с SELECT същия WHERE
   ├─ Ако е важно: BEGIN TRAN ... COMMIT/ROLLBACK
   └─ Можеш да видиш какво е променено с OUTPUT:
      └─ OUTPUT inserted.*, deleted.*;
	
5) TRUNCATE - “изчистване” на таблица (DDL-подобно)	
TRUNCATE = “изпразни данните, запази таблицата”
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
	
=====================================================================

2222222222222222222222222222222222222222222222222222222222222222222222222222222
2222222222222222222222222222222222222222222222222222222222222222222222222222222


[ ] → имена (таблици/колони/alias-и) в SQL Server (най-сигурно)

" " → имена, но само ако е позволено (QUOTED_IDENTIFIER ON)

' ' → стойности (текст/дата/символен литерал)

======================================================================
SELECT – (избиране на данни)
├─ Синтаксис (основен): SELECT <колони> FROM <таблица>;
│  └─ пример: SELECT * FROM Users;
├─ Избор на колони:
│  ├─ SELECT Username, Email FROM Users;
│  └─ alias: SELECT Username AS [User Name] FROM Users;
├─ Филтър (WHERE):
│  └─ SELECT * FROM Users WHERE IsDeleted = 0;
├─ Сортиране (ORDER BY):
│  └─ SELECT * FROM Users ORDER BY CreatedOn DESC;
├─ Уникални редове (DISTINCT):
│  └─ SELECT DISTINCT City FROM Users;
├─ Групиране (GROUP BY + HAVING):
│  ├─ SELECT City, COUNT(*) AS Cnt FROM Users GROUP BY City;
│  └─ ... HAVING COUNT(*) >= 10;
├─ JOIN (свързване на таблици):
│  └─ SELECT u.Username, o.Total
│     FROM Users u
│     JOIN Orders o ON o.UserId = u.Id;
└─ Top редове:
   └─ SELECT TOP (10) * FROM Orders ORDER BY Total DESC;
   =====================================================================
   WHERE <условие>
├─ сравнение (=, <>, !=, >, <, >=, <=)
│ ├─ Синтаксис: WHERE <колона> <оператор> <стойност>
│ ├─ Примери:
│ │ WHERE Age >= 18
│ │ WHERE Status <> 'Banned'
│ │ WHERE CreatedOn < '2026-01-01'
│
├─ диапазон (BETWEEN … AND …)
│ ├─ Синтаксис: WHERE <колона> BETWEEN <min> AND <max>
│ ├─ Примери:
│ │ WHERE Total BETWEEN 50 AND 100
│ │ WHERE OrderDate BETWEEN '2026-01-01' AND '2026-01-31'
│
├─ списък (IN (…) / NOT IN (…))
│ ├─ Синтаксис:
│ │ WHERE <колона> IN (<v1>, <v2>, <v3> ...)
│ │ WHERE <колона> NOT IN (<v1>, <v2>, <v3> ...)
│ │ WHERE <колона> IN (SELECT <col> FROM <table> WHERE ...)
│ ├─ Примери:
│ │ WHERE City IN ('Plovdiv','Sofia','Varna')
│ │ WHERE Id NOT IN (1,2,3)
│ │ WHERE UserId IN (SELECT Id FROM Users WHERE IsActive = 1)
│
├─ шаблон (LIKE / NOT LIKE)
│ ├─ Синтаксис:
│ │ WHERE <колона> LIKE '<pattern>'
│ │ WHERE <колона> NOT LIKE '<pattern>'
│ │ % = много символи, _ = 1 символ
│ ├─ Примери:
│ │ WHERE Name LIKE 'Tes%'
│ │ WHERE Name LIKE '%Model%'
│ │ WHERE Code LIKE 'A_3'
│
├─ NULL (IS NULL / IS NOT NULL)
│ ├─ Синтаксис:
│ │ WHERE <колона> IS NULL
│ │ WHERE <колона> IS NOT NULL
│ ├─ Примери:
│ │ WHERE DeletedAt IS NULL
│ │ WHERE Email IS NOT NULL
│
├─ съществуване (EXISTS / NOT EXISTS)
│ ├─ Синтаксис:
│ │ WHERE EXISTS (SELECT 1 FROM <table> t WHERE <условие>)
│ │ WHERE NOT EXISTS (SELECT 1 FROM <table> t WHERE <условие>)
│ ├─ Примери:
│ │ WHERE EXISTS (SELECT 1 FROM Orders o WHERE o.UserId = u.Id)
│ │ WHERE NOT EXISTS (SELECT 1 FROM Orders o WHERE o.UserId = u.Id)
│
└─ подзаявка сравнения (ANY/SOME / ALL)
├─ Синтаксис:
│ WHERE <стойност/колона> <оператор> ANY (SELECT <col> FROM <table> WHERE ...)
│ WHERE <стойност/колона> <оператор> ALL (SELECT <col> FROM <table> WHERE ...)
├─ Примери:
│ WHERE Total > ANY (SELECT Total FROM Orders WHERE UserId = 5)
│ WHERE Total > ALL (SELECT Total FROM Orders WHERE UserId = 5)
======================================================================
Column Aliases = псевдоним (ново име) на колона в резултата.

SELECT
├─ Синтаксис
│ ├─ SELECT ColumnName AS AliasName FROM Table;
│ ├─ SELECT ColumnName AliasName FROM Table; (AS е по избор в T-SQL)
│ └─ ако има интервали/спец. символи → SELECT ColumnName AS [Total Price] ...
│
├─ Примери
│ ├─ SELECT FirstName AS Name FROM Users;
│ ├─ SELECT Price * Quantity AS Total FROM OrderItems;
│ ├─ SELECT GETDATE() AS [Today Date];
│ └─ SELECT u.Username AS [User Name], u.Email AS [E-mail] FROM Users u;
│
├─ Кога се ползва
│ ├─ за по-четим резултат (по-добри имена)
│ ├─ при изчисления/агрегати (SUM, COUNT, AVG)
│ └─ при JOIN-и (когато има еднакви имена на колони)
│
└─ Важно
├─ Alias е само за резултата (не преименува реалната колона в таблицата)
└─ В ORDER BY можеш да ползваш alias-а:
SELECT Price*Quantity AS Total FROM Items ORDER BY Total DESC;
======================================================================
Concatenation (слепване)
├─ CONCAT(...)
│  ├─ без автоматичен разделител
│  └─ NULL → ''    
SELECT CONCAT('Hi ', NULL, ' Atanas') AS Msg; 
Резултат:
Hi Atanas (NULL е “прескочен” като празно)

└─ CONCAT_WS(sep, ...)
   ├─ с разделител между елементите
   └─ NULL се прескачат (без излишни разделители)
   
   CONCAT_WS(separator, expr1, expr2, expr3, ...)
   =====================================================================
   DISTINCT (уникални редове)
├─ Цел: маха дублиращи се редове в резултата
├─ Синтаксис:
│  └─ SELECT DISTINCT <колона/колони>
│     FROM <таблица>
│     WHERE <условие>;
├─ 1 колона (уникални стойности):
│  └─ SELECT DISTINCT City
│     FROM dbo.Users
│     WHERE IsDeleted = 0;
├─ няколко колони (уникална комбинация):
│  └─ SELECT DISTINCT City, Country
│     FROM dbo.Users
│     WHERE IsDeleted = 0;
└─ Важно:
   ├─ DISTINCT важи за всички избрани колони (целия SELECT списък)
   └─ повече колони = уникалност по комбинация = може да излязат повече редове
  =====================================================================
  ORDER BY (сортиране на резултата)
├─ Цел: подрежда редовете в резултата
├─ Синтаксис:
│  └─ SELECT <колони>
│     FROM <таблица>
│     WHERE <условие>
│     ORDER BY <колона/израз> [ASC|DESC], <колона2> [ASC|DESC];
├─ Варианти:
│  ├─ ASC  = възходящо (по подразбиране)
│  └─ DESC = низходящо
├─ Примери:
│  ├─ ORDER BY Salary;                 -- ASC по подразбиране
│  ├─ ORDER BY Salary DESC;            -- от голямо към малко
│  ├─ ORDER BY LastName, FirstName;    -- първо по фамилия, после по име
│  └─ ORDER BY Salary DESC, Id ASC;    -- комбинирано сортиране
└─ Важно:
   ├─ ORDER BY е последното в заявката (след WHERE/GROUP BY/HAVING)
   ├─ Можеш да сортираш и по alias:
   │  └─ SELECT Price*Qty AS Total ... ORDER BY Total DESC;
   └─ Без ORDER BY няма гарантиран ред на резултатите
   =====================================================================
   VIEW (изглед)
├─ Какво е:
│  └─ “виртуална таблица” – запазена SELECT заявка (не пази данни, пази логика)
├─ Кога се използва:
│  ├─ за по-лесни заявки (скрива сложни JOIN-и/филтри)
│  ├─ за сигурност (даваш достъп само до нужните колони/редове)
│  ├─ за повторна употреба (един стандартен репорт/изглед)
│  └─ като стабилен слой между приложение и таблици
├─ Синтаксис (CREATE VIEW):
│  └─ CREATE VIEW dbo.V_EmployeesBasic
│     AS
│     SELECT
│         e.EmployeeID,
│         e.FirstName,
│         e.LastName,
│         e.Salary
│     FROM dbo.Employees AS e;
├─ Използване:
│  └─ SELECT * FROM dbo.V_EmployeesBasic;
├─ Промяна:
│  ├─ ALTER VIEW dbo.V_EmployeesBasic AS ...
│  └─ или CREATE OR ALTER VIEW dbo.V_EmployeesBasic AS ...
└─ Важно:
   ├─ ORDER BY не се слага във VIEW (освен с TOP, и пак не е гаранция за ред)
   ├─ VIEW не приема параметри (за параметри → stored procedure / function)
   └─ Може да има “indexed view”, но е отделна тема (по-строги правила)
======================================================================
   ISNULL (NULL replacement)
├─ Цел: ако изразът е NULL → връща заместителя
├─ Синтаксис:
│  └─ ISNULL(<израз>, <заместваща_стойност>)
├─ Пример (текст):
│  └─ SELECT ISNULL(MiddleName, '') AS MiddleName
│     FROM dbo.Employees;
├─ Пример (число):
│  └─ SELECT ISNULL(Discount, 0) AS Discount
│     FROM dbo.Orders;
└─ Важно:
   ├─ работи само с 2 аргумента
   ├─ резултатният тип се определя от първия аргумент (израза)
   └─ алтернатива (по-стандартна): COALESCE(expr, replacement)
=====================================================================
 CASE ... WHEN (условна логика в SELECT/ORDER BY/WHERE)
├─ Цел: връща стойност според условие (като if-else)
├─ Видове:
│  ├─ Simple CASE:
│  │   └─ CASE <израз>
│  │      WHEN <стойност> THEN <резултат>
│  │      ...
│  │      ELSE <резултат>
│  │      END
│  └─ Searched CASE (най-често):
│      └─ CASE
│         WHEN <условие> THEN <резултат>
│         ...
│         ELSE <резултат>
│         END
├─ Пример (в SELECT):
│  └─ SELECT
│         [FirstName],
│         [Salary],
│         CASE
│             WHEN [Salary] >= 3000 THEN 'High'
│             WHEN [Salary] >= 1500 THEN 'Mid'
│             ELSE 'Low'
│         END AS [SalaryLevel]
│     FROM [Employees];
├─ Пример (в ORDER BY):
│  └─ SELECT [FirstName], [Salary]
│     FROM [Employees]
│     ORDER BY CASE WHEN [Salary] IS NULL THEN 1 ELSE 0 END, [Salary] DESC;
├─ Пример (в WHERE):
│  └─ SELECT *
│     FROM [Employees]
│     WHERE CASE WHEN [IsDeleted] = 1 THEN 0 ELSE 1 END = 1;
└─ Важно:
   ├─ CASE връща 1 стойност (скалар)
   ├─ ELSE е препоръчително (ако липсва → връща NULL)
   └─ Всички THEN/ELSE трябва да са съвместими типове
======================================================================
   IF ... ELSE (T-SQL)
├─ Цел: изпълнява различни SQL команди според условие
├─ Къде: в скриптове, stored procedures, batches
├─ Синтаксис:
│  ├─ IF <условие>
│  │     <една_команда>
│  └─ ELSE
│        <една_команда>
├─ Много команди:
│  ├─ IF <условие>
│  │  BEGIN
│  │      <команда1>
│  │      <команда2>
│  │  END
│  └─ ELSE
│     BEGIN
│         <команда1>
│         <команда2>
│     END
└─ Пример:
   └─ IF EXISTS (SELECT 1 FROM [Employees] WHERE [Salary] > 5000)
      BEGIN
          PRINT 'Has high salaries';
      END
      ELSE
      BEGIN
          PRINT 'No high salaries';
      END
3333333333333333333333333333333333333333333333333333333333333333333333333333333
3333333333333333333333333333333333333333333333333333333333333333333333333333333
=======================String Functions====================================
Главни/малки букви
UPPER(x) → главни
Пример: SELECT UPPER([Email]) FROM [dbo].[Employees];

LOWER(x) → малки
Пример: SELECT LOWER([Email]) FROM [dbo].[Employees];

Дължина / позиции

LEN(x) → дължина
Пример: SELECT LEN([Email]) FROM [dbo].[Employees];

CHARINDEX(find, x) → позиция на подниз
Пример: SELECT CHARINDEX('@', [Email]) FROM [dbo].[Employees];

Изрязване

SUBSTRING(x, start, len) → част от текст
Пример (домейн след @):
SELECT SUBSTRING([Email], CHARINDEX('@',[Email])+1, LEN([Email])) FROM [dbo].[Employees];

LEFT(x, n) → първите n
Пример: SELECT LEFT([Email], 3) FROM [dbo].[Employees];

RIGHT(x, n) → последните n
Пример: SELECT RIGHT([Email], 3) FROM [dbo].[Employees];

Интервали

TRIM(x) → маха интервали
Пример: SELECT TRIM([FullName]) FROM [dbo].[Employees];

Замяна

REPLACE(x, old, new) → замяна
Пример: SELECT REPLACE([FullName], '.', ' ') FROM [dbo].[Employees];

Съединяване

CONCAT(a, b, c) → слепя
Пример: SELECT CONCAT([FirstName], ' ', [LastName]) FROM [dbo].[Employees];

Други

STRING_SPLIT(x, sep) → текст → редове
Пример: SELECT [value] FROM STRING_SPLIT('a,b,c', ',');

STRING_AGG(x, sep) → редове → 1 текст
Пример: SELECT STRING_AGG([PeakName], ', ') FROM [dbo].[Peaks] WHERE [MountainId]=17;


SELECT CONCAT(SUBSTRING('ATANAS',1,LEN('ATANAS')-2),REPLICATE('@',2))
=======================Math Functions====================================
ABS(x) → абсолютна стойност
Пример: SELECT ABS([Value]) FROM [dbo].[Numbers];

CEILING(x) → закръгля нагоре
Пример: SELECT CEILING([Value]) FROM [dbo].[Numbers];

FLOOR(x) → закръгля надолу
Пример: SELECT FLOOR([Value]) FROM [dbo].[Numbers];

ROUND(x, d) → закръгля до d знака
Пример: SELECT ROUND([Value], 2) FROM [dbo].[Numbers];

POWER(x, y) → x на степен y
Пример: SELECT POWER([Value], 2) FROM [dbo].[Numbers];

SQRT(x) → корен квадратен
Пример: SELECT SQRT([Value]) FROM [dbo].[Numbers];

SIGN(x) → знак (-1, 0, 1)
Пример: SELECT SIGN([Value]) FROM [dbo].[Numbers];

PI() → π
Пример: SELECT PI();

RAND() → случайно число (0..1)
Пример: SELECT RAND();
=======================Date Functions====================================