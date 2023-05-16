using System;

namespace P09MyE02_18_19Juy20_.AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOver20kg = double.Parse(Console.ReadLine());
            double kgBaggage = double.Parse(Console.ReadLine());
            double daysUntilTravel = double.Parse(Console.ReadLine());
            double numBaggage = double.Parse(Console.ReadLine());
            double priceOfBaggage = 0;
            if (kgBaggage<10)
            {
                priceOfBaggage = priceOver20kg * 0.2;
            }
            else if (kgBaggage>=10 && kgBaggage<=20)
            {
                priceOfBaggage = priceOver20kg * 0.5;
            }
            else if (kgBaggage>20)
            {
                priceOfBaggage = priceOver20kg; 
            }

            if (daysUntilTravel > 30)
            {
                priceOfBaggage *= 1.1;
            }
            else if (daysUntilTravel <= 30 && daysUntilTravel>=7)
            {
                priceOfBaggage *= 1.15;
            }
            else if (daysUntilTravel<7)
            { 
                priceOfBaggage *= 1.4;
            }
            double totalPrice = numBaggage * priceOfBaggage;

            Console.WriteLine($" The total price of bags is: {totalPrice:f2} lv.");

        }

    }
}
