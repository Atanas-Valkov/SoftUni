namespace _00.Demo.Person;

public class Employee : Person
{
    public Employee(string name, string address, string company) 
        : base(address, name)
    {
    }

    public string Company { get; set; }

}