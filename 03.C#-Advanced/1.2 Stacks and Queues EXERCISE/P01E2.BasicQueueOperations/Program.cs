namespace P01E2.BasicQueueOperations
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
            Queue<int> queue = new Queue<int>(numbers.Take(n));

            for (int i = 0; i < s && queue.Count > 0; i++)
            {
                queue.Dequeue();
            }

            if (!queue.Any())
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var number in queue)
            {
                if (number == x)
                {
                    Console.WriteLine($"true");
                    return;
                }
            }
            Console.WriteLine(queue.Min());
        }
    }
}
