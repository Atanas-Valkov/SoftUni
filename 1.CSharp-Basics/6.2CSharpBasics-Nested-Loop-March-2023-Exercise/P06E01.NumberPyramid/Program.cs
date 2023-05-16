using System;

namespace P01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int currentNumber = 1;
            bool isBigger = false;

            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (currentNumber > num)
                    {
                        isBigger = true;
                        break;
                    }

                    Console.Write(currentNumber + " ");
                    currentNumber++;

                   
                }
                
                Console.WriteLine();
                if (isBigger)
                {
                    break;              
                
                }

            }


        }

    }
}
