using System.Text.RegularExpressions;

namespace P04L08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal baseNumber = decimal.Parse(Console.ReadLine());
            decimal powerNumber = decimal.Parse(Console.ReadLine());

            Console.WriteLine(RaiseToPower(baseNumber, powerNumber));
        }
        static decimal RaiseToPower(decimal baseNumber, decimal powerNumber)
        {
            decimal result = 1m;
            for (int i = 1; i <= powerNumber; i++)
            {
                result *= baseNumber;
            }
            return result;
        }
    }
}