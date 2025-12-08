using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models.Diver
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private double competitionPoints;
        private bool hasHealthIssues;
        private List<string> catchlList;
        protected Diver(string name, int oxygenLevel)
        {
            this.name = name;
            this.OxygenLevel = oxygenLevel;
            catchlList = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get => this.oxygenLevel;
            protected set
            {
                this.oxygenLevel = value;
            }
        }
        public IReadOnlyCollection<string> Catch => catchlList.AsReadOnly();

        public double CompetitionPoints
        {
            get => this.competitionPoints;
            private set
            {
                this.competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get => this.hasHealthIssues;
            protected set
            {
                this.hasHealthIssues = value;
            }
        }
        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.catchlList.Add(fish.Name);
            this.competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public void UpdateHealthStatus()
        {
            this.HasHealthIssues = !this.HasHealthIssues;
        }

        public abstract void RenewOxy();

        public override string ToString()
        {
            var result = Math.Round(CompetitionPoints, 1, MidpointRounding.AwayFromZero);
            return
                $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {result} ]";
        }
    }
}
