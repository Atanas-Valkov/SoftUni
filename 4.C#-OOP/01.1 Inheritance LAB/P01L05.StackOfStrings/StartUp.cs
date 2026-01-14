namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            
            Stack<string> toAdd = new Stack<string>();
            toAdd.Push("4");
            toAdd.Push("5");
            stack.AddRange(toAdd);
        }
    }
}
