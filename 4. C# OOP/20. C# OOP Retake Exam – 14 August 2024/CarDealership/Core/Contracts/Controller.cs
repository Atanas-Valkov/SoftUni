using CarDealership.Models.Customer;
using CarDealership.Utilities.Messages;
using System.Collections;
using System.Text;
using CarDealership.Models.Customer.Customer;
using CarDealership.Models.Vehicles;
using CarDealership.Models;
using CarDealership.Models.Dealerships;

namespace CarDealership.Core.Contracts;

public class Controller : IController
{
    private readonly IDealership dealership = new Dealership();


    public string AddCustomer(string customerTypeName, string customerName)
    {
        if (customerTypeName != nameof(IndividualClient) && customerTypeName != nameof(LegalEntityCustomer))
        {
            return string.Format(OutputMessages.InvalidType, customerTypeName);
        }


        if (this.dealership.Customers.Exists(customerName))
        {
            return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
        }

        ICustomer customer;

        if (customerTypeName == nameof(IndividualClient))
        {
            customer = new IndividualClient(customerName);
        }
        else
        {
            customer = new LegalEntityCustomer(customerName);
        }
        this.dealership.Customers.Add(customer);
        ;
        return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
    }

    public string AddVehicle(string vehicleTypeName, string model, double price)
    {
        if (vehicleTypeName != nameof(SaloonCar) &&
            vehicleTypeName != nameof(SUV) &&
            vehicleTypeName != nameof(Truck))
        {
            return string.Format(OutputMessages.InvalidType, vehicleTypeName);
        }

        if (this.dealership.Vehicles?.Exists(model) == true)
        {
            return string.Format(OutputMessages.VehicleAlreadyAdded, model);
        }

        IVehicle vehicle = null;

        if (vehicleTypeName == nameof(SaloonCar))
        {
            vehicle = new SaloonCar(model, price);
        }
        else if (vehicleTypeName == nameof(SUV))
        {
            vehicle = new SUV(model, price);
        }
        else if (vehicleTypeName == nameof(Truck))
        {
            vehicle = new Truck(model, price);
        }

        this.dealership.Vehicles.Add(vehicle);

        return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, $"{vehicle.Price:F2}");

    }

    public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
    {
        if ( !this.dealership.Customers.Exists(customerName))
        {
            return string.Format(OutputMessages.CustomerNotFound, customerName);
        }

        if (!dealership.Vehicles.Models.Any(m => m.GetType().Name == vehicleTypeName))
        {
            return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
        }

        ICustomer customer = this.dealership.Customers.Get(customerName);

        if (customer.GetType().Name == nameof(IndividualClient) && vehicleTypeName == nameof(Truck) ||
            customer.GetType().Name == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar))
        {
            return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
        }

        List<IVehicle> filter = this.dealership.Vehicles.Models
            .Where(x => x.GetType().Name == vehicleTypeName)
            .Where(x => x.Price <= budget)
            .ToList();

        if (!filter.Any())
        {
            return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
        }

        IVehicle expensiveOne = filter.MaxBy(x => x.Price);

        customer.BuyVehicle(expensiveOne.Model);
        expensiveOne.SellVehicle(customerName);

        return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, expensiveOne.Model);
    }

    public string CustomerReport()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Customer Report:");

        foreach (var customer in dealership.Customers.Models.OrderBy(c => c.Name))
        {
            sb.AppendLine(customer.ToString());
            sb.AppendLine("-Models:");

            if (customer.Purchases.Count == 0)
            {
                sb.AppendLine("--none");
            }
            else
            {
                foreach (var model in customer.Purchases.OrderBy(x => x))
                {
                    sb.AppendLine($"--{model}");
                }
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string SalesReport(string vehicleTypeName)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{vehicleTypeName} Sales Report:");

        List<IVehicle> vehicles = dealership.Vehicles.Models
            .Where(x => x.GetType().Name == vehicleTypeName)
            .ToList();

        foreach (var vehicle in vehicles.OrderBy(x => x.Model))
        {
            sb.AppendLine($"--{vehicle.ToString()}");
        }

        sb.AppendLine($"-Total Purchases: {vehicles.Select(x => x.SalesCount).Sum()}");

        return sb.ToString().TrimEnd();
    }
}