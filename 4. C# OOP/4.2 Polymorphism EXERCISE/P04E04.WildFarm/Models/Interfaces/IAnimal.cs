using P04E04.WildFarm.Models.Food;

namespace P04E04.WildFarm.Models.Interfaces;

public interface IAnimal 
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }

    bool Eat(IFood food);
}