using System.Data;

namespace P2L06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] rowInfo = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                jaggedArray[row] = rowInfo;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commandInfo[0];
                int rowModification = int.Parse(commandInfo[1]);
                int colModification = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if (operation == "Add")
                {
                    if (rowModification < 0 || rowModification >= n ||
                        colModification < 0 || colModification > jaggedArray[rowModification].Length)
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }

                    jaggedArray[rowModification][colModification] += value;
                }
                else if (operation == "Subtract")
                {
                    if (rowModification < 0 || rowModification >= n ||
                        colModification < 0 || colModification > jaggedArray[rowModification].Length)
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }
                    jaggedArray[rowModification][colModification] -= value;
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
