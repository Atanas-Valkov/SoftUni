using System;

namespace P07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int qtyChickenMenu = int.Parse(Console.ReadLine());
            int qtyfishMenu = int.Parse(Console.ReadLine());
            int qtyvegMenu = int.Parse(Console.ReadLine());

            double priceChickenMenu = 10.35;
            double priceFishMenu = 12.40;
            double priceVegMenu =  8.15;

            double totalPriceMenu = (qtyChickenMenu * priceChickenMenu) + (qtyfishMenu * priceFishMenu) + (qtyvegMenu * priceVegMenu);

            totalPriceMenu = (totalPriceMenu * 0.2) + totalPriceMenu + 2.5;

            Console.WriteLine(totalPriceMenu);




        }
    }
}
