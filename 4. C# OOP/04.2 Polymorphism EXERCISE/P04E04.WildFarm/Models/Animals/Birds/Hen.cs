using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Birds;

public class Hen : Bird  
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected override double Grow { get; } = 0.35;
    
    public override string ProduceSound()
    {
        return "Cluck";
    }

}