using System;

namespace demooooo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenNumber = int.Parse(Console.ReadLine());

            int boatRentSpring = 3000;
            int boatRentSummerAutumn = 4200;
            int boatRentWinter = 2600;

            double shipRent = 0;
            double moneyLeft = Math.Abs(groupBudget - shipRent);

            if (season == "Spring" || season == "Summer" || season == "Autumn" || season == "Winter")

                if (fishermenNumber <= 6)
                {
                    shipRent -= shipRent * 0.10;
                }
                else if (fishermenNumber <= 7 && fishermenNumber <= 11)
                {
                    shipRent -= shipRent * 0.15;
                }
                else
                {
                    shipRent -= shipRent * 0.25;
                }
            if (fishermenNumber % 2 == 0 && season != "Autumn")
            {
                shipRent -= shipRent * 0.05;
            }

            if (groupBudget > shipRent)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyLeft:F2} leva.");

            }

        }
    }

}
