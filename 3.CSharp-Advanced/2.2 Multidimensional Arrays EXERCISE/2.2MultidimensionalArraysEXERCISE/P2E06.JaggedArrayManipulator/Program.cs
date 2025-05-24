using System.Dynamic;

namespace P2E06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                int[] colInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggedArray[row] = colInfo;
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }

                    for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                    {
                        jaggedArray[i + 1][j] /= 2;
                    }
                }
            }

            string command = " ";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if (row >= 0 && row < jaggedArray.Length &&
                    col >= 0 && col < jaggedArray[row].Length)
                {
                    if (commandInfo[0] == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (commandInfo[0] == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}