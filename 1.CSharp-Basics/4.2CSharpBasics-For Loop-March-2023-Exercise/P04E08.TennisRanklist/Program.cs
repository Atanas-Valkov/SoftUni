using System;

namespace P08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int turnaments = int.Parse(Console.ReadLine());
           int startingPoints = int.Parse(Console.ReadLine());  
           

            int turnamentsPoin = 0;
            double totalPoints = 0;
            int wins = 0;
            for (int i = 1; i <= turnaments; i++)
            {

               string stage = Console.ReadLine();
                
                if (stage == "W")
                {
                    wins++;
                    turnamentsPoin += 2000;
                }
                else if(stage == "F")
                {
                    turnamentsPoin += 1200;
                }
                else if (stage == "SF")
                {
                    turnamentsPoin += 720;

                }
            }
            
            totalPoints = startingPoints + turnamentsPoin;
           

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {turnamentsPoin / turnaments} ");
            Console.WriteLine($"{(double)wins / turnaments * 100:f2}%");
        }
    }
}
