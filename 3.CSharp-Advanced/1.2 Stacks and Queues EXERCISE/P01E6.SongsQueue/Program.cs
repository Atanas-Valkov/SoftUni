//using  System.Diagnostics;

using System.Diagnostics;

namespace P01E6.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songs = new Queue<string>(input);

            while (songs.Any())
            {
                string[] commandLine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string operation = commandLine[0];
                string songName = string.Join(" ", commandLine.Skip(1));

                if (operation == "Add")
                {
                    if (!songs.Contains(songName))
                    {
                        songs.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (operation == "Play")
                {
                    if (songs.Any())
                    {
                        songs.Dequeue();
                    }
                }
                else if (commandLine.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
