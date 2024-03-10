/*
Mike, John, Eddie
Blacklist Mike
Error 0
Report

Mike, John, Eddie, William
Error 3
Error 3
Change 0 Mike123
Report

Mike, John, Eddie, William
Blacklist Maya
Error 1
Change 4 George
Report

*/
using System.Collections.Generic;

namespace ME_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(", ")
                .ToList();

            string report;
            int blackListeCounter = 0;
            int lostNameCounter = 0;
            while ((report = Console.ReadLine()) != "Report")
            {
                string[] commands = report.Split();
                string firstIndex = commands[0];
                string secondIndex = commands[1];
                
                if (firstIndex == "Blacklist")
                {
                    if (names.Any(x=>x.Contains(secondIndex)))
                    {
                       int index = names.IndexOf(secondIndex);
                        names[index] = "Blacklisted";

                       Console.WriteLine($"{secondIndex} was blacklisted.");
                       blackListeCounter++;
                    }
                    else
                    {
                       Console.WriteLine($"{secondIndex} was not found.");
                    }
                }
                else if (firstIndex == "Error")
                {
                    int errorIndex = int.Parse(secondIndex);

                    if ( errorIndex >=0 && errorIndex <=names.Count -1 )
                    {
                        if (names[errorIndex] != "Lost"  )
                        {
                            string lostName = names[errorIndex];
                            names[errorIndex] = "Lost";
                            lostNameCounter ++ ;

                            Console.WriteLine($"{lostName} was lost due to an error.");
                        }
                    }
                }
                else if (firstIndex == "Change")
                {
                    string thirdIndex = commands[2];
                    int changeIndex = int.Parse(secondIndex);
                    if (changeIndex >= 0 && changeIndex < names.Count - 1)
                    {
                        string oldName = names[changeIndex];
                        names.Any(x => x.Contains(secondIndex));
                        int index = names.IndexOf(secondIndex);
                        names[changeIndex] = thirdIndex;

                        Console.WriteLine($"{oldName} changed his username to {thirdIndex}.");
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blackListeCounter}");
            Console.WriteLine($"Lost names: {lostNameCounter}");
            Console.WriteLine(string.Join(" ",names));
        }
    }
}