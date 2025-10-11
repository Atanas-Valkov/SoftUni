using System;

namespace P05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string  destination = string.Empty;
            string  typeOfRest = string.Empty;

            if ((budget <= 100) && (season == "summer"))
            {
                destination = "Bulgaria";
                typeOfRest = "Camp";
                budget = budget * 0.3;
            }
            else if ((budget<=1000)&& (season == "summer"))
            {
                destination = "Balkans";
                typeOfRest = "Camp";
                budget = budget * 0.4;
            }
            else if((budget>1000)&& (season == "summer"))
            {
                destination = "Europe";
                typeOfRest = "Hotel";
                budget = budget * 0.9;
            }
            

            if ((budget <= 100) && (season == "winter"))
            {
                destination = "Bulgaria";
                typeOfRest = "Hotel";
                budget = budget * 0.7;
            }
            else if ((budget>100) && (budget <= 1000)&&(season == "winter"))
            {
                destination = "Balkans";
                typeOfRest = "Hotel";
                budget = budget * 0.8;
            }
            else if ((budget > 1000)&& (season == "winter"))
            {
                destination = "Europe";
                typeOfRest = "Hotel";
                budget = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfRest} - {budget:f2}");
        }
    }
}
