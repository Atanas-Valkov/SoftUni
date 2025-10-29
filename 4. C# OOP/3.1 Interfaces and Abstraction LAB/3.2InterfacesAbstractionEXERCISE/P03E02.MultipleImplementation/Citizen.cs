namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string Id, string Birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = Id;
        this.Birthdate = Birthdate;

    }
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
}