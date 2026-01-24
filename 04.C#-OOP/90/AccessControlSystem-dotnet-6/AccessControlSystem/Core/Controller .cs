using AccessControlSystem.Core.Contracts;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Models.Department;
using AccessControlSystem.Models.Employee;
using AccessControlSystem.Models.SecurityZone;
using AccessControlSystem.Repositories;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Core;

public class Controller : IController
{
    private readonly List<IDepartment> department;
    private readonly SecurityZoneRepository securityZoneRepository;
    private readonly EmployeeRepository employeeRepository;


    public Controller()
    {
        this.securityZoneRepository = new SecurityZoneRepository();
        this.employeeRepository = new EmployeeRepository();
        this.department = new List<IDepartment>();
    }

    public string AddDepartment(string departmentTypeName)
    {
        IDepartment department = null;

        if (departmentTypeName == nameof(ITDepartment))
        {
            department = new ITDepartment();
        }
        else if (departmentTypeName == nameof(HRDepartment))
        {
            department = new HRDepartment();
        }
        else if (departmentTypeName == nameof(FinanceDepartment))
        {
            department = new FinanceDepartment();
        }
        else
        {
            return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);
        }

        bool ifExists = this.department.Any(d => d.GetType().Name == departmentTypeName);

        if (ifExists)
        {
            return string.Format(OutputMessages.DepartmentExists, departmentTypeName);
        }

        this.department.Add(department);


        return string.Format(OutputMessages.DepartmentAdded, departmentTypeName);

    }

    public string AddEmployeeToApplication(string employeeName, string employeeTypeName, int securityId)
    {

        if (employeeTypeName != nameof(GeneralEmployee) &&
            employeeTypeName != nameof(ITSpecialist))
        {
            return string.Format(OutputMessages.InvalidEmployeeType, employeeTypeName);
        }

        if (this.employeeRepository.GetByName(employeeName) != null)
        {
            return string.Format(OutputMessages.EmployeeExistsInApplication, employeeName);
        }

        bool securityIdExists = this.employeeRepository.Models.Any(e => e.SecurityId == securityId);

        if (securityIdExists)
        {
            return string.Format(OutputMessages.SecurityIdExists, securityId);
        }
        IEmployee employee = null;

        if (employeeTypeName == nameof(GeneralEmployee))
        {
            employee = new GeneralEmployee(employeeName, securityId);
        }
        else if (employeeTypeName == nameof(ITSpecialist))
        {
            employee = new ITSpecialist(employeeName, securityId);
        }

        this.employeeRepository.AddNew(employee);

        return string.Format(OutputMessages.EmployeeAddedToApplication, employeeName);

    }

    public string AddEmployeeToDepartment(string employeeName, string departmentTypeName)
    {
        IEmployee employee = this.employeeRepository.GetByName(employeeName);
        if (employee == null)
        {
            return string.Format(OutputMessages.EmployeeNotInApplication, employeeName);
        }

        if (departmentTypeName != nameof(ITDepartment) &&
            departmentTypeName != nameof(HRDepartment) &&
            departmentTypeName != nameof(FinanceDepartment))
        {

            return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);
        }


        string employeeTypeName = employee.GetType().Name;

        bool isITSpecialist = employee is ITSpecialist;
        bool isGeneralEmployee = employee is GeneralEmployee;

        if (isITSpecialist && departmentTypeName != nameof(ITDepartment))
        {
            return string.Format(OutputMessages.ContractNotAllowed, employeeTypeName, departmentTypeName);
        }

        if (isGeneralEmployee && departmentTypeName == nameof(ITDepartment))
        {
            return string.Format(OutputMessages.ContractNotAllowed, employeeTypeName, departmentTypeName);
        }

        IDepartment departmentInstance = this.department
            .FirstOrDefault(d => d.GetType().Name == departmentTypeName);

        if (departmentInstance == null)
        {
            return string.Format(OutputMessages.DepartmentIsNotAvailable, departmentTypeName);
        }

        if (employee.Department != null)
        {
            return string.Format(OutputMessages.EmployeeExistsInDepartment, employeeName);
        }

        if (departmentInstance.Employees.Count >= departmentInstance.MaxEmployeesCount)
        {
            return string.Format(OutputMessages.DepartmentFull, departmentTypeName);
        }

        departmentInstance.ContractEmployee(employeeName);
        employee.AssignToDepartment(departmentInstance);

        return string.Format(OutputMessages.EmployeeAddedToDepartment, employeeTypeName, departmentTypeName);

    }

    public string AddSecurityZone(string securityZoneName, int accessLevelRequired)
    {

        var existingZone = this.securityZoneRepository.GetByName(securityZoneName);

        if (existingZone != null)
        {
            return string.Format(OutputMessages.SecurityZoneNotFound, securityZoneName);

        }

        var securityZone = new SecurityZone(securityZoneName, accessLevelRequired);
        this.securityZoneRepository.AddNew(securityZone);

        return string.Format(OutputMessages.SecurityZoneAdded, securityZoneName);
    }

    public string AuthorizeAccess(string securityZoneName, string employeeName)
    {
        return string.Empty;
    }

    public string SecurityReport()
    {
        return string.Empty; 
    }
}