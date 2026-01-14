namespace _1.RapidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> weightPackages = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> loadingCapacities = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalDeliveredWeight = 0;

            while (weightPackages.Any() && loadingCapacities.Any())
            {
                int currentCourier = loadingCapacities.Dequeue();
                int currentPackages = weightPackages.Pop();


                if (currentCourier >= currentPackages)
                {
                    totalDeliveredWeight += currentPackages;
                    currentCourier -= currentPackages * 2;
                    if (currentCourier > 0)
                    {
                        loadingCapacities.Enqueue(currentCourier);
                    }
                }
                else if (currentCourier < currentPackages)
                {
                    int remainingWeight = currentPackages - currentCourier;
                    weightPackages.Push(remainingWeight);
                    totalDeliveredWeight += currentPackages - remainingWeight;
                }
            }

            Console.WriteLine($"Total weight: {totalDeliveredWeight} kg");

            if (!weightPackages.Any() && !loadingCapacities.Any())
            {
                Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
            }

            if (weightPackages.Any() && !loadingCapacities.Any())
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", weightPackages)}");
            }

            if (!weightPackages.Any() && loadingCapacities.Any())
            {
                Console.WriteLine($"Couriers are still on duty: {string.Join(", ", loadingCapacities)} but there are no more packages to deliver.");
            }
        }
    }
}
