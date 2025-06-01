namespace P3L01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countSameValues = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!countSameValues.ContainsKey(input[i]))
                {
                    countSameValues[input[i]] = 0;
                }

                countSameValues[input[i]]++;
            }

            foreach (var kvp in countSameValues)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
