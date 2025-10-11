using System;
using System.Runtime.CompilerServices;

namespace P08E05.EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruid = Console.ReadLine();  
            string setSize = Console.ReadLine();           
            int numberOfSets =int.Parse(Console.ReadLine());
            
            double totalpirce = 0; 
            double setSizePrice = 0;

            if (setSize == "small")
            {
                numberOfSets = numberOfSets * 2;


                if (fruid == "Watermelon")
                {
                    setSizePrice = 56;
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if (fruid == "Mango")
                {
                    setSizePrice = 36.66;
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if(fruid == "Pineapple") 
                {
                    setSizePrice = 42.10; 
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if (fruid == "Raspberry")
                {
                    setSizePrice = 20;
                    totalpirce = numberOfSets * setSizePrice;
                }
            }
            else if (setSize == "big")
            {

                numberOfSets = numberOfSets * 5;
                if (fruid == "Watermelon")
                {
                    setSizePrice = 28.70;
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if (fruid == "Mango")
                {
                    setSizePrice = 19.60;
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if (fruid == "Pineapple")
                {
                    setSizePrice = 24.80;
                    totalpirce = numberOfSets * setSizePrice;
                }
                else if (fruid == "Raspberry")
                {
                    setSizePrice = 15.20;
                    totalpirce = numberOfSets * setSizePrice;
                }
            }

            if (totalpirce >= 400 && totalpirce <= 1000)
            {
                totalpirce *= 0.85;
                Console.WriteLine($"{totalpirce:f2} lv.");
            }
            else if (totalpirce > 1000)
            {
                totalpirce *= 0.5;
                Console.WriteLine($"{totalpirce:f2} lv.");
            }
            else if (totalpirce < 400)
            {
                Console.WriteLine($"{totalpirce:f2} lv.");
            }
        }
    }
}
