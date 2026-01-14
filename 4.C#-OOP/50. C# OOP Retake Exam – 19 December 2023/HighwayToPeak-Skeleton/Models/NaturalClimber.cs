namespace HighwayToPeak.Models;

public class NaturalClimber : Climber
{
    private const int InitialStamina = 6;
    private const int RecoverStaminaPerDay = 2;
    public NaturalClimber(string name) 
        : base(name, InitialStamina)
    {
    }

    public override void Rest(int daysCount)
    {
        this.Stamina += daysCount * RecoverStaminaPerDay;
    }
}