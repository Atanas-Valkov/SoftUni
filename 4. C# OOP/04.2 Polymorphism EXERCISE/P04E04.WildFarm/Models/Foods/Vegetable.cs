namespace P04E04.WildFarm.Models.Food;

public class Vegetable : Food
{
    public Vegetable(int quantity) 
        : base(quantity)
    {
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}";
    }
}