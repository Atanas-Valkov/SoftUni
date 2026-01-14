using System;

namespace P08MyE04.MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double wrInSec = double.Parse(Console.ReadLine());
           double DistanceInMeters = double.Parse(Console.ReadLine());
           double oneMeterInSec = double.Parse(Console.ReadLine());

            double time = DistanceInMeters * oneMeterInSec;
            double delayTime = Math.Floor(DistanceInMeters / 50) * 30;
            double totalTime = time + delayTime;

            if (wrInSec <= totalTime)
            {
                Console.WriteLine($"No! He was {Math.Abs(wrInSec - totalTime):f2} seconds slower.");
                
            }
            else if (wrInSec > totalTime)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }



        }
    }
}
