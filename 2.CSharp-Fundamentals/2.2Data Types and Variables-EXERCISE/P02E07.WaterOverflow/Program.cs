using System;

namespace P02E07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersFollow = int.Parse(Console.ReadLine());
            int tankCapacity = 255;

            for (int i = 1; i <= numbersFollow; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (tankCapacity < liters)
                {
                    Console.WriteLine($"Insufficient capacity!");
                    continue;
                }
                tankCapacity -= liters;
            }
            Console.WriteLine($"{255 - tankCapacity}");
        }
    }
}
