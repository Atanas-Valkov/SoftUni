namespace P03ME4.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int k = input.Length / 4;  

            int[] firstPart = new int[k];
            int[] secondPart = new int[2 * k];
            int[] thirdPart = new int[k];

            for (int i = 0; i < k; i++)
            {
                firstPart[i] = int.Parse(input[i]);
            }

            for (int i = 0; i < 2 * k; i++)
            {
                secondPart[i] = int.Parse(input[k + i]);
            }

            for (int i = 0; i < k; i++)
            {
                thirdPart[i] = int.Parse(input[3 * k + i]);
            }

            Array.Reverse(firstPart);
            Array.Reverse(thirdPart);

            int[] upperRow = new int[2 * k];
            for (int i = 0; i < k; i++)
            {
                upperRow[i] = firstPart[i];
                upperRow[k + i] = thirdPart[i];
            }

            int[] lowerRow = secondPart;
            int[] result = new int[2 * k];
            for (int i = 0; i < 2 * k; i++)
            {
                result[i] = upperRow[i] + lowerRow[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}