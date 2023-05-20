using System;

namespace P02L08.TownInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            uint area = uint.Parse(Console.ReadLine());


            Console.WriteLine($"Town {city} has population of {population} and area {area} square km.");
        }
    }
}
