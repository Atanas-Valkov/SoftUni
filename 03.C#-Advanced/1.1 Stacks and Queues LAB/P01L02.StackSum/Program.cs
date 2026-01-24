namespace P01L02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> input = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            string command = string.Empty;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                string[] arguments = command.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operations = arguments[0];
                int argument2 = int.Parse(arguments[1]);

                if (operations == "add")
                {
                    input.Push(argument2);
                    input.Push(int.Parse(arguments[2]));
                }
                else if (operations == "remove" && input.Count >= argument2)
                {
                    while (argument2 > 0)
                    {
                        input.Pop();
                        argument2--;
                    }
                }
            }

            Console.WriteLine($"Sum: {input.Sum()}");
        }
    }
}
