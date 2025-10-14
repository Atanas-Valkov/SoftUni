using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffee = new Coffee("Espresso", 100);
            Console.WriteLine(coffee.Milliliters);

            Tea tea = new Tea("GreenTea", 2.5m, 300);
            Console.WriteLine(tea.Milliliters);

            Fish fish = new Fish("Salmon", 9.50m);
            Console.WriteLine(fish.Grams);

            Cake cake = new Cake("ChocolateCake");
            Console.WriteLine(cake.Grams);

            Soup soup = new Soup("ChickenSoup", 5.50m, 150);
            Console.WriteLine(soup.Name);
        }
    }
}