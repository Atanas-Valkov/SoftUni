using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace P06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie; 
            int studentCounter = 0;
            int standardCounter = 0;
            int kidCounter = 0;
           
            while ((nameOfMovie = Console.ReadLine()) != "Finish")
            {
                int availableTickets = int.Parse(Console.ReadLine());
                int ticketsSells = 0;

                while (availableTickets > ticketsSells)
                {
                    string typeOfTickets = Console.ReadLine();

                    if (typeOfTickets == "End")
                    {
                        break;
                    }
                    
                    
                    if (typeOfTickets == "student")
                    {
                        studentCounter++;
                    }
                    else if (typeOfTickets == "standard")
                    {
                        standardCounter++;
                    }
                    else if (typeOfTickets == "kid")
                    {
                        kidCounter++;
                    }

                    ticketsSells++;
                }
               double hallFull = (double)ticketsSells / availableTickets  *100;
                Console.WriteLine($"{nameOfMovie} - {hallFull:f2}% full.");
                


            }
           int totalTickets = studentCounter + standardCounter + kidCounter;
           double averageStudentTickets = (double)studentCounter / totalTickets * 100;
           double averageStandardTickets = (double)standardCounter / totalTickets * 100;
           double averageKidTickets = (double)kidCounter / totalTickets * 100;
           
           Console.WriteLine($"Total tickets: {totalTickets}");
           Console.WriteLine($"{averageStudentTickets:f2}% student tickets.");
           Console.WriteLine($"{averageStandardTickets:f2}% standard tickets.");
           Console.WriteLine($"{averageKidTickets:f2}% kids tickets.");
        }
    }
}
