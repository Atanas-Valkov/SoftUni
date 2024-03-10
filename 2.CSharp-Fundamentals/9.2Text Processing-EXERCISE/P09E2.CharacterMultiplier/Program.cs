using System.Diagnostics.CodeAnalysis;

namespace P09E2.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();



            Console.WriteLine(sum(input[0], input[1]));
        }

        private static decimal sum(string first, string second)
        {
            int sum = 0;
            int length = Math.Max(first.Length, second.Length);

            for (int i = 0; i < length; i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    sum += first[i] * second[i];
                }
                else if (i < first.Length)
                {
                    sum += first[i];
                }
                else if (i < second.Length)
                {
                    sum += second[i];
                }

            }

            return sum;
        }


    }
}