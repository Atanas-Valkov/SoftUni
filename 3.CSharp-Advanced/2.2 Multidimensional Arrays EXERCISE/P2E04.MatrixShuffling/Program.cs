namespace P2E04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowColInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[rowColInfo[0], rowColInfo[1]];

            for (int row = 0; row < rowColInfo[0]; row++)
            {
                string[] rowInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < rowInfo.Length; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = arguments[0];

              
                if (operation == "swap" && arguments.Length == 5)
                {
                    int row = int.Parse(arguments[1]);
                    int col = int.Parse(arguments[2]);
                    int row1 = int.Parse(arguments[3]);
                    int col1 = int.Parse(arguments[4]);

                    if (rowColInfo[0] - 1 >= row && row >= 0 && rowColInfo[1] - 1 >= col && col >= 0 &&
                        rowColInfo[0] - 1 >= row1 && row1 >= 0 && rowColInfo[1] - 1 >= col1 && col1 >= 0)
                    {
                        string temp = matrix[row, col];
                        matrix[row, col] = matrix[row1, col1];
                        matrix[row1, col1] = temp;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");

                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }
            }
        }
    }
}