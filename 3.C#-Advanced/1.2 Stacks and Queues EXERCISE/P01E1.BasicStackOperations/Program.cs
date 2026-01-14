using System.Threading.Channels;

namespace P01E1.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers.Take(n));

            for (int i = 0; i < s && stack.Count > 0; i++)
            {
                stack.Pop();
            }

            if (!stack.Any())
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var number in stack)
            {
                if (number == x)
                {
                    Console.WriteLine($"true");
                    return;
                }
            }
            Console.WriteLine(stack.Min());
        }
    }
}
