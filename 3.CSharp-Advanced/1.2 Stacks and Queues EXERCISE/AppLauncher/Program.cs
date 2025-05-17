namespace AppLauncher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(firstLine);
            Queue<int> bottles = new Queue<int>(secondLine);

            int wastedLittersOfWater = 0;
            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Peek();
                if (currentCup < currentBottle)
                {
                    wastedLittersOfWater = currentCup - currentBottle;
                    bottles.Dequeue();
                    cups.Pop();
                }
                else
                {
                    bottles.Dequeue();
                    currentCup += currentBottle;
                }
            }

            Console.WriteLine("add");
        }
    }
}
