using System;

namespace P01.ReadText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                Console.WriteLine(input);
            }
        }
    }
}
