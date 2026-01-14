namespace P01E5.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int copyOfRackCapacity = rackCapacity;
            int racksCount = 1;
            Stack<int> box = new Stack<int>(clothes);

            while (box.Any())
            {
                if (copyOfRackCapacity - box.Peek() >= 0)
                {
                    copyOfRackCapacity -= box.Peek();
                    box.Pop();
                }
                else
                {
                    copyOfRackCapacity = rackCapacity;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
