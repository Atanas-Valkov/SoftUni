using System;

namespace P02E06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i <97+n; i++)
            {
                char first = (char)i;
                for (int j = 97; j <97+n; j++)
                {
                    char second  = (char)j;
                    for (int k = 97; k <97+n; k++)
                    {
                       char third = (char)k;
                        
                        Console.WriteLine($"{first}{second}{third}");
     
                        
                    }
                }
            }

        }
    }
}
