using System.ComponentModel;

namespace P04L11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());
            
            if (operation == "/")
            {
                Console.WriteLine(Devision(firstNumber, secondNumber));
            }
            else if (operation == "*")
            {
                Console.WriteLine(Multiplied(firstNumber, secondNumber));
            }
            else if (operation == "+")
            {
                Console.WriteLine(Add(firstNumber, secondNumber));
            }
            else if (operation == "-")
            {
                Console.WriteLine(Substract(firstNumber, secondNumber));
            }
        }
        static double Substract(double firstNumber, double secondNumber)
        {
            return  firstNumber - secondNumber;
        }
        static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        static double Multiplied(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        static double Devision(double firstNumber, double secondNumber)
        {
            return  firstNumber / secondNumber;
        }
    }
}
