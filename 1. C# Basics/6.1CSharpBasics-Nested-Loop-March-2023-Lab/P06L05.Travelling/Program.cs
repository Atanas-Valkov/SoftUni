using System;
using System.Diagnostics.CodeAnalysis;

namespace P05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = "";
            
            
            while ((destination = Console.ReadLine()) != "End") 
            {
                double savedMoney = 0;
                  double budget = double.Parse(Console.ReadLine());

                while (savedMoney < budget)
                {
                    savedMoney += double.Parse(Console.ReadLine());
                    
                }
                Console.WriteLine($"Going to {destination}!");
            }


        }
    }
}
