using System;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace P05E01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string aniBook = Console.ReadLine();
            int counter = 0;

            string input = string.Empty;

            while (input != "No More Books")
            {
                input = Console.ReadLine();


                if (input == aniBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");

                    break;
                }

                if (input != "No More Books")
                {
                    counter++;
                }
            }

            if (input == "No More Books")
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");

            }
        }
    }
}
