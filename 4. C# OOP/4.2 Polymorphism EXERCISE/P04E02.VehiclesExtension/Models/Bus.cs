namespace P04E02.VehiclesExtension.Models;

public class Bus : BaseVehicle
{
    private const double AirConditionerConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + AirConditionerConsumption, tankCapacity)
    {
    }

    public string DriveEmpty(double distance)
    {
        double original = this.FuelConsumption;
        this.FuelConsumption -= AirConditionerConsumption;

        string result = this.Drive(distance);
        this.FuelConsumption = original;
        return result;
    }
}
