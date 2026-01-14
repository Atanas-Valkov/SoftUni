using CarDealership.Models;
using CarDealership.Models.Customer.Customer;

namespace CarDealership.Models.Customer.Customer;

public class LegalEntityCustomer : Customer
{
    public LegalEntityCustomer(string name) 
        : base(name)
    {
    }

}