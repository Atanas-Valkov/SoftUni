using System;

namespace P08MyE10.SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double volumeOfPlane = double.Parse(Console.ReadLine());
            string volumeOfSuitcase = "";
            double counterSuitcase = 0;
            double totalVolumeOfSuitcases = 0;


            while ((volumeOfSuitcase = Console.ReadLine()) != "End") 
            { 
                double currentVolumeOfSuitcase = double.Parse(volumeOfSuitcase);
                
                if (counterSuitcase % 3 == 0)
                {
                    currentVolumeOfSuitcase *= 1.1;
                }
                if ((volumeOfPlane - totalVolumeOfSuitcases) <= currentVolumeOfSuitcase)
                {
                    Console.WriteLine($"No more space!");
                    break;
                }
                
                totalVolumeOfSuitcases += currentVolumeOfSuitcase;
                counterSuitcase++;

            }
            if (volumeOfSuitcase == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            
            Console.WriteLine($"Statistic: {counterSuitcase} suitcases loaded.");

        }
    }
}
