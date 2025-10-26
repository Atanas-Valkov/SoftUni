
namespace Cars;

public class Seat : ICar
{

    private string model;
    private string color;
    public Seat( string color, string model)
    {
        Color = color;
        Model = model;
    }

    public string Model { get; }
    public string Color { get; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
       return "Breaaak!";
    }
    public override string ToString()
    {
        return $"{this.Color} Seat {this.Model}";
    }
}