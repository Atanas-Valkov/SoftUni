using System;

namespace P02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string userName = Console.ReadLine();    
           string password = Console.ReadLine();

            string currentPassword = Console.ReadLine();

            while (currentPassword != password)
            {
                currentPassword = Console.ReadLine();

            }
            Console.WriteLine($"Welcome {userName}!");
        }

    }
}
