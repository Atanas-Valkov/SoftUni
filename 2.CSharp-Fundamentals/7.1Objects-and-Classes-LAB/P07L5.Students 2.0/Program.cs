namespace P07L5.Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            string command = " ";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] infoForStudent = command.Split();

                string firstName = infoForStudent[0];
                string lastName = infoForStudent[1];
                int age = int.Parse(infoForStudent[2]);
                string homeTown = infoForStudent[3];


                Student student = list.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);


                if (student == null)
                {
                    list.Add(new Student(firstName, lastName, age, homeTown));
                }
                else
                {
                    student.HomeTown = homeTown;
                    student.Age = age;
                }
            }
            string town = Console.ReadLine();
            foreach (Student student in list)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
    
}