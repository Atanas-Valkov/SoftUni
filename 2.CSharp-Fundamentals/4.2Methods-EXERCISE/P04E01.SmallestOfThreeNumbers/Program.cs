using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace P04E01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            SmallestOfThreeNumbers(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(SmallestOfThreeNumbers(firstNumber, secondNumber, thirdNumber));
        }

        private static int SmallestOfThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            int firstCompare = Math.Min(firstNumber, secondNumber);
            int secondCompare = Math.Min(firstCompare, thirdNumber);

            return secondCompare;
        }
    }
}