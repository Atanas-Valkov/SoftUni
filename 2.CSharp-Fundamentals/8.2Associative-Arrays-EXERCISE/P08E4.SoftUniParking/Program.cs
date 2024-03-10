

namespace P08E4.SoftUniParking
{
    internal class Program
    {
        public class Customer
        {
            public Customer(string userName, string licensePlateNumber)
            {
                UserName = userName;
                LicensePlateNumber = licensePlateNumber;
            }

            public string UserName { get; set; }

            public string LicensePlateNumber { get; set; }

        }

        static void Main(string[] args)
        {
            Dictionary<string, string> kvp = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();

                string registerUnregister = command[0];
                string username = command[1];

                if (registerUnregister == "register")
                {
                    string licensePlateNumber = command[2];
                    Customer newCustomer = new Customer(username, licensePlateNumber);

                    if (!kvp.ContainsKey(newCustomer.UserName))
                    {
                        kvp.Add(newCustomer.UserName, newCustomer.LicensePlateNumber);
                        Console.WriteLine($"{newCustomer.UserName} registered {newCustomer.LicensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {newCustomer.LicensePlateNumber}");
                    }
                }
                else if (registerUnregister == "unregister")
                {
                    if (!kvp.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        kvp.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var print in kvp)
            {
                Console.WriteLine($"{print.Key} => {print.Value}");
            }

        }
    }
}