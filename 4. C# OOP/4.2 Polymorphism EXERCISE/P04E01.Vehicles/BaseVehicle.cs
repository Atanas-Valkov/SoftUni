using P04E01.Vehicles.Models.Interfaces;

namespace P04E01.Vehicles;

public abstract class BaseVehicle : IVehicles
{

    public BaseVehicle(double fuelQuantity, double fuelConsumption)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumption = fuelConsumption;
    }
    public double fuelQuantity { get; private set; }
    public virtual double fuelConsumption { get; }

    public string Drive(double distance)
    {
        double neededFuel = distance * this.fuelConsumption;
        if (neededFuel > this.fuelQuantity)
        {
            return $"{this.GetType().Name} needs refueling";
        }
        this.fuelQuantity -= neededFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double liters)
    {
        
        fuelQuantity += liters;
    }
}