using _00.Demo.Models.Interfaces;

namespace _00.Demo;

public class Document : IPrintable, IReadable
{
    public void Print()
    {
        Console.WriteLine("I am document");
    }

    public void Read()
    {
        Console.WriteLine("Just read... ");
    }
}