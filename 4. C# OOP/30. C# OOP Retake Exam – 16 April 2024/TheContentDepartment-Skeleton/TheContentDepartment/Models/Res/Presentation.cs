namespace TheContentDepartment.Models.Entities;

public class Presentation : Resource
{
    private const int ConstantPriority = 3;
    public Presentation(string name, string creator)
        : base(name, creator, ConstantPriority)
    {

    }

    
}