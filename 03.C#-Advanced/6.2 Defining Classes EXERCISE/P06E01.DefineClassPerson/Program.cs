using System.Runtime.CompilerServices;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] person = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                person[i] = new Person(name, age);
            }

            foreach (Person pr in person.Where(a => a.Age>30).OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{pr.Name} - {pr.Age}");
            }
        }
    }
}
