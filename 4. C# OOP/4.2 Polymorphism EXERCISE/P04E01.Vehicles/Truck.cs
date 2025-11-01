using P04E01.Vehicles.Models.Interfaces;

namespace P04E01.Vehicles;

public class Truck : BaseVehicle
{
    private const double airConditionerConsumption = 1.6;
    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override double fuelConsumption => base.fuelConsumption + airConditionerConsumption;
    public override void Refuel(double liters)
    {
        base.Refuel(liters * 0.95);
    }
}