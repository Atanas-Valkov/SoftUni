using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Mammals;

public class Dog : Mammal, IAbility
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected override double Grow { get; } = 0.40;

    public override bool Eat(IFood food)
    {
        if ( food is Meat && base.Eat(food))
        {
            return base.Eat(food);
        }
        Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
        return false;
    }

    public override string ProduceSound()
    {
       return "Woof!";
    }
    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}