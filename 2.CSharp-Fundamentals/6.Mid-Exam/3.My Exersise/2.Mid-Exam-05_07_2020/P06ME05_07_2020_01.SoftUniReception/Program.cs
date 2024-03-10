namespace P06ME05_07_2020_01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int allStudents = int.Parse(Console.ReadLine());
            int restCounter = 0;
            int totalStudentsPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int hoursCount = 0;

            if (allStudents % totalStudentsPerHour == 0)
            {
                hoursCount = allStudents / totalStudentsPerHour;
            }
            else
            {
                hoursCount = allStudents / totalStudentsPerHour + 1;
            }

            if (hoursCount > 3 && hoursCount % 3 == 0)
            {
                hoursCount += hoursCount / 3 - 1;
            }
            else if (hoursCount > 3)
            {
                hoursCount += hoursCount / 3;
            }

            Console.WriteLine($"Time needed: {hoursCount}h.");
        }
    }
}