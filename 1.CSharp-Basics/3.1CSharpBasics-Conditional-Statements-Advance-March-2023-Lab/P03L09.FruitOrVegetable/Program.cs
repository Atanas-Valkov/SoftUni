using System;

namespace P03L09.FruitOrVegetable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string products = Console.ReadLine();

            if (products == "banana" || products == "apple" || products == "kiwi" || products == "cherry" || products == "lemon" || products == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (products == "tomato" || products == "cucumber" || products == "pepper" || products == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }    
        }
    }
}
