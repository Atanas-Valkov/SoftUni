using System;
using System.Net.WebSockets;
using System.Security;

namespace P06.VowelsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            int vowelSum = 0;


            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (currentChar == 'a')
                {
                    vowelSum += 1;
                }
                else if (currentChar == 'e')
                {
                    vowelSum += 2;  
                }
                else if (currentChar == 'i')
                {
                    vowelSum += 3;
                }
                else if (currentChar == 'o')
                {
                    vowelSum += 4;
                }
                else if (currentChar == 'u')
                {
                    vowelSum += 5;
                }

            }


            Console.WriteLine(vowelSum);

        }
    }
}
