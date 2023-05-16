using System;

namespace P04.GrandpaStavri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double counterLiters = 0;
            double counterDegrees = 0;
            double dayDegrees = 0 ;
            for (int i = 1; i <= days; i++)
            {
                double currentLiters = double.Parse(Console.ReadLine());
                double currentDegrees = double.Parse(Console.ReadLine());

                counterLiters += currentLiters;
                double currentDayDegrees = currentLiters * currentDegrees;
                dayDegrees += currentDayDegrees;
                counterDegrees += currentDegrees;

            }


            double degreesForAllLiters = dayDegrees / counterLiters;
            Console.WriteLine($"Liter: {counterLiters:f2}");
            Console.WriteLine($"Degrees: {degreesForAllLiters:f2}");

            if (degreesForAllLiters<38)
            {
                Console.WriteLine($"Not good, you should baking!");
            }
            else if (degreesForAllLiters >=38 && degreesForAllLiters<=42)
            {
                Console.WriteLine($"Super!");
            }
            else if (degreesForAllLiters>42)
            {
                Console.WriteLine($"Dilution with distilled water!");
            }
            
            
            
           


        }
    }
}
