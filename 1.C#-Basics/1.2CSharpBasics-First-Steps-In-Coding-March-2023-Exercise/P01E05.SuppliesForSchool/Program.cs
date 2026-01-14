using System;

namespace P05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            double PackOfPens = double.Parse(Console.ReadLine());
            double packOfMarkers = double.Parse(Console.ReadLine());
            double cleaningProducts = double.Parse(Console.ReadLine());
            double discoun =     double.Parse(Console.ReadLine());

           double pricePackOfPens = 5.8;
           double priceOfMarkers = 7.2;
           double priceCleaningProducts = 1.2;
            

            double amountMoney = (PackOfPens * pricePackOfPens) + (packOfMarkers * priceOfMarkers) + (cleaningProducts * priceCleaningProducts) ;

            discoun = discoun/ 100;

            amountMoney = amountMoney -(amountMoney * discoun);
           
            Console.WriteLine(amountMoney);





        }
    }
}
