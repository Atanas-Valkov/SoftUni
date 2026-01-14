using CarDealership.Utilities.Messages;

namespace CarDealership.Models.Customer.Customer;

public abstract class Customer : ICustomer
{
    private string name;
    private List<string> purchases;

    protected Customer(string name)
    {
        this.Name = name;
        this.purchases = new List<string>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameIsRequired);
            }

            this.name = value;
        }
    }

    public IReadOnlyCollection<string> Purchases => this.purchases.AsReadOnly();
    public void BuyVehicle(string vehicleModel)
    {
        purchases.Add(vehicleModel);
    }

    public override string ToString()
    {
        return $"{this.Name} - Purchases: {Purchases.Count}";
    }
}