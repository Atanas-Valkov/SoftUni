using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;

namespace P04L05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            OrdersCalculation(product, quantity);
        }

        private static void OrdersCalculation(string product, double quantity)
        {
            double price = 0;
            if (product == "coffee")
            {
                price = quantity * 1.5;
            }
            else if (product == "water")
            {
                price = quantity * 1;
            }
            else if (product == "coke")
            {
                price = quantity * 1.4;
            }
            else if (product == "snacks")
            {
                price = quantity * 2;
            }
            Print(price);
        }
        private static void Print(double quantity)
        {
            Console.WriteLine($"{quantity:F2}");
        }
    }
}