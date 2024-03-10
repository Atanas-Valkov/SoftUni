using System.Data;

namespace P04L04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            UpperPartTriangle(input);
            LowerPartTriangle(input);


        }
        static void UpperPartTriangle(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        static void LowerPartTriangle(int input)
        {
            for (int i = input - 1; i >= 1; i--)
            {

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine();
            }
        }
    }
}


