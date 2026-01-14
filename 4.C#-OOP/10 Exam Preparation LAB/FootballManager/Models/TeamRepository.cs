using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Models;

public class TeamRepository : IRepository<ITeam>
{
    private List<ITeam> teams;
    private const int MaximumCapacity = 10;


    public TeamRepository()
    {
        this.teams = new List<ITeam>();
    }

    public IReadOnlyCollection<ITeam> Models
    {
        get
        {
          return this.teams.AsReadOnly();
        }
    }

    public int Capacity
    {
        get
        {
          return  MaximumCapacity;
        }
    
    }

    public void Add(ITeam model)
    {
        if (this.teams.Count == Capacity)   
        {
            return;
        }
        this.teams.Add(model);
    }

    public bool Remove(string name)
    {
        var teamToRemove = this.teams.First(t => t.Name == name);

        if (teamToRemove != null)
        {
            this.teams.Remove(teamToRemove);
            return true;
        }
        return false;
    }

    public bool Exists(string name)
    {

        if (this.teams.Any(t => t.Name == name))
        {
            return true;
        }

        return false;
    }

    public ITeam Get(string name)
    {
        return this.teams.FirstOrDefault(t => t.Name == name);
    }
}