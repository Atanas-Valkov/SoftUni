namespace P04E01.Vehicles.Models.Interfaces;

public interface IVehicles
{
    double FuelQuantity { get; }
    double FuelConsumption { get;}
    double TankCapacity { get; }

    string Drive(double distance);
    void Refuel(double result);
}