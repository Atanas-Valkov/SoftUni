
using System.Net;

namespace P01E7.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<(int, int)> petrolPumpsQueue = new Queue<(int, int)>();

            for (int i = 0; i < petrolPumps; i++)
            {
                int[] commandInfo = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int liters = commandInfo[0];
                int distanceToNextPump = commandInfo[1];

                petrolPumpsQueue.Enqueue((liters, distanceToNextPump));
            }

            int startIndex = 0; 

            while (true) 
            {
                int totalLiters = 0;
                foreach (var item in petrolPumpsQueue)
                {
                    totalLiters += item.Item1;
                    int distanceToNextPump = item.Item2;
                    totalLiters -= distanceToNextPump;
                    if (totalLiters < 0)
                    {
                        break;
                    }
                }

                if (totalLiters < 0)
                {
                    startIndex++;
                    petrolPumpsQueue.Enqueue(petrolPumpsQueue.Dequeue());
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
