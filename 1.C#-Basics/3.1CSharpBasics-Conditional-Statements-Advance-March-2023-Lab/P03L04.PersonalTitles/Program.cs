using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace P04.PersonalTitles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double age  = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            if (gender == 'm')

            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
            else if (gender == 'f')
            {
                if (age<16)
                {
                    Console.WriteLine("Miss");
                }
                else 
                {
                    Console.WriteLine("Ms.");
                }

            }
              



         


        }
    }
}
