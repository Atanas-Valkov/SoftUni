namespace P06E07.RawData;

public class Car
{

    public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tire;
    }


    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public Tire[] Tires { get; set; }
}