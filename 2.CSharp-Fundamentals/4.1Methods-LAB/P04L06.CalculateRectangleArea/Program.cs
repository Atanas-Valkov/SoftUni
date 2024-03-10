namespace P04L06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());
            double area = width * altitude;
            GetRectangleArea(width , altitude);
            Console.WriteLine(area);
        }

        static double GetRectangleArea(double width, double altitude)
        {
            return width * altitude;
        }
    }
}