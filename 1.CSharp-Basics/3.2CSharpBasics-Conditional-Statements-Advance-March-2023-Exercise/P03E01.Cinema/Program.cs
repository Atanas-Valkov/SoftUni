using System;
using System.Runtime.CompilerServices;

namespace P09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine();
            int numRows = int.Parse(Console.ReadLine());
            int numcolums = int.Parse(Console.ReadLine());

            double projectionPrice = 0;
            double income = 0;


            if (typeOfProjection == "Premiere" || typeOfProjection == "Normal"
                || typeOfProjection == "Discount")
            {

                if (typeOfProjection == "Premiere")
                {
                    income = numRows * numcolums * 12;
                }
                else if (typeOfProjection == "Normal")
                {
                    income = numRows * numcolums * 7.5;
                }
                else if (typeOfProjection == "Discount")
                {
                    income = numRows * numcolums * 5;
                }
                Console.WriteLine($"{income:f2} leva");





            }

        }
    }
}
