using System;

namespace P02L10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());

            if (char.IsLower(n))
            {
                Console.WriteLine(@"lower-case");
            }
            else 
            { 
            
                Console.WriteLine(@"upper-case");

            }

        }
    }
}
