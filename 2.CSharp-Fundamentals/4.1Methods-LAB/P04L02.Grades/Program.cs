using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.Serialization;
using Double = System.Double;

namespace P04L02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inputGrade = double.Parse(Console.ReadLine());
            string correspondingGrade = "";

            PrintGrade(correspondingGrade, inputGrade);
        }

        private static void PrintGrade(string correspondingGrade, double inputGrade)
        {
            if (inputGrade >= 2 && inputGrade < 3)
            {
                Console.WriteLine($"Fail");
            }
            else if(inputGrade >= 3 && inputGrade < 3.5)
            {
                Console.WriteLine($"Poor");
            }
            else if (inputGrade >= 3.5 && inputGrade < 4.5)
            {
                Console.WriteLine($"Good");
            }
            else if (inputGrade >= 4.5 && inputGrade < 5.5)
            {
                Console.WriteLine($"Very good");
            }
            else if (inputGrade >= 5.5 && inputGrade < 6)
            {
                Console.WriteLine($"Excellent");
            }
        }
    }
}