using System.Data;

namespace P04L04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            UpperPart(number);
            BottomPart(number - 1);
        }

        private static void UpperPart(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
                if (i == number)
                {
                    return;
                }

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
            }
        }
        private static void BottomPart(int number)
        {
            for (int i = number; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " " );
                }
                Console.WriteLine();
            }
        }
    }
}
