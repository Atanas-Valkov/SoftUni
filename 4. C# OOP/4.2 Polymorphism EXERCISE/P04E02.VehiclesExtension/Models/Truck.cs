using System;
using P04E01.Vehicles.Models.Interfaces;
using P04E02.VehiclesExtension.Models;

public class Truck : BaseVehicle
{
    private const double AirConditionerConsumption = 1.6;
    private const double RefuelLoss = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + AirConditionerConsumption, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (this.FuelQuantity + liters > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }

        this.FuelQuantity += liters * RefuelLoss;
    }
}