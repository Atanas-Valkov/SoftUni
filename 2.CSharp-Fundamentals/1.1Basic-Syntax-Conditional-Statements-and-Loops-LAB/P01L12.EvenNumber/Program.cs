﻿using System;
using System.Numerics;

namespace P01L12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            while (true)
            {
                if (number % 2 == 0) 
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Please write an even number.");
                }
                number = int.Parse(Console.ReadLine());
            }
        }
    }
}

