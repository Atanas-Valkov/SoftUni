using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models;

public abstract class Animal : IAnimal , IAbility
{
    protected Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;

    }

    public string Name { get; private set; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }

    protected abstract double Grow { get; }

    public virtual bool Eat(IFood food)
    {
        // 1000 * 0.1 + 0.5  
        this.Weight += food.Quantity * this.Grow;
        this.FoodEaten += food.Quantity;
        return true;
    }

    public abstract string ProduceSound();

}
    
    