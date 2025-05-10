using System.Linq.Expressions;

namespace P01L4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                else if(input[i] == ')')
                {
                    int startBracket = brackets.Pop();
                    int endBracket = i;

                    string expression = input.Substring(startBracket, endBracket - startBracket + 1);

                    Console.WriteLine(expression);
                }
            }
        }
    }
}
