using System;
using System.Threading;

namespace P02E03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling(numberOfPeople / capacity);
            
            Console.WriteLine($"{courses}");
        }
    }
}
