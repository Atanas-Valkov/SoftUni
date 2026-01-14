using System; 
using System.Dynamic;

namespace P08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string studentName = Console.ReadLine();
            int currentGrades = 1;
            int repeats = 0;
            double markSum = 0;
            bool isExculded = false;
           
            while (currentGrades<=12)
            { 
              double currentMark = double.Parse(Console.ReadLine());

                if (currentMark<4)
                {
                    repeats++;
                        if (repeats>1)
                        {
                          isExculded = true;
                           break;
                        }

                    continue;
                }
               
                markSum += currentMark;
                currentGrades++;

            }
            if (isExculded) 
            {
                Console.WriteLine($"{studentName} has been excluded at {currentGrades} grade");
            }
            else
            {
                double avaregeGrades = markSum / 12; 
                Console.WriteLine($"{studentName} graduated. Average grade: {avaregeGrades:f2}");
            }

        }
    }
}
