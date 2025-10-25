using System.Diagnostics.Metrics;

namespace P02E04.PizzaCalories;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    public Dough Dough { get; set; }

    public int Counter => toppings.Count;

    public void AddTopping(Topping topping)
    {
        if (Counter > 10)
        {
            throw new Exception("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double TotalCalories()
    {
        double totalCalories = this.Dough.TotalDoughCalories()
                               + this.toppings.Sum(t => t.TotalToppingCalories());
        return totalCalories;
    }

    public override string ToString()
    {
        return $"{name} - {TotalCalories():F2} Calories.";
    }
}