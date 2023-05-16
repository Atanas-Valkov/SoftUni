using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace P01E07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coints = "";
             decimal totallMoney = 0;
            
              while ((coints = Console.ReadLine())  != "Start")
              {
                decimal currentCoint = decimal.Parse(coints);
                if (currentCoint == 0.1m)
                {
                    totallMoney += currentCoint;
                }
                else if (currentCoint == 0.2m)
                {
                    totallMoney += currentCoint;
                }
                else if (currentCoint == 0.5m)
                {
                    totallMoney += currentCoint;
                }
                else if (currentCoint == 1m)
                {
                    totallMoney += currentCoint;
                }
                else if (currentCoint == 2m)
                {
                    totallMoney += currentCoint;
                }
                else 
                {
                    Console.WriteLine($"Cannot accept {currentCoint}");
                    continue;
                }
                if (coints == "Start")
                {
                    break;
                }                
              }
            string products = "";
            decimal totalProductsMoney = 0;
                decimal productPrice = 0;
            while ((products = Console.ReadLine()) != "End")
            {
                if (products == "Nuts")
                {
                    productPrice = 2.0m;
                }
                else if (products == "Water")
                {
                    productPrice = 0.7m;
                }
                else if (products == "Crisps")
                {
                    productPrice = 1.5m;
                }
                else if (products == "Soda")
                {
                    productPrice = 0.8m;
                }
                else if (products == "Coke")
                {
                    productPrice = 1m;
                }
                else
                {
                    Console.WriteLine($"Invalid product");
                    continue;
                }
                if (totallMoney>=productPrice)
                {
                    totallMoney -= productPrice;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else if (totallMoney < productPrice)
                {
                    Console.WriteLine($"Sorry, not enough money");                 
                }
            }
             if (products == "End")
             {            
                Console.WriteLine($"Change: {totallMoney:f2}");
             }

        }
    }
}
