using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{

    public abstract class Manager : IManager
    {
        private string name;
        private double ranking;

        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }

                this.name = value;
            }
        }

        public double Ranking
        {
            get => this.ranking;
            protected set
            {
                this.ranking  = value;
            }
        }

        public abstract void RankingUpdate(double updateValue);

        protected void ValidateAndUpdateRanking(double updateValue)
        {
            this.Ranking += updateValue;

            if (this.Ranking < 0 )
            {
                this.Ranking = 0;
            }

            if (this.Ranking > 100)
            {
                this.Ranking = 100;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }
    }
}