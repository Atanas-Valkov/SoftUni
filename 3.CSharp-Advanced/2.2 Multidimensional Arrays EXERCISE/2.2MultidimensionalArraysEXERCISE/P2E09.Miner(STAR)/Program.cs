using System.Reflection.Metadata;

namespace P2E09.Miner_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isMoved = false;
            Queue<string> commands = new Queue<string>(Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            int minerRow = 0;
            int minerCol = 0;
            char[,] field = new char[number, number];
            int totalCoal = 0;
            for (int row = 0; row < number; row++)
            {
                char[] colInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < number; col++)
                {
                    field[row, col] = colInfo[col];
                    if (field[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (field[row, col] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }

            char currentChar = default;

            while (commands.Count > 0)
            {
                string command = commands.Dequeue();
                int movedRow = minerRow;
                int movedCol = minerCol;

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

                if (IsInside(field, movedRow, movedCol))
                {
                    currentChar = field[movedRow, movedCol];
                    if (currentChar == 'c' && totalCoal > 0)
                    {
                        totalCoal--;
                        if (totalCoal == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({movedRow}, {movedCol})");
                        }
                    }
                    else if (currentChar == 'e')
                    {
                        Console.WriteLine($"Game over! ({movedRow}, {movedCol})");
                        break;
                    }

                    field[minerRow, minerCol] = '*';
                    minerRow = movedRow;
                    minerCol = movedCol;
                    field[minerRow, minerCol] = 's';
                }
            }

            if (commands.Count == 0 && currentChar != 'e' && totalCoal != 0)
            {
                Console.WriteLine($"{totalCoal} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsInside(char[,] field, int movedRow, int movedCol)
        {
            return movedRow >= 0 && movedRow < field.GetLength(0) &&
                   movedCol >= 0 && movedCol < field.GetLength(1);
        }
    }
}