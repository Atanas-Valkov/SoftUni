using System;
using System.Reflection;

namespace P04E06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacters(input);
        }

        private static void MiddleCharacters(string input)
        {
            int length = input.Length;
            if (length % 2 == 0)
            {
                Console.WriteLine($"{input[length / 2 - 1]}{input[length / 2]}");
            }
            else
            {
                Console.WriteLine(input[length / 2]);
            }   
        }
    }
}