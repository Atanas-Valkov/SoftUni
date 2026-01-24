/*
1 2 2 4 2 2 2 9
4 2

1 4 4 2 8 9 1
9 3

1 7 7 1 2 3
7 1

1 1 2 1 1 1 2 1 1 1
2 1
 */

namespace P05E05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombDetails = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bomb = bombDetails[0];
            int power = bombDetails[1];
            Detonate(numbers, bomb, power);
            Console.WriteLine(numbers.Sum());
        }
        private static void Detonate(List<int> numbers, int bomb, int power)
        {
            while (numbers.Contains(bomb))
            {
                int bombIndex = numbers.IndexOf(bomb);
                int start = Math.Max(0, bombIndex - power);
                int count = Math.Min(numbers.Count - start, power * 2 + 1);
                numbers.RemoveRange(start, count);
            }
        }
    }
}