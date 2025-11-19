namespace P03E09.ExplicitInterfaces;

public interface IResident
{
    string Name { get; }
    string Country { get; }

    string GetName();
}