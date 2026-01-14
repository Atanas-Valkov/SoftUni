using System;
using System.Diagnostics;

namespace P04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInJury = int.Parse(Console.ReadLine());
            string presentation;
            double allGradeSum = 0;
            double gradeCounter = 0;
            while ((presentation = Console.ReadLine()) != "Finish") 
            {
                double sumOfGrade = 0;
                
                for (int i = 1; i <= peopleInJury; i++)
                {
                    double currentGade = double.Parse(Console.ReadLine());

                    sumOfGrade += currentGade;
                    allGradeSum += currentGade;
                    gradeCounter++;
                    if (peopleInJury ==  i)
                    {
                        Console.WriteLine($"{presentation} - {sumOfGrade / peopleInJury:f2}.");
                    }
                }

            }

            if (presentation == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {allGradeSum / gradeCounter:f2}.");
            }


        }
    }
}
