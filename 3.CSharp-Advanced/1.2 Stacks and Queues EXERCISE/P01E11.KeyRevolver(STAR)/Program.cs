using System.Collections.Concurrent;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace P01E11.KeyRevolver_STAR_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int sizeOfTheGun = int.Parse(Console.ReadLine());

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

            int award = int.Parse(Console.ReadLine());
            int bulletsCounter = 0;
            int bulletsFiredSinceReload = 0; 
            while (bullets.Any() && locks.Any())
            {
                bulletsCounter++;
                bulletsFiredSinceReload++;
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine($"Bang!");
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                if (bulletsFiredSinceReload == sizeOfTheGun && bullets.Any())
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
                int moneyEarned = award - (bulletsCounter * price);
                Console.WriteLine($"{bullets.Count} bullets left. Earned {moneyEarned}");
            }
        }
    }
}
