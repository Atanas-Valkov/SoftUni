using System.Text;
using System.Threading.Channels;

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
                sb.Append((char)(input[i] + 3));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}