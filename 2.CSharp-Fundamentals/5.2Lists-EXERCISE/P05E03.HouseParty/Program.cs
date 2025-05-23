﻿
using System.Net;

namespace P05E03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int numberOfGuests = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfGuests; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = command[0];
                if (command[2] == "going!")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else if (command[2] == "not")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}