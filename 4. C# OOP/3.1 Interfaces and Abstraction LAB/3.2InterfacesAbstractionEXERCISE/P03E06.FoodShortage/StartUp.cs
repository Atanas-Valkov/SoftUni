using P03E05.BirthdayCelebrations;

namespace P03E06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> allBuyer = new List<IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];
                int age = int.Parse(parts[1]);
                if (parts.Length == 4)
                {
                    string id = parts[2];
                    string birthdate = parts[3];
                    int food = 0;
                    IBuyer citizen = new Citizen(name, age, id, birthdate, food);
                    allBuyer.Add(citizen);
                }
                else if (parts.Length == 3)
                {
                    string group = parts[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    allBuyer.Add(rebel);
                }
            }

            IBuyer buyer = null;
            var byName = allBuyer.ToDictionary(b => b.Name);
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;
                buyer = allBuyer.FirstOrDefault(b => b.Name == name);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(byName.Values.Sum(b => b.Food));

        }
    }

}
