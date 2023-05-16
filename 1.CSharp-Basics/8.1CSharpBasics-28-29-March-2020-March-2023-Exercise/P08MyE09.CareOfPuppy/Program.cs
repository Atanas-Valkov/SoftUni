using System;
using System.Runtime.CompilerServices;

namespace P08MyE09.CareOfPuppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine()) * 1000;
            string eatenFoodInGrams;
            int totaleEatenFoodInGrams = 0;

            while ((eatenFoodInGrams = Console.ReadLine()) != "Adopted") 
            { 
              int currentNumber = int.Parse(eatenFoodInGrams);

                totaleEatenFoodInGrams += currentNumber;
                
         
            }
            if (eatenFoodInGrams == "Adopted")
            {
                if (food >= totaleEatenFoodInGrams)
                {
                    Console.WriteLine($"Food is enough! Leftovers: {food - totaleEatenFoodInGrams} grams.");
                }
                else if (food <= totaleEatenFoodInGrams)
                {
                    Console.WriteLine($"Food is not enough. You need {totaleEatenFoodInGrams - food} grams more.");
                }
                
            }


        }
    }
}
