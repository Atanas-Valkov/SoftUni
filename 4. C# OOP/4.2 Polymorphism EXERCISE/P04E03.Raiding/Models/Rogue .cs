namespace P04E03.Raiding.Models;

public class Rogue : BaseHero
{
    public Rogue(string heroName, double power) 
        : base(heroName, power)
    {
       
        this.Power = 80;
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {HeroName} hit for {this.Power} damage";
    }
}