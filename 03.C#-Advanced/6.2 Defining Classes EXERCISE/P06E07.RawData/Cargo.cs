namespace P06E07.RawData;

public class Cargo
{
    public Cargo(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type { get; set; }

    public double Weight { get; set; }

}