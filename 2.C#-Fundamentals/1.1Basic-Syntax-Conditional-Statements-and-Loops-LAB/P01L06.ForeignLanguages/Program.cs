using System;
using System.Xml.Linq;

namespace P01L06.ForeignLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine(); 
            string language = String.Empty;

            if (countryName == "England" || countryName == "USA")
            {
                language = "English";
                Console.WriteLine($"{language}");
            }
            else if (countryName == "Spain" || countryName == "Argentina" || countryName == "Mexico")
            {
                language = "Spanish";
                Console.WriteLine($"{language}");
            }
            else
            {
                Console.WriteLine($"unknown");
            }
        }
    }
}
