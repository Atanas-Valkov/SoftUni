using System;

namespace P02E07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            ushort litersCounter = 0;
            for (int i = 1; i <=n ; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine()) ;
                ushort currentLiters = liters;
                if (litersCounter + currentLiters > 255)
                {
                    Console.WriteLine($"Insufficient capacity!");
                }
                else
                {
                        
                    litersCounter += liters;
                }
            }

            Console.WriteLine(litersCounter);
        }
    }
}
