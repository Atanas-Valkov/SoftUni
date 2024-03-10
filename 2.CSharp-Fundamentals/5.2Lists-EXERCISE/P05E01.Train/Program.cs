namespace P05E01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());
            string passengers;

            while ((passengers = Console.ReadLine()) != "end")
            {
                string[] operation = passengers.Split();
                if (operation[0] == "end")
                {
                    break;
                }

                if (operation[0] == "Add")
                {
                    int index = int.Parse(operation[1]);
                    listWagons.Add(index);
                }
                else
                {
                    int incomingPassengers = int.Parse(operation[0]);

                    for (int i = 0; i < listWagons.Count; i++)
                    {
                        if (listWagons[i] + incomingPassengers <= maxCapacity || listWagons[i] <= 0)
                        {
                            listWagons[i] += incomingPassengers;
                            break;
                        }
                    }

                }

            }

            Console.WriteLine(string.Join(" ", listWagons));
        }
    }
}