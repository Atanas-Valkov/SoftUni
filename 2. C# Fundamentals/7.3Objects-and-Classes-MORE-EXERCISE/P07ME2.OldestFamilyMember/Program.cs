using System.Xml.Linq;

namespace P07ME2.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMembers = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < numberOfMembers; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person member = new Person(age, name);
                family.AddMember(member);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }   
    }

    public class Family
    {
        private List<Person> listOfPeople = new List<Person>();

        public void AddMember(Person member)
        {
            listOfPeople.Add(member);
        }
        public Person GetOldestMember()
        {
            return listOfPeople.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }

    public class Person
    {
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
