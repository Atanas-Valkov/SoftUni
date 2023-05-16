using System;

namespace P02.RadiansToDegrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
          double radiant = double.Parse(Console.ReadLine());
          double degrees = radiant * 180 / Math.PI;
          Console.WriteLine(degrees);


        }
    }
}
