using System;
using System.Runtime.CompilerServices;

namespace P05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int tab = int.Parse(Console.ReadLine());
           int salary = int.Parse(Console.ReadLine());

            string sait = string.Empty;

            for (int i = 1; i <= tab; i++)
            {
                sait = Console.ReadLine();

                if (sait == "Facebook")
                {
                    salary -= 150;
                }
                else if(sait == "Instagram")
                {
                    salary -= 100;
                }
                else if (sait == "Reddit")
                {
                    salary -= 50;
                }
                if (salary<=0 )
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
               


            }


           if(salary>0)
            {
                Console.WriteLine(salary);
            }





        }
    }
}
