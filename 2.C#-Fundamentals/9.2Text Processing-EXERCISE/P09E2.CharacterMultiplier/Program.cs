using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Threading.Channels;

namespace P09E2.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string first = input[0];
            string second = input[1];
            double sum = 0;
            CharacterMultiplier(first, second);
        }

        public static void CharacterMultiplier(string first, string second)
        {
            double result = 0;
            var biggerLength = Math.Max(first.Length, second.Length);
            var smallerLength = Math.Min(first.Length, second.Length );

            for (int i = 0; i < biggerLength; i++)
            {
                if (i < smallerLength)
                {
                   result += first[i] * second[i];
                }
                else if (first.Length > second.Length)
                {
                    result += first[i];
                }
                else if (first.Length < second.Length)
                {
                    result += second[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}