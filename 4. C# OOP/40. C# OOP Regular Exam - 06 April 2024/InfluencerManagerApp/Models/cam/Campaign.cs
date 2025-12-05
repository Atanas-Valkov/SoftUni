using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models.cam
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private double budget;
        private readonly List<string> contributors;

        protected Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            contributors = new List<string>();
        }
        



        public string Brand
        {
            get => this.brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }

                this.brand = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                this.budget = value;
            }
        }

        public IReadOnlyCollection<string> Contributors => this.contributors.AsReadOnly();
        public void Gain(double amount)
        {
            this.budget += amount;  // ?!?!?!!?!
        }

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
            budget -= influencer.CalculateCampaignPrice();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {this.contributors.Count}";
        }
    }
}
