using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace P01E02.Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bigestNumber = 0;

            if (number % 2 == 0)
            {
                bigestNumber = 2;
            }
            if (number % 3 == 0)
            {
                bigestNumber = 3;
            }
            if (number % 6 == 0)
            {
                bigestNumber = 6;
            }
            if (number % 7 == 0)
            {
                bigestNumber = 7;
            }
            if (number % 10 == 0)
            {
                bigestNumber = 10;
            }

            if (bigestNumber == 0 )
            {
                Console.WriteLine($"Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {bigestNumber}");   
            }
        }
    }
}
