using System.Text.RegularExpressions;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace P10L3.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<date>\d{2})(?<separator>\.|\-|\/)(?<month>[A-Z][a-z]+)(\k<separator>)(?<year>\d{4})\b";

            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match m in match)
            {
                Console.WriteLine($"Day: {m.Groups["date"].Value}, Month: {m.Groups["month"].Value}, Year: {m.Groups["year"].Value}");
            }
        }
    }
}