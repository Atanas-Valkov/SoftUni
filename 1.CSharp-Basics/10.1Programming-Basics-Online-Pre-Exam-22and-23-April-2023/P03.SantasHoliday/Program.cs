using System;

namespace P03.SantasHoliday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string typeResidence = Console.ReadLine();
            string rate = Console.ReadLine();

            double roomForOnePerson = 18;
            double apartment = 25;
            double presidentApartment = 35;

            double totalPrice = 0;

            if (typeResidence == "room for one person")
            {
                if (days < 10)
                {
                    if (rate == "positive")
                    {
                        roomForOnePerson *= 1.25;
                    }
                    else if (rate == "negative")
                    {
                        roomForOnePerson *= 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    if (rate == "positive")
                    {
                        roomForOnePerson *= 1.25;
                    }
                    else if (rate == "negative")
                    {
                        roomForOnePerson *= 0.9;
                    }
                }
                if (days > 15)
                {
                    if (rate == "positive")
                    {
                        roomForOnePerson *= 1.25;
                    }
                    else if (rate == "negative")
                    {
                        roomForOnePerson *= 0.9;
                    }
                }
                totalPrice = days * roomForOnePerson;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (typeResidence == "apartment")
            {
                if (days < 10)
                {
                    apartment *= 0.7;
                    if (rate == "positive")
                    {
                        apartment *= 1.25;
                    }
                    else
                    {
                        apartment *= 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    apartment *= 0.65;
                    if (rate == "positive")
                    {
                        apartment *= 1.25;
                    }
                    else
                    {
                        apartment *= 0.9;
                    }
                }
                else if (days > 15)
                {
                    apartment *= 0.50;
                    if (rate == "positive")
                    {
                        apartment *= 1.25;
                    }
                    else
                    {
                        apartment *= 0.9;
                    }
                }
                totalPrice = days * apartment;
                Console.WriteLine($"{totalPrice:f2}");
            }
            else if (typeResidence == "president apartment")
            {
                if (days < 10)
                {
                    presidentApartment *= 0.9;
                    if (rate == "positive")
                    {
                        presidentApartment *= 1.25;
                    }
                    else
                    {
                        presidentApartment *= 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    presidentApartment *= 0.65;
                    if (rate == "positive")
                    {
                        presidentApartment *= 1.25;
                    }
                    else
                    {
                        presidentApartment *= 0.9;
                    }
                }
                else if (days > 15)
                {
                    presidentApartment *= 0.8;
                    if (rate == "positive")
                    {
                        presidentApartment *= 1.25;
                    }
                    else
                    {
                        presidentApartment *= 0.9;
                    }
                }
                totalPrice = days * presidentApartment;
                Console.WriteLine($"{totalPrice:f2}");
            }
        }
    }
}
