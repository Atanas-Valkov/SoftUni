using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace P07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpu = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            int gpuPrice = gpu * 250;
            double cpuPrice = gpuPrice * 0.35;
            double ramPrice = gpuPrice * 0.10;

            double totalPrice = gpuPrice + (cpu * cpuPrice) + (ram * ramPrice);

            if (gpu>cpu)
            {
                totalPrice = totalPrice-totalPrice * 0.15;
            }
    
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {Math.Abs(budget- totalPrice):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalPrice - budget):f2} leva more!");
            }



        }
    }
}
