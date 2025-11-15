using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04E03.Raiding.Models.Interfaces
{
    public interface ICastAbility
    {
        string HeroName { get; }
        double Power { get; }

        string CastAbility();
    }
}
