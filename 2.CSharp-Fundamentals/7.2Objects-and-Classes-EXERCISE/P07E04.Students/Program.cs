namespace P07E04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                string[] studentInfo = input.Split(" ");
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student student = new Student(firstName, grade, lastName);
                students.Add(student);

            }

            students = students.OrderByDescending(x => x.grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.firstName} {student.lastName}: {student.grade:F2}");
            }
        }
    }

    public class Student
    {
        public Student(string firstName, double grade, string lastName)
        {
            this.firstName = firstName;
            this.grade = grade;
            this.lastName = lastName;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public double grade { get; set; }
    }
}