using System;

namespace P03L10.InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > 200)
            {
                Console.WriteLine("invalid");

            }
            else if (num < 100 && num !=0)
            {
                Console.WriteLine("invalid");

            }
            else if (num < 0)
            {
                Console.WriteLine("invalid");

            }
           
        }
    }
}

