using System;

namespace P2L02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gbp = double.Parse(Console.ReadLine());

            double usd = gbp * 1.31;
            Console.WriteLine($"{usd:f3}");


        }
    }
}
