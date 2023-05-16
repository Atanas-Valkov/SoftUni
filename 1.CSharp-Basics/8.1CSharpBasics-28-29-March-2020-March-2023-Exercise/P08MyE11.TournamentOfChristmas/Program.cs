using System;
using System.Runtime.CompilerServices;

namespace P08MyE11.TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            string sport;
            string result;
            //double dayBudget = 0;
            double totalBudget =0 ;
            int winCounter = 0;
            int winCounterday = 0;
            int loseCounter = 0;
            int loseCounterday = 0;
            for (int i = 1; i <= numberOfDays; i++)
            {
                double dayBudget = 0;
                while ((sport = Console.ReadLine()) != "Finish")
                {                    
                    result = Console.ReadLine();
                    if (result == "win")
                    {                      
                        dayBudget += 20;
                        winCounter++;
                        winCounterday++;
                    }
                    else if (result == "lose")
                    {
                        loseCounter++;
                        loseCounterday++;
                    }

                }

                if (winCounterday > loseCounterday)
                {
                    dayBudget *= 1.1;
                    totalBudget += dayBudget;
                }
                else
                {
                    totalBudget += dayBudget;
                    
                }
                winCounterday = 0;
                loseCounterday = 0;

            }
            if (winCounter > loseCounter)
            {
                totalBudget *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalBudget:f2}");

            }
            else if (winCounter < loseCounter) 
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalBudget:f2}");

            }
           
        }
    }
}
