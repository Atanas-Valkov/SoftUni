using System;

namespace P01L06.ForeignLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string language = string.Empty ;

            if (country == "England" || country == "USA")
            {
                language = "English";
                Console.WriteLine($"{language}");
            }
            else if (country == "Spain" || country == "Argentina" || country == "Mexico")
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
