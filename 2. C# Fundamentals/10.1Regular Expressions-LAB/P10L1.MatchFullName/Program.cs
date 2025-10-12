using System.Text.RegularExpressions;

namespace P10L1.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b(?<firstName>[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+)\b";

            Regex regex = new Regex(pattern);


            foreach (Match names in regex.Matches(input))
            {
                Console.Write($"{names.Groups["firstName"].Value} {names.Groups["lastName"].Value} ");
            }

        }
    }
}