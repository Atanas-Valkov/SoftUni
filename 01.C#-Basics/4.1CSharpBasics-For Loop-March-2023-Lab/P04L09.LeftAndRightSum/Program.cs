using System;

namespace P09.LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int leftsum = 0;
            int rightsum = 0;
            for (int i = 1; i <= n; i++) 
            {
                int number = int.Parse(Console.ReadLine());                 
                leftsum += number;
            }
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());   
                rightsum += number;
            }
             if (leftsum == rightsum) 
             {
                Console.WriteLine($"Yes, sum = {leftsum}");
             }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftsum-rightsum)}");
            }
        }
    }
}
