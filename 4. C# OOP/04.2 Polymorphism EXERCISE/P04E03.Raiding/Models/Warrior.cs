namespace P04E03.Raiding.Models;

public class Warrior : BaseHero
{
    public Warrior(string heroName, double power)
        : base(heroName, power)
    {
        
        this.Power = 100;
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {HeroName} hit for {this.Power} damage";
    }
}