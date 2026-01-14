using System;

namespace P05.GodzillavVs.Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int actorsQuantity = int.Parse(Console.ReadLine());
            double clothingPricePerPerson = double.Parse(Console.ReadLine());

            double decore = budget * 0.10;

            if (actorsQuantity> 150)
            {
                clothingPricePerPerson -= clothingPricePerPerson * 0.10;
            }
           
            double totalPriceCloths = actorsQuantity * clothingPricePerPerson;

            double totalMovie = decore + totalPriceCloths;

            double remnant = budget - totalMovie;

            if (budget >= totalMovie) 
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {remnant:f2} leva left. ");
            }
            else 
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(remnant):f2} leva more.");
            }


        }
    }
}
