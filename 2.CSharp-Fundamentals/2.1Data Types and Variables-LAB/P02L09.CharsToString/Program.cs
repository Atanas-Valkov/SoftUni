﻿using System;

namespace P02L09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            char char3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{char1}{char2}{char3}");
        }
    }
}
