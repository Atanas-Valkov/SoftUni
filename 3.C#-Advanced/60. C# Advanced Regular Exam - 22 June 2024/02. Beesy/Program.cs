using System;
using System.Drawing;
using System.IO.IsolatedStorage;

namespace _02._Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startBeePositionRow = 0;
            int startBeePositionCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colInfo[col];
                    if (matrix[row, col] == 'B')
                    {
                        startBeePositionRow = row;
                        startBeePositionCol = col;
                    }
                }
            }

            int energy = 15;
            int nectar = 0;
            bool isRestoredEnergy = false;
            while (true)
            {
                string command = Console.ReadLine();
                int movedRow = startBeePositionRow;
                int movedCol = startBeePositionCol;
                matrix[startBeePositionRow, startBeePositionCol] = '-';
                if (command == "up")
                {
                    movedRow--;
                }
                else if (command == "right")
                {
                    movedCol++;
                }
                else if (command == "left")
                {
                    movedCol--;
                }
                else if (command == "down")
                {
                    movedRow++;
                }

                movedRow = (movedRow + n) % n;
                movedCol = (movedCol + n) % n;
                energy--;

                if (char.IsDigit(matrix[movedRow, movedCol]))
                {
                    nectar += int.Parse(matrix[movedRow, movedCol].ToString());
                }

                startBeePositionRow = movedRow;
                startBeePositionCol = movedCol;

                if (matrix[movedRow, movedCol] != 'H')
                {
                    matrix[movedRow, movedCol] = 'B';
                }


                if (energy <= 0)
                {
                    if (nectar >= 30 && !isRestoredEnergy)
                    {
                        int restore = nectar - 30;
                        energy += restore;
                        nectar = 30;
                        isRestoredEnergy = true;

                    }
                    else
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        matrix[movedRow, movedCol] = 'B';
                        Print(matrix);
                        return;
                    }
                }

                if (matrix[movedRow, movedCol] == 'H')
                {
                    if (nectar >= 30)
                    {
                        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
                    }
                    else
                    {
                        Console.WriteLine("Beesy did not manage to collect enough nectar.");
                    }

                    matrix[movedRow, movedCol] = 'B';
                    Print(matrix);
                    return;
                }
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(char[,] matrix, int movedRow, int movedCol)
        {
            return movedRow >= 0 && movedRow < matrix.GetLength(0) &&
                   movedCol >= 0 && movedCol < matrix.GetLength(1);
        }
    }
}
