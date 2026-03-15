### Football Betting
Your task is to create a database for a FootballBookmakerSystem, using the Code First approach. It should look like this:
# Database Diagram



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






