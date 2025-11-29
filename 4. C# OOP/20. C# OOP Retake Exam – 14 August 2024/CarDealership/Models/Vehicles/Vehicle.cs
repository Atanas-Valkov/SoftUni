using CarDealership.Utilities.Messages;

namespace CarDealership.Models.Vehicles;

public abstract class Vehicle : IVehicle
{
    private string model;
    private double price;
    private readonly List<string> buyers;

    protected Vehicle(string model, double price)
    {
        this.model = model;
        this.price = price;
        buyers = new List<string>();
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelIsRequired);
            }
            model = value;
        }
    }

    public double Price
    {
        get => price;
        private set
        {
            if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
            }

            price = value;
        }
    }

    public IReadOnlyCollection<string> Buyers => buyers.AsReadOnly();
    public int SalesCount => buyers.Count;
    public void SellVehicle(string buyerName)
    {
        buyers.Add(buyerName);
    }

    public override string ToString()
    {
        return $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";
    }
}