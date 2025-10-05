namespace P06E07.RawData;

public class Engine
{
    public Engine (double engineSpeed, double enginePower)
    {
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
    }

    public double EngineSpeed { get; set; }

    public double EnginePower { get; set; }

}