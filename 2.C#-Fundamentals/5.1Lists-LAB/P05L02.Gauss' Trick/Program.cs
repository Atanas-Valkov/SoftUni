namespace P05L02.Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            List<double> result = new List<double>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                double sum = numbers[i] + numbers[numbers.Count - 1 - i];
                result.Add(sum);
            }
            if (numbers.Count % 2 != 0)
            {
                int half = numbers.Count / 2;
                result.Add(numbers[half]);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}