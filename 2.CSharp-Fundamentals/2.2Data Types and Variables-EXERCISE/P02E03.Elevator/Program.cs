using System;
using System.Threading;

namespace P02E03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int courses = 0;

            for (int i = p; i <=n; i+=p )
            {
                courses++;
            }
            if (n % p != 0 )
            {

                courses += 1;
            }
            Console.WriteLine(courses);
        }


    }
}
