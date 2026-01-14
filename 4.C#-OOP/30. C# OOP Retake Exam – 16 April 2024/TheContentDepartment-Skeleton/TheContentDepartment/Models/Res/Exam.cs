namespace TheContentDepartment.Models.Entities;

public class Exam : Resource
{
    private const int ConstantPriority = 1;
    public Exam(string name, string creator)
        : base(name, creator, ConstantPriority)

    {
        
    }
}