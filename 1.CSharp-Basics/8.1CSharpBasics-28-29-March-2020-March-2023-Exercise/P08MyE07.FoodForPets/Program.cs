using System;

namespace P08MyE07.FoodForPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalAmountOfFood = double.Parse(Console.ReadLine());
            double sum;
            double sumFoodDog = 0;
            double sumFoodCat = 0;
            double biscuits = 0;
            for (int i = 1; i <=days; i++)
            {
                double dogFood = double.Parse(Console.ReadLine());
                double catFood = double.Parse(Console.ReadLine());
                sumFoodDog += dogFood;
                sumFoodCat += catFood;
                if (i % 3 == 0) 
                {
                   double currentBiscuits = (dogFood + catFood) * 0.1;
                    biscuits += currentBiscuits;
                } 
            }
            double eatenFood = sumFoodDog + sumFoodCat;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{(eatenFood/totalAmountOfFood)*100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(sumFoodDog/eatenFood)*100:f2}% eaten from the dog.");
            Console.WriteLine($"{(sumFoodCat/eatenFood)*100:f2}% eaten from the cat.");
        }
    }
}
