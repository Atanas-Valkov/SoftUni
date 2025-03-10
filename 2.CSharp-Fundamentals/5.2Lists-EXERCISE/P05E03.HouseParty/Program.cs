﻿
using System.Net;

namespace P05E03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> trackGuests = new List<string>();
            int counter = 0;

            while (counter < numberOfCommands)
            {
                string whoIsGoing = Console.ReadLine();
                string[] token = whoIsGoing.Split(); 
                
                if (token[2] == "going!")
                {
                    AddGuest(token, trackGuests);
                }
                else if (token[2] == "not")
                {
                    RemoveGuest(token, trackGuests);
                }
                counter++;
            }
            foreach (var guestName in trackGuests)
            {
                Console.WriteLine(guestName);
            }
        }

        private static void AddGuest(string[] token, List<string> namesOfGuests)
        {
            for (int i = 0; i < namesOfGuests.Count; i++)
            {
                string addGuest = token[0];
                if (addGuest == namesOfGuests[i])
                {
                    Console.WriteLine($"{addGuest} is already in the list!");
                    return;
                }
            }
            namesOfGuests.Add(token[0]);
        }

        private static void RemoveGuest(string[] token, List<string> namesOfGuests)
        {
            string removeGuest = token[0];
            for (int i = 0; i < namesOfGuests.Count; i++)
            {
                if (removeGuest == namesOfGuests[i])
                {
                    namesOfGuests.RemoveAll(name => name == removeGuest);
                    return;
                }
            }
            Console.WriteLine($"{removeGuest} is not in the list!");

        }
    }
}