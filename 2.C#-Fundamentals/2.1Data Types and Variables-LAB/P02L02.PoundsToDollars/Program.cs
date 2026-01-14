using System;

namespace P2L02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gbp = double.Parse(Console.ReadLine());
            double usd = 1.31;
            usd = usd * gbp;
            Console.WriteLine($"{usd:F3}");
        }
    }
}

