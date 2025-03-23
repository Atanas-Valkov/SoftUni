using System;

namespace P04E08.FacturialFirst 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double factorial = double.Parse(Console.ReadLine());
            double divider = double.Parse(Console.ReadLine());

            FacturialFirst (factorial);
            FacturialSecond(divider);
            Console.WriteLine($"{FacturialFirst(factorial) / FacturialSecond(divider):f2}");
        }

        private static double FacturialSecond(double divider)
        {
            double sum = 1;
            for (double i = divider; i >= 1; i--)
            {
                sum *= i;
            }
            return sum;
        }

        private static double FacturialFirst (double factorial)
        {
            double sum = 1;
            for (double i = factorial ; i >= 1; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}