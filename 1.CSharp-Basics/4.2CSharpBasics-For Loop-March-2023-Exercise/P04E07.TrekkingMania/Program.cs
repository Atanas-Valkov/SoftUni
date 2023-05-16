using System;
using System.IO;

namespace P07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int peak1 = 0;
            int peak2 = 0;
            int peak3 = 0;
            int peak4 = 0;
            int peak5 = 0;
            int totalPeople = 0;
            for (int i = 1; i <= groups; i++)
            {
                int peopeleInGroup = int.Parse(Console.ReadLine());
                if (peopeleInGroup<=5)
                {
                    peak1 += peopeleInGroup;
                }
                else if (peopeleInGroup <= 12)
                {
                    peak2 += peopeleInGroup;
                }
                else if (peopeleInGroup <= 25)
                {
                    peak3 += peopeleInGroup;
                }
                else if (peopeleInGroup <= 40)
                {
                    peak4 += peopeleInGroup;
                }
                else if (peopeleInGroup >= 41)
                {
                    peak5 += peopeleInGroup;
                }
            }

            totalPeople = peak1 + peak2 + peak3 + peak4 + peak5;
            Console.WriteLine($"{(double)peak1 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)peak2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)peak3 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)peak4 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)peak5 / totalPeople * 100:f2}%");
        }
    }
}
