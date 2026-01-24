namespace P08L2.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string[] input = Console.ReadLine().ToLower().Split(' ');

            Dictionary<string,int> oddOccurrences = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!oddOccurrences.ContainsKey(input[i]))
                {
                    oddOccurrences.Add(input[i], 0);
                }
                oddOccurrences[input[i]]++;
            }

            oddOccurrences
                .Where(x => x.Value % 2 != 0)
                .ToList()
                .ForEach(x => Console.Write($"{x.Key} "));
        }
    }
}