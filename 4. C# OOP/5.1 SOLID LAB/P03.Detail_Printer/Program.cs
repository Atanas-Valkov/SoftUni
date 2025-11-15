using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("John Doe");
            Manager manager = new Manager("Jane Smith", new string[] { "Document1", "Document2" });

            DetailsPrinter printer = new DetailsPrinter(new List<Employee> { employee, manager });
            printer.PrintDetails();
        }
    }
}
