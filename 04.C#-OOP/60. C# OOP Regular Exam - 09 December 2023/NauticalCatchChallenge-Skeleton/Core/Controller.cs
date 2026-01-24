using System.Security.Cryptography.X509Certificates;
using System.Text;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.Diver;
using NauticalCatchChallenge.Models.Fish;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    private readonly DiverRepository divers;
    private readonly FishRepository fish;

    public Controller()
    {
        divers = new DiverRepository();
        fish = new FishRepository();
    }

    public string DiveIntoCompetition(string diverType, string diverName)
    {
        if (diverType != nameof(FreeDiver) &&
            diverType != nameof(ScubaDiver))
        {
            return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
        }

        if (this.divers.GetModel(diverName) != null)
        {
            return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
        }

        IDiver diver;
        if (diverType == nameof(FreeDiver))
        {
            diver = new FreeDiver(diverName);
        }
        else
        {
            diver = new ScubaDiver(diverName);
        }

        this.divers.AddModel(diver);
        return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
    }

    public string SwimIntoCompetition(string fishType, string fishName, double points)
    {
        if (fishType != nameof(DeepSeaFish) &&
            fishType != nameof(PredatoryFish) &&
            fishType != nameof(ReefFish))
        {
            return string.Format(OutputMessages.FishTypeNotPresented, fishType);
        }

        if (this.fish.GetModel(fishName) != null)
        {
            return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
        }

        IFish createFish;
        if (fishType == nameof(DeepSeaFish))
        {
            createFish = new DeepSeaFish(fishName, points);
        }
        else if (fishType == nameof(PredatoryFish))
        {
            createFish = new PredatoryFish(fishName, points);
        }
        else
        {
            createFish = new ReefFish(fishName, points);
        }

        this.fish.AddModel(createFish);
        return string.Format(OutputMessages.FishCreated, fishName);
    }

    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {

        if (this.divers.GetModel(diverName) == null)
        {
            return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
        }

        if (this.fish.GetModel(fishName) == null)
        {
            return string.Format(OutputMessages.FishNotAllowed, fishName);
        }

        if (this.divers.GetModel(diverName).OxygenLevel == 0)
        {
            this.divers.GetModel(diverName).UpdateHealthStatus();
            return string.Format(OutputMessages.DiverHealthCheck, diverName);
        }

        IDiver diver = this.divers.GetModel(diverName);
        IFish fish = this.fish.GetModel(fishName);

        if (diver.OxygenLevel < fish.TimeToCatch)
        {
            diver.Miss(fish.TimeToCatch);

            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }

        if (diver.OxygenLevel == fish.TimeToCatch)
        {
            if (isLucky)
            {
                diver.Hit(fish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }

            diver.Miss(fish.TimeToCatch);
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }

        if (diver.OxygenLevel > fish.TimeToCatch)
        {
            diver.Hit(fish);
        }

        return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
    }

    public string HealthRecovery()
    {

        int counter = 0;
        foreach (var diver in divers.Models)
        {
            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                counter++;
            }
        }

        return string.Format(OutputMessages.DiversRecovered, counter);
    }

    public string DiverCatchReport(string diverName)
    {
        StringBuilder sb = new StringBuilder();

        var totalPoints = divers.Models
            .Where(x => x.Name == diverName)
            .Select(x => x.CompetitionPoints)
            .Sum();

        var totalCaughts = divers.Models
            .Where(x => x.Name == diverName)
            .Select(x => x.Catch)
            .Sum(x => x.Count);
        totalPoints = Math.Round(totalPoints, 1, MidpointRounding.AwayFromZero);
        sb.Append(
            $"Diver [ Name: {diverName}, Oxygen left: {this.divers.GetModel(diverName).OxygenLevel}, Fish caught: {totalCaughts}, Points earned: {totalPoints} ]");
        sb.AppendLine();
        sb.AppendLine("Catch Report:");
     
        var filter = divers.Models
            .Where(x => x.Name == diverName)
            .SelectMany(x => x.Catch)
            .ToList();

        foreach (var fishName in filter)
        {
            var fish = this.fish.GetModel(fishName);
            sb.AppendLine(fish.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public string CompetitionStatistics()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("**Nautical-Catch-Challenge**");
        sb.AppendLine();

        var filter = this.divers.Models
            .Where(x=>x.OxygenLevel>0)
            .OrderByDescending(x=>x.CompetitionPoints)
            .ThenByDescending(x=>x.Catch.Count)
            .ThenBy(x=>x.Name);

        foreach (var diver in filter)
        {
            sb.AppendLine(diver.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}