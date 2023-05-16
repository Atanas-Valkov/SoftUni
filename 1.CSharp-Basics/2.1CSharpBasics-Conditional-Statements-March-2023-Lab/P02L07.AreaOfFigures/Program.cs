using System;
using System.Drawing;

namespace P02L07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            




            string typeOfFigure = Console.ReadLine();
            


            if (typeOfFigure == "square")
            {
                double sideA = double.Parse(Console.ReadLine());
                double areaSquare = sideA * sideA;
                Console.WriteLine($"{areaSquare:f3}");
            }
            else if (typeOfFigure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());

                double areaRectangle = sideA * sideB;
                Console.WriteLine($"{areaRectangle:f3}");

            }
            else if (typeOfFigure == "circle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double areaCircle = (sideA * sideA) * Math.PI;
                Console.WriteLine($"{areaCircle:f3}");
            }
            else if (typeOfFigure == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());

                double areaTriangle = sideA * sideB / 2;
                Console.WriteLine($"{areaTriangle:f3}");
            }

        }
    }
}
