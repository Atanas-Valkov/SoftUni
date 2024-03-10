namespace P05L03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> lastList = new List<int>();

            int biggerList = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < biggerList; i++)
            {

                if (i < firstList.Count)
                {
                    lastList.Add(firstList[i]);;
                }

                if (i < secondList.Count)
                {
                    lastList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", lastList));
        }
    }
}



