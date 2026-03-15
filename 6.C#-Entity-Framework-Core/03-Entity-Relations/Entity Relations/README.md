Exercises: Entity Relations

You can check your solutions in Judge

1. Student System
Your task is to create a database for the StudentSystem, using the EF Core Code First approach. It should look like this:

Constraints
Your namespaces should be:
* P01_StudentSystem – for your Startup class, if you have one
* P01_StudentSystem.Data – for your DbContext
* P01_StudentSystem.Data.Models – for your models
Your models should be:
* StudentSystemContext – your DbContext
* Student
o StudentId
o Name – up to 100 characters, unicode
o PhoneNumber – exactly 10 characters, not unicode, not required
o RegisteredOn
o Birthday – not required
* Course
o CourseId
o Name – up to 80 characters, unicode
o Description – unicode, not required
o StartDate
o EndDate
o Price
* Resource
o ResourceId
o Name – up to 50 characters, unicode
o Url – not unicode
o ResourceType – enum, can be Video, Presentation, Document or Other
o CourseId
* Homework
o HomeworkId
o Content – string, linking to a file, not unicode
o ContentType - enum, can be Application, Pdf or Zip
o SubmissionTime
o StudentId
o CourseId
* StudentCourse – mapping between Students and Courses
Table relations:	
* One student can have many Courses 
* One student can have many Homeworks 
* One course can have many Students
* One course can have many Resources
* One course can have many Homeworks
You will need a constructor, accepting DbContextOptions to test your solution in Judge!
2. Football Betting
Your task is to create a database for a FootballBookmakerSystem, using the Code First approach. It should look like this:

Constraints
Your namespaces should be:
* P02_FootballBetting – for your Startup class, if you have one
* P02_FootballBetting.Data – for your DbContext
* P02_FootballBetting.Data.Models – for your models
Your models should be:
* FootballBettingContext – your DbContext
* Team – TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
* Color – ColorId, Name
* Town – TownId, Name, CountryId
* Country – CountryId, Name
* Player – PlayerId, Name, SquadNumber, IsInjured, PositionId , TeamId, TownId 
* Position – PositionId, Name
* PlayerStatistic – GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed
* Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, DateTime, Result
* Bet – BetId, Amount, Prediction, DateTime, UserId, GameId
* User – UserId, Username, Name, Password, Email, Balance
Table relationships:
* A Team has one PrimaryKitColor and one SecondaryKitColor
* A Color has many PrimaryKitTeams and many SecondaryKitTeams
* A Team residents in one Town
* A Town can host several Teams
* A Game has one HomeTeam and one AwayTeam and a Team can have many HomeGames and many AwayGames
* A Town can be placed in one Country and a Country can have many Towns
* A Player can play for one Team and one Team can have many Players
* A Player can play at one Position and one Position can be played by many Players
* One Player can play in many Games and in each Game, many Players take part (both collections must be named PlayersStatistics)
* Many Bets can be placed on one Game, but a Bet can be only on one Game
* Each bet for given game must Prediction
* A Bet can be placed by only one User and one User can place many Bets
Separate the models, data and client into different layers (projects).






