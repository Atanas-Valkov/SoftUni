using System;

namespace P02L09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thidChar = char.Parse(Console.ReadLine());

            Console.WriteLine($"{firstChar}{secondChar}{thidChar}");

        }
    }
}
