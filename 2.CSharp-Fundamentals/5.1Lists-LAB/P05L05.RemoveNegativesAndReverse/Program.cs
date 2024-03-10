namespace P05L05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> newList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber > 0)
                {
                    newList.Add(currentNumber);
                }
            }

            if (newList.Count == 0) {
                    Console.WriteLine($"empty");
            }
            newList.Reverse();

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}