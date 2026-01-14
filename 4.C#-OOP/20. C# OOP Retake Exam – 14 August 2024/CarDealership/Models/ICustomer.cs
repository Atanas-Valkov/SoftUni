namespace CarDealership.Models
{
    public interface ICustomer
    {
        string Name { get; }

        IReadOnlyCollection<string> Purchases { get; }

        void BuyVehicle(string vehicleModel);
    }
}
