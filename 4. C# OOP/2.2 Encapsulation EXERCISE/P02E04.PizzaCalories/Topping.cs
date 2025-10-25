namespace P02E04.PizzaCalories;

public class Topping 
{
    Dictionary<string, double> toppingInfo = new Dictionary<string, double>
    {
        {"meat", (1.2) },
        {"veggies", (0.8) },
        {"cheese", (1.1) },
        {"sauce", (0.9) }
    };

    private string toppingType;
    private double weight;
    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public string ToppingType
    {
        get => this.toppingType;
        set
        {
            
            if (!toppingInfo.ContainsKey(value.ToLower()))
            {
               
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    public double Weight
    {
        get => this.weight;
        set
        {
            if (value<1 || value>50)
            {
                throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double TotalToppingCalories()
    {
        return 2 * this.Weight * toppingInfo[this.ToppingType];
    }
}