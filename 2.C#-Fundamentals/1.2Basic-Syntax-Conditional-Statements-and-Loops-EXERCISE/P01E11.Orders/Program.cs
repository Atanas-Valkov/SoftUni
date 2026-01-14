using System;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace P01E11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOrders = int.Parse(Console.ReadLine());
            double orderPrice = 0;
            double totalPrice = 0;
            for (int i = 1; i <= countOrders; i++)
            {
               double PricePerCapsule = double.Parse(Console.ReadLine());
               
               int days = int.Parse(Console.ReadLine());
               int capsulesCount = int.Parse(Console.ReadLine());

               orderPrice = days * capsulesCount * PricePerCapsule;
               totalPrice += orderPrice;
               Console.WriteLine($"The price for the coffee is: ${orderPrice:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
