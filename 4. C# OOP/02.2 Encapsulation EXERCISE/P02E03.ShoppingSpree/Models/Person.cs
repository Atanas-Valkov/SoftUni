namespace P02E03.ShoppingSpree.Models;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person()
    {
        this.bagOfProducts = new List<Product>();
    }

    public Person(decimal money, string name): this()
    {
        this.Money = money;
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public void BuyProduct(Product product)
    {
        if (product.Cost<= Money )
        {
            bagOfProducts.Add(product);
            Money -= product.Cost;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
    }

    public override string ToString()
    {
        if (bagOfProducts.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        return $"{Name} - {string.Join(", ", bagOfProducts.Select(p => p.Name))}";
    }
}