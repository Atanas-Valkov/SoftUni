namespace Animals;

public class Dog : Animal
{
    public Dog(string name, string favoriteFood) 
        : base(name, favoriteFood)
    {
    }
    public override string ExplainSelf()
    {
        return $"I am {this.Name} and my favourite food is {this.FavoriteFood} DJAAF";
    }
}