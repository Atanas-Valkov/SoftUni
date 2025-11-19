using System.Collections.Concurrent;
using P04E01.Vehicles.Models.Interfaces;

namespace P04E02.VehiclesExtension.Models;

public class Car : BaseVehicle
{
    private const double airConditionerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption => base.FuelConsumption + airConditionerConsumption;

}