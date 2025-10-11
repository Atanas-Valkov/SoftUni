using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace P06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double wrInSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeFor1m = double.Parse(Console.ReadLine());

            double Time = distance * timeFor1m;
            double delay = Math.Floor(distance / 15) * 12.5;
            double totalTime = Time + delay;
            
            if (wrInSec <= totalTime)
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(wrInSec - totalTime):f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }










        }
    }
}
