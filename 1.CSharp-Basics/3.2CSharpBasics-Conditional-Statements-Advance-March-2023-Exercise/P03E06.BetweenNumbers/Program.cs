using System;
using System.Runtime.CompilerServices;

namespace P06.BetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());   
            char operation = char.Parse(Console.ReadLine());

            
            

            if (operation == '+' || operation == '-' || operation == '*')
            {
                string condition = "odd";
                double result = 0;

                if (operation == '+')
                {
                    result = num1 + num2;
                    
                }
                else if (operation == '-')
                {
                    result = num1 - num2; 
                }
                else if (operation == '*')
                {
                    result= num1 * num2;    
                }

                if (result % 2 == 0)
                {
                    condition = "even";
                }
                Console.WriteLine($"{num1} {operation} {num2} = {result} - {condition}");

            }
            else 
            {

                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else if (operation == '/')
                {
                    double result = (double)num1 / num2;
                    Console.WriteLine($"{num1} {operation} {num2} = {result:f2}");
                }
                else if (operation == '%')
                   
                {
                    double result = num1 % num2;
                    Console.WriteLine($"{num1} {operation} {num2} = {result}");

                }

            }
           
        }
    }
}
