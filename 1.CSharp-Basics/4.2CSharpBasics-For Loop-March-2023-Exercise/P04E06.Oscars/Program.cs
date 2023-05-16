using System;
using System.ComponentModel.Design;

namespace P06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string acter = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string assessorName;
            double assessorPoints; 

            for (int assessor = 1; assessor <= n; assessor++)
            {
                assessorName = Console.ReadLine();
                assessorPoints = double.Parse(Console.ReadLine());   

                academyPoints = academyPoints + assessorName.Length * assessorPoints / 2;
                
                
                if (academyPoints>=1250.5)
                {
                    Console.WriteLine($"Congratulations, {acter} got a nominee for leading role with {academyPoints:f1}!");
                    break;
                }
            }
             if (academyPoints<1250.5)
            {
                Console.WriteLine($"Sorry, {acter} you need {1250.5 - academyPoints:f1} more!");
            }

        }
    }
}
