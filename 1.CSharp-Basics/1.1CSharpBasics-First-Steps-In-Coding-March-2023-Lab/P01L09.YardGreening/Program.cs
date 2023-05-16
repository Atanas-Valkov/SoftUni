using System;
using System.Transactions;

namespace P09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double pricePerSqm = 7.61;
            double amountBeforeDiscount = area * pricePerSqm;
            double amountDiscount = 0.18;
            double amountAfterDiscount = amountDiscount * amountBeforeDiscount;
            double finalPrice = amountBeforeDiscount - amountAfterDiscount;
            Console.WriteLine($"The final price is: {finalPrice}" + " " + "lv.");
            Console.WriteLine($"The discount is: {amountAfterDiscount}" + " " + "lv.");

        }
    }
}
