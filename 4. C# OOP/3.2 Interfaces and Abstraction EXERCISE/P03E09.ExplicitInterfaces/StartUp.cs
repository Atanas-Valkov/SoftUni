namespace P03E09.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                string country = parts[1];
                int age = int.Parse(parts[2]);
                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
