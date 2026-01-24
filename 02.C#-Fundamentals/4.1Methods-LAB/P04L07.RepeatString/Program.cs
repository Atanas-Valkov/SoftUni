using System.Net;
using System.Runtime.InteropServices;

namespace P04L07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parameterString = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            RepeatString(parameterString, n);
            Console.WriteLine(RepeatString(parameterString,n));
        }

        private static string RepeatString(string parameterString, int n)
        {
            string output = "";
            for (int i = 0; i < n; i++)
            {
                output += parameterString;
            }

            return output;
        }
    }
}