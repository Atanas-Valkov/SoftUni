using System;
using System.Numerics;
using System.Threading.Channels;

namespace P08MyE08.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfGroups = int.Parse(Console.ReadLine());
           
            
            int counterMusalla = 0;
            int counterMontBlanc = 0;
            int counterKilimanjaro = 0;
            int counterK2 = 0;
            int counterEverest = 0;
            int totalPeople = 0;


            for (int i = 1; i <= numbersOfGroups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());

                if (peopleInGroup<=5)
                {
                    counterMusalla += peopleInGroup;
                }
                else if (peopleInGroup<=12)
                {
                    counterMontBlanc += peopleInGroup;
                }
                else if (peopleInGroup<=25)
                {
                    counterKilimanjaro += peopleInGroup;
                }
                else if (peopleInGroup<=40)
                {
                    counterK2 += peopleInGroup;
                }
                else if (peopleInGroup>=41)
                {
                    counterEverest += peopleInGroup;
                }
            }
            
            totalPeople = counterMusalla + counterMontBlanc + counterKilimanjaro + counterK2 + counterEverest;
            
            
            Console.WriteLine($"{(double)counterMusalla / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)counterMontBlanc / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)counterKilimanjaro / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)counterK2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)counterEverest / totalPeople * 100:f2}%");
        }
    }
}
