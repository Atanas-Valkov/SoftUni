namespace P3E03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var each in elements)
                {
                    uniqueElements.Add(each);
                }
            }

            Console.WriteLine(string.Join(" ",uniqueElements));
        }
    }
}
