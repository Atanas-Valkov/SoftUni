using System;
using System.Transactions;

namespace P02E09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int storage = 0;
            int counterDays = 0;

            while (yield >= 100)
            {
                counterDays++;
                storage += yield - 26;
                yield -= 10;
            }

            if (yield < 100 && counterDays == 0)
            {
                Console.WriteLine($"{counterDays}");
                Console.WriteLine($"{storage}");

            }
            else
            {
                storage -= 26;
                Console.WriteLine($"{counterDays}");
                Console.WriteLine($"{storage}");
            }
        }
    }
}
