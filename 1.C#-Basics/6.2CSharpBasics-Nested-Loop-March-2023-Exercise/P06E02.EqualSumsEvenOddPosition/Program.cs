using System;

namespace P02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            
            for (int i = start; i <= end; i++) 
            {
                string currentNumber = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currentNumber.Length; j++)
                {

                    if (j % 2 == 1)
                    {
                        oddSum += int.Parse(currentNumber[j].ToString());

                    }
                    else if (j % 2 == 0)
                    {
                        evenSum += int.Parse(currentNumber[j].ToString());
                    }

                    
                
                }
                if (oddSum == evenSum)
                {
                    Console.Write(currentNumber + " ");
                }

            }
        }
    }
}
