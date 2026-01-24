using System.Linq.Expressions;

namespace P05E01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacityofEachWAgon = int.Parse(Console.ReadLine());
            string command = " ";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string addWagon = commandArgs[0];
                if (addWagon == "Add")
                {
                    Add(commandArgs, train);
                }
                else
                {
                    FitAllTheIncomingPassengers(addWagon, train, maxCapacityofEachWAgon);
                }
            }
            Console.WriteLine(string.Join(" ", train));
        }

        private static void Add(string[] commandArgs, List<int> train)
        {
            int number = int.Parse(commandArgs[1]);
            train.Add(number);
        }
        private static void FitAllTheIncomingPassengers(string addWagon, List<int> train, int maxCapacityofEachWAgon)
        {
            int passengers = int.Parse(addWagon);
            for (int i = 0; i < train.Count; i++)
            {
                if (train[i] + passengers <= maxCapacityofEachWAgon)
                {
                    train[i] += passengers;
                    return;
                }
            }
        }
    }
}