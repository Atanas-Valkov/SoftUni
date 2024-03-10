using System;

namespace P01L04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes<=29)
            {
                minutes += 30;
            }
            else
            {
                minutes = (minutes + 30) - 60;
                hours++;
            }
            if (hours>23)
            {
                hours = 0;
            }
            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
