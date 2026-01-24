using System;
using System.Runtime.CompilerServices;

namespace P02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int maxNum = int.MinValue;

            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                
                sum += currentNumber;

                if (currentNumber> maxNum)
                {
                    maxNum= currentNumber;  

                }
            }
            sum -= maxNum;
            if (sum == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+sum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = "+Math.Abs(sum-maxNum));
            }
        }
    }
}
