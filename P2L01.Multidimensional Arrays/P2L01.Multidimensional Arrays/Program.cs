namespace P2L01.Multidimensional_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rowMatrix = matrixInfo[0];
            int colMatrix = matrixInfo[1];
            int sum = 0;
            int[,] matrix = new int[rowMatrix, colMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine($"{rowMatrix}");
            Console.WriteLine($"{colMatrix}");
            Console.WriteLine($"{sum}");
        }
    }
}
