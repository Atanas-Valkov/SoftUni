using System;
using System.Diagnostics.Tracing;

namespace P05E02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filedTimes = int.Parse(Console.ReadLine());
            int evaluationCount = 0;
            int evaluationSum = 0;
            int filedCount = 0;
            int evaluation = 0;
            string input = Console.ReadLine();
            string lastExercise = string.Empty;

            while (input != "Enough")
            {
                lastExercise = input;
                evaluation = int.Parse(Console.ReadLine());

                evaluationSum += evaluation;
                evaluationCount++;

                if (evaluation <= 4)
                {
                    filedCount++;

                    if (filedTimes == filedCount)
                    {
                        Console.WriteLine($"You need a break, {filedCount} poor grades.");
                        break;

                    }
                }

                input = Console.ReadLine();

                if (input == "Enough")
                {
                    Console.WriteLine($"Average score: {(double)evaluationSum / evaluationCount:f2}");
                    Console.WriteLine($"Number of problems: {evaluationCount}");
                    Console.WriteLine($"Last problem: {lastExercise}");

                }
            }
        }
    }
}
