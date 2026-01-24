namespace P03E05.BirthdayCelebrations;

public class Robots 
{

    private string model;
    private string id;
    public Robots(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; private set; }
    public string Id { get; private set; }
}