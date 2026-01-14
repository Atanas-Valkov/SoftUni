using P04E03.Raiding.Models.Interfaces;

namespace P04E03.Raiding.Models;

public class Druid : BaseHero
{
    public Druid(string heroName, double power) 
        : base(heroName, power)
    {
       
        this.Power = 80;
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {HeroName} healed for {this.Power}";
    }
}