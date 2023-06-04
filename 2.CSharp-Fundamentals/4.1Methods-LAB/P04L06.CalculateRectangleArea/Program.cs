namespace P04L06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width= double.Parse(Console.ReadLine());
            double area = rectangleArea(height, width);

            Console.WriteLine(area);
        }

        static double rectangleArea(double height, double width)
        {
            return height * width;
        }
    }
}