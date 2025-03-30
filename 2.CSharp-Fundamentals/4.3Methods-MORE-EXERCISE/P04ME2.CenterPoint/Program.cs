namespace P04ME2.CenterPodouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PointClosestToTheCenter(x1, y1, x2, y2);
        }

        private static void PointClosestToTheCenter(double x1, double y1, double x2, double y2)
        {
            double firstSetOfPoints = Math.Abs(x1) + Math.Abs(y1);
            double secondSetOfPoints = Math.Abs(x2) + Math.Abs(y2);

            if (firstSetOfPoints <= secondSetOfPoints)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else 
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}