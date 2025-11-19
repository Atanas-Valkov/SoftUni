using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models;

public class Team : ITeam
{
    private string name;
    private int championshipPoints;
    private IManager teamManager;

    public Team(string name)
    {
        this.Name = name;
    }
    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }

            this.name = value;
        }
    }

    public int ChampionshipPoints
    {
        get => this.championshipPoints;
        private set
        {
            this.championshipPoints = value;
        }
    }

    public IManager TeamManager
    {
        get => this.teamManager;
        private set
        {
            this.teamManager = value;
        }
    }

    public int PresentCondition
    {
        get
        {
            if (this.TeamManager == null)
            {
                return 0;
            }

            double result = 0d;

            if (this.ChampionshipPoints == 0)
            {
                result = this.TeamManager.Ranking;
            }
            else
            {
                result = this.ChampionshipPoints * TeamManager.Ranking;
            }
            return (int)Math.Floor(result);
        }
    }


    public void SignWith(IManager manager)
    {
        this.teamManager = manager;
    }

    public void GainPoints(int points)
    {
        this.championshipPoints += points;
    }

    public void ResetPoints()
    {
        this.championshipPoints = 0;
    }

    public override string ToString()
    {
        return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        
    }
}