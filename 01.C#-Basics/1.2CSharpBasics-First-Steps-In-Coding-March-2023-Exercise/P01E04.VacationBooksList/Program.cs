using System;

namespace P04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPage = int.Parse(Console.ReadLine());
            int pagePerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int sum = (numPage / pagePerHour) / days;

            Console.WriteLine(sum);


        }
    }
}
