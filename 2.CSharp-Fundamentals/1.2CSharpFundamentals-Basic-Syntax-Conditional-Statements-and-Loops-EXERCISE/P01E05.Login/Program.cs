using System;

namespace P01E05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string userNameReversed = string.Empty;
            string userInput = string.Empty;
            int counter = 0;

            for (int i = userName.Length - 1; i >= 0; --i)
            {
                userNameReversed += userName[i];
            }

            while ((userInput = Console.ReadLine()) != userNameReversed)
            {
                if (userInput != userNameReversed)
                {
                    if (counter == 3)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine($"Incorrect password. Try again.");
                    counter++;
                }
            }

            if (userInput == userNameReversed)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
        }
    }
}
