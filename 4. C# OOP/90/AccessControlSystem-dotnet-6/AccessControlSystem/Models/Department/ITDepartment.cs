namespace AccessControlSystem.Models.Department;

public class ITDepartment : Department
{
    public ITDepartment()
    {
        this.SecurityLevel = 5;
        this.MaxEmployeesCount = 8;
    }
}