namespace P07L5.Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = " ";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentInfo = input.Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                Student student  = students.FirstOrDefault(x => x.firstName == firstName && x.lastName == lastName);
                
                if (student == null)
                {
                    student = new Student(age, firstName, homeTown, lastName);
                    students.Add(student);
                }
                else
                {
                    student.age = age;
                    student.homeTown = homeTown;
                }   
            }

            string givenTown = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.homeTown == givenTown)
                {
                    Console.WriteLine($"{student.firstName} {student.lastName} is {student.age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public Student(int age, string firstName, string homeTown, string lastName)
        {
            this.age = age;
            this.firstName = firstName;
            this.homeTown = homeTown;
            this.lastName = lastName;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string homeTown { get; set; }
    }
}