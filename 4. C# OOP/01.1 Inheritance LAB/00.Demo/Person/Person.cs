using System.Runtime.InteropServices.JavaScript;

namespace _00.Demo.Person;

public class Person
{
    public Person(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }
    public string Address { get; set; }
}