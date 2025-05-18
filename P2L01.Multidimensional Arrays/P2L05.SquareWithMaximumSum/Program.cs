namespace P2L05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColsInfo = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] bord = new int[rowsColsInfo[0], rowsColsInfo[1]];

            for (int row = 0; row < rowsColsInfo[0]; row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < rowsColsInfo[1]; col++)
                {
                    bord[row, col] = colElements[col];
                }
            }

            int sumSquare = int.MinValue;
            int topLeftRow = 0;
            int topLeftCol = 0;

            for (int rowBord = 0; rowBord < bord.GetLength(0) - 1; rowBord++)
            {
                for (int colBord = 0; colBord < bord.GetLength(1) - 1; colBord++)
                {
                    int currentSum = sumSquare;
                    currentSum = bord[rowBord, colBord] +
                                 bord[rowBord, colBord + 1] +
                                 bord[rowBord + 1, colBord] +
                                 bord[rowBord + 1, colBord + 1];
                    if (currentSum > sumSquare)
                    {
                        sumSquare = currentSum;
                        topLeftRow = rowBord;
                        topLeftCol = colBord;
                    }
                }
            }

            Console.WriteLine($"{bord[topLeftRow, topLeftCol]} {bord[topLeftRow, topLeftCol + 1]}");
            Console.WriteLine($"{bord[topLeftRow + 1, topLeftCol]} {bord[topLeftRow + 1, topLeftCol + 1]}");
            Console.WriteLine(sumSquare);
        }
    }
}
