namespace P3E05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!countSymbols.ContainsKey(input[i]))
                {
                    countSymbols.Add(input[i], 0);
                }

                countSymbols[input[i]]++;
            }

            foreach (var kvp in countSymbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}