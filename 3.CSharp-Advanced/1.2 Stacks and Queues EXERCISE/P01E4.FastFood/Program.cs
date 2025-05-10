namespace P01E4.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);
            int originalLength = queue.Count;
            for (int i = 0; i < originalLength; i++)
            {
                if (foodQuantity >= queue.Peek())
                {
                    int foodToRemove = queue.Dequeue();
                    foodQuantity -= foodToRemove;
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
            else 
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
