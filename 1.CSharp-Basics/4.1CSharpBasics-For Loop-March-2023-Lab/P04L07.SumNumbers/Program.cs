﻿using System;

namespace P07.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int sum = 0;


            for (int i = 1; i <=n; i++)
            {
                int nmber = int.Parse(Console.ReadLine());  

                sum += nmber;

            }

            Console.WriteLine(sum);


        }
    }
}
