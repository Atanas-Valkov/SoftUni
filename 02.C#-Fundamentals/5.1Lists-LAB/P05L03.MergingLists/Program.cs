namespace P05L03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> firstList = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToList();

            List<double> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> mergedList = new List<double>();

            if (firstList.Count > secondList.Count)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (i < secondList.Count)
                    {
                        mergedList.Add(firstList[i]);
                        mergedList.Add(secondList[i]);
                    }
                    else
                    {
                        mergedList.Add(firstList[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < secondList.Count; i++)
                {
                    if (i < firstList.Count)
                    {
                        mergedList.Add(firstList[i]);
                        mergedList.Add(secondList[i]);
                    }
                    else
                    {
                        mergedList.Add(secondList[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));

        }
    }
}



