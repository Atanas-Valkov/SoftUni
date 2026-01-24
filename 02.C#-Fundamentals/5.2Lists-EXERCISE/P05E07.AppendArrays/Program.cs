/*
1 2 3 |4 5 6 | 7 8

7 | 4 5|1 0| 2 5 |3

1| 4 5 6 7 | 8 9
 */

using System.Net;

namespace P05E07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<int> result = new List<int>();
            foreach (var item in input)
            {
                string[] numbers = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var number in numbers)
                {
                    result.Add(int.Parse(number));
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}