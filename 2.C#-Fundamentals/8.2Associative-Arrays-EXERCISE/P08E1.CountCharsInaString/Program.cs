using System.Threading.Channels;

namespace P08E1.CountCharsInaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine().Replace(" ","");

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (!charCount.ContainsKey(inputString[i]))
                {
                    charCount.Add(inputString[i], 0);
                }
                charCount[inputString[i]]++;
            }

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }   
        }
    }
}
