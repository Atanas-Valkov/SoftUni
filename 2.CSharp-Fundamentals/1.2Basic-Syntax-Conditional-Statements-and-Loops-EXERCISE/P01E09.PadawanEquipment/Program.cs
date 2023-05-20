using System;

namespace P01E09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());    
            double countOfStudents = double.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double numLightsabers = Math.Ceiling(countOfStudents * 1.1);
            double numRobes = countOfStudents;
            double numBelts = 0; 
            
            for (int i = 1; i <= countOfStudents; i++) 
            {
                if (i % 6 != 0 )
                {
                    numBelts++;
                }
            
            }

            double totalSpendMoney = (priceLightsabers * numLightsabers) + (priceRobes * numRobes) + (priceBelts * numBelts);

            if (amountOfMoney >= totalSpendMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSpendMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(totalSpendMoney - amountOfMoney):f2}lv more.");
            }




        }
    }
}
