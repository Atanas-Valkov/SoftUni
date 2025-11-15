using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Mammals;

public abstract class Mammal : Animal
{
    public Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }



    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {FoodEaten}]";
    }
}