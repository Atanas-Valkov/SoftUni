using System.Diagnostics;
using System.Runtime.Serialization;
using Double = System.Double;

namespace P04L02.Grades
{
    internal class Program
    {
        static void Main()
        {
            double gradr = double.Parse(Console.ReadLine());

            GradeDefinition(gradr);
        }
        static void GradeDefinition(double grade)
        {
            if (grade >= 2 && grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (grade > 2.99 && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (grade > 3.49 && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (grade > 4.49 && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (grade > 5.49 && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
            //do something  //do something  //do something  //do something  //do something
        }
    }

}