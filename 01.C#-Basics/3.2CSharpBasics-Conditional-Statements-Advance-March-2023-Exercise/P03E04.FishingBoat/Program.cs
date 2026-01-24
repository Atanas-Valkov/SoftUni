using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace P04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string  season = Console.ReadLine();    
            int countFishers = int.Parse(Console.ReadLine());


            double rentShip = 0;

            switch (season) 
            {
                case "Spring":
                    rentShip = 3000;
                    break;
                case "Summer":
                    rentShip = 4200;
                    break;
                case "Autumn":
                    rentShip = 4200;
                    break;
                default:
                    rentShip = 2600;
                    break;
            }

            if (countFishers <= 6) 
            {
                rentShip *= 0.9;
            }
            else if (countFishers<=11)
            {
                rentShip *= 0.85;
            }
            else
            {
                rentShip *= 0.75;
            }

            if ((countFishers % 2 == 0) && (season != "Autumn"))
            {
                rentShip *= 0.95;
            }
            if (budget>= rentShip)
            {
                Console.WriteLine($"Yes! You have {(budget-rentShip):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - rentShip):f2} leva.");

            }

        }
    }
}
