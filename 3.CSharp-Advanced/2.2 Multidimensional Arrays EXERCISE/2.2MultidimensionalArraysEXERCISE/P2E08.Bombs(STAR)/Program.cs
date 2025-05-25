using System.Diagnostics.Metrics;
using System.Threading.Channels;

namespace P2E08.Bombs_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] bombBord = new int[number, number];
            for (int row = 0; row < bombBord.GetLength(0); row++)
            {
                int[] colInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < bombBord.GetLength(1); col++)
                {
                    bombBord[row, col] = colInfo[col];
                }
            }

            int[] bombInfo = Console.ReadLine()
                .Split(' ', ',')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombInfo.Length - 1; i += 2)
            {
                int r = bombInfo[i];
                int c = bombInfo[i + 1];
                int currentValue = bombBord[r, c];

                if (bombBord[r, c] <= 0)
                {
                    continue;
                }

                for (int row = r - 1; row <= r + 1; row++)
                {
                    for (int col = c - 1; col <= c + 1; col++)
                    {
                        if (IsInside(bombBord, row, col) && bombBord[row, col] > 0)
                        {
                            bombBord[row, col] -= currentValue;
                        }
                    }
                }
            }

            int aliveCells = 0;
            int counter = 0;
            foreach (var asd in bombBord)
            {
                if (asd > 0)
                {
                    counter++;
                    aliveCells += asd;
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {aliveCells}");
            for (int i = 0; i < bombBord.GetLength(0); i++)
            {
                for (int j = 0; j < bombBord.GetLength(1); j++)
                {
                    Console.Write($"{bombBord[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] bombBord, int row, int col)
        {
            return row >= 0 && row < bombBord.GetLength(0) &&
                   col >= 0 && col < bombBord.GetLength(1);
        }
    }
}