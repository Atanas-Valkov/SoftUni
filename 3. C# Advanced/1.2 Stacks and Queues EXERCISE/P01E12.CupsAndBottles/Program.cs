using System.Diagnostics.Metrics;

namespace P01E12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] firstLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(firstLine);
            Stack<int> bottles = new Stack<int>(secondLine);

            int wastedWater = 0;
            while (cups.Any() && bottles.Any())
            {
                int cup = cups.Peek();

                int bottle = bottles.Peek();

                if (cup > bottle)
                {
                    while (cup > 0)
                    {

                        cup -= bottles.Pop();
                        if (cup < 0)
                        {
                            wastedWater += Math.Abs(cup);
                        }
                    }

                    cups.Dequeue();
                }
                else if (cup <= bottle)
                {
                    wastedWater += bottle - cup;
                    bottles.Pop();
                    cups.Dequeue();
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
