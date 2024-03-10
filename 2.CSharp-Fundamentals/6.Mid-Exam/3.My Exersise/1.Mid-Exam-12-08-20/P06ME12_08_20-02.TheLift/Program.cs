namespace P06ME12_08_20_02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            List<int> liftList = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int freeSpotsInWagon = 0;

            for (int i = 0; i < liftList.Count; i++)
            {
                freeSpotsInWagon = 4 - liftList[i];

                if (peopleWaiting <= 0)
                {
                    break;
                }
                int lowestValue = Math.Min(peopleWaiting, freeSpotsInWagon);
                liftList[i] += lowestValue;
                peopleWaiting -= lowestValue;

            }

            if (peopleWaiting <= 0 && liftList.Any(x => x < 4))
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", liftList));
            }
            else if (liftList.All(x => x == 4) && peopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", liftList));
            }

        }
    }
}