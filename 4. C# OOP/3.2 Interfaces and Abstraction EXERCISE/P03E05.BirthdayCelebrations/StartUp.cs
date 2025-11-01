using System.Reflection.PortableExecutable;

namespace P03E05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<ICheckable> allBirthdates = new List<ICheckable>();

            while ((command = Console.ReadLine()) != "End")
            {
                ICheckable checkable = null;
                string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];
                    checkable = new Citizen(name, age, id, birthdate);
                    allBirthdates.Add(checkable);
                }
                else if (parts[0] == "Pet")
                {
                    string model = parts[1];
                    string id = parts[2];
                    checkable = new Pet(model, id);
                    allBirthdates.Add(checkable);
                }
            }
            string specificYear = Console.ReadLine();
            foreach (var member in allBirthdates)
            {
                if (member.Birthdate.EndsWith(specificYear))
                {
                    Console.WriteLine(member.Birthdate);
                }
            }
        }
    }
}
