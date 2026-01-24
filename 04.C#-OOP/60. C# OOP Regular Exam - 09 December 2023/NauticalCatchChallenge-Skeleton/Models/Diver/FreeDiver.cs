using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.Diver
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevel = 120;
        private const double decreaseOxygen = 60;
        public FreeDiver(string name)
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
        //     this.HasHealthIssues = !this.HasHealthIssues;
        // }

        public override void RenewOxy()
        {
            this.OxygenLevel = oxygenLevel;
        }
    }
}
