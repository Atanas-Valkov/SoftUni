namespace P3E02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int first = nm[0];
            int second = nm[1];

            for (int i = 0; i < first + second; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i <= first -1 )
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            foreach (var num in firstSet)
            {
                foreach (var num1 in secondSet)
                {
                    if (num == num1)
                    {
                        Console.Write(num + " ");
                    }
                }
            }
        }
    }
}
