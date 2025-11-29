using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models.Dealerships;

public class Dealership : IDealership
{
    private readonly IRepository<ICustomer> customers;
    private readonly IRepository<IVehicle> vehicles;

    public Dealership()
    {
        this.customers = new CustomerRepository();
        this.vehicles = new VehicleRepository();
    }

    public IRepository<ICustomer> Customers
    {
        get => this.customers;
    }

    public IRepository<IVehicle> Vehicles
    {
        get => this.vehicles;
    }
}