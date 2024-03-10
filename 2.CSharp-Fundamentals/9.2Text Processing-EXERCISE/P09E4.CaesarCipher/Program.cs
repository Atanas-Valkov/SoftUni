using System.Text;

namespace P09E4.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

             StringBuilder sb = new StringBuilder();    
            for (int i = 0; i < input.Length; i++)
            {
                char originalChar = input[i];
                sb.Append((char)(originalChar+3));
            }
            Console.WriteLine(sb);
        }
    }
}