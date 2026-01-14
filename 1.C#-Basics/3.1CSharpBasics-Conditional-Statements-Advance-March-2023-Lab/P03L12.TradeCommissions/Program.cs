using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace P03L12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());
            double comissiong = 0;

            if (city == "Sofia")
            {
                if (sells >= 0 && sells <= 500)
                {
                    comissiong = sells * 0.05;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (500<sells && sells<=1000 )
                { 
                    comissiong = sells * 0.07;
                    Console.WriteLine($"{comissiong:f2}");

                }
                else if(1000<sells && sells<=10000)
                {
                    comissiong = sells * 0.08;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells>10000)
                {
                    comissiong = sells * 0.12;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells<0)
                {
                    Console.WriteLine("error");
                }

            }
            else if (city == "Varna")
            {
                if(sells >= 0 && sells <= 500)
                {
                    comissiong = sells * 0.045;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (500 < sells && sells <= 1000)
                {
                    comissiong = sells * 0.075;
                    Console.WriteLine($"{comissiong:f2}");

                }
                else if (1000 < sells && sells <= 10000)
                {
                    comissiong = sells * 0.1;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells > 10000)
                {
                    comissiong = sells * 0.13;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells < 0)
                {
                    Console.WriteLine("error");
                }

            }
            else if (city == "Plovdiv")
            {
                if (sells >= 0 && sells <= 500)
                {
                    comissiong = sells * 0.055;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (500 < sells && sells <= 1000)
                {
                    comissiong = sells * 0.08;
                    Console.WriteLine($"{comissiong:f2}");

                }
                else if (1000 < sells && sells <= 10000)
                {
                    comissiong = sells * 0.12;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells > 10000)
                {
                    comissiong = sells * 0.145;
                    Console.WriteLine($"{comissiong:f2}");
                }
                else if (sells < 0)
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
