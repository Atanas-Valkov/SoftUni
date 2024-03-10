using System;
using System.Xml.Schema;

namespace P02L06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            for (int i = 1; i <= 3; i++)
            {
                char chars = char.Parse(Console.ReadLine());
                input += chars;
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write($"{input[i]} ");
            }
        }
    }
}
