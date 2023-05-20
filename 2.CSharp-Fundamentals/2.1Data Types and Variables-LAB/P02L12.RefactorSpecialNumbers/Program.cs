using System;

namespace P02L12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
          
            

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int sum = 0;
                while (number != 0)
                {
                    int lastGigit = number % 10;
                    number /= 10;
                    sum += lastGigit;
                }
                bool isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine("{0} -> {1}", i, isSpecial);
               
                
            }

        }
    }
}
