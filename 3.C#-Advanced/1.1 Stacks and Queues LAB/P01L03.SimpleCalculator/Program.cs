namespace P01L03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> input = new Stack<string>(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse());

            int sum = int.Parse(input.Pop());

            while (input.Count > 0)
            {
                string operation = input.Pop();
                if (operation == "-")
                {
                    sum -= int.Parse(input.Pop());
                }
                else if (operation == "+")
                {
                    sum += int.Parse(input.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}
