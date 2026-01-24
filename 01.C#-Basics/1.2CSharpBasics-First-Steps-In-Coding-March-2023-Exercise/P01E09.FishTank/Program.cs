using System;

namespace P09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());  
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage= double.Parse(Console.ReadLine());

            double volumeTank = length * width * height;
            volumeTank = volumeTank / 1000;
            percentage = percentage / 100;

            volumeTank = volumeTank * (1 - percentage);

                Console.WriteLine(volumeTank);
        }
    }
}
