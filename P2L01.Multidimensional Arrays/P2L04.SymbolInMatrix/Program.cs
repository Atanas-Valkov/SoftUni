namespace P2L04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSymbolFound = false;
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] charArr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = charArr[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isSymbolFound = true;
                        break;
                    }
                }

                if (isSymbolFound)
                {
                    break;
                }
            }

            if (!isSymbolFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
    }
}
