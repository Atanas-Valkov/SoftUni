using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace P04L08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            MathPower(number, power);
            Console.WriteLine(MathPower(number, power));
        }

        private static double MathPower(double number, double power)
        {
            double result = 0;
            return result = Math.Pow(number, power);
        }
    }
}