using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace P04L03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                Add(firstNumber, secondNumber);
            }
            else if (command == "multiply")
            {
                Multiply(firstNumber, secondNumber);
            }
            else if (command == "subtract")
            {
                Subtract(firstNumber, secondNumber);
            }
            else if (command == "divide")
            {
                Divide(firstNumber, secondNumber);
            }
        }

        private static void Add(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber + secondNumber}");
        }
        private static void Multiply(int  firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber * secondNumber}");
        }
        private static void Subtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber - secondNumber}");
        }
        private static void Divide(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber / secondNumber}");
        }
    }
}