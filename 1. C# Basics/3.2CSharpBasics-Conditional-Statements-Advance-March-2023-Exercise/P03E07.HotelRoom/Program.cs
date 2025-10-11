using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace P07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string month = Console.ReadLine();
           double numOfDays = double.Parse(Console.ReadLine());

            double priceApartment = 0;
            double priceStudio = 0;

            if (month == "May" || month == "October")
            {
                if (numOfDays<=7)
                {
                    priceStudio = 50;
                    priceApartment = 65;
                }
                else if (numOfDays > 7 && numOfDays <= 14) 
                {
                    priceStudio = 50;
                    priceApartment = 65;
                    priceStudio *= 0.95;
                }
                else if (numOfDays >= 15)
                {
                    priceStudio = 50;
                    priceApartment = 65;
                    priceStudio *= 0.70;
                    priceApartment *= 0.9;
                }  
            }
            else if (month == "June" || month == "September")
            {
                if (numOfDays<=7) 
                {
                    priceStudio = 75.20;
                    priceApartment = 68.70;                
                }
                else if (numOfDays > 7 && numOfDays <= 14)
                {
                    priceStudio = 75.20;
                    priceApartment = 68.70;
                }
                else if (numOfDays >= 15)
                {
                    priceStudio = 75.20;
                    priceApartment = 68.70;
                    priceStudio *= 0.8;
                    priceApartment *= 0.90;
                }

            }
            else if (month == "July" || month == "August")
            {
                if (numOfDays<=7)
                {
                    priceStudio = 76;
                    priceApartment = 77;

                }
                else if (numOfDays > 7 && numOfDays <= 14)
                {
                    priceStudio = 76;
                    priceApartment = 77;
                }
                else if (numOfDays >= 15)
                {
                    priceStudio = 76;
                    priceApartment = 77;
                    priceApartment *= 0.9;
                }

            }
            double totalPriceApartment = numOfDays * priceApartment;
            double totalPriceStudio = numOfDays * priceStudio;

            Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");

        }
    }
}
