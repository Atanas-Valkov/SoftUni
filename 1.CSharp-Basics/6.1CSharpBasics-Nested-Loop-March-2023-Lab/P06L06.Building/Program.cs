using System;
using System.Runtime.CompilerServices;

namespace P06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberFloors = int.Parse(Console.ReadLine());   
            int apartments = int.Parse(Console.ReadLine());

            for (int i = numberFloors; i>=1; i--)
            {

                for (int i1 = 0; i1 < apartments; i1++)
                {
                    if (i == numberFloors)
                    {
                        Console.Write($"L{i}{i1} ");

                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{i1} ");
                    }
                    else
                    {
                     Console.Write($"A{i}{i1} ");
                    }
                }

                Console.WriteLine();
                      
            }


        }
    }
}
