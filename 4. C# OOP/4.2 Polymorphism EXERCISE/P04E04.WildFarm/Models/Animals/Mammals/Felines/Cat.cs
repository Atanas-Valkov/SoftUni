using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Mammals.Felines;

public class Cat : Feline, IAbility
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double Grow { get; } = 0.30;

    public override bool Eat(IFood food)
    {
        if (food is Vegetable || food is Meat && base.Eat(food))
        {
            return base.Eat(food);
        }
        Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
        return false;
    }
   
    public override string ProduceSound()
    {
        return "Meow";
    }
    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }

}