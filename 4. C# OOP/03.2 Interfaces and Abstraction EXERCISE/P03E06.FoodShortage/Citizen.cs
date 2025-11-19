using P03E06.FoodShortage;

namespace P03E05.BirthdayCelebrations;

public class Citizen : IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    private int food = 0;

    public Citizen(string name, int age, string id, string birthdate,int food)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
        this.Food = 0;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }
    public int Food { get; set; }

    public void BuyFood()
    {
        this.food += 10;
         Food = this.food;

    }
}