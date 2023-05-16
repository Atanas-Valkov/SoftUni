using System;

namespace P01L07.TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;
            if (age>=0 && 18>=age)
            {
                if (day == "Weekday")
                {
                    ticketPrice = 12;
                }
                else if (day == "Weekend")
                {
                    ticketPrice = 15;
                }
                else if (day == "Holiday")
                {
                    ticketPrice = 5;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else if (age>18 && age<=64)
            {
                if (day == "Weekday")
                {
                    ticketPrice = 18;
                }
                else if (day == "Weekend")
                {
                    ticketPrice = 20;
                }
                else if (day == "Holiday")
                {
                    ticketPrice = 12;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else if(age > 64 && age <= 122)
            {
                if (day == "Weekday")
                {
                    ticketPrice = 12;
                }
                else if (day == "Weekend")
                {
                    ticketPrice = 15;
                }
                else if (day == "Holiday")
                {
                    ticketPrice = 10;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
