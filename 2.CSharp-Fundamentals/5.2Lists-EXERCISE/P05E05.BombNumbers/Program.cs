namespace P05E05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bombNumber = bombAndPower[0];
            int power = bombAndPower[1];

            BombDetonate(listNumbers, bombNumber, power);

            PrintOutput(listNumbers);
        }

        private static void PrintOutput(List<int> listNumbers)
        {
            int sum = 0;
            foreach (int num in listNumbers)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }

        private static void BombDetonate(List<int> listNumbers, int bombNumber, int power)
        {
            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (listNumbers[i] == bombNumber)
                {
                    int bomobPosition = listNumbers[i];

                    int from = Math.Max(0, i - power);
                    int to = Math.Min(listNumbers.Count - 1, i + power);

                    for (int j = from; j <= to; j++)
                    {
                        listNumbers[j] = 0;
                    }
                }
            }
        }
    }
}