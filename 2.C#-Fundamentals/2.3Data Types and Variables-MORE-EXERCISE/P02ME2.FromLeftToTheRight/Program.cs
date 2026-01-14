using System.Net;

namespace P02ME2.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                string line = Console.ReadLine();
                string leftPart = "";
                string rightPart = "";
                bool space = false;
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == ' ')
                    {
                        space = true;
                    }
                    if (!space)
                    {
                        leftPart += line[j];
                    }
                    else
                    {
                        rightPart += line[j];
                    }
                }

                long leftNumber = long.Parse(leftPart);
                long rightNumber = long.Parse(rightPart);
                long sumLeft = 0;
                long sumRight = 0;
                long tempLeft = leftNumber;
                long tempRight = rightNumber;
                while (leftNumber != 0)
                {
                    sumLeft += leftNumber % 10;
                    leftNumber /= 10;

                }

                while (rightNumber != 0)
                {
                    sumRight += rightNumber % 10;
                    rightNumber /= 10;
                }

                if (tempLeft > tempRight)
                {
                    Console.WriteLine($"{Math.Abs(sumLeft)}");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(sumRight)}");
                }
            }
        }
    }
}  