namespace _01.WildSurvival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bees = new Queue<int>(Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> beeEaters = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            int remaining = 0;

            while (bees.Any() && beeEaters.Any())
            {
                int currentBeesGroup = bees.Dequeue();
                int currentBeeEatersGroup = beeEaters.Pop();

                currentBeeEatersGroup += remaining;
                remaining = 0;

                if (currentBeesGroup > currentBeeEatersGroup * 7)
                {
                    int survivedBees = currentBeesGroup - currentBeeEatersGroup * 7;
                    bees.Enqueue(survivedBees);
                }
                else if (currentBeesGroup < currentBeeEatersGroup * 7)
                {
                    int beeEatersReturn = (int)Math.Ceiling((double)(currentBeeEatersGroup * 7 - currentBeesGroup) / 7);

                    if (beeEaters.Any())
                    {
                        beeEaters.Push(beeEaters.Pop() + beeEatersReturn);
                    }
                    else
                    {
                        beeEaters.Push(beeEatersReturn);
                    }
                }
            }

            Console.WriteLine($"The final battle is over!");
            if (bees.Any())
            {
                Console.WriteLine($"Bee groups left: {string.Join(", ", bees)}");
            }
            else if (beeEaters.Any())
            {
                Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
            }
            else
            {
                Console.WriteLine($"But no one made it out alive!");
            }
        }
    }
}