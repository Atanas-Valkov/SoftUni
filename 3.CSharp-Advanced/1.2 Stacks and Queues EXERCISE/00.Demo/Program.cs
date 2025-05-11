using System;
using System.Collections.Generic;
using System.Linq;

namespace P01E9.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletsUsed = 0;
            int bulletsFiredSinceReload = 0;

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                bulletsUsed++;
                bulletsFiredSinceReload++;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsFiredSinceReload == gunBarrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    bulletsFiredSinceReload = 0;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = intelligenceValue - (bulletsUsed * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }

        }
    }
}
