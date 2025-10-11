using System;
using System.Reflection.Metadata;
using System.Security;
using System.Transactions;

namespace P08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double dog = double.Parse(Console.ReadLine());
            
            int cat = int.Parse(Console.ReadLine());

            string sum = (dog * 2.5) + (cat * 4) + " " + "lv.";

            Console.WriteLine(sum);



        }
    }
}
