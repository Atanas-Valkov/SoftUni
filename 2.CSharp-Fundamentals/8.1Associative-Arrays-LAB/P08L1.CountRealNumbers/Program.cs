namespace P08L1.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input= Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();


            SortedDictionary<double,int> kvp = new SortedDictionary<double,int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!kvp.ContainsKey(input[i]))
                {
                    kvp[input[i]] = 1;
                }
                else
                {
                    kvp[input[i]] ++;
                }

            }

            foreach (var keyValuePair in kvp)
            {
              Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value} ");
            }
        }
    }
}