using System;
using System.Runtime.ConstrainedExecution;

namespace P08MyE03.CatWalking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesWalk = int.Parse(Console.ReadLine());
            int numOfWalks = int.Parse(Console.ReadLine());
            int caloriesPerDay = int.Parse(Console.ReadLine());

            int totalMinPerDay = minutesWalk * numOfWalks;
            int totalBurnCaloriesPerDay = totalMinPerDay * 5;
            double burnCalory = caloriesPerDay * 0.5;
            if (totalBurnCaloriesPerDay >= burnCalory)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalBurnCaloriesPerDay}.");
            }
            else if (totalBurnCaloriesPerDay <= burnCalory)
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalBurnCaloriesPerDay}.");
            }

           
        }
    }
}
