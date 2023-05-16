using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace P11MoreNL02.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());
            char missChar = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char i = startChar; i <= endChar; i++)
            {
                for (char k = startChar; k <= endChar; k++)
                {
                    for (char j = startChar; j <= endChar; j++)
                    {
                        if (i != missChar && k != missChar && j != missChar)
                        {
                            counter++;
                            Console.Write($"{i}{k}{j} ");
                        }
                       
                    }

                }
                
            }

            Console.WriteLine($"{counter}");
        }
    }
}
