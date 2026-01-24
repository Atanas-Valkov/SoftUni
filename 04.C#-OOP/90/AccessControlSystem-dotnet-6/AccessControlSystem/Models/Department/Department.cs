using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models.Department;

public abstract class Department: IDepartment
{
    private int securityLevel;
    private int maxEmployeesCount;
    private List<string> employees;

    protected Department()
    {
        this.SecurityLevel = securityLevel;
        this.MaxEmployeesCount = maxEmployeesCount;
        this.employees = new List<string>();
    }

    public int SecurityLevel
    {
        get => this.securityLevel;
        protected set => this.securityLevel = value;
    }
    public IReadOnlyCollection<string> Employees => this.employees.AsReadOnly();

    public int MaxEmployeesCount
    {
        get=> this.maxEmployeesCount;
        protected set => this.maxEmployeesCount = value;
    }
    public void ContractEmployee(string employeeName)
    {
        if (this.maxEmployeesCount <= this.employees.Count)
        {
            throw new ArgumentException(ExceptionMessages.InvalidDepartmentCapacity);
        }

        if (this.employees.Contains(employeeName))
        {
            throw new ArgumentException(ExceptionMessages.EmployeeAlreadyAdded);
        }

        this.employees.Add(employeeName);
    }
}