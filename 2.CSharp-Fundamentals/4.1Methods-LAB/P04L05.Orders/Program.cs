using System.Diagnostics;
using System.Net.Http.Headers;

namespace P04L05.Orders
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int qty = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            double productPrice = 0;

       //   if (product == "coffee")
       //   {
       //       productPrice = 1.5;
       //   }
       //   else if (product == "water")
       //   {
       //       productPrice = 1.0;
       //   }
       //   else if (product == "coke")
       //   {
       //       productPrice = 1.40;
       //   }
       //   else if (product == "snacks")
       //   {
       //       productPrice = 2.00;
       //   }
            CalculatesTheTotalPriceOfOrder(product, qty, productPrice);

            PrintTotalPrice(productPrice, qty, totalPrice);
        }
  static void CalculatesTheTotalPriceOfOrder(string product, int qty,double productPrice)
  {
      if (product == "coffee")
      {
          productPrice = 1.5;
      }
      else if (product == "water")
      {
          productPrice = 1.0;
      }
      else if (product == "coke")
      {
          productPrice = 1.40;
      }
      else if (product == "snacks")
      {
          productPrice = 2.00;
      }


  }

        static double PrintTotalPrice(double productPrice, int qty,double totalPrice)
        {
            totalPrice= qty * productPrice;
            Console.WriteLine($"{totalPrice:F2}");

        }



        
    }
}