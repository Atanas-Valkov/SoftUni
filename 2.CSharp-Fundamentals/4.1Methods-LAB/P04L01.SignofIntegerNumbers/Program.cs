using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace P04L01.SignofIntegerNumbers
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            IsPositive(number);
            IsNegative(number);
            IsZero(number);
        }

        private static void IsZero(int number)
        {
            if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }

        private static void IsNegative(int number)
        {
            if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }

        private static void IsPositive(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");


                c 
               


            }
        }
    }
}