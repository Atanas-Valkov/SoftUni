namespace P01E3.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int operation = command[0];

                if (operation == 1)
                {
                    int number = command[1];
                    stack.Push(number);
                }
                else if (operation == 2 && stack.Any())
                {
                    stack.Pop();
                }
                else if (operation == 3 && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (operation == 4 && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
