/*
George 524244 20
Peter 78911 15
Stephen 524244 10
End

Lewis 123456 20
James 78911 15
Robert 523444 11
Jennifer 345244 13
Mary 52424678 22
Patricia 567343 54
End
 */
using System;
using System.Collections.Generic;
namespace P07E01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string id = input[1];
                int age = int.Parse(input[2]);

                Person person = new Person(age, id, name);
                Person findID = persons.Find(x => x.ID == id);
                if (findID == null)
                {
                    persons.Add(person);
                }
                else
                {
                    findID.Name = name;
                    findID.Age = age;
                }
            }

            foreach (Person person in persons.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public Person(int age, string id, string name)
        {
            Age = age;
            ID = id;
            Name = name;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
