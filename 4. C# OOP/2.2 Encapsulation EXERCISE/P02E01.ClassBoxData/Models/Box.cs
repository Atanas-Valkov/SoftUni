namespace P02E01.ClassBoxData.Models;

public class Box
{
    private double height;
    private double width;
    private double length;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }

            length = value;
        }
    }

    public double Width
    {
        get => width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get => height;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            height = value;
        }
    }

    public override string ToString()
    {
        return $"{length}" +
               $"{width}" +
               $"{height}";
    }

    public double SurfaceArea()
    {
        return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
    }

    public double LateralSurfaceArea()
    {
        return 2 * this.height * (this.length + this.width);
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }
}