namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startingPositionRow = -1;
            int startingPositionCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colInfo[col];

                    if (matrix[row, col] == 'S')
                    {
                        startingPositionRow = row;
                        startingPositionCol = col;
                    }
                }
            }

            int stealthPoints = 100;


            while (true)
            {
                string command = Console.ReadLine();
                int nextRow = startingPositionRow;
                int nextCol = startingPositionCol;
                switch (command)
                {
                    case "up": nextRow--; break;
                    case "down": nextRow++; break;
                    case "left": nextCol--; break;
                    case "right": nextCol++; break;
                }
                if (!IsInside(n, nextRow, nextCol))
                {
                    continue;
                }

                matrix[startingPositionRow, startingPositionCol] = '.';

                if (matrix[nextRow, nextCol] == 'G')
                {
                    stealthPoints -= 40;
                    if (stealthPoints <= 0)
                    {
                        matrix[nextRow, nextCol] = 'S';
                        Console.WriteLine($"Mission failed. Spy compromised.");
                        Console.WriteLine($"Stealth level: {stealthPoints} units");
                        Print(matrix);
                        return;
                    }
                    else
                    {
                        matrix[nextRow, nextCol] = '.';

                    }
                }
                else if (matrix[nextRow, nextCol] == 'B')
                {
                    stealthPoints += 15;

                    if (stealthPoints > 100)
                    {
                        stealthPoints = 100;
                    }
                    matrix[nextRow, nextCol] = '.';
                }
                else if (matrix[nextRow, nextCol] == 'E')
                {
                    Console.WriteLine($"Mission accomplished. Spy extracted successfully.");
                    Console.WriteLine($"Stealth level: {stealthPoints} units");
                    Print(matrix);
                    return;
                }
                startingPositionRow = nextRow;
                startingPositionCol = nextCol;
                matrix[startingPositionRow, startingPositionCol] = 'S';
            }
        }
        private static bool IsInside(int n, int movedRow, int movedCol)
        {
            return movedRow >= 0 && movedRow < n &&
                   movedCol >= 0 && movedCol < n;
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
    }
}
