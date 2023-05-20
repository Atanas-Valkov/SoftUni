using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace P01L09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());    
                
             int counter = 0;
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0 )
                {
                    counter++;
                    sum += i;
                    Console.WriteLine($"{i}");
                }
                if (counter == num)
                {
                    break;
                }
            }
                    Console.WriteLine($"Sum: {sum}");
        }
    }
}
