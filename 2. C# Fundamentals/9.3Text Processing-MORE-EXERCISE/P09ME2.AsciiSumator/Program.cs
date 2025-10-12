using System.Threading.Channels;

namespace P09ME2.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           char firstChar= char.Parse(Console.ReadLine());
           char secondChar= char.Parse(Console.ReadLine());
           
           string randomChars = Console.ReadLine();

           int biggerChar = Math.Max(firstChar, secondChar);
           int smallerChar = Math.Min(firstChar, secondChar);
           int sum = 0;

           for (int i = 0; i < randomChars.Length; i++)
           {
               char  current = randomChars[i];
               if (current < biggerChar && current > smallerChar)
               {
                   sum += randomChars[i];
               }
           }


           Console.WriteLine(sum);
        }
    }
}
