namespace P03ME5.LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int[] nums = Array.ConvertAll(input, int.Parse);

            if (nums.Length == 0)
            {
                Console.WriteLine("");
                return;
            }

            int n = nums.Length;
            int[] len = new int[n];
            int[] prev = new int[n];

            for (int i = 0; i < n; i++)
            {
                len[i] = 1;
                prev[i] = -1; 
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && len[i] < len[j] + 1)
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            int maxLenIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (len[i] > len[maxLenIndex])
                {
                    maxLenIndex = i;
                }
            }

            List<int> lis = new List<int>();
            while (maxLenIndex != -1)
            {
                lis.Add(nums[maxLenIndex]);
                maxLenIndex = prev[maxLenIndex];
            }

            lis.Reverse();
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}