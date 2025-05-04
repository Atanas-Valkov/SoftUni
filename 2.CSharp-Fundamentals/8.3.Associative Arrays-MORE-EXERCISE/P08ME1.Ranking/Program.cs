namespace P08ME1.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> namePoints = new Dictionary<string, Dictionary<string, int>>();

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "end of contests")
            {
                string[] command = commandLine.Split(" -> ");
                string contest = command[0];
                string password = command[1];

                Data data = new Data(contest, password);

                if (!contestPasswords.ContainsKey(contest))
                {
                    contestPasswords.Add(contest, password);
                }
            }

            while ((commandLine = Console.ReadLine()) != "end of submissions")
            {
                string[] command = commandLine.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = command[0];
                string password = command[1];
                string name = command[2];
                int points = int.Parse(command[3]);

                if (contestPasswords.ContainsKey(contest) && contestPasswords.ContainsValue(password))
                {
                    People people = new People(name, points);
                    if (!namePoints.ContainsKey(name))
                    {
                        namePoints.Add(name, new Dictionary<string, int>());
                        namePoints[name].Add(contest, points);
                    }
                    else
                    {
                        if (namePoints[name].ContainsKey(contest))
                        {
                            if (namePoints[name][contest] < points)
                            {
                                namePoints[name][contest] = points;
                            }
                        }
                        else
                        {
                            namePoints[name].Add(contest, points);
                        }
                    }
                }
            }

            var totalPoints = namePoints
                .OrderByDescending(x => x.Value.Values.Sum())
                 .FirstOrDefault();
            string bestCandidate = totalPoints.Key;
            int totalPointsInt = totalPoints.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {totalPoints.Key} with total {totalPointsInt} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in namePoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }

    public class Data
    {
        public Data(string contest, string type)
        {
            Contest = contest;
            Type = type;
        }

        public string Contest { get; set; }
        public string Type { get; set; }
    }

    public class People
    {
        public People(string name, double points)
        {
            Name = name;
            Points = points;
        }

        public string Name { get; set; }
        public double Points { get; set; }
    }
}