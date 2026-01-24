using System.Xml.Linq;

namespace P08E7.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string commandLine;
            while ((commandLine = Console.ReadLine()) != "End")
            {
                string[] command = commandLine.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = command[0];
                string employeeId = command[1];

                User user = new User(company, employeeId);

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                if (!companies[company].Contains(employeeId))
                {
                    companies[company].Add(employeeId);
                }
            }

            foreach (var item in companies)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var employeeId in item.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }

    public class User
    {
        public User(string company, string employeeId)
        {
            Company = company;
            EmployeeId = employeeId;
        }
        public string Company { get; set; }
        public string EmployeeId { get; set; }
    }
}