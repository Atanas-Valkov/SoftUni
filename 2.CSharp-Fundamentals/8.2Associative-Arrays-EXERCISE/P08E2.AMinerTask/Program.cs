namespace P08E2.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kvp = new Dictionary<string, int>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
              
                int quantity = int.Parse(Console.ReadLine());

                if (!kvp.ContainsKey(resource))
                {
                    kvp.Add(resource, quantity);
                }
                else
                {
                 kvp[resource] += quantity;
                        
                }

            }

            foreach (var asd in kvp)
            {
                Console.WriteLine($"{asd.Key} -> {asd.Value}");
            }
        }
    }
}