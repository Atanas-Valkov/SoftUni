using System.Net;
using System.Runtime.InteropServices;

namespace P04L07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeated = int.Parse(Console.ReadLine());
            
            Print(input, repeated);
        }

        static string Print(string input, int repeated)
        {
            for (int i = 1; i <= repeated; i++)
            {
                Console.Write(input);
                
            }

            return input;
        }
    }
}