using System.Text;
using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Core;

public class Controller : IController
{
    private readonly string[] managerTypes = new string[]
    {
        "AmateurManager",
        "ProfessionalManager",
        "SeniorManager"
    };

    private TeamRepository championship;

    public Controller()
    {
        this.championship = new TeamRepository();
    }


    public string JoinChampionship(string teamName)
    {
        if (this.championship.Capacity == this.championship.Models.Count)
        {
            return OutputMessages.ChampionshipFull;
        }

        if (championship.Exists(teamName))
        {
            return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
        }

        Team team = new Team(teamName);
        this.championship.Add(team);
        return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);

    }


    public string SignManager(string teamName, string managerTypeName, string managerName)
    {
        if (!this.championship.Exists(teamName))
        {
            return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
        }

        if (!managerTypes.Contains(managerTypeName))
        {
            return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
        }

        ITeam team = this.championship.Get(teamName);

        if (team.TeamManager != null)
        {
            return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
        }

        // foreach (var existingTeam in this.championship.Models)
        // {
        //    if (existingTeam.TeamManager?.Name == managerName) => ако това преди ? е null не извиквай Name а ВРЪЩА null
        //    {                                                  => ако не е null продължи с извикването на Name
        //    
        //        return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);

        //    }
        //
        // }

        ITeam existingTeam = this.championship.Models.FirstOrDefault
                (t => t.TeamManager != null && t.TeamManager.Name == managerName);

        if (existingTeam != null)
        {
            return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
        }

        var manager = this.CreateManagerByType(managerTypeName, managerName);
        team.SignWith(manager);
        return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
    }

    private Manager CreateManagerByType(string managerTypeName, string managerName)
    {
        if (managerTypeName == typeof(AmateurManager).Name)
        {
            return new AmateurManager(managerName);
        }
        else if (managerTypeName == typeof(ProfessionalManager).Name)
        {
            return new ProfessionalManager(managerName);
        }
        else if (managerTypeName == typeof(SeniorManager).Name)
        {
            return new SeniorManager(managerName);
        }

        return null;
    }


    public string MatchBetween(string teamOneName, string teamTwoName)
    {
        if (!this.championship.Exists(teamOneName) || !this.championship.Exists(teamTwoName))
        {
            return string.Format(OutputMessages.OneOfTheTeamDoesNotExist);
        }

        var teamOne = this.championship.Get(teamOneName);
        var teamTwo = this.championship.Get(teamTwoName);

        var winner = teamOne;
        var loser = teamTwo;

        if (teamOne.PresentCondition > teamTwo.PresentCondition)
        {
            winner = teamOne;
            loser = teamTwo;
        }
        else if (teamTwo.PresentCondition > teamOne.PresentCondition)
        {
            winner = teamTwo;
            loser = teamOne;
        }
        else
        {
            teamOne.GainPoints(1);
            teamTwo.GainPoints(1);
            return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
        }

        winner.GainPoints(3);

        winner.TeamManager?.RankingUpdate(5);
        loser.TeamManager?.RankingUpdate(-5);

        return string.Format(OutputMessages.TeamWinsMatch, winner.Name, loser.Name);
    }

    public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
    {
        if (!this.championship.Exists(droppingTeamName))
        {
            return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
        }

        if (this.championship.Exists(promotingTeamName))
        {
            return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
        }

        var team = new Team(promotingTeamName);

        var managerExist = false;

        ITeam existingTeam = this.championship.Models.FirstOrDefault
            (t => t.TeamManager != null && t.TeamManager.Name == managerName);

        if (existingTeam != null)
        {
            managerExist = true;
             
        }

        if (!managerExist && managerTypes.Contains(managerTypeName))
        {
            var manager = this.CreateManagerByType(managerTypeName, managerName);
            team.SignWith(manager);
        }

        foreach (var existTeam in this.championship.Models)
        {
            existTeam.ResetPoints();
        }

        this.championship.Remove(droppingTeamName);

        this.championship.Add(team);

        return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
    }

    public string ChampionshipRankings()
    {
        var sortedTeams = this.championship.Models
            .OrderByDescending(t => t.ChampionshipPoints)
            .ThenByDescending(t => t.PresentCondition)
            .ToList();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("***Ranking Table***");
        int counter = 1;

        foreach (var sortedTeam in sortedTeams)
        {
            sb.AppendLine($"{counter++}. {sortedTeam}/{sortedTeam.TeamManager}");
        }

        return sb.ToString().TrimEnd();
    }
}