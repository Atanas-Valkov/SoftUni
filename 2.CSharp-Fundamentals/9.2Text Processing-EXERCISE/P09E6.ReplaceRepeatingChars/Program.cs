﻿using System.Text;

namespace P09E6.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    sb.Append(input[i]);
                }
            }
            Console.WriteLine(sb);
        }
    }
}