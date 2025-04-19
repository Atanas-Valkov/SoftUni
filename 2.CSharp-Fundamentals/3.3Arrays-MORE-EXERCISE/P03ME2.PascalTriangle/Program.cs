using System.Net;

namespace P03ME2.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            double leftCar = 0;
            double rightCar = 0;

            for (int i = 0; i < input.Count / 2; i++)
            {
                if (input[i] == 0)
                {
                    leftCar *= 0.8;
                }
                leftCar += input[i];
            }

            for (int i = input.Count - 1; i > input.Count / 2; i--)
            {
                if (input[i] == 0)
                {
                    rightCar *= 0.8;
                }
                rightCar += input[i];
            }

            string winner = Math.Min(leftCar, rightCar) == leftCar ? "left" : "right";
            double winnerTime = Math.Min(leftCar, rightCar);
            winnerTime = Math.Round(winnerTime, 1);
            Console.WriteLine($"The winner is {winner} with total time: {winnerTime}");
        }
    }
}
