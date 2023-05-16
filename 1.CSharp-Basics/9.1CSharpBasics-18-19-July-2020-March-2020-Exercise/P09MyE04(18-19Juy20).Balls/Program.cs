using System;
using System.IO.Pipes;

namespace P09MyE04_18_19Juy20_.Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numBalls = int.Parse(Console.ReadLine());

            double totalPoints = 0;
            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int WhiteBalls = 0;
            int otherColors = 0;
            int dividesBlackBall = 0;




            for (int i = 1; i <= numBalls; i++)
            {
                string currentColor = Console.ReadLine();

                if (currentColor == "red")
                {
                    redBalls++;
                    totalPoints += 5;

                }
                else if (currentColor == "orange")
                {
                    orangeBalls++;
                    totalPoints += 10;
                }
                else if (currentColor == "yellow")
                {
                    yellowBalls++;
                    totalPoints += 15;
                }
                else if (currentColor == "white")
                {
                    WhiteBalls ++;
                    totalPoints += 20;
                }
                else if (currentColor == "black")
                {
                    dividesBlackBall++;
                    totalPoints = Math.Floor(totalPoints / 2);   
                }
                else
                {
                    otherColors ++;

                }
            }
            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {WhiteBalls}");
            Console.WriteLine($"Other colors picked: {otherColors}");
            Console.WriteLine($"Divides from black balls: {dividesBlackBall}");


        }
    }
}
