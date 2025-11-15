using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Birds;

public class Owl : Bird, IAbility
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }
    protected override double Grow { get; } = 0.25;
    
    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }

}