namespace _02.SpaceMissionProblemDescription
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            string[,] spaceSquareGrid = new string[inputNumber, inputNumber];

            int spaceShipPositionRow = 0;
            int spaceShipPositionCol = 0;

            for (int row = 0; row < spaceSquareGrid.GetLength(0); row++)
            {
                string[] colInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < spaceSquareGrid.GetLength(1); col++)
                {
                    spaceSquareGrid[row, col] = colInfo[col];

                    if (spaceSquareGrid[row, col] == "S")
                    {
                        spaceShipPositionRow = row;
                        spaceShipPositionCol = col;
                        spaceSquareGrid[row, col] = ".";
                    }
                }
            }

            int units = 100;

            while (true)
            {
                string command = Console.ReadLine();
                int movedRow = spaceShipPositionRow;
                int movedCol = spaceShipPositionCol;

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

                if (!IsInside(spaceSquareGrid, movedRow, movedCol))
                {
                    Console.WriteLine("Mission failed! The spaceship was lost in space.");
                    spaceSquareGrid[spaceShipPositionRow, spaceShipPositionCol] = "S";
                    Print(spaceSquareGrid);
                    break;
                }

                units -= 5;
                spaceShipPositionRow = movedRow;
                spaceShipPositionCol = movedCol;
                string currentPosition = spaceSquareGrid[spaceShipPositionRow, spaceShipPositionCol];

                if (currentPosition == "M")
                {
                    units -= 5;
                    spaceSquareGrid[spaceShipPositionRow, spaceShipPositionCol] = ".";
                }
                else if (currentPosition == "R")
                {
                    units += 10;
                    if (units > 100)
                    {
                        units = 100;
                    }
                }
                else if (currentPosition == "P")
                {
                    Console.WriteLine($"Mission accomplished! The spaceship reached Planet Eryndor with {units} resources left.");
                    Print(spaceSquareGrid);
                    break;
                }

                if (units < 5)
                {
                    Console.WriteLine("Mission failed! The spaceship was stranded in space.");
                    spaceSquareGrid[spaceShipPositionRow, spaceShipPositionCol] = "S";
                    Print(spaceSquareGrid);
                    break;
                }
            }
        }

        private static bool IsInside(string[,] spaceSquareGrid, int movedRow, int movedCol)
        {
            return movedRow >= 0 && movedRow < spaceSquareGrid.GetLength(0) &&
                   movedCol >= 0 && movedCol < spaceSquareGrid.GetLength(1);
        }

        private static void Print(string[,] spaceSquareGrid)
        {
            for (int i = 0; i < spaceSquareGrid.GetLength(0); i++)
            {
                for (int j = 0; j < spaceSquareGrid.GetLength(1); j++)
                {
                    Console.Write($"{spaceSquareGrid[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}