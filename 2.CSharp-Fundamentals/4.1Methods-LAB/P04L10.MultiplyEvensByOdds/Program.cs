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
            int multipleOfEvenAndOdd = 0;

            Console.WriteLine(GetMultipleOfEvenAndOdds(evenSum, oddSum, input));
        }
        private static int GetSumOfEvenDigits(int input, int evenSum)
        {
            while (input > 0)
            {
                int lastIndex = input % 10;

                if (lastIndex % 2 == 0)
                {
                    evenSum += lastIndex;
                }

                input = input / 10;
            }

            return evenSum;
        }
        private static int GetSumOfOddDigits(int input, int oddSum)
        {
            while (input > 0)
            {
                int lastIndex = input % 10;

                if (lastIndex % 2 != 0)
                {
                    oddSum += lastIndex;
                }

                input = input / 10;
            }

            return oddSum;
        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum, int input)
        {
          int  multipleOfEvenAndOdd = GetSumOfEvenDigits(input, evenSum) * GetSumOfOddDigits(input, oddSum);

          return multipleOfEvenAndOdd;
        }
    }
}