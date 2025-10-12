using System;
using System.Collections.Generic;

namespace RadioactiveBunniesFixed
{
    internal class Program
    {
        static bool isDead = false;
        static bool isWon = false;
        static int playerRow;
        static int playerCol;

        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split();
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            char[,] board = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int c = 0; c < cols; c++)
                {
                    board[r, c] = input[c];
                    if (board[r, c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }

            Queue<char> commands = new Queue<char>(Console.ReadLine());

            while (commands.Count > 0)
            {
                int nextRow = playerRow;
                int nextCol = playerCol;

                switch (commands.Dequeue())
                {
                    case 'U': nextRow--; break;
                    case 'D': nextRow++; break;
                    case 'L': nextCol--; break;
                    case 'R': nextCol++; break;
                }

                board[playerRow, playerCol] = '.';

                if (!IsInside(board, nextRow, nextCol))
                {
                    isWon = true;
                }
                else if (board[nextRow, nextCol] == 'B')
                {
                    isDead = true;
                    playerRow = nextRow;
                    playerCol = nextCol;
                }
                else
                {
                    playerRow = nextRow;
                    playerCol = nextCol;
                    board[playerRow, playerCol] = 'P';
                }

                board = SpreadBunnies(board);

                if (!isWon && board[playerRow, playerCol] == 'B')
                {
                    isDead = true;
                }

                if (isDead || isWon)
                {
                    break;
                }
            }

            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.Write(board[r, c]);
                }
                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                   col >= 0 && col < board.GetLength(1);
        }

        static char[,] SpreadBunnies(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            char[,] newBoard = (char[,])board.Clone();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (board[r, c] == 'B')
                    {
                        TrySpread(newBoard, r - 1, c);
                        TrySpread(newBoard, r + 1, c);
                        TrySpread(newBoard, r, c - 1);
                        TrySpread(newBoard, r, c + 1);
                    }
                }
            }

            return newBoard;
        }

        static void TrySpread(char[,] board, int row, int col)
        {
            if (IsInside(board, row, col))
            {
                board[row, col] = 'B';
            }
        }
    }
}
