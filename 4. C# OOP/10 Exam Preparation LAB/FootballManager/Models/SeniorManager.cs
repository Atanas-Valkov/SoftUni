using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        private const double InitialRanking = 30.0;
        public SeniorManager(string name)
            : base(name, InitialRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.ValidateAndUpdateRanking(updateValue);
        }

        
    }
}
