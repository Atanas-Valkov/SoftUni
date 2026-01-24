using System;

namespace P02.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int m1 = 1; m1 <=10; m1++)
            {
                for (int m2 = 1; m2 <= 10; m2++)
                {
                    Console.WriteLine($"{m1} * {m2} = {m1*m2}");
                }
            }
        }
    }
}
