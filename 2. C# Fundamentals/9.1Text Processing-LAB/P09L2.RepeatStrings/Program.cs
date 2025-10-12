using System.Text;

namespace P09L2.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine ().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            foreach (var words in input)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    result.Append(words);
                }
            }

            Console.WriteLine(result);
        }
    }
}