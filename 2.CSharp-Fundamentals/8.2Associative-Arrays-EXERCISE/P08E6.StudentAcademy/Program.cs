using System.Diagnostics;
using System.Collections.Generic;

namespace P08E6.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberPairOfRows = int.Parse(Console.ReadLine()); 
            Dictionary<string, List<double>> kvp = new Dictionary<string, List<double>> ();

            for (int i = 0; i < numberPairOfRows; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());


                if (!kvp.ContainsKey(studentName))
                {
                    kvp.Add(studentName,new List<double>());
                }
                kvp[studentName].Add(studentGrade);
            }

            Dictionary<string,double> averageGrade = new Dictionary<string, double>();

            foreach (var average in kvp)
            {
                double currentGrade = average.Value.Average();

                if (currentGrade>=4.5)
                {
                    averageGrade.Add(average.Key,currentGrade);
                }
            }

            foreach (var print in averageGrade)
            {
                Console.WriteLine($"{print.Key} -> {print.Value:f2}");
            }
        }
    }
}