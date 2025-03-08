using System.Net;

namespace P03ME2.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                int number = 1;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");
                    number = number * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }
        }
    }
}
