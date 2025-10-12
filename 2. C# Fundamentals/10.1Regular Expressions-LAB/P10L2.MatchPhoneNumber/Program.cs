using System.Text.RegularExpressions;

namespace P10L2.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(?<separator>[ -])[2](\k<separator>)\d{3}(\k<separator>)\d{4}\b";

            MatchCollection match = Regex.Matches(input, pattern);

                Console.WriteLine(string.Join(", ", match));
            
        }
    }
}