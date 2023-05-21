using System;
using System.Runtime.InteropServices;

namespace P02E04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int sum = 0;
             int numberOfLines = int.Parse(Console.ReadLine());
            
             for (int i = 0; i < numberOfLines; i++)
             {
                 char ascii = char.Parse(Console.ReadLine());
                   
                 int charr = (int)ascii;
                 sum += charr;
             }
             Console.WriteLine($"The sum equals: {sum}");
 
        }
    }
}
