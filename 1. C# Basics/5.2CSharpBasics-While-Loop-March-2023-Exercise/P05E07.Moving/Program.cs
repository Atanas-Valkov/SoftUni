using System;

namespace P07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string boxes;
            int counterBoxs = 0;

            int volumOfTheProperty = width * lenght * height;
            
            
            while (volumOfTheProperty > counterBoxs)
            {
                boxes = Console.ReadLine();
                if (boxes != "Done")
                {
                    counterBoxs += int.Parse(boxes);
                }
                else if (boxes == "Done")
                {
                    Console.WriteLine($"{volumOfTheProperty- counterBoxs} Cubic meters left.");
                    break;
                }
                if (volumOfTheProperty< counterBoxs)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volumOfTheProperty-counterBoxs)} Cubic meters more.");
                }
            }

        }
    }
}
