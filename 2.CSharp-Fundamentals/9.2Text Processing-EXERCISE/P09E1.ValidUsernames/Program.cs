using System.Security.Cryptography.X509Certificates;

namespace P09E1.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var str in input)
            {
                if (str.Length>=3 && str.Length<=16)
                {
                    if (str.All(x => char.IsLetterOrDigit(x) || x == '-' || x == '_'))
                    {
                        Console.WriteLine(str);    
                    }
                }
            }
        }
    }
}