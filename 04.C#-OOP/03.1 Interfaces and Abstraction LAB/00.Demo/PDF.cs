using _00.Demo.Models.Interfaces;

namespace _00.Demo;

public class PDF : IPrintable
{
    public void Print()
    {
        Console.WriteLine("I am PDF" );
    }
}