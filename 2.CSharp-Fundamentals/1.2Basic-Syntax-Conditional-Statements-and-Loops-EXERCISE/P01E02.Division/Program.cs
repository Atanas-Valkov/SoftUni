using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace P01E02.Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int num = int.Parse(Console.ReadLine());
            int bigestNumber = 0;
           
            if (num % 2 == 0 )
            {
                bigestNumber = 2;
            }
            if (num % 3 == 0)
            {
               bigestNumber = 3;

            }
            if (num % 6 == 0)
            {
                bigestNumber = 6;

            }
            if (num % 7 == 0)
            {
                bigestNumber = 7; 

            }
            if (num % 10 == 0)
            {
                bigestNumber = 10;

            }

            if (bigestNumber == 0)
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
