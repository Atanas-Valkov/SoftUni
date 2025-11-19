using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;

namespace P04E04.WildFarm.Models.Animals.Mammals.Felines;

public abstract class Feline : Mammal
{
    public Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed { get; private set; }

   


}