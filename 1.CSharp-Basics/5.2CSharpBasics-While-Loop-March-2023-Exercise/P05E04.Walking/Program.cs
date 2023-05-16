using System;

namespace P04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepsPerDay = 0;

            string input;

            while (stepsPerDay<10000)
            {
                input = Console.ReadLine();

                if (input=="Going home")
                {
                    stepsPerDay += int.Parse(Console.ReadLine());

                    break;

                }

                stepsPerDay += int.Parse(input);
                
               
            }

            if (stepsPerDay < 10000)
            {
                
                Console.WriteLine($"{10000 - stepsPerDay} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsPerDay - 10000} steps over the goal!");
            }

        }
    }
}
