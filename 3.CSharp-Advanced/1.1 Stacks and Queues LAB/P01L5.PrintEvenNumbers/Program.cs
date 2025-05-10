namespace P01L5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToList();

            input.ForEach(x => numbers.Enqueue(x));
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
