namespace P2L02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixInfo[0], matrixInfo[1]];
            int sumRows = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col]= colElements[col];
                }
            }

            for (int cow = 0; cow < matrix.GetLength(1); cow++)
            {
                sumRows = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumRows+= matrix[row, cow];
                }
                Console.WriteLine(sumRows);
            }

        }
    }
}
