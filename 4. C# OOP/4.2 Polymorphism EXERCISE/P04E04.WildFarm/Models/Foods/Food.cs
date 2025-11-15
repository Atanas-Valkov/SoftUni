using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Food;


public abstract class Food : IFood
{
    protected Food(int quantity)
    {
        Quantity = quantity;
    }
    public int Quantity { get; private set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}";
    }

}