using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

public class EmployeeRepository : IRepository<IEmployee>
{
    private readonly List<IEmployee> employees;
    public EmployeeRepository()
    {
        this.employees = new List<IEmployee>();
    }

    public IReadOnlyCollection<IEmployee> Models => this.employees.AsReadOnly();
    public void AddNew(IEmployee model)
    {
        this.employees.Add(model);
    }

    public IEmployee GetByName(string modelName)
    {
        return this.employees.FirstOrDefault(e => e.Name == modelName);
    }

    public int SecurityCheck(string modelName)
    {
        var employee = this.GetByName(modelName);

        if (employee == null || employee.Department == null)
        {
            return 0;
        }

        return employee.Department.SecurityLevel;
    }
}