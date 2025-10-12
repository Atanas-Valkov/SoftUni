namespace P3L05.CitiesContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> organiser =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = inputLine[0];
                string country = inputLine[1];
                string city = inputLine[2];

                if (!organiser.ContainsKey(continent))
                {
                    organiser.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!organiser[continent].ContainsKey(country))
                {
                    organiser[continent].Add(country, new List<string>());
                }

                organiser[continent][country].Add(city);
            }

            foreach (var continent in organiser)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var kvp in continent.Value)
                {
                    Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
                }
            }
        }
    }
}