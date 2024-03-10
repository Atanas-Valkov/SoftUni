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
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double result = 0;

            if (command == "add")
            {
                Add(firstNumber, secondNumber, result);
            }
            else if (command == "multiply")
            {
                Multiply(firstNumber, secondNumber, result);
            }
            else if (command == "subtract")
            {
                Subtract(firstNumber, secondNumber, result);
            }
            else if (command == "divide")
            {
                Divide(firstNumber, secondNumber, result);
            }
        }

        static void Divide(double firstNumber, double secondNumber, double result)
        {
           result = firstNumber / secondNumber;
           Console.WriteLine(result);
        }

        static void Subtract(double firstNumber, double secondNumber, double result)
        {
            result = firstNumber - secondNumber;
            Console.WriteLine(result);
        }

        static void Multiply(double firstNumber, double secondNumber, double result)
        {
            result = firstNumber * secondNumber;
            Console.WriteLine(result);
        }

        static void Add(double firstNumber, double secondNumber, double result)
        {
            result = firstNumber + secondNumber;
            Console.WriteLine(result);
        }
    }
}