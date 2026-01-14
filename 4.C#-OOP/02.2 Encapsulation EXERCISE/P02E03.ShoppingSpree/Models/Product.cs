using System.ComponentModel.DataAnnotations;

namespace P02E03.ShoppingSpree.Models;

public class Product
{
    private string name;
    private decimal cost;

    public Product(decimal cost, string name)
    {
        this.Cost = cost;
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

    public decimal Cost
    {
        get => this.cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.cost = value;
        }
    }
}