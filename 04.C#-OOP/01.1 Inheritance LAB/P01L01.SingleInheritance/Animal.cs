using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Farm;

public class Animal
{
    public Animal(string name)
    {
        Name = name;
    }


    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat()
    {
        Console.WriteLine("eating...");
    }

}