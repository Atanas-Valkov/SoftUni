using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace P03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"Roses", "Dahlias", "Tulips", "Narcissus", "Gladiolus"
            string typeFlowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double priceRoses = 5;
            double priceDahlias = 3.80;
            double priceTulips = 2.80;
            double priceNarcissus = 3;
            double priceGladiolus = 2.50;


            double totalPrice = 0;

            if (typeFlowers == "Roses")
            {
                if (numFlowers > 80)
                {
                    priceRoses *= 0.90;
                }
                totalPrice = numFlowers * priceRoses;
            }
            else if (typeFlowers == "Dahlias")
            {
                if (numFlowers > 90)
                {
                    priceDahlias *= 0.85;
                }

                totalPrice = numFlowers * priceDahlias;

            }
            else if (typeFlowers == "Tulips")
            {
                if (numFlowers > 80)
                {
                    priceTulips *= 0.85;
                }

                totalPrice = numFlowers * priceTulips;

            }
            else if (typeFlowers == "Narcissus")
            {
                if (numFlowers < 120)
                {
                    priceNarcissus *= 1.15;
                }
                totalPrice = numFlowers * priceNarcissus;


            }
            else if(typeFlowers == "Gladiolus")
            {
                if (numFlowers < 80)
                {
                    priceGladiolus *= 1.2;
                }             
                totalPrice = numFlowers * priceGladiolus;
            }
            if (budget>= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {typeFlowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice-budget:f2} leva more.");
            }

        }

    }
}
