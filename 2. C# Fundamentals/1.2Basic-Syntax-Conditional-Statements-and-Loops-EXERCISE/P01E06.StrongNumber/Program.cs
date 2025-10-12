using System;
using System.Net;

namespace P01E06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;
            int sum = 0;

            while (number>0)
            {
                int factorials = 1;
                int currentNumber = number % 10;
                number = number / 10;
                for (int i = 2; i <= currentNumber; i++)
                {

                    factorials *= i;

                }
                sum += factorials;
            }

            Console.WriteLine(sum == copyNumber ? "yes" : "no");
        }
    }
}
