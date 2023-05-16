using System;

namespace P04.Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNumb = 1;

            while (currentNumb<=n) 
            {
                Console.WriteLine(currentNumb);
                currentNumb = (currentNumb  * 2) + 1;

            
            }

            
               
        }

    }
}
