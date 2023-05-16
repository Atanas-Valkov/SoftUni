using System;

namespace P06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double plastic = double.Parse(Console.ReadLine()); 
            double paint = double.Parse(Console.ReadLine());    
            double thinner = double.Parse(Console.ReadLine());
            double Hours = double.Parse(Console.ReadLine());

            double pricePlastic = 1.5;
            double pricePaint = 14.50;
            double thinnerPrice = 5.00;
            double pricePerHour = 0;

            double totalplastic = (plastic + 2) * pricePlastic;
            double totalPaint = (paint * 1.1) * pricePaint;

            double priceMaterials = totalplastic + totalPaint + thinner * thinnerPrice + 0.4;

            pricePerHour = (priceMaterials * 0.3) * Hours;

            Console.WriteLine(priceMaterials + pricePerHour);



        }
    }
}
