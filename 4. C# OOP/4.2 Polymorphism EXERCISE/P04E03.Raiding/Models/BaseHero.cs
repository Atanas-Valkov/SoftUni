using P04E03.Raiding.Models.Interfaces;

namespace P04E03.Raiding.Models;

public abstract class BaseHero : ICastAbility 
{
    protected BaseHero(string heroName, double power)
    {
        this.HeroName = heroName;
        this.Power = power;
    }

    public string HeroName { get; }
    public double Power { get; protected init; }
    public abstract string CastAbility();
}