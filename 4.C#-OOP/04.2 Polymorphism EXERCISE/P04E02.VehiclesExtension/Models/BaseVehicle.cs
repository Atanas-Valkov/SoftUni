using System.Diagnostics;
using P04E01.Vehicles.Models.Interfaces;

namespace P04E02.VehiclesExtension.Models;

public abstract class BaseVehicle : IVehicles
{
    protected BaseVehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity > tankCapacity
            ? 0   
            : fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; protected set; }

    public virtual double FuelConsumption { get; protected set; }

    public double TankCapacity { get; private set; }

    public string Drive(double distance)
    {
        double neededFuel = distance * this.FuelConsumption;

        if (neededFuel > this.FuelQuantity)
        {
            return $"{this.GetType().Name} needs refueling";
        }

        this.FuelQuantity -= neededFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double liters)
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

        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}