using System;
using System.Runtime.CompilerServices;

namespace P02L04.CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong centuries = ulong.Parse(Console.ReadLine());
            ulong years = centuries * 100;
            ulong days = (ulong)(years * 365.2422m);
            ulong hours = days * 24;
            ulong minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
