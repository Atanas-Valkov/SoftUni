using _00.Demo.Models.Interfaces;

namespace _00.Demo;

public class Image : IPrintable 
{
    public void Print()
    {
        Console.WriteLine("i am image ?!? ");
    }
}