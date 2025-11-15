namespace P04E04.WildFarm.Models.Food;

/// <inheritdoc />
public class Fruit : Food
{
    public Fruit(int quantity) 
        : base(quantity)
    {
    }
    public override string ToString()
    {
        return $"a";
    }

}