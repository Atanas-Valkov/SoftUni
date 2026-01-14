using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace P2E02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int row = number[0];
            int col = number[1];
            int counter = 0;
            char[,] matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0)- 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)- 1; j++)
                {

                    if (matrix[i, j] == matrix[i, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j] &&
                        matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
