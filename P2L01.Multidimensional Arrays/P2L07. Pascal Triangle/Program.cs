using System.Net.WebSockets;

namespace P2L07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            ulong[][] pascalTriangle = new ulong[n][];
            

            for (int row = 0; row < n; row++)
            {
                pascalTriangle[row] = new ulong[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][row] = 1;

                for (int col = 1; col < row; col++)
                {
                    ulong value = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                    pascalTriangle[row][col] = value;
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
