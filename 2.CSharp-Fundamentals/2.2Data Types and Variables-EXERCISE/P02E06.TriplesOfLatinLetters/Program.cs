using System;

namespace P02E06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int end = 97 + n;

            for (int i = 97; i < end; i++)
            {
                for (int j = 97; j <end; j++)
                {
                    for (int k = 97; k < end; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
