using P04E04.WildFarm.Models;
using P04E04.WildFarm.Models.Animals.Birds;
using P04E04.WildFarm.Models.Animals.Mammals;
using P04E04.WildFarm.Models.Animals.Mammals.Felines;
using P04E04.WildFarm.Models.Food;
using P04E04.WildFarm.Models.Interfaces;
using System.IO;

namespace P04E04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();


            while (true)
            {
                string animalLine = Console.ReadLine();
                if (animalLine == "End")
                {
                    break;
                }

                string[] animalParts = animalLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = ProcessAnimal(animalParts);
                animals.Add(animal);

                string foodLine = Console.ReadLine();
                string[] foodParts = foodLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Console.WriteLine(animal.ProduceSound());

                try
                {
                    Food someFood = ProcessFood(foodParts);
                    animal.Eat(someFood);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (var a in animals)
            {
                Console.WriteLine(a);
            }
        }

        static Animal ProcessAnimal(string[] parts)
        {
            return parts[0] switch
            {
                nameof(Hen) => new Hen(parts[1], double.Parse(parts[2]), double.Parse(parts[3])),
                nameof(Owl) => new Owl(parts[1], double.Parse(parts[2]), double.Parse(parts[3])),
                nameof(Cat) => new Cat(parts[1], double.Parse(parts[2]), parts[3], parts[4]),
                nameof(Tiger) => new Tiger(parts[1], double.Parse(parts[2]), parts[3], parts[4]),
                nameof(Dog) => new Dog(parts[1], double.Parse(parts[2]), parts[3]),
                nameof(Mouse) => new Mouse(parts[1], double.Parse(parts[2]), parts[3]),
                _ => throw new InvalidOperationException("Invalid animal type")
            };
        }

        public static Food ProcessFood(string[] parts)
        {
            string type = parts[0];
            int quantity = int.Parse(parts[1]);

            return type switch
            {
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                _ => throw new InvalidOperationException("Invalid food type")
            };
        }
    }
}
