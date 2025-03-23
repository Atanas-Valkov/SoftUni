using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace P04L11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string commandLine = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            MathOperationt(firstNumber, secondNumber, commandLine);
            Console.WriteLine(MathOperationt(firstNumber, secondNumber, commandLine));
        }

        private static double MathOperationt(double firstNumber, double secondNumber, string? commandLine)
        {
            double sum = 0;
            if (commandLine == "+")
            {
                sum = firstNumber + secondNumber;
            }
            else if (commandLine == "-")
            {
                sum = firstNumber - secondNumber;
            }
            else if (commandLine == "*")
            {
                sum = firstNumber * secondNumber;
            }
            else if (commandLine == "/")
            {
                sum = firstNumber - secondNumber;
            }

            return sum;
        }
    }
}
