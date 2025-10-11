using System;

namespace P03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;

            while ((input = Console.ReadLine()) != "stop") 
            { 
                int currentNumber = int.Parse(input);
                int primeCounter = 0;
         
                if (currentNumber<0)
                {
                    Console.WriteLine($"Number is negative.");
                    continue;
                }
                if (currentNumber == 0) 
                {
                    continue;
                
                }
                for (int i = 1; i <=currentNumber; i++)
                {
                    if (currentNumber % i == 0 )
                    {
                        primeCounter++;
                    }
                }
                if (primeCounter == 2 )
                {
                    sumPrimeNumbers += currentNumber;
                }
                else 
                { 
                    sumNonPrimeNumbers += currentNumber;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");

        }
    }
}
