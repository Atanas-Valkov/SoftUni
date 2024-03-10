using System;
using System.Reflection;

namespace P04E06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintTheMiddleCharacter(input);

        }

        static void PrintTheMiddleCharacter(string input)
        {
            if (input.Length>2)
            {
                if (input.Length % 2 == 0)
                {
                    for (int i = (input.Length - 1) / 2; i >= 0; i--)
                    {
                        Console.Write(input[i]);
                        break;
                    }
                    for (int i = input.Length / 2; i >= 0; i--)
                    {
                        Console.Write(input[i]);
                        break;
                    }
                }
                else
                {
                    for (int i = input.Length / 2 ; i >= 0; i--)
                    {
                        Console.WriteLine(input[i]);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(input);
            }

        }
    }
}