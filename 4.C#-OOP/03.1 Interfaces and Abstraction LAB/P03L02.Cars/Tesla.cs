namespace Cars;
public class Tesla : ICar, IElectricCar
{
    private int battery;
    public Tesla(string color, string model, int battery )
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public int Battery { get; }
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
        return $"{this.Color} Tesla {this.Model} with {this.Battery} batteries";
    }
}