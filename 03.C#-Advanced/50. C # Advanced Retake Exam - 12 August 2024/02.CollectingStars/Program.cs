namespace _02.CollectingStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] field = new string[n, n];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(" ");
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == "P")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int stars = 2;
            field[playerRow, playerCol] = ".";
            string command;
            while ((command = Console.ReadLine()) != null)
            {
                int nextRow = playerRow;
                int nextCol = playerCol;

                switch (command)
                {
                    case "up": nextRow--; break;
                    case "down": nextRow++; break;
                    case "left": nextCol--; break;
                    case "right": nextCol++; break;
                }

                if (!IsInside(nextRow, nextCol, n))
                {
                    field[playerRow, playerCol] = ".";
                    playerRow = 0;

                    playerCol = 0;
                    field[playerRow, playerCol] = "P";
                    continue;
                }

                string nextCell = field[nextRow, nextCol];

                if (nextCell == "#")
                {
                    stars--;
                    if (stars <= 0)
                    {
                        field[playerRow, playerCol] = "P";
                        Console.WriteLine("Game over! You are out of any stars.");
                        Console.WriteLine($"Your final position is [{playerRow}, {playerCol}]");
                        Print(field);
                        return;
                    }
                    continue;
                }

                field[playerRow, playerCol] = ".";
                playerRow = nextRow;
                playerCol = nextCol;

                if (nextCell == "*")
                {
                    stars++;
                }

                if (stars >= 10)
                {
                    field[playerRow, playerCol] = "P";
                    Console.WriteLine("You won! You have collected 10 stars.");
                    Console.WriteLine($"Your final position is [{playerRow}, {playerCol}]");
                    Print(field);
                    return;
                }

                field[playerRow, playerCol] = "P";
            }
        }

        static bool IsInside(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        static void Print(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
