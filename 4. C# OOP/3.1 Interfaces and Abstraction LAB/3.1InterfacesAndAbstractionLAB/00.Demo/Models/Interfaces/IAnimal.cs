namespace _00.Demo.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }
    int Age { get; }

    void SayHello();
}