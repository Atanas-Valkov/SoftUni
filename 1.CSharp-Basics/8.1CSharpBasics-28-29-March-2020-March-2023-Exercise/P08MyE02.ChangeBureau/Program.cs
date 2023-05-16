using System;

namespace P0801.ChangeBureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bitcoin = double.Parse(Console.ReadLine());
            double cny = double.Parse(Console.ReadLine());  
            double commission = double.Parse(Console.ReadLine());

            double bitcoinPrice = 1168;
            double cnyPrice = 0.15 * 1.76;
            double eurPrice = 1.95;

          double totalBitcoinPrice = bitcoin * bitcoinPrice;
          double totalCnyPrice = cny * cnyPrice;
          double totalSumLev = totalBitcoinPrice + totalCnyPrice;
          double totalSumEur = totalSumLev / eurPrice;
            commission = 1 - (commission / 100);
            totalSumEur *= commission;
                Console.WriteLine($"{totalSumEur:f2}");
        }
    }
}   
