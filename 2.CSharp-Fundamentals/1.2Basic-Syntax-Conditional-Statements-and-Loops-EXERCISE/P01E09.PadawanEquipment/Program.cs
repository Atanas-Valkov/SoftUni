using System;

namespace P01E09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            double countOfStudents = double.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            double equipmentCost = 0;
            double freeBelts = 0;

            for (int i = 1; i <= countOfStudents; i++)
            {
                if (i % 6 == 0)
                {
                    freeBelts++;
                }
            }
            equipmentCost = priceOfLightsabers * Math.Ceiling(countOfStudents * 1.1) + priceOfRobes * countOfStudents + priceOfBelts * (countOfStudents - freeBelts);
            double needed = equipmentCost - amountOfMoney;

            if (equipmentCost <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentCost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {needed:F2}lv more.");
            }
        }
    }
}
