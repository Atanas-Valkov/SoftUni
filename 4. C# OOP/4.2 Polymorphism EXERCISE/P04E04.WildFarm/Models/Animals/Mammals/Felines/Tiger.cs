using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04E04.WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline, IAbility
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        protected override double Grow { get; } = 1;

        public override bool Eat(IFood food)
        {
            if (food is Meat && base.Eat(food))
            {
                return base.Eat(food);
            }

            Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            return false;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

    }
}
