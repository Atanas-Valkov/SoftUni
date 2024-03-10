using System.Runtime.CompilerServices;
using static P08E5.Courses.Program;

namespace P08E5.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, List<string>> kvp = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] courseName = input.Split(" : ");

                string course = courseName[0];
                string student = courseName[1];

                if (!kvp.ContainsKey(course))
                {
                    kvp.Add(course,new List<string>());
                }
                kvp[course].Add(student);
            }

   
            foreach (var print in kvp)
            {
                Console.WriteLine($"{print.Key}: {print.Value.Count}");

                foreach (var print1 in print.Value)
                {
                    Console.WriteLine($"-- {print1}");
                }
            }
            //  foreach (var print in kvp)
            //  {
            //      Console.WriteLine($"{print.Key}: {kvp.Values.Count}");
            //
            //      foreach (var asd in kvp)
            //      {
            //          if (print.Key == asd.Key)
            //          {
            //
            //              for (int i = 0; i < kvp.Values.Count; i++)
            //              {
            //                  Console.WriteLine($"-- {asd.Value[i]}");
            //              }
            //          }
            //      }
            //  }


        }
    }
}