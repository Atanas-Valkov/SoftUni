using System;

namespace P02L07.ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string simb = Console.ReadLine();

            Console.WriteLine($"{name1}{simb}{name2}");
        }
    }
}
