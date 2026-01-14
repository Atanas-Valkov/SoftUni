using System;

namespace P02L12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                int sum = 0;
                int number = i;
                while (number > 0)
                {
                    int lasrDigit= number % 10;
                    number /= 10;
                    sum += lasrDigit;
                }
                bool isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
