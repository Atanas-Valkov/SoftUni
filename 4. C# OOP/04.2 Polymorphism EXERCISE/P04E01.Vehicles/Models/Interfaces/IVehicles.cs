namespace P04E01.Vehicles.Models.Interfaces;

public interface IVehicles
{
    double fuelQuantity { get; }
    double fuelConsumption { get;}

    string Drive(double distance);
    void Refuel(double liters);


}