using System;

namespace P01L01.ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int distanceM = int.Parse(Console.ReadLine());

            float distanceKm = distanceM / 1000.0f;
            Console.WriteLine($"{distanceKm:f2}");
        }
    }
}
