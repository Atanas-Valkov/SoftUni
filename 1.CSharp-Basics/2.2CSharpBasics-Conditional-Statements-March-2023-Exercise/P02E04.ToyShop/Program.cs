using System;
using System.Transactions;

namespace P04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double tripPrice = double.Parse(Console.ReadLine()); 

            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double money = puzzles * 2.60 + dolls * 3.00 + bears * 4.10 + minions * 8.20 + trucks * 2;
            
            int toysQuantity = puzzles + dolls  + bears + minions + trucks;

            if (toysQuantity>=50)
            {
                money -= money * 0.25;
            }
            money -= money * 0.1;

            if (tripPrice <= money)
            {
                Console.WriteLine($"Yes! {money - tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(tripPrice - money):f2} lv needed.");





            }

        }
    }
}
