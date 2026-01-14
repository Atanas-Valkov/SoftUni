using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace P04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int mN = int.Parse(Console.ReadLine());
            int counter = 0;
            int i = 0;
            int j = 0;
            bool isCombi = false;

            for (i = n1; i <=n2; i++)
            {
                for (j = n1; j <= n2; j++)
                {
                    counter++;
                    if (i+j == mN)
                    {
                        isCombi=true;
                        break;
                    }                   
                }
                
              if (isCombi)
              {
                    break;
              }
            }
           
            if (isCombi)
            {
                Console.WriteLine($"Combination N:{counter} ({i} + {j} = {mN})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {mN}");
            }

        }
    }
}
