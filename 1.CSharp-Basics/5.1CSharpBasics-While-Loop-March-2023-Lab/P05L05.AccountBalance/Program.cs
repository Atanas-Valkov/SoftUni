using System;

namespace P05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double balance = 0; 
            string input;
            while ((input = Console.ReadLine()) != "NoMoreMoney") 
            { 
              double money = double.Parse(input);

                if (money<0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }

                balance += money;                   
                 Console.WriteLine($"Increase: {money:f2}");
            }

            Console.WriteLine($"Total: {balance:f2}");


        }
    }
}
