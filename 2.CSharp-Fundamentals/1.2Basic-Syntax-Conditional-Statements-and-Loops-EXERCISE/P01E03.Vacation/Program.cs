using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Xml.Schema;

namespace P01E03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();

            double totalPrice = 0;
            double pricePerPerson = 0;

            if (dayOfTheWeek == "Friday")
            {
                if (typeOfGroup == "Students")
                {
                    pricePerPerson = 8.45;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    pricePerPerson = 10.90;
                    totalPrice = countOfPeople * pricePerPerson;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                        totalPrice = countOfPeople * pricePerPerson;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    pricePerPerson = 15;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }
            }
            else if (dayOfTheWeek == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    pricePerPerson = 9.80;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    pricePerPerson = 15.60;
                    totalPrice = countOfPeople * pricePerPerson;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                        totalPrice = countOfPeople * pricePerPerson;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    pricePerPerson = 20;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }
            }
            else if (dayOfTheWeek == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    pricePerPerson = 10.46;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    pricePerPerson = 16;
                    totalPrice = countOfPeople * pricePerPerson;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                        totalPrice = countOfPeople * pricePerPerson;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    pricePerPerson = 22.50;
                    totalPrice = countOfPeople * pricePerPerson;
                    totalPrice = countOfPeople * pricePerPerson;
                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
