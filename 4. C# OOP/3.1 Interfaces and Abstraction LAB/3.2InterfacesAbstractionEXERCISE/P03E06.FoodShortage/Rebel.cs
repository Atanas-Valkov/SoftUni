namespace P03E06.FoodShortage;

public class Rebel : IBuyer
{
    private string name;
    private int age;
    private string group;
    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Group { get; private set; }
    public int Food { get; set; }
    public void BuyFood()
    {
        this.Food += 5;
    }



}