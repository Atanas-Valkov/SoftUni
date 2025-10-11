using System;

namespace P03L08.CinemaTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = Console.ReadLine();
            int ticketPrice = 0;

            if (dayOfWeek == "Monday")
            {
                ticketPrice = 12;
                Console.WriteLine(ticketPrice);

            }
            else if (dayOfWeek == "Tuesday")
            {
                ticketPrice = 12;
                Console.WriteLine(ticketPrice);
            }
            else if (dayOfWeek == "Wednesday")
            {
                ticketPrice = 14;
                Console.WriteLine(ticketPrice);
            }
            else if (dayOfWeek == "Thursday")
            {
                ticketPrice = 14;
                Console.WriteLine(ticketPrice);
            }
            else if (dayOfWeek == "Friday")
            {
                ticketPrice = 12;
                Console.WriteLine(ticketPrice);
            }
            else if (dayOfWeek == "Saturday")
            {
                ticketPrice = 16;
                Console.WriteLine(ticketPrice);
            }
            else if (dayOfWeek == "Sunday")
            {
                ticketPrice = 16;
                Console.WriteLine(ticketPrice);
            }
    }
}
