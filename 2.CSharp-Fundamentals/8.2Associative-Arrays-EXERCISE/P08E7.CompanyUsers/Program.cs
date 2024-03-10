using System.Xml.Linq;

namespace P08E7.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> kvp = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" -> ");

                string companyName = inputArray[0];
                string employeeId = inputArray[1];

                if (!kvp.ContainsKey(companyName))
                {
                    kvp.Add(companyName, new List<string>());
                }

                if (!kvp[companyName].Contains(employeeId))
                {
                    kvp[companyName].Add(employeeId);
                }
            }

            foreach (var print in kvp)
            {
                Console.WriteLine($"{print.Key}");

                foreach (var print1 in print.Value)
                {
                    Console.WriteLine($"-- {print1}");
                }
            }

        }
    }
}