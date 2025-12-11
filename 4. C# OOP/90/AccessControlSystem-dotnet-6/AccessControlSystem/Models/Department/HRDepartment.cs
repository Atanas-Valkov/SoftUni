namespace AccessControlSystem.Models.Department;

public class HRDepartment : Department
{
    public HRDepartment()
    {
        this.SecurityLevel = 3;
        this.MaxEmployeesCount = 5;
    }

}