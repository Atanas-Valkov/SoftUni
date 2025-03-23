
namespace P04L06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            CalculateRectangleArea(width, height);
            double area = CalculateRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}