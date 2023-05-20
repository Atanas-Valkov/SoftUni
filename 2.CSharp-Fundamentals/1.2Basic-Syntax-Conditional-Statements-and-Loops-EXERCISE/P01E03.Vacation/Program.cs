using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Xml.Schema;

namespace P01E03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int .Parse(Console.ReadLine()); 
            string typeOfGroup = Console.ReadLine();   
            string day = Console.ReadLine();

            double ticketPrice = 0;
            double totalPrice = 0;
            
            if (typeOfGroup == "Students")
            {
                if (day == "Friday")
                {
                    ticketPrice = 8.45;
                }
                else if (day == "Saturday")
                {
                    ticketPrice = 9.80;
                }
                else if (day == "Sunday")
                {
                    ticketPrice = 10.46;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (day == "Friday")
                {
                    ticketPrice = 10.90;
                }
                else if (day == "Saturday")
                {
                    ticketPrice = 15.60;
                }
                else if (day == "Sunday")
                {
                    ticketPrice = 16;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (day == "Friday")
                {
                    ticketPrice = 15;
                }
                else if (day == "Saturday")
                {
                    ticketPrice = 20;
                }
                else if (day == "Sunday")
                {
                    ticketPrice = 22.5;
                }
            }
            if (countOfPeople >= 30 && typeOfGroup == "Students")
            {
                ticketPrice *= 0.85;
            }
            else if (countOfPeople > 100 && typeOfGroup == "Business")
            {
                countOfPeople -= 10;
            }
            else if (countOfPeople>= 10 && countOfPeople<20 && typeOfGroup == "Regular")
            {
                ticketPrice *= 0.95;
            }
                
            totalPrice = countOfPeople * ticketPrice;
               
     
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
