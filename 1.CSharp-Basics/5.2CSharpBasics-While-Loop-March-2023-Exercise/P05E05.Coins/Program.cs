using System;
using System.Diagnostics.Tracing;
using System.Security.Authentication.ExtendedProtection;

namespace P05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumToReturn = double.Parse(Console.ReadLine()) * 100;

            int counter = 0;

            while (sumToReturn>=0) 
            {
                if (sumToReturn >= 200)
                {
                    sumToReturn -= 200;
                }
                else if (sumToReturn>=100)
                {
                    sumToReturn -= 100;

                }
                else if (sumToReturn >= 50)
                {
                    sumToReturn -= 50;

                }
                else if (sumToReturn >= 20)
                {
                    sumToReturn -= 20;

                }
                else if (sumToReturn >= 10)
                {
                    sumToReturn -= 10;
                }
                else if (sumToReturn >= 5)
                {
                    sumToReturn -= 5;
                }
                else if (sumToReturn >= 2)
                {
                    sumToReturn -= 2;

                }
                else if (sumToReturn>=1)
                {
                    sumToReturn = 0;
                }
                else
                {
                    break;  
                }
                counter++;  
            }
            Console.WriteLine(counter);
        }
    }
}
