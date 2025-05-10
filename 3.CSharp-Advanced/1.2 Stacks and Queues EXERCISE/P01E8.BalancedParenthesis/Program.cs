namespace P01E8.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<char> stack = new Stack<char>();

            string input = Console.ReadLine();
            bool isBalanced = true;
            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                    continue;
                }

                stack.TryPeek(out char resu);
                bool tryPeek = stack.TryPeek(out char poppedChar);

                if (tryPeek && ((poppedChar == '(' && ch == ')')
                                || (poppedChar == '[' && ch == ']')
                                || (poppedChar == '{' && ch == '}')))
                {
                    stack.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
