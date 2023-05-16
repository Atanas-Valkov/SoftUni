using System;
using System.Threading;
using System.Transactions;

namespace P05E03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyTrip = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            string input;
            double money = 0;

            int totalPassDays = 0;
            int spendCounter = 0;

            while (currentMoney < moneyTrip)
            {
                input = Console.ReadLine();
                money = double.Parse(Console.ReadLine());

                totalPassDays++;

                if (input == "spend")
                {
                    spendCounter++;

                    if (spendCounter == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine(totalPassDays);
                        break;
                    }
                    currentMoney -= money;

                    if (currentMoney < 0)
                    {
                        currentMoney = 0;

                    }

                }
                else
                {
                    currentMoney += money;
                    spendCounter = 0;
                }

            }


            if (currentMoney >= moneyTrip)
            {
                Console.WriteLine($"You saved the money for {totalPassDays} days.");
            }
        }

    }
}
