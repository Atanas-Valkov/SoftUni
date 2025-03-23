
using System.Runtime.ExceptionServices;

namespace P04E02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine().ToLower();

           VowelsCount(input);
           Console.WriteLine(VowelsCount(input));
        }

        private static int VowelsCount(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    count++;
                } 
            }
            return count;
        }
    }
}