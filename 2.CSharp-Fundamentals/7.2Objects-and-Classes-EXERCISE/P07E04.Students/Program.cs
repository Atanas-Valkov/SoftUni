namespace P07E04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int number  = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();



           for (int i = 0; i < number; i++)
           {
               string[] studentInfo = Console.ReadLine().Split();

               string firstName = studentInfo[0];
               string lastName = studentInfo[1];
               double grade = double.Parse(studentInfo[2]);

               Student student = new Student(firstName, lastName, grade);

                students.Add(student);

           }

           List<Student> filtered = students.OrderByDescending(x => x.Grade).ToList();

           foreach (Student student in filtered)
           {
                Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:f2}");

           }
           
        }
    }


    public class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public double Grade { get; set; }

    }
}