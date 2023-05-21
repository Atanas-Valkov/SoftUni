using System;

namespace P02E08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int numberOfKegs = int.Parse(Console.ReadLine());
            double biggestVolume = 0;
            string biggestKeg = "";
            for (int i = 1; i <=numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                
                double currentVolume = Math.PI * Math.Pow(radius, 2) * height;
                string currentModel = model;
                if (currentVolume > biggestVolume)
                {
                    biggestKeg = currentModel;
                    biggestVolume = currentVolume;
                }

            }
            Console.WriteLine(biggestKeg);
        }
    }
}
