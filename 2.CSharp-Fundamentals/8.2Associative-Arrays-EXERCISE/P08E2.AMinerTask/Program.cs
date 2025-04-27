/*
gold
155
silver
10
copper
17
gold
15
stop
 */

namespace P08E2.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                string quantity = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource,0);
                }
                resources[resource]+= int.Parse(quantity);
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}