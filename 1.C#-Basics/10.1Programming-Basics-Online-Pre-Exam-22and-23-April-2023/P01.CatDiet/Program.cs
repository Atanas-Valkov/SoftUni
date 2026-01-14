using System;

namespace P01.CatDiet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fat =double.Parse(Console.ReadLine());
            double proteins = double.Parse(Console.ReadLine());
            double carbohydrates = double.Parse(Console.ReadLine());
            double totalCalories= double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());

            double totalGramsFat = totalCalories * (fat / 100)/9;
            double totalGramsProteins = totalCalories * (proteins / 100) / 4;
            double totalGramsCarbohydrates = totalCalories * (carbohydrates / 100) / 4;

            double totalGramsFood = totalGramsFat + totalGramsProteins + totalGramsCarbohydrates;
            double caloriesForOneGram = totalCalories / totalGramsFood;
            double lastCalories = caloriesForOneGram * ((100 - water) / 100);

            Console.WriteLine($"{lastCalories:f4}");
        }
    }
}
