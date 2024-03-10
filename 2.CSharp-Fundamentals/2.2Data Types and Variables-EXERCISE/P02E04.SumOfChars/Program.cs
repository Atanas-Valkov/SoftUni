using System;
using System.Runtime.InteropServices;

namespace P02E04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= lines; i++)
            {
                char chars = char.Parse(Console.ReadLine());
                int currentChar = (int)chars;
                sum += currentChar;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
