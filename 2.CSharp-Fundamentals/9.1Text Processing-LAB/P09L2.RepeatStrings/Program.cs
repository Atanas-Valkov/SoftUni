using System.Text;

namespace P09L2.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ");

            string result =  "";
            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {

                    result += word;
                }
                
            }

            Console.WriteLine(result);



        }
    }
}