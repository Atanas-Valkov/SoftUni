namespace P01L7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Queue<string> hotPotato = new Queue<string>(input);

            while (hotPotato.Count > 1)
            {
                for (int i = 0; i < n-1; i++)
                {
                    hotPotato.Enqueue(hotPotato.Dequeue());
                }

                string removed = hotPotato.Dequeue();
                Console.WriteLine($"Removed {removed}");
            }

            foreach (var kid in hotPotato)
            {
                Console.WriteLine($"Last is {kid}");
            }
        }
    }
}
