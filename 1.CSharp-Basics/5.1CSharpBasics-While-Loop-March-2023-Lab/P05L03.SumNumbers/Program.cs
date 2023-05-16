using System;

namespace P03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int num = int.Parse(Console.ReadLine());
          int sum = 0;
        
            while (sum<num)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;   

            }
            Console.WriteLine(sum);
        }
    }
}
