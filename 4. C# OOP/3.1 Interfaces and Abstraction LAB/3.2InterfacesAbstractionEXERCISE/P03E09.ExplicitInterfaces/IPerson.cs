namespace P03E09.ExplicitInterfaces;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
    string GetName();
}