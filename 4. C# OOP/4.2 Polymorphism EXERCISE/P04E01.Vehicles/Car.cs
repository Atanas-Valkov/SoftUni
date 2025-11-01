using System.Collections.Concurrent;
using P04E01.Vehicles.Models.Interfaces;

namespace P04E01.Vehicles;

public class Car : BaseVehicle
{
    private const double airConditionerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override double fuelConsumption => base.fuelConsumption + airConditionerConsumption;

}