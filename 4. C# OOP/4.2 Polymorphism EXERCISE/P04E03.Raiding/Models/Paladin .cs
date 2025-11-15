namespace P04E03.Raiding.Models;

public class Paladin : BaseHero
{
    public Paladin(string heroName, double power) 
        : base(heroName, power)
    {
        this.Power = 100;
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {HeroName} healed for {this.Power}";
    }
}