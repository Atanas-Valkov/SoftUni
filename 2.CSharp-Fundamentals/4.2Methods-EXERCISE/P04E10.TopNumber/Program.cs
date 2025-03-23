
using System.Collections.Generic;
using System.Security.Cryptography;

namespace P04E10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            for (int i = 2; i <= endNumber; i++)
            {
                int currentNumber = i;
                IsDivisibleByEight(endNumber, currentNumber);
                HoldsAtLeastOneOddDigit(endNumber, currentNumber);
                if (IsDivisibleByEight(endNumber, currentNumber) && HoldsAtLeastOneOddDigit(endNumber, currentNumber))
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }

        private static bool HoldsAtLeastOneOddDigit(int endNumber, int currentNumber)
        {
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;
                currentNumber /= 10;
                if (lastDigit % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsDivisibleByEight(int endNumber,int currentNumber )
        {
            int sum = 0;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;
                sum += lastDigit;
                currentNumber /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }
            return false;
        }
    }
}