namespace P2E03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[info[0], info[1]];

            for (int row = 0; row < info[0]; row++)
            {
                int[] rowInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < info[1]; col++)
                {

                    matrix[row, col] = rowInfo[col];
                }
            }
            int sum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = sum;
                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                                 + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                                 + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > sum)
                    {
                        sum = currentSum;

                        rowIndex = i; colIndex = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}