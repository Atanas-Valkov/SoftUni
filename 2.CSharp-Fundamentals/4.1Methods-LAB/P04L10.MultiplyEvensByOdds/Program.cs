using System;
using System.Diagnostics;
using System.Linq;

namespace P04L10.MultiplyEvensByOdds
{



    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            input = Math.Abs(input);

            int evenSum = 0;
            int oddSum = 0;
            int totalSum = 0;
            
           Console.WriteLine(GetMultipleOfEvenAndOdds(input, oddSum, evenSum));
        }
        static int GetMultipleOfEvenAndOdds(int input, int oddSum, int evenSum)
        {
            int totalSum = GetSumOfEvenDigits(input, evenSum) * GetSumOfOddDigits(input, oddSum);

            return totalSum;

        }
        static int GetSumOfEvenDigits(int input, int evenSum)
        {

            while (input > 0)
            {
                int lastNumber = input % 10;
                if (lastNumber % 2 == 0)
                {
                    evenSum += lastNumber;
                }
                input = input / 10;
            }
            return evenSum;
        }
        static int GetSumOfOddDigits(int input, int oddSum)
        {
            while (input > 0)
            {
                int lastNumber = input % 10;
                if (lastNumber % 2 != 0)
                {
                    oddSum += lastNumber;
                }
                input = input / 10;
            }
            return oddSum;
        }

    }
}