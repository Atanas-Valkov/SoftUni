using System.Runtime.CompilerServices;
using P04E03.Raiding.Models;
using P04E03.Raiding.Models.Interfaces;
using ICastAbility = P04E03.Raiding.Models.Interfaces.ICastAbility;

namespace P04E03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();
            AddHeroesToTheGroup(n, raidGroup);

            double bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            double heroesTotalPower = raidGroup.Sum(h => h.Power);

            if (heroesTotalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static void AddHeroesToTheGroup(int n, List<BaseHero> raidGroup)
        {
            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    Druid druid = new Druid(heroName,0);
                    raidGroup.Add(druid);
                }
                else if (heroType == "Paladin")
                {
                    Paladin paladin = new Paladin(heroName, 0);
                    raidGroup.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    Rogue rogue = new Rogue(heroName, 0);
                    raidGroup.Add(rogue);
                }
                else if (heroType == "Warrior")
                {
                    Warrior warrior = new Warrior(heroName, 0);
                    raidGroup.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }
        }
    }
}
