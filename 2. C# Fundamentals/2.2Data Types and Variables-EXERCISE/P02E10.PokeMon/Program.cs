using System;

namespace P02E10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine()); 
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());
            int originalPowerN = powerN;
            int counter = 0;
            while (powerN >= distanceM)
            {
                if (originalPowerN * 0.5 == powerN)
                {
                    if (exhaustionFactorY != 0 )
                    {
                        powerN /= exhaustionFactorY;
                        continue;
                    }
                }
                powerN -=distanceM;
                counter++;
            }

            Console.WriteLine($"{powerN}");
            Console.WriteLine($"{counter}");
        }
    }
}
