namespace CarDealership.Models.Vehicles;

public class SUV : Vehicle
{
    private const double AdditionalCosts = 1.20;
    public SUV(string model, double price) 
        : base(model, price * AdditionalCosts)
    {
    }
}