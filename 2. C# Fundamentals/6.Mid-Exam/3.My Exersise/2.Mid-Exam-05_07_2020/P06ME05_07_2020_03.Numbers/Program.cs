using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace P06ME05_07_2020_03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList(); 
            List<int> greaterList = new List<int>();
            
            double avrNum = 0;
            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
                avrNum = sum / numbers.Count;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (avrNum < numbers[i])
                {
                    greaterList.Add(numbers[i]);
                }
            }

            var result = greaterList.OrderByDescending(x=>x).Take(5).ToList();

            if (greaterList.Count < 1)
            {
                Console.WriteLine($"No");
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}