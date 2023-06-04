using System.Diagnostics;
using Double = System.Double;

namespace P04L02.Grades
{
    internal class Program
    {
        static void PrintsTheCorrespondingGradeDefinition(double grade)
        {

            if (grade >= 2 && grade < 3)
            {
                Console.WriteLine("Fail");
            }
            else if (grade >= 3 && grade < 3.5)
            {
                Console.WriteLine("Poor");
            }
            else if (grade >= 3.5 && grade < 4.5)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 4.5 && grade < 5.5)
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 5.5 && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());

            PrintsTheCorrespondingGradeDefinition(grade);
        }

    }
            
}