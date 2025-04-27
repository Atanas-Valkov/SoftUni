using System.Runtime.CompilerServices;
using static P08E5.Courses.Program;

namespace P08E5.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string commandLine;
            while ((commandLine = Console.ReadLine()) != "end") 
            {
                string[] command = commandLine.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string curseName = command[0];
                string studentName = command[1];

                if (!courses.ContainsKey(curseName))
                {
                    courses.Add(curseName, new List<string>());
                }
                courses[curseName].Add(studentName);
            }

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}