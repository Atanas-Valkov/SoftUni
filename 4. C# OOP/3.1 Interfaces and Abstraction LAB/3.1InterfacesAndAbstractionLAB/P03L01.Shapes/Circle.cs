namespace Shapes;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public int Radius
    {
        get { return this.radius; }
    }

    public void Draw()
    {
        double rinnerRadius = this.radius - 0.4;
        double routerRadius = this.radius + 0.4;
        for (double y = this.radius; y >= -this.radius; --y)
        {
            for (double x = -this.radius; x < routerRadius; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= rinnerRadius * rinnerRadius && value <= routerRadius * routerRadius)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}