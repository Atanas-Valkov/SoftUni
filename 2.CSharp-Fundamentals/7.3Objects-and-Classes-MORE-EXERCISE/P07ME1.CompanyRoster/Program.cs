/*
5
Steve 10
Christopher 15
John 35
Annie 4
John 35
Maria 34
 */

namespace P07ME1.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string department = input[2];

                Employee employee = new Employee(department, name, salary);
                employees.Add(employee);
            }

            var departmentWithHighestAvgSalary = employees
                .GroupBy(g => g.Department)
                .Select(x => new 
                {
                    Department = x.Key,
                    AverageSalary = x.Average(y => y.Salary),
                    Employees = x.ToList()

                })
                .OrderByDescending(x => x.AverageSalary)
                .First();
            Console.WriteLine($"Highest Average Salary: {departmentWithHighestAvgSalary.Department}");
            foreach (var employee in departmentWithHighestAvgSalary.Employees.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    public class Employee
    {
        public Employee(string department, string name, decimal salary)
        {
            Department = department;
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }


    }


}