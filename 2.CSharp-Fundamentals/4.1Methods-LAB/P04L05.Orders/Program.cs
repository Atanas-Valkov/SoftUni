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
            double totalSum = 0;
            double price = 0;

            TotalPrice(product, quantity, totalSum, price);
        }

        static void TotalPrice(string product, double quantity, double totalSum, double price)
        {
            if (product == "coffee")
            {
                price = 1.5;

            }
            else if (product == "water")
            {
                price = 1.00;

            }
            else if (product == "coke")
            {
                price = 1.40;
            }
            else if (product == "snacks")
            {
                price = 2.00;
            }
            totalSum = quantity * price;
            Console.WriteLine($"{totalSum:F2}");
        }
    }
}