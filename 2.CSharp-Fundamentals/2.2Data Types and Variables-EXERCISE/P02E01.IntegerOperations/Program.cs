using System;

namespace P2E01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int firstOperation = firstNumber + secondNumber;
            int secondOperation = firstOperation / thirdNumber;
            int thirdOperation = secondOperation * fourthNumber;

            Console.WriteLine($"{thirdOperation}");
        }
    }   
}
