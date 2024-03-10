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

            Console.WriteLine(SmallestOfThreeInteger(firstNumber, secondNumber, thirdNumber));
        }

        static int SmallestOfThreeInteger(int firstNumber, int secondNumber, int thirdNumber)
        {
            int firstCommpear = Math.Min(firstNumber, secondNumber);
            int lastCommpear = Math.Min(firstCommpear, thirdNumber);
            return lastCommpear;
        }
    }
}