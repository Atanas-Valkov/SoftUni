namespace P05L01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    double sum = input[i] + input[i + 1];
                    input.RemoveAt(i);
                    input.RemoveAt(i);
                    input.Insert(i, sum);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}