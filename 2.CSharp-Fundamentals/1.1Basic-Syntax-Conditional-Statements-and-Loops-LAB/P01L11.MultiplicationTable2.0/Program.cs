using System;
using System.Data.Common;

namespace P01L11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = times; i <= 10; i++)
            {
                sum = number * i;
                Console.WriteLine($"{number} X {i} = {sum}");
            }

            if (times > 10)
            {
                sum = number * times; 
                Console.WriteLine($"{number} X {times} = {sum}");
            }

        }
    }
}
