using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace P04ME1.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();

            if (firstLine == "int")
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(DataType(number));
            }
            else if (firstLine == "real")
            {
                double number = double.Parse(Console.ReadLine());
                Console.WriteLine($"{DataType(number):F2}");
            }
            else if (firstLine == "string")
            {
                string text = Console.ReadLine();
                Console.WriteLine(DataType(text));
            }
        }

        private static int DataType(int number)
        {
            return number * 2;
        }

        private static double DataType(double number)
        {
            return number * 1.5;
        }

        private static string DataType(string text)
        {
            return $"${text}$";
        }
    }
}