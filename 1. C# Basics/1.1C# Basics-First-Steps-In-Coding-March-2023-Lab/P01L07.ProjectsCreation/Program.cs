using System;
using System.Numerics;

namespace P07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string name = Console.ReadLine();
          int project = int.Parse(Console.ReadLine());
          int sum = project * 3;

         Console.WriteLine($"The architect {name} will need {sum} hours to complete {project} project/s.");




        }
    }
}
