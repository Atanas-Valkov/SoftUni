using System;
using System.Globalization;
using System.Runtime.ExceptionServices;

namespace P04L09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string type = Console.ReadLine();

            if (type == "int")
            {
                int firsInt = int.Parse(Console.ReadLine());
                int secondInt = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firsInt, secondInt));
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstChar, secondChar));
            }
            else if (type == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();
                Console.WriteLine(GetMax(firstString, secondString));
            }
        }
        static int GetMax(int firstInt, int secontInt)
        {
            return Math.Max(firstInt, secontInt);
        }
        static char GetMax(char firstChar, char secontChar)
        {
            if (firstChar > secontChar)
            {
                return firstChar;
            }
            else
            {
                return secontChar;
            }
        }

        static string GetMax(string firstString, string secondString)
        {
            int biggest = firstString.CompareTo(secondString);

            if (biggest > 0)
                return firstString;
            else
                return secondString;
            
        }
    }
}







