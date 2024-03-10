using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace P04E08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            FactorialFirstNumber(firstNumber);
            FactorialSecondNumber(secondNumber);
            Printing(FactorialFirstNumber(firstNumber), FactorialSecondNumber(secondNumber));
        }
        static double FactorialFirstNumber(double firstNumber)
        {
            double sumFirstFactorial = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                double currentIndex = i;
                sumFirstFactorial *= currentIndex;
            }
            return sumFirstFactorial;
        }
        static double FactorialSecondNumber(double secondNumber)
        {
            double sumSecondFactorial = 1;
            for (int i = 1; i <= secondNumber; i++)
            {
                double currentIndex = i;
                sumSecondFactorial *= currentIndex;
            }
            return sumSecondFactorial;
        }
        static void Printing(double factorialFirstNumber, double factorialSecondNumber)
        {
            double result = factorialFirstNumber / factorialSecondNumber;
            Console.WriteLine($"{result:F2}");
        }
    }
}