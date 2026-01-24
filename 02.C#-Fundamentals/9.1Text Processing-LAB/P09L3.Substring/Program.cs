namespace P09L3.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string text = Console.ReadLine();
            string result = string.Empty;
            while (text.Contains(wordToRemove))
            {
                 text = text.Replace(wordToRemove, string.Empty);
            }

            Console.WriteLine(text);
        }
    }
}