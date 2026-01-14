using FootballManager.Models.Contracts;

namespace FootballManager.Models;

public class AmateurManager : Manager
{
    private const double InitialRanking = 15;

    public AmateurManager(string name) 
        : base(name, InitialRanking)
    {
    }

    public override void RankingUpdate(double updateValue)
    {
        this.ValidateAndUpdateRanking(updateValue * 0.75);
    }
}