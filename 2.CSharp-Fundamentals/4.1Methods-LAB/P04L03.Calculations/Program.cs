using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace P04L03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operations = Console.ReadLine();
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());

            if (operations == "add")
            {
                add(firstInt, secondInt);
            }
            else if(operations == "multiply")
            {
                multiply(firstInt, secondInt);
            }
            else if (operations == "subtract")
            {
                subtract(firstInt, secondInt);
            }
            else if (operations == "divide")
            {
                divide(firstInt, secondInt);
            }
        }
        static void add(int firstInt, int secondInt)
        {
            Console.WriteLine(firstInt + secondInt);
        }
        static void multiply(int firstInt, int secondInt)
        {
            Console.WriteLine(firstInt * secondInt);
        }
        static void subtract(int firstInt, int secondInt)
        {
            Console.WriteLine(firstInt - secondInt);
        }
        static void divide(int firstInt, int secondInt)
        {
            Console.WriteLine(firstInt / secondInt);
        }
    }
}