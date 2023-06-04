using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace P04L01.SignofIntegerNumbers
{
    internal class Program
    {
        static void IsNumberPositiveNegativeOrZero()
        {
            int num = int.Parse(Console.ReadLine());

            if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {num} is zero.");

            }
        }

        static void Main()
        {
           
            IsNumberPositiveNegativeOrZero();
        }
    }
}