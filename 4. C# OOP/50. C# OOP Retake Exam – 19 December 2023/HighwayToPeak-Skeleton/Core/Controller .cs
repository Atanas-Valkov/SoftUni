using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System.Xml.Linq;

namespace HighwayToPeak.Core;

public class Controller : IController
{
    private readonly PeakRepository peaks;
    private readonly ClimberRepository climbers;
    private readonly BaseCamp baseCamp;
    public Controller()
    {
        peaks = new PeakRepository();
        climbers = new ClimberRepository();
        baseCamp = new BaseCamp();
    }


    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        if (this.peaks.Get(name) != null)
        {
            return string.Format(OutputMessages.PeakAlreadyAdded, name);
        }

        if (difficultyLevel != "Extreme" &&
            difficultyLevel != "Hard" &&
            difficultyLevel != "Moderate")
        {
            return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
        }

        IPeak peak = new Peak(name, elevation, difficultyLevel);
        this.peaks.Add(peak);

        return string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        if (this.climbers.Get(name) != null)
        {
            return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository)); // ?!?!?
        }

        IClimber climber;

        if (isOxygenUsed)
        {
            climber = new OxygenClimber(name);
        }
        else
        {
            climber = new NaturalClimber(name);
        }

        climbers.Add(climber);
        baseCamp.ArriveAtCamp(name);
        return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
    }

    public string AttackPeak(string climberName, string peakName)
    {
        if (this.climbers.Get(climberName) == null)
        {
            return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
        }

        if (this.peaks.Get(peakName) == null)
        {
            return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
        }


        if (!this.baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
        }

        IPeak peak = this.peaks.Get(peakName);
        IClimber climber = this.climbers.Get(climberName);


        if (peak.DifficultyLevel is "Extreme" && climber is NaturalClimber)
        {
            return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
        }

        this.baseCamp.LeaveCamp(climberName);
        climber.Climb(peak);

        if (climber.Stamina == 0)
        {
            return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
        }

        this.baseCamp.ArriveAtCamp(climberName);
        return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
    }

    public string CampRecovery(string climberName, int daysToRecover)
    {
        if (!this.baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
        }

        IClimber climber = this.climbers.Get(climberName);

        if (climber.Stamina == 10)
        {
            return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
        }

        climber.Rest(daysToRecover);
        return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
    }

    public string BaseCampReport()
    {
        if (!this.baseCamp.Residents.Any())
        {
            return "BaseCamp is currently empty.";
        }
        StringBuilder sb = new StringBuilder();

        sb.Append("BaseCamp residents:");
        sb.AppendLine();

        foreach (var resident in this.baseCamp.Residents)
        {
            IClimber climber = this.climbers.Get(resident);

            sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
        }

        return sb.ToString().TrimEnd();
    }

    public string OverallStatistics()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("***Highway-To-Peak***");

        foreach (var climber in climbers.All
                     .OrderByDescending(x => x.ConqueredPeaks.Count)
                     .ThenBy(x => x.Name))
        {
            sb.AppendLine($"{climber.ToString()}");

            foreach (var peak in climber.ConqueredPeaks
                         .Select(peakName => this.peaks.Get(peakName))
                         .Where(p=>p != null)
                         .OrderByDescending(x=>x.Elevation))
            {
                sb.AppendLine($"{peak.ToString()}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}