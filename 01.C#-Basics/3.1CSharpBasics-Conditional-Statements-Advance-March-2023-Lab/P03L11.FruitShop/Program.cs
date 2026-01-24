using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace P03L11.FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string fruit = Console.ReadLine();
           string dayOfTheWeek = Console.ReadLine();    
           double qtyFruit = double.Parse(Console.ReadLine());
           double totalPrice = 0;
            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday" || dayOfTheWeek == "Friday")
            {
                if (fruit == "banana")
                {
                    totalPrice = qtyFruit * 2.50;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    totalPrice = qtyFruit * 1.2;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    totalPrice = qtyFruit * 0.85;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    totalPrice = qtyFruit * 1.45;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    totalPrice = qtyFruit * 2.70;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    totalPrice = qtyFruit * 5.50;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    totalPrice = qtyFruit * 3.85;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else 
                {
                    Console.WriteLine("error");
                }
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                if (fruit == "banana")
                {
                    totalPrice = qtyFruit * 2.70;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    totalPrice = qtyFruit * 1.25;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    totalPrice = qtyFruit * 0.90;
                    Console.WriteLine($"{totalPrice:f2}");
                }   
                else if (fruit == "grapefruit")
                {
                    totalPrice = qtyFruit * 1.6;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    totalPrice = qtyFruit * 3.00;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    totalPrice = qtyFruit * 5.6;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    totalPrice = qtyFruit * 4.20;
                    Console.WriteLine($"{totalPrice:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }



            }
            else { Console.WriteLine("error"); }    
        }
    }
}
