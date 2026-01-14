using CarDealership.Models;
using CarDealership.Repositories.Contracts;
using System.Reflection;

namespace CarDealership.Repositories;

public class VehicleRepository : IRepository<IVehicle>
{
    private readonly List<IVehicle> models;
    public IReadOnlyCollection<IVehicle> Models => models.AsReadOnly();

    public VehicleRepository()
    {
        this.models = new List<IVehicle>();
    }

    public void Add(IVehicle model)
    { 
        this.models.Add(model);
    }

    public bool Remove(string text)
    {
        IVehicle toRemove = this.models.FirstOrDefault(v => v.Model == text);
        if (toRemove != null)
        {
            this.models.Remove(toRemove);
            return true;
        }
        return false;
    }

    public bool Exists(string text)
    {
        return this.models.Any(m => m.Model == text);
    }

    public IVehicle Get(string text)
    {
        return this.models.FirstOrDefault(v => v.Model == text);
    }
}