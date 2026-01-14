namespace P02E01.ClassBoxData;

public class Box
{
    private double height;
    private double width;
    private double length;


    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get => this.length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{this.length} cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{this.width} cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get => this.height;
        private set
        {                          // Използвай nameof(Height) за да получиш
                                   // името на свойството като текст.                    
            if (value <= 0)        //            |       
            {                      //            v 
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public override string ToString()
    {
        return $"{this.length}" +
               $"{this.width}" +
               $"{this.height}";
    }

   

}



