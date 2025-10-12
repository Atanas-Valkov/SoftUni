using System.Diagnostics;
using System.Collections.Generic;
using System.Net;

namespace P08E6.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> academy = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                Student student = new Student(grade, name);
                if (!academy.ContainsKey(name))
                {
                    academy.Add(name, new List<double>());
                }
                academy[name].Add(grade);
            }

            foreach (var item in academy.Where(x => x.Value.Average() >= 4.5))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():F2}");
            }
        }
    }

    public class Student
    {
        public Student(double grade, string name)
        {
            Grade = grade;
            Name = name;
        }
        public string Name { get; set; }
        public double Grade { get; set; }
    }
}