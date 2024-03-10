using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading.Channels;

namespace P02ME1.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integer = 0;
            double FloatingPoint = 0;
            char characters = ' ';
            bool boolean;
            bool currentInput = false;

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                

                if (currentInput = int.TryParse(input, out integer))
                {
                    Console.WriteLine($"{input} is integer type");
                    
                }
                else if (currentInput = double.TryParse(input, out FloatingPoint))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (currentInput = char.TryParse(input, out characters))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (currentInput = bool.TryParse(input, out boolean))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}