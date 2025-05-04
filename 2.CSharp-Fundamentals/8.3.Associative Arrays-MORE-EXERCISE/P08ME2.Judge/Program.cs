using System.Net.WebSockets;

namespace P08ME2.Judge
{
    internal class Program
    {                ////////////////////////////////// 83/100 ?!?!?
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> contestData = new Dictionary<string, Dictionary<string, double>>();
            string commandLine;
            while ((commandLine = Console.ReadLine()) != "no more time")

            {
                string[] arguments = commandLine.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string userName = arguments[0];
                string contest = arguments[1];
                double points = double.Parse(arguments[2]);


                if (!contestData.ContainsKey(userName))
                {
                    contestData.Add(userName, new Dictionary<string, double>());
                }

                if (!contestData[userName].ContainsKey(contest))
                {
                    contestData[userName][contest] = points;
                }
                else if(contestData[userName][contest] < points)
                {
                    contestData[userName][contest] = points;
                }
            }

            Dictionary<string, Dictionary<string, double>> contestResult = new Dictionary<string, Dictionary<string, double>>();

            foreach (var userEntry in contestData)
            {
                string user = userEntry.Key;
                foreach (var contestEntry in userEntry.Value)
                {
                    string contest = contestEntry.Key;
                    double points = contestEntry.Value;

                    if (!contestResult.ContainsKey(contest))
                    {
                        contestResult[contest] = new Dictionary<string, double>();
                    }

                    if (!contestResult[contest].ContainsKey(user))
                    {
                        contestResult[contest][user] = points;
                    }
                    else
                    {
                        if (contestResult[contest][user] < points)
                        {
                            contestResult[contest][user] = points;
                        }
                    }
                }
            }

            foreach (var kvp in contestResult)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count()} participants");

                int counter = 1;
                foreach (var user in kvp.Value
                             .OrderByDescending(x => x.Value)
                             .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter++}. {user.Key} <::> {user.Value}");

                }
            }

            Console.WriteLine($"Individual standings:");
            var totalPoints = contestData
                .ToDictionary(x => x.Key, x => x.Value.Values.Sum());
            int counter2 = 1;
            foreach (var ind in totalPoints
                         .OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter2++}. {ind.Key} -> {ind.Value}");
            }
        }
    }
}