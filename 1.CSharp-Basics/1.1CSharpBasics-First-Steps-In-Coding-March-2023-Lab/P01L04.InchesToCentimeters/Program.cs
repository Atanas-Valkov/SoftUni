﻿using System;

namespace P04.InchesToCentimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
          double inches = Double.Parse(Console.ReadLine());
            double centimeters = inches * 2.54;
            Console.WriteLine(centimeters);

        }
    }
}