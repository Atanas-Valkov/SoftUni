using System;

namespace P05.BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bestPlayer = string.Empty;
            int numberOfGoals = 0;

            int maxNum = int.MinValue;
            string playerName;
            while ((playerName = Console.ReadLine()) != "END" )
            {

                int currentGoals = int.Parse(Console.ReadLine());
                if (currentGoals > numberOfGoals)
                {
                    bestPlayer = playerName;
                    numberOfGoals = currentGoals;
                }
                if (numberOfGoals>=10)
                {
                    break;
                }



            }


            Console.WriteLine($"{bestPlayer} is the best player!");



            if (numberOfGoals >= 3)
            {
                Console.WriteLine($"He has scored {numberOfGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {numberOfGoals} goals.");
            }
        }
    }
}
