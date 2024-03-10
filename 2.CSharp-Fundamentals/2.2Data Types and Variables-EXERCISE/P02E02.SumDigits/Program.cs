using System;

namespace P02E02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            while (input > 0)
            {
                int currentNumber = input % 10;
                input /= 10;
                sum += currentNumber;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
