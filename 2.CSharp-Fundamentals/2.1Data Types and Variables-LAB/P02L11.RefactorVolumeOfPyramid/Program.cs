﻿using System;

namespace P02L11.RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            
            
           double V = (length * width * height) / 3;
            
            
            
            Console.Write($"Length: ");
            Console.Write($"Width: ");
            Console.Write($"Height: ");
            
            Console.WriteLine($"Pyramid Volume: {V:f2}");
        }
    }
}
