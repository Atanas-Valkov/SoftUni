using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace P01E07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coins = "";
            double totalMoney = 0;

            while ((coins = Console.ReadLine()) != "Start")
            {
                double currentCoin = double.Parse(coins);
                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    totalMoney += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
                if (coins == "Start")
                {
                    break;
                }
            }

            string product = "";
            double productPrice = 0;
            while ((product = Console.ReadLine()) != "End")
            {
                if (product == "Nuts")
                {
                    productPrice = 2.0;
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {
                    productPrice = 0.7;
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased water");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (product == "Soda")
                {
                    productPrice = 0.8;
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {
                    productPrice = 1.0;
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid product");
                }
            }
            Console.WriteLine($"Change: {totalMoney:F2}");
        }
    }
}
