namespace P09E1.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] words = input.Split(", ");

            foreach (var word in words)
            {
                if (word.Length<3 || word.Length>16)
                {
                    continue;
                }

                bool wordToPrint = word.All(x => char.IsLetterOrDigit(x) || x == '-' || x == '_');

                if (wordToPrint)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}