using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace P09MyE03_18_19Juy20_.AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberOfWindows = double.Parse(Console.ReadLine());   
            string type = Console.ReadLine();
            string typeOfDelivery = Console.ReadLine();
            double priceForWindow = 0;
            double totalPrice = 0; 
            if (type == "90X130")
            {
                if (numberOfWindows<=30 && numberOfWindows>=10)
                {
                    priceForWindow = 110;
                }
                else if (numberOfWindows > 30 && numberOfWindows<=60)
                {
                    priceForWindow = 110;
                    priceForWindow *= 0.95;
                }
                else if (numberOfWindows > 60)
                {
                    priceForWindow = 110;
                    priceForWindow *= 0.92;
                    
                }

            }
            else if (type == "100X150")
            {
                if (numberOfWindows<=40 && numberOfWindows >= 10)
                {
                    priceForWindow = 140;
                }
                else if(numberOfWindows > 40 && numberOfWindows <= 80)
                {
                    priceForWindow = 140;
                    priceForWindow *= 0.94;
                }
                else if (numberOfWindows > 80)
                {
                    priceForWindow = 140;
                    priceForWindow *= 0.9;
                } 
            }
            else if (type == "130X180")
            {
                if (numberOfWindows <= 20 && numberOfWindows >= 10)
                {
                    priceForWindow = 190;
                }
                else if (numberOfWindows > 20 && numberOfWindows <= 50)
                {
                    priceForWindow = 190;
                    priceForWindow *= 0.93;
                }  
                else if (numberOfWindows > 50)
                {
                    priceForWindow = 190;
                    priceForWindow *= 0.88;
                }  
            }
            else if (type == "200X300")
            {
                if (numberOfWindows <= 25 && numberOfWindows >= 10)
                {
                    priceForWindow = 250;
                }
                else if (numberOfWindows > 25 && numberOfWindows <= 50)
                {
                    priceForWindow = 250;
                    priceForWindow *= 0.91;
                }
                else if (numberOfWindows >50 )
                {
                    priceForWindow = 250;
                    priceForWindow *= 0.86;
                }
            }
            

            if (typeOfDelivery == "With delivery")
            {
                totalPrice = (numberOfWindows * priceForWindow)+ 60;
                
            }
            else if (typeOfDelivery == "Without delivery")
            {
                totalPrice = (numberOfWindows * priceForWindow);
            }
            if (numberOfWindows >= 100)
            {
                totalPrice *= 0.96;

            }
            if (numberOfWindows < 10)
            {
                Console.WriteLine($"Invalid order");
            }
            else 
            {
                Console.WriteLine($"{totalPrice:f2} BGN");
            }
            






        }
    }
}
