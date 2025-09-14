namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] resources = new[] { "Iron", "Titanium", "Aluminium", "Chlorine", "Sulfur" };
            int[] amountInKg = new[] { 80, 90, 100, 60, 70 };

            Stack<int> dailySolarEnergy = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> dailyDistances = new Queue<int>(Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<string> collectedResources = new Queue<string>();
            int resourcesCount = 5;
            int nextResources = 0;
            int sum = 0;
            while (dailySolarEnergy.Any() && dailyDistances.Any() && nextResources < resources.Length)
            {
                sum = dailySolarEnergy.Pop() + dailyDistances.Dequeue();

                if (sum >= amountInKg[nextResources])
                {
                    collectedResources.Enqueue(resources[nextResources]);
                    nextResources++;
                }
            }

            if (nextResources == resourcesCount)
            {
                Console.WriteLine($"Mission complete! All minerals have been collected.");
            }
            else
            {
                Console.WriteLine($"Mission not completed! Awaiting further instructions from Earth.");
            }

            if (collectedResources.Any())
            {
                Console.WriteLine($"Collected resources:");
            }

            foreach (var resource in collectedResources)
            {
                Console.WriteLine($"{resource}");
            }
        }
    }
}
