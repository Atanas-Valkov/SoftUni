using System;
using System.Transactions;

namespace P02E09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int yieldDrops = 0;
            
            int daysCounter = 0;
            while (startingYield >= 100) 
            { 
                daysCounter++;
                yieldDrops += startingYield;

                startingYield -= 10;
                yieldDrops -= 26;
            }
            if (startingYield < 100)
            {
                yieldDrops -= 26;

            }
            if (yieldDrops < 0)
            {
                yieldDrops = 0;
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(yieldDrops);

        }
    }
}
