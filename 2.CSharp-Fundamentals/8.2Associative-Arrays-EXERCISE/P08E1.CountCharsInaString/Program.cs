namespace P08E1.CountCharsInaString
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                char charr = input[i];
                if (charr == ' ' )
                {
                    continue;
                }

                if (!keyValuePairs.ContainsKey(charr))
                {
                    keyValuePairs.Add(charr, 0);

                }

                keyValuePairs[charr]++;
            }

            foreach (var kvp in keyValuePairs)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }


        }

    }


}
