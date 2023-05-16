using System;
using System.Reflection.PortableExecutable;

namespace P04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());  
            int toyPrice = int.Parse(Console.ReadLine());

            
            int totalMony = 0;
            for (int i = 1; i <= age ; i++)
            {
                
                if (i % 2 == 0)
                {
                    totalMony += i * 5 - 1;
                }
                else
                {
                    totalMony += toyPrice;
                }

               
            }
            if (washingMachinePrice<= totalMony)
            {
                Console.WriteLine($"Yes! {totalMony- washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(totalMony - washingMachinePrice):f2}");

            }
        }
    }
}
