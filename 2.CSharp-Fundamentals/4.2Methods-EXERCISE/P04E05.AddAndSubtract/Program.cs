using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace P04E05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Sum(firstNumber, secondNumber);
            Subtract(thirdNumber, Sum(firstNumber, secondNumber));
            Console.WriteLine(Subtract(thirdNumber, Sum(firstNumber, secondNumber)));
        }

        private static int Subtract(int thirdNumber, int sum)
        {
            return sum - thirdNumber;
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}