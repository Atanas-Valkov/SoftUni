using CarDealership.Repositories.Contracts;

namespace CarDealership.Models
{
    public interface IDealership
    {
        IRepository<IVehicle> Vehicles { get; }

        IRepository<ICustomer> Customers { get; }
    }
}
