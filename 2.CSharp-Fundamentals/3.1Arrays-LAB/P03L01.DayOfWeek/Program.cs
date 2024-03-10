

using System;
using System.Runtime.Serialization.Formatters;

namespace P01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (input < 1 || input >= 8)
            {
                Console.WriteLine($"Invalid day!");
            }
            else
            {
                Console.WriteLine(days[input - 1]);
            }
        }
    }
}

