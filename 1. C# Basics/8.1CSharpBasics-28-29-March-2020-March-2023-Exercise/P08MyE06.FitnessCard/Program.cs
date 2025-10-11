using System;
using System.Runtime.CompilerServices;

namespace P08MyE06.FitnessCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double availableSum = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double cardPrice = 0;
            if (gender == "m")
            {
                if (sport == "Gym")
                {
                    cardPrice = 42;
                }
                else if (sport == "Boxing")
                {
                    cardPrice = 41;
                }
                else if (sport == "Yoga")
                {
                    cardPrice = 45;
                }
                else if (sport == "Zumba")
                {
                    cardPrice = 34;
                }
                else if (sport == "Dances")
                {
                    cardPrice = 51;
                }
                else if (sport == "Pilates")
                {
                    cardPrice = 39;
                }
            }
            else if (gender == "f")
            {
                if (sport == "Gym")
                {
                    cardPrice = 35;
                }
                else if (sport == "Boxing")
                {
                    cardPrice = 37;
                }
                else if (sport == "Yoga")
                {
                    cardPrice = 42;
                }
                else if (sport == "Zumba")
                {
                    cardPrice = 31;
                }
                else if (sport == "Dances")
                {
                    cardPrice = 53;
                }
                else if (sport == "Pilates")
                {
                    cardPrice = 37;
                }
            }
            if (age<=19)
            {
                cardPrice *= 0.8;

                if (availableSum>=cardPrice)
                {
                    Console.WriteLine($"You purchased a 1 month pass for {sport}.");
                }
                else if (availableSum < cardPrice)
                {
                    Console.WriteLine($"You don't have enough money! You need ${(cardPrice - availableSum):f2} more.");
                }
            }
            else if (age>19 )
            {
                if (availableSum >= cardPrice)
                {
                    Console.WriteLine($"You purchased a 1 month pass for {sport}.");
                }
                else if (availableSum < cardPrice)
                {
                    Console.WriteLine($"You don't have enough money! You need ${(cardPrice - availableSum):f2} more.");
                }
            }
        }
    }
}
