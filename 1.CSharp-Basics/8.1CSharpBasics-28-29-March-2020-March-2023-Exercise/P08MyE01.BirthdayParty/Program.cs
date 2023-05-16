using System;

namespace P01.BirthdayParty_Условие
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hallForChildren = int.Parse(Console.ReadLine());

            double cake = hallForChildren * 0.2;
            double drinks = cake-(cake * 0.45);
            double animator = hallForChildren / 3;

            double totalBudget = hallForChildren + cake + drinks + animator;

            Console.WriteLine(totalBudget);
        }
    }
}
