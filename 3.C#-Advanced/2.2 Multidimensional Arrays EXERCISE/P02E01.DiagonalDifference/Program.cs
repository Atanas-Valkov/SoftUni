namespace P02E01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[n, n];
            int sumLeftToRight = 0;
            int sumRightToLeft = 0;
            for (int row = 0; row < n; row++)
            {
                int[] rowINfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    squareMatrix[row, col] = rowINfo[col];
                    if (row == col)
                    {
                        sumLeftToRight += squareMatrix[row, col];
                    }
                }
                int startLast = squareMatrix[row, rowINfo.Length - 1 - row];
                sumRightToLeft += startLast;
            }

            Console.WriteLine($"{Math.Abs(sumLeftToRight - sumRightToLeft)}");
        }
    }
}
