using System.Collections;
using System.Collections.Generic;

namespace P2E05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowColInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[rowColInfo[0], rowColInfo[1]];
            Queue<char> snake =
                new Queue<char>(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        char currentString = snake.Dequeue();
                        matrix[row, col] = currentString;
                        snake.Enqueue(currentString);
                    }
                    else
                    {
                        char currentString = snake.Dequeue();
                        matrix[row, matrix.GetLength(1) - 1 - col] = currentString;
                        snake.Enqueue(currentString);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}