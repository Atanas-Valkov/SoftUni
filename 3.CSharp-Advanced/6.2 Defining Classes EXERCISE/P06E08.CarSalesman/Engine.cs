namespace P06E08.CarSalesman;

public class Engine
{

    public Engine(string model, int power, int? displacement, string? efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement ?? 0;
        this.Efficiency = efficiency ?? "n/a";
    }

    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

}