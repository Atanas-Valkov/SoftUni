namespace AccessControlSystem.Models.Department;

public class FinanceDepartment : Department
{
    public FinanceDepartment()
    {
        this.SecurityLevel = 4;
        this.MaxEmployeesCount = 3;
    }
}