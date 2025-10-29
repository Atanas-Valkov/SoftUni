using System.Data;

namespace P03E04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<ICheckable> allIds = new List<ICheckable>();

            while ((command = Console.ReadLine()) != "End")
            {
                ICheckable checkable = null;
                string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    checkable  = new Citizen(name, age, id);
                }
                else if(parts.Length == 2)
                {
                    string model = parts[0];
                    string id = parts[1]; 
                    checkable = new Robots(model, id);
                }
                allIds.Add(checkable);
            }
            string fakeId = Console.ReadLine(); 

            foreach (var member in allIds)
            {
                if (member.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(member.Id);
                }
            }
        }
    }
}
