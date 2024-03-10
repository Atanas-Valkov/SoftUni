namespace P09L4.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            string word1 = words[0];
            string word2 = words[1];

            foreach (var word in words)
            {
               text = text.Replace(word, new string('*',word.Length));

            }

            Console.WriteLine(text);
        }
    }
}