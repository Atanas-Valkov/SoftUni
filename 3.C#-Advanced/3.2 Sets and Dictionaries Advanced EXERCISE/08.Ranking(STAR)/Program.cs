using System.Runtime.ExceptionServices;
using System.Xml.Linq;

namespace _08.Ranking_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userScore = new Dictionary<string, Dictionary<string, int>>();
            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] inputLine = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputLine[0];
                string password = inputLine[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] arguments = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = arguments[0];
                string password = arguments[1];
                string name = arguments[2];
                int points = int.Parse(arguments[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!userScore.ContainsKey(name))
                    {
                        userScore.Add(name, new Dictionary<string, int>());
                    }

                    if (!userScore[name].ContainsKey(contest))
                    {
                        userScore[name][contest] = points;
                    }
                    else
                    {
                        if (points > userScore[name][contest])
                        {
                            userScore[name][contest] = points;
                        }
                    }
                }
            }

            var bestCandidate = userScore
                .Select(x => new { Name = x.Key, TotalPoints = x.Value.Values.Sum() })
                .OrderByDescending(x => x.TotalPoints)
                .First();

            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.TotalPoints} points.");
            Console.WriteLine($"Ranking:");
            foreach (var kvp in userScore.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var contestPoints in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contestPoints.Key} -> {contestPoints.Value}");

                }
            }
        }
    }
}