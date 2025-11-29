using CarDealership.Models;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories;

public class CustomerRepository : IRepository<ICustomer>
{
    private List<ICustomer> models;

    public CustomerRepository()
    {
        this.models = new List<ICustomer>();
    }

    public IReadOnlyCollection<ICustomer> Models => this.models.AsReadOnly();
    public void Add(ICustomer model)
    {
        this.models.Add(model);
    }

    public bool Remove(string text)
    {
        ICustomer toRemove = this.Get(text);

        if (toRemove != null)
        {
            this.models.Remove(toRemove);
            return true;
        }
        return false;
    }

    public bool Exists(string text)
    {
        return this.models.Any(c => c.Name == text);
    }

    public ICustomer Get(string text)
    {
        return this.models.FirstOrDefault(c => c.Name == text);
    }
}