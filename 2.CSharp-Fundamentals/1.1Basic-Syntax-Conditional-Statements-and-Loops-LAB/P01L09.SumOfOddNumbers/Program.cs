﻿using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace P01L09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;  
            
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(2*i-1);
                sum += 2 * i - 1;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
