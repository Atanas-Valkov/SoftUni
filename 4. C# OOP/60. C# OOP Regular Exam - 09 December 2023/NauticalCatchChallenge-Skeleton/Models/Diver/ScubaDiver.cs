namespace NauticalCatchChallenge.Models.Diver;

public class ScubaDiver : Diver
{
    private const int oxygenLevel = 540;
    private const double decreaseOxygen = 30;

    public ScubaDiver(string name) 
        : base(name, oxygenLevel)
    {
    }

    public override void Miss(int TimeToCatch)
    {
        double result = TimeToCatch * decreaseOxygen / 100;
        OxygenLevel -= (int)Math.Round(result, MidpointRounding.AwayFromZero);

        if (OxygenLevel < 0)
        {
            OxygenLevel = 0;
        }
    }

    // public void UpdateHealthStatus()
    // {
    //     
    // }

    public override void RenewOxy()
    {
        this.OxygenLevel = oxygenLevel;
    }
   
}