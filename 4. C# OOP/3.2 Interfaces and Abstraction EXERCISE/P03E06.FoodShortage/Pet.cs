using System.ComponentModel;

namespace P03E05.BirthdayCelebrations;

public class Pet : ICheckable
{
    private string name;
    
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }
    
}