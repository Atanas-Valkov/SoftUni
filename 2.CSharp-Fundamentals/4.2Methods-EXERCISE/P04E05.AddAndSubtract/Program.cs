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
            int result = 0;
            int sum = SumOfFirstTwoIntegers(firstNumber, secondNumber);
            ThirdNumberSubtractSum(thirdNumber, sum);
        }
        static int SumOfFirstTwoIntegers(int firstNumber, int secondNumber )
        {
           int sum = firstNumber + secondNumber;
           return sum; 
        }
        static void ThirdNumberSubtractSum(int thirdNumber, int sum)
        {
            int result = sum - thirdNumber;
            Console.WriteLine(result);
        }
    }
}