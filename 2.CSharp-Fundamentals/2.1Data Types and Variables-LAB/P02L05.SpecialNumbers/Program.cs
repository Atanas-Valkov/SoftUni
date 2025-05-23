﻿using System;
using System.Net;

namespace P02L05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                int number = i;
                int sum = 0;

                while (number != 0)
                {
                    int lastdigit = number % 10;
                    number /= 10;
                    sum += lastdigit;
                }

                bool isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
