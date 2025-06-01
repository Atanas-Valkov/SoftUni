using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

namespace P3E07.TheV_Logger_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, string>> vloggers =
                new SortedDictionary<string, Dictionary<string, string>>();
            string commandInfo;
            while ((commandInfo = Console.ReadLine()) != "Statistics")
            {
                string[] arguments = commandInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string followerName = arguments[0];
                string command = arguments[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(followerName))
                    {
                        vloggers.Add(followerName, new Dictionary<string, string>());
                    }
                }
                else if (command == "followed")
                {
                    string followedName = arguments[2];
                    if (!vloggers.ContainsKey(followerName) || !vloggers.ContainsKey(followedName))
                    {
                        continue;
                    }

                    if (followerName == followedName)
                    {
                        continue;
                    }

                    if (!vloggers[followedName].ContainsKey(followerName) && followedName != followerName)
                    {
                        vloggers[followedName].Add(followerName, string.Empty);
                    }
                }
            }

            bool isFirstVlogger = true;
            int counter = 0;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");
            foreach (var kvp in vloggers.OrderByDescending(x => x.Value.Count)
                         .ThenBy(v => vloggers.Values.Count(d => d.ContainsKey(v.Key)))
                         .ThenBy(v => v.Key))

            {
                int followersCount = kvp.Value.Count;
                int followingCount = vloggers.Values.Sum(x => x.ContainsKey(kvp.Key) ? 1 : 0);

                Console.WriteLine($"{++counter}. {kvp.Key} : {followersCount} followers, {followingCount} following");

                if (isFirstVlogger)
                {
                    foreach (var follower in kvp.Value.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"*  {follower.Key}");
                        isFirstVlogger = false;
                    }
                }
            }
        }
    }
}
