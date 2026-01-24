namespace P02E04.PizzaCalories;

public class Dough
{
    Dictionary<string, double> doughInfo = new Dictionary<string, double>()
    {
        {"white", 1.5 },
        {"wholegrain", 1.0 },
        {"crispy", 0.9 },
        {"chewy", 1.1 },
        {"homemade", 1.0 }
    };

    private string flourType;
    private string bakingTechnique;
    private double weigh;

    public Dough(string bakingTechnique, string flourType, double weigh)
    {
        this.BakingTechnique = bakingTechnique;
        this.FlourType = flourType;
        this.Weigh = weigh;
    }

    public string FlourType
    {
        get => this.flourType;
        private set
        {
            if (!doughInfo.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get => this.bakingTechnique;
        private set
        {
            if (!doughInfo.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weigh
    {
        get => this.weigh;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weigh = value;
        }
    }
 
    // (2 * 100) * 1.5 * 1.1 = 330.00 total calories
    public double TotalDoughCalories()
    {
        return 2 * weigh * doughInfo[this.FlourType] * doughInfo[this.BakingTechnique];
    }

}