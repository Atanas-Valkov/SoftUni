using System;

namespace P02.MaidenParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double partyPrice = double.Parse(Console.ReadLine());
            double messages = double.Parse(Console.ReadLine());
            double roses = double.Parse(Console.ReadLine());
            double keyHolders = double.Parse(Console.ReadLine());
            double cartoons = double.Parse(Console.ReadLine());
            double surprise = double.Parse(Console.ReadLine());


            double totalSum = (messages * 0.6) + (roses * 7.2) + (keyHolders * 3.6) + (cartoons * 18.20) + (surprise * 22);
            double totalItems = messages + roses + keyHolders + cartoons + surprise;

            if (totalItems >= 25)
            {
                totalSum *= 0.65;
            }
            totalSum *= 0.9;

            if (partyPrice<=totalSum)
            {
                Console.WriteLine($"Yes! {(totalSum- partyPrice):f2} lv left.");
            }
            else 
            {
                Console.WriteLine($"Not enough money! {Math.Abs(totalSum - partyPrice):f2} lv needed.");

            }


        }
    }
}
