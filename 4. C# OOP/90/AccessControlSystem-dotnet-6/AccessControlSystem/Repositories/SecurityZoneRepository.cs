using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

public class SecurityZoneRepository : IRepository<ISecurityZone>
{
    private readonly List<ISecurityZone> models;
    public SecurityZoneRepository()
    {
        this.models = new List<ISecurityZone>();
    }


    public IReadOnlyCollection<ISecurityZone> Models => this.models.AsReadOnly();
    public void AddNew(ISecurityZone model)
    {
        this.models.Add(model);
    }

    public ISecurityZone GetByName(string modelName)
    {
        return this.models.FirstOrDefault(e => e.Name == modelName);
    }

    public int SecurityCheck(string modelName)
    {
        var securityZone = this.GetByName(modelName);

        if (securityZone == null)
        {
            return 0;
        }
        return securityZone.AccessLevelRequired;
    }
}