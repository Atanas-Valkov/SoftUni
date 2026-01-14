namespace Shapes;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Width { get; private set; }

    public double Height { get; private set; }
    public override double CalculatePerimeter()
    {
        return 2 * (this.Width + this.Height);
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override string Draw()
    {
        return $"Drawing Rectangle";
    }
}