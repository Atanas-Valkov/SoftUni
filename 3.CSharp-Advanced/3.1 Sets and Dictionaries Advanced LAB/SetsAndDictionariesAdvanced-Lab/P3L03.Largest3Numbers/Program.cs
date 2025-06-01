

namespace P3L03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> largestNumber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .OrderByDescending(x => x)
                .ToList()
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", largestNumber));
        }
    }
}
