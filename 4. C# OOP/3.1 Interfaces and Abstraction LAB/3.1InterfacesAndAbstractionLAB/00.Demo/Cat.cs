using _00.Demo.Models.Interfaces;

namespace _00.Demo;

public class Cat : IAnimal , IMovable
{
    public string Name { get; }
    public int Age { get; }
    public void SayHello()
    {
        Console.WriteLine($"Hello");
    } 

    public void Move()
    {
        Console.WriteLine("something");
    }
}