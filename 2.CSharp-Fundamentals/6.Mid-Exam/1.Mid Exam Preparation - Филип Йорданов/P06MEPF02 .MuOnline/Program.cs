using System.Threading;

namespace P06MEPF02_.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonsRooms = Console.ReadLine()
                .Split("|")
                .ToList();
            
            int health = 100; 
            int bitcoins = 0;
            
            int roomCounter = 0;

            foreach (string rooms in dungeonsRooms)
            {
                roomCounter++;
                string[] command = rooms.Split(" ").ToArray();

                string attackOfTheMonster = command[0];
                int index = int.Parse(command[1]);
                if (attackOfTheMonster == "potion")
                {
                    if (health + index>100)
                    {
                       Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else
                    {
                       health += index;
                       Console.WriteLine($"You healed for {index} hp.");
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (attackOfTheMonster == "chest")
                {
                    bitcoins += index;
                    Console.WriteLine($"You found {index} bitcoins.");
                }
                else
                {
                    health -= index;
                    
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command[0]}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return; 
                    }

                    Console.WriteLine($"You slayed {command[0]}.");
                }
            }
            Console.WriteLine($"You've made it!"); 
            Console.WriteLine($"Bitcoins: {bitcoins}"); 
            Console.WriteLine($"Health: {health}");
        }
    }
}