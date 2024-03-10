using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace P04L08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double baseNumber = double.Parse(Console.ReadLine());
           double power = double.Parse(Console.ReadLine());

           Result(baseNumber, power);
        }

        static void Result(double baseNumber, double power)
        {
           double result =  Math.Pow(baseNumber, power);
           Console.WriteLine(result);
        }
    }
}