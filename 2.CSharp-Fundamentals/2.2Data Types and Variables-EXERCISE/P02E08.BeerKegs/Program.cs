using System;

namespace P02E08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double biggeseVolume = 0;
            string biggestKegName = "";
            for (int i = 1; i <= input; i++)
            {
                string modelKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double currentVolume = Math.PI * Math.Pow(radius, 2) * height;
                string currentModelKeg = modelKeg;
                if (currentVolume > biggeseVolume)
                {
                    biggeseVolume = currentVolume;
                    biggestKegName=currentModelKeg;
                }
            }
            Console.WriteLine($"{biggestKegName}");
        }
    }
}
