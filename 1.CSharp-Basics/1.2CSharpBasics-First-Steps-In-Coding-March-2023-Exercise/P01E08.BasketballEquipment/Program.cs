using System;

namespace P08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualTrainingFee = int.Parse(Console.ReadLine());
            double totalNeededMoney = 0;
            double priceSneakers = annualTrainingFee * 0.6;
            double priceClothes = priceSneakers - (priceSneakers * 0.2);
            double priceBalls = priceClothes * 0.25;
            double priceAccessories = priceBalls * 0.2;


            totalNeededMoney= priceSneakers + priceClothes+priceBalls+priceAccessories + annualTrainingFee;
            Console.WriteLine(totalNeededMoney);



        }
    }
}
