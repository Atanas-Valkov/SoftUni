using System;
using System.Diagnostics;
using System.Linq;

namespace P04L10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipleOfEvenAndOdds(GetSumOfEvenDigits(number), GetSumOfOddDigits(number));

            Console.WriteLine(result);

        }
        static int GetSumOfOddDigits(int number)
        {
            int sumOfOddGigits = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;
                if (currentDigit % 2 != 0)
                {
                    sumOfOddGigits += currentDigit; 
                }
            }
            return sumOfOddGigits;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sumOfEvenDigits = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;
                if (currentDigit % 2 == 0)
                {
                    sumOfEvenDigits += currentDigit;
                }
            }
            return sumOfEvenDigits;
            
        }

        static int GetMultipleOfEvenAndOdds(int sumOfEvenDigits, int sumOfOddGigits)
        {


            return sumOfEvenDigits * sumOfOddGigits;
        }
    }
}